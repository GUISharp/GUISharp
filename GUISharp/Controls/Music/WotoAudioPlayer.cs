// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

#define WOTO_AUDIO_PLAYER

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.XAudio2;
using SharpDX.MediaFoundation;
using GUISharp.Logging;
using GUISharp.Constants;

namespace GUISharp.Controls.Music
{
	/// <summary>
	/// Woto Audio Player, which provides a strong 
	/// audio playing engine.
	/// it has too many bugs, so I used too many try ... catch
	/// in it, please be carefull in using it.
	/// used by: <see cref="SoundPlayer"/> class.
	/// </summary>
	public class WotoAudioPlayer
	{
		//-------------------------------------------------
		#region Constant's Region
		private const int MIN_COUNTER	   = 0;
		private const int MAX_COUNTER	   = 10000;
		private const int WaitPrecision	 = 1;
		private const float DEFAULT_VOLUME  = 1f;
		private const int BUFFER_QUALITY	= 3;
		private const int AUDIO_QUALITY	 = 32 * 1024; // default size 32Kb
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// Gets the XAudio2 <see cref="SourceVoice"/> created by this decoder.
		/// </summary>
		/// <value>The source voice.</value>
		public SourceVoice SourceVoice
		{
			get
			{
				if (sourceVoice != null)
				{
					return sourceVoice;
				}
				return null;
			}
		}

		/// <summary>
		/// Gets the state of this instance.
		/// </summary>
		/// <value>The state.</value>
		public AudioPlayerState State { get; private set; }

		/// <summary>
		/// Gets the duration in seconds of the current sound.
		/// </summary>
		/// <value>The duration.</value>
		public TimeSpan Duration
		{
			get
			{
				return audioDecoder.Duration;
			}
		}

		/// <summary>
		/// Gets or sets the position in seconds.
		/// </summary>
		/// <value>The position.</value>
		public TimeSpan Position
		{
			get
			{
				return playPosition;
			}
			private set
			{
				playPosition = value;
				nextPlayPosition = value;
				playPositionStart = value;
				clock.Restart();
				ChangeCounter();
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to the sound is looping when the end of the buffer is reached.
		/// </summary>
		/// <value><c>true</c> if to loop the sound; otherwise, <c>false</c>.</value>
		public bool IsRepeating { get; private set; }

		/// <summary>
		/// Gets or sets the volume.
		/// </summary>
		/// <value>The volume.</value>
		public float Volume
		{
			get
			{
				return localVolume;
			}
			private set
			{
				localVolume = value;
				sourceVoice.SetVolume(value);
			}
		}

		public SoundPlayer Father { get; }
		#endregion
		//-------------------------------------------------
		#region field's Region
		private XAudio2 xaudio2;
		private AudioDecoder audioDecoder;
		private SourceVoice sourceVoice;
		private AudioBuffer[] audioBuffersRing;
		private DataPointer[] memBuffers;
		private Stopwatch clock;
		private ManualResetEvent playEvent;
		private ManualResetEvent waitForPlayToOutput;
		private AutoResetEvent bufferEndEvent;
		private MasteringVoice masteringVoice;
		private Stream _stream;
		private TimeSpan playPosition;
		private TimeSpan nextPlayPosition;
		private TimeSpan playPositionStart;
		private Task playingTask;
		private int _playCounter;
		private float localVolume;
		private bool IsDisposed;
		private bool notStartedYet;
		#endregion
		//-------------------------------------------------
		#region Event Handler's Region
		public event EventHandler PlayDone;
		public event EventHandler PlayStopped;
		public event EventHandler PlayPaused;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Initializes a new instance of the <see cref="WotoAudioPlayer" /> class.
		/// </summary>
		/// <param name="xAudio2">The xaudio2 engine.</param>
		/// <param name="audioStream">The input audio stream.</param>
		private WotoAudioPlayer(XAudio2 xAudio2, FileStream audioStream)
		{
			try
			{
				masteringVoice = new MasteringVoice(xAudio2);
				xaudio2 = xAudio2;
				audioDecoder = new AudioDecoder(audioStream);
				sourceVoice = new SourceVoice(xAudio2, audioDecoder.WaveFormat);
				localVolume = DEFAULT_VOLUME;

				// runnig primary start
				PrimaryStart();
			}
			catch(Exception ex)
			{
				AppLogger.Log(ex);
			}

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="WotoAudioPlayer" /> class,
		/// which has to call <see cref="PrimaryStart()"/>
		/// afterward.
		/// </summary>
		/// <param name="xAudio2">The xaudio2 engine.</param>
		private WotoAudioPlayer(XAudio2 xAudio2)
		{
			try
			{
				masteringVoice = new MasteringVoice(xAudio2);
				xaudio2 = xAudio2;
				localVolume = DEFAULT_VOLUME;
				notStartedYet = true;
			}
			catch
			{
				return;
			}

		}
		#endregion
		//-------------------------------------------------
		#region Set Method's Region

		/// <summary>
		/// change the volume of the woto player.
		/// </summary>
		/// <param name="value"></param>
		public void ChangeVolume(float value)
		{
			try
			{
				Volume = value;
			}
			catch
			{
				return;
			}
			
		}

		/// <summary>
		/// while this woto player is playing the music or not disposed yet,
		/// you can use this to repeat the music.
		/// NOTICE: this method won't play the music if the music is already ended.
		/// </summary>
		public void Repeat()
		{
			try
			{
				IsRepeating = true;
			}
			catch
			{
				return;
			}
			
		}

		/// <summary>
		/// stop me from repeating the music.
		/// </summary>
		public void StopRepeat()
		{
			try
			{
				IsRepeating = false;
			}
			catch
			{
				return;
			}
			
		}

		/// <summary>
		/// change the position of the music.
		/// </summary>
		/// <param name="position"></param>
		public void ChangePosition(TimeSpan position)
		{
			try
			{
				Position = position;
			}
			catch
			{
				return;
			}
			
		}

		/// <summary>
		/// change the stream of the file with the new path as the parameter.
		/// </summary>
		/// <param name="path">
		/// the path to the local file in the local storage.
		/// this argument can be null if and only if you pass the
		/// replacement stream to this method.
		/// </param>
		/// <param name="replacement">
		/// the replacement of the stream.
		/// pass this when you want to use directly a stream for reading
		/// the song data.
		/// </param>
		public void ChangeStream(string path, Stream replacement = null)
		{
			try
			{
				if (string.IsNullOrEmpty(path))
				{
					if (replacement == null || !replacement.CanSeek)
					{
						return;
					}

					_stream = replacement;
					ChangeStream(replacement);
					return;
				}

				_stream = File.OpenRead(path);
				ChangeStream(_stream);
			}
			catch (Exception ex)
			{
				AppLogger.Log(ex);
			}
		}

		/// <summary>
		/// change the stream of the file with the new file stream object
		/// as the parameter.
		/// </summary>
		/// <param name="file"></param>
		public void ChangeStream(Stream file)
		{
			try
			{
				if (notStartedYet)
				{
					audioDecoder = new AudioDecoder(file);
					sourceVoice = new SourceVoice(xaudio2, audioDecoder.WaveFormat);
					IsDisposed = false;
					PrimaryStart();
					return;
				}
				else
				{
					StopInner();
					//DisposePlayer();
					xaudio2 = new XAudio2();
					masteringVoice = new MasteringVoice(xaudio2);
					audioDecoder = new AudioDecoder(file);
					sourceVoice = new SourceVoice(xaudio2, audioDecoder.WaveFormat);

					PrimaryStart();

					// Pre-allocate buffers
					//audioBuffersRing = new AudioBuffer[3];
					//memBuffers = new DataPointer[audioBuffersRing.Length];
					//for (int i = 0; i < audioBuffersRing.Length; i++)
					//{
					//audioBuffersRing[i] = new AudioBuffer();
					//memBuffers[i].Size = 32 * 1024; // default size 32Kb
					//memBuffers[i].Pointer = Utilities.AllocateMemory(memBuffers[i].Size);
					//}
				}
			}
			catch
			{
				return;
			}
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region

		#endregion
		//-------------------------------------------------
		#region Ordinary Method's Region
		/// <summary>
		/// Plays the sound.
		/// </summary>
		public void Play()
		{
			try
			{
				if (notStartedYet)
				{
					PrimaryStart();
				}
				if (State != AudioPlayerState.Playing)
				{
					bool waitForFirstPlay = false;
					if (State == AudioPlayerState.Stopped)
					{
						ChangeCounter();
						waitForPlayToOutput.Reset();
						waitForFirstPlay = true;
					}
					else
					{
						// The song was paused
						clock.Start();
					}

					State = AudioPlayerState.Playing;
					playEvent.Set();

					if (waitForFirstPlay)
					{
						waitForPlayToOutput.WaitOne();
					}
				}
			}
			catch
			{
				return;
			}
		}

		/// <summary>
		/// Pauses the sound.
		/// </summary>
		public void Pause()
		{
			try
			{
				if (State == AudioPlayerState.Playing)
				{
					clock.Stop();
					State = AudioPlayerState.Paused;

					playEvent.Reset();

					PlayPaused?.Invoke(this, null);
				}
			}
			catch
			{
				; // nothing is here.
			}
		}

		/// <summary>
		/// Stops the sound.
		/// </summary>
		public void Stop(bool force = false)
		{
			try
			{
				if (State != AudioPlayerState.Stopped)
				{
					// set the TimeSpans to zero
					playPosition = TimeSpan.Zero;
					nextPlayPosition = TimeSpan.Zero;
					playPositionStart = TimeSpan.Zero;
					
					// stop the clock
					clock.Stop();

					// increase play counter parameter of the player
					ChangeCounter();

					// set the state of the player to stopped
					State = AudioPlayerState.Stopped;

					// reset the play event of the player
					playEvent.Reset();

					// check if this method has been called by force or not
					if (force)
					{
						// if this method is called by force,
						// then call the DisposePlayer method to 
						// completley abondon the resources
						DisposePlayer(force);
					}

					// invoke the play done event handler
					PlayStopped?.Invoke(Father, Father.SoundPlayerEventArgs);
				}
			}
			catch
			{
				return;
			}
		}

		/// <summary>
		/// Close this audio player.
		/// </summary>
		/// <remarks>
		/// This is similar to call Stop(), Dispose(), Wait().
		/// </remarks>
		public void Close()
		{
			try
			{
				Stop();
				IsDisposed = true;
				Wait();
			}
			catch
			{
				;
			}
			
		}

		/// <summary>
		/// Wait that the player is finished.
		/// </summary>
		public void Wait()
		{
			try
			{
				playingTask.Wait();
			}
			catch
			{
				;
			}
		}

		/// <summary>
		/// Internal method to play the sound.
		/// </summary>
		private void PlayAsync()
		{
			try
			{
				int currentPlayCounter = 0;
				int nextBuffer = 0;

				try
				{
					while (true)
					{
						// Check that this instanced is not disposed
						while (!IsDisposed)
						{
							if (playEvent.WaitOne(WaitPrecision))
								break;
						}

						if (IsDisposed)
							break;

						clock.Restart();
						playPositionStart = nextPlayPosition;
						playPosition = playPositionStart;
						currentPlayCounter = _playCounter;

						// Get the decoded samples from the specified starting position.
						var sampleIterator = audioDecoder.GetSamples(playPositionStart).GetEnumerator();

						bool isFirstTime = true;

						bool endOfSong = false;

						// Playing all the samples
						while (true)
						{
							if (ThereIsGConstants.Forming.GClient is null || ThereIsGConstants.Forming.GClient.IsDisposed)
							{
								break;
							}

							// If the player is stopped or disposed, then break of this loop
							while (!IsDisposed && State != AudioPlayerState.Stopped)
							{
								if (playEvent.WaitOne(WaitPrecision))
									break;
							}

							// If the player is stopped or disposed, then break of this loop
							if (IsDisposed || State == AudioPlayerState.Stopped)
							{
								nextPlayPosition = TimeSpan.Zero;
								break;
							}

							// If there was a change in the play position, restart the sample iterator.
							if (currentPlayCounter != _playCounter)
								break;

							try
							{
								// If ring buffer queued is full, wait for the end of a buffer.
								while (sourceVoice.State.BuffersQueued == audioBuffersRing.Length && !IsDisposed && State != AudioPlayerState.Stopped)
									bufferEndEvent.WaitOne(WaitPrecision);
							}
							catch
							{

							}
							

							// If the player is stopped or disposed, then break of this loop
							if (IsDisposed || State == AudioPlayerState.Stopped)
							{
								nextPlayPosition = TimeSpan.Zero;
								break;
							}

							// Check that there is a next sample
							if (!sampleIterator.MoveNext())
							{
								endOfSong = true;
								break;
							}

							// Retrieve a pointer to the sample data
							var bufferPointer = sampleIterator.Current;

							// If there was a change in the play position, restart the sample iterator.
							if (currentPlayCounter != _playCounter)
								break;

							// Check that our ring buffer has enough space to store the audio buffer.
							if (bufferPointer.Size > memBuffers[nextBuffer].Size)
							{
								if (memBuffers[nextBuffer].Pointer != IntPtr.Zero)
									Utilities.FreeMemory(memBuffers[nextBuffer].Pointer);

								memBuffers[nextBuffer].Pointer = Utilities.AllocateMemory(bufferPointer.Size);
								memBuffers[nextBuffer].Size = bufferPointer.Size;
							}

							// Copy the memory from MediaFoundation AudioDecoder to the buffer that is going to be played.
							Utilities.CopyMemory(memBuffers[nextBuffer].Pointer, bufferPointer.Pointer, bufferPointer.Size);

							// Set the pointer to the data.
							audioBuffersRing[nextBuffer].AudioDataPointer = memBuffers[nextBuffer].Pointer;
							audioBuffersRing[nextBuffer].AudioBytes = bufferPointer.Size;

							// If this is a first play, restart the clock and notify play method.
							if (isFirstTime)
							{
								clock.Restart();
								isFirstTime = false;

								waitForPlayToOutput.Set();
							}

							// Update the current position used for sync
							playPosition = new TimeSpan(playPositionStart.Ticks + clock.Elapsed.Ticks);

							try
							{
								// Submit the audio buffer to xaudio2
								sourceVoice.SubmitSourceBuffer(audioBuffersRing[nextBuffer], null);
							}
							catch
							{
								; // nothing
							}

							// Go to next entry in the ring audio buffer
							nextBuffer = ++nextBuffer % audioBuffersRing.Length;
						}

						// If the song is not looping (by default), then stop the audio player.
						if (endOfSong && !IsRepeating && State == AudioPlayerState.Playing)
						{
							StopInner();
							if (endOfSong)
							{
								try
								{
									PlayDone?.Invoke(Father, null);
								}
								catch
								{
									return;
								}
							}
						}
					}
				}
				catch
				{
					; // nothing
				}
				finally
				{
					DisposePlayer();
				}
				
			}
			catch
			{
				return;
			}
			
		}

		/// <summary>
		/// stop the sound from the inside of the
		/// class.
		/// this method will not trigger the events.
		/// </summary>
		private void StopInner()
		{
			try
			{
				if (State != AudioPlayerState.Stopped)
				{
					playPosition = TimeSpan.Zero;
					nextPlayPosition = TimeSpan.Zero;
					playPositionStart = TimeSpan.Zero;
					clock.Stop();

					// increase play counter parameter of the player
					ChangeCounter();

					// set the state of the player to stopped
					State = AudioPlayerState.Stopped;

					// reset the play event of the player
					playEvent.Reset();
				}
			}
			catch
			{
				return;
			}
			
		}

		/// <summary>
		/// dis pose the woto player, and realese all the resources.
		/// </summary>
		/// <param name="force">
		/// the value to check if you want to lose all the 
		/// resources or not.
		/// </param>
		private void DisposePlayer(bool force = false)
		{
			try
			{
				if (!(audioDecoder is null))
				{
					audioDecoder.Dispose();
					if (force)
					{
						audioDecoder = null;
					}
				}
				if (!(masteringVoice is null))
				{
					masteringVoice.Dispose();
					if (force)
					{
						sourceVoice = null;
					}
				}
				if (!(sourceVoice is null))
				{
					sourceVoice.Dispose();
					if (force)
					{
						sourceVoice = null;
					}
				}
				if (!(_stream is null))
				{
					_stream.Close();
					_stream.Dispose();
					_stream = null;
				}

				if (!(audioBuffersRing is null || memBuffers is null))
				{
					for (int i = 0; i < audioBuffersRing.Length; i++)
					{
						Utilities.FreeMemory(memBuffers[i].Pointer);
						memBuffers[i].Pointer = IntPtr.Zero;
					}
				}
			}
			catch
			{
				return;
			}
			
		}

		/// <summary>
		/// Buffer end event handler for source voice of the
		/// woto aoudio player
		/// used for <see cref="sourceVoice"/> field,
		/// also check this property: <seealso cref="SourceVoice"/>.
		/// </summary>
		/// <param name="obj">
		/// the int pointer of the source voice.
		/// </param>
		private void SourceVoice_BufferEnd(IntPtr obj)
		{
			try
			{
				bufferEndEvent.Set();
			}
			catch
			{
				return;
			}
		}

		private void ChangeCounter()
		{
			try
			{

			}
			catch
			{

			}
			_playCounter++;
			if (_playCounter >= MAX_COUNTER)
			{
				_playCounter = MIN_COUNTER;
			}
		}

		private void PrimaryStart()
		{
			try
			{
				sourceVoice.BufferEnd -= SourceVoice_BufferEnd;
				sourceVoice.BufferEnd += SourceVoice_BufferEnd;
				sourceVoice.Start();

				bufferEndEvent = new AutoResetEvent(false);
				playEvent = new ManualResetEvent(false);
				waitForPlayToOutput = new ManualResetEvent(false);

				clock = new Stopwatch();

				// Pre-allocate buffers
				audioBuffersRing = new AudioBuffer[BUFFER_QUALITY];
				memBuffers = new DataPointer[audioBuffersRing.Length];
				for (int i = 0; i < audioBuffersRing.Length; i++)
				{
					audioBuffersRing[i] = new AudioBuffer();
					memBuffers[i].Size = AUDIO_QUALITY;
					memBuffers[i].Pointer = Utilities.AllocateMemory(memBuffers[i].Size);
				}

				// Initialize to stopped
				State = AudioPlayerState.Stopped;


				// Starts the playing thread
				playingTask = Task.Factory.StartNew(PlayAsync, TaskCreationOptions.LongRunning);

				// already started
				notStartedYet = false;
			}
			catch
			{
				;
			}
			
		}
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		public static WotoAudioPlayer GeneratePlayer(XAudio2 _device, string _path)
		{
			return new WotoAudioPlayer(_device, File.OpenRead(_path));
		}
		public static WotoAudioPlayer GeneratePlayer(XAudio2 device, FileStream file)
		{
			return new WotoAudioPlayer(device, file);
		}
		public static WotoAudioPlayer GeneratePlayer()
		{
			return new WotoAudioPlayer(new XAudio2());
		}
		#endregion
		//-------------------------------------------------
	}
}
