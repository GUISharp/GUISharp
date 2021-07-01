// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

#if __WINDOWS__

using System;
using System.Threading.Tasks;

namespace GUISharp.Controls.Music
{
	partial class SoundPlayer
	{
		//---------------------------------------------
		#region Initialize Region
		private void InitializeComponent(bool notTheFirstTime = false)
		{
			//-------------------------------------
			this._player.PlayDone -= SoundPlayerLoopMode_PlayDone;
			this._player.PlayStopped -= SoundPlayer_PlayStopped;
			this._player.PlayPaused -= SoundPlayer_PlayPaused;


			this._player.PlayDone += SoundPlayerLoopMode_PlayDone;
			this._player.PlayStopped += SoundPlayer_PlayStopped;
			this._player.PlayPaused += SoundPlayer_PlayPaused;
			if (!notTheFirstTime)
			{
				Father.Unloading -= Father_Unloading;
				Father.Unloading += Father_Unloading;
			}
			//-------------------------------------
			//-------------------------------------
		}

		private void ReverseInitializeComponent()
		{
			//-------------------------------------
			this._player.PlayDone -= SoundPlayerLoopMode_PlayDone;
			this._player.PlayStopped -= SoundPlayer_PlayStopped;
			this._player.PlayPaused -= SoundPlayer_PlayPaused;
			//-------------------------------------
			//-------------------------------------
		}
		#endregion
		//---------------------------------------------
		#region Events Region
		private void Father_Unloading()
		{
			try
			{
				this._player.Stop(true);
			}
			catch
			{
				return;
			}
		}

		private void SoundPlayer_PlayPaused(object sender, EventArgs e)
		{
			this.StopInner();
			this.IsPaused = true;
		}

		private void SoundPlayer_PlayStopped(object sender, EventArgs e)
		{
			try
			{
				this.StopInner();
				this.IsStopped = true;
				//this.Dispose();
			}
			catch
			{
				return;
			}
		}

		private async void SoundPlayerLoopMode_PlayDone(object sender, EventArgs e)
		{
			try
			{
				this.IsPlaying = false;
				if (!Father.IsDisposed)
				{
					switch (TheMode)
					{
						case LoopMode.TrackNoLoop:
							if (IsPlaying)
							{
								//this.StopInner();
								this.IsStopped = true;
							}
							break;
						case LoopMode.SingleTrackLoop:
							ReverseInitializeComponent();
							await Task.Delay(1500);
							this.StopInner();
							this.Play();
							InitializeComponent(true);
							break;
						case LoopMode.AlbumNoLoop:
						case LoopMode.AlbumLoop:
							this.Next();
							InitializeComponent(true);
							break;
						default:
							break;
					}
				}
				else
				{
					if (IsPlaying)
					{
						IsPlaying = false;
						IsStopped = true;
					}
					if (!this.IsStable)
					{
						this.Dispose();
					}
				}
			}
			catch
			{
				; // do nothing here
			}
		}
		#endregion
		//---------------------------------------------
		#region Set Method's Region
		public void ChangeVolume(float value)
		{
			this.Volume = value;
			this._player.ChangeVolume(Volume);
			this.VolumeChanged?.Invoke(this, null);
		}
		public void ChangePosition(TimeSpan span)
		{
			this._player.ChangePosition(span);
			this.SoundLocationChanged?.Invoke(this, null);
		}
		#endregion
		//---------------------------------------------
		#region Get Method's Region

		#endregion
		//---------------------------------------------
		#region Ordinary Methods Region
		/// <summary>
		/// Plays and loops the file using a new thread, and loads the file first
		/// if it has not been loaded.
		/// </summary>
		public void PlayLooping(bool noCheck = false)
		{
			if (TheAlbum is null)
			{
				TheMode = LoopMode.SingleTrackLoop;
			}
			else
			{
				if (!noCheck)
				{
					TheMode = LoopMode.AlbumLoop;
				}
			}
			if (this.IsPlaying)
			{
				if (!this._player.IsRepeating)
				{
					if (TheMode != LoopMode.AlbumLoop)
					{
						this._player.Repeat();
					}
				}
			}
			else
			{
				if (!this._player.IsRepeating)
				{
					if (TheMode != LoopMode.AlbumLoop)
					{
						this._player.Repeat();
					}
				}
				this.IsPlaying = true;
				this._player.ChangeStream(this.TheStream);
				this._player.Play();
			}
		}
		public void Next()
		{
			if (TheAlbum is null)
			{
				return;
			}
			switch (TheMode)
			{
				case LoopMode.AlbumNoLoop:
					if (IsEndOfAlbum())
					{
						Stop();
					}
					else
					{
						this.NextAlbumIndex();
						this.Play();
					}
					break;
				case LoopMode.AlbumLoop:
					this.NextAlbumIndex();
					this.Play();
					break;
				default:
					break;
			}
		}
		public async void Next(Album myAlbum, bool loop = false)
		{
			this.StopInner();
			await Task.Delay(WorkerTimeout); // waiting for workers...
			TheAlbum = myAlbum;
			if (IsLoopMode != loop)
			{
				LoopModeChanged?.Invoke(this, null);
			}
			IsLoopMode = loop;
			this.ResetAlbumIndex();
			this.Relive();
			//SoundLocation = TheAlbum[IndexOfAlbum].Path;
			TheStream = TheAlbum[IndexOfAlbum].TheStream;
			if (IsLoopMode)
			{
				TheMode = LoopMode.AlbumLoop;
				this.PlayLooping(true);
			}
			else
			{
				TheMode = LoopMode.AlbumNoLoop;
				this.Play();
			}
		}
		/// <summary>
		/// Play the speciafied indexed Music in the current Album.
		///
		/// </summary>
		/// <param name="index"></param>
		public void Next(uint index)
		{
			if (this.TheAlbum == null || index >= TheAlbum.Length ||
				index < (uint)default)
			{
				return;
			}
			IndexOfAlbum = index;
			Next();
		}
		/// <summary>
		/// Dispose the Player and release all resources used by this player.
		/// </summary>
		public void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}
			ReverseInitializeComponent();
			this.IsDisposed = true;
			if (IsPlaying)
			{
				this.Stop();
			}
		}
		/// <summary>
		/// Play the music,
		/// This method will check the loop mode automatically.
		/// If this sound player is already playing a song, this method
		/// will do nothing.
		/// If <see cref="TheStream"/> is null, this method will
		/// return. Do NOT dispose the stream.
		/// </summary>
		public void Play()
		{
			if (this.IsPlaying)
			{
				return;
			}
			switch (TheMode)
			{
				case LoopMode.TrackNoLoop:
				case LoopMode.SingleTrackLoop:
				{
					if (TheStream is null)
					{
						return;
					}
					break;
				}
				case LoopMode.AlbumNoLoop:
				case LoopMode.AlbumLoop:
					//SoundLocation = TheAlbum[IndexOfAlbum].Path;
					this.TheStream = TheAlbum[IndexOfAlbum].TheStream;
					break;
				default:
					break;
			}
			this.StopInner();
			this.IsPlaying = true;
			this._player.ChangeStream(TheStream);
			this._player.Play();
		}
		public void Play(uint index)
		{
			switch (TheMode)
			{
				case LoopMode.TrackNoLoop:
				case LoopMode.SingleTrackLoop:
					return;
				case LoopMode.AlbumNoLoop:
				case LoopMode.AlbumLoop:
					this.SetAlbumIndex(index);
					this.Play();
					return;
				default:
					break;
			}
		}
		public void Play(Album myAlbum, uint index = 0, bool loop = false)
		{
			TheAlbum = myAlbum;
			IndexOfAlbum = index;
			IsLoopMode = loop;
			if (TheAlbum is null)
			{
				return;
			}
			if (IsLoopMode)
			{
				TheMode = LoopMode.AlbumLoop;
			}
			else
			{
				TheMode = LoopMode.AlbumNoLoop;
			}
			this.Relive();
			this.Play();
		}
		/// <summary>
		/// Stop the Player from playing the current music.
		/// This method won't dispose the palyer.
		/// This may cause some troubles for you in the future,
		/// so we strongly recommend you that if you don't want to use
		/// this sound player in the future anymore, please use
		/// <see cref="Dispose()"/> method to free up the memory.
		/// But if you use this method, you can use the sound player
		/// again in the future, but you can't resume the music.
		/// You have to load a new music (TODO: load already existing stream.)
		/// </summary>
		public void Stop()
		{
			if (this.IsStopped)
			{
				return;
			}
			this.IsPlaying = false;
			this.IsPaused = false;
			this.IsStopped = true;
			if (!this.IsStable)
			{
				this.Dispose();
			}
			this._player.Stop();
		}
		
		/// <summary>
		/// Resume the player, please notice that you can't use 
		/// this method after using neither <see cref="Stop()"/> nor
		/// <see cref="Dispose()"/>; thus you can't resume the music.
		/// --> You can only use it after using <see cref="Pause()"/>.
		/// </summary>
		public void Resume()
		{
			if (this.IsPlaying || this.IsStopped)
			{
				return;
			}
			this.StopInner();
			this.IsPlaying = true;
			this._player.Play();
		}
		/// <summary>
		/// Pause this music, also you can use <see cref="Resume()"/>
		/// after this method to resume the music;
		/// Please notice that this method won't dispose the 
		/// resources using by this player.
		/// </summary>
		public void Pause()
		{
			try
			{
				if (!this.IsPlaying || this.IsStopped)
				{
					return;
				}
				this.IsPlaying = false;
				this.IsStopped = false;
				this.IsPaused = true;
				this._player?.Pause();
			}
			catch
			{
				; // nothing
			}
			
		}
		/// <summary>
		/// Make this sound player an unstable sound player.
		/// Unstable sound players will dispose themselves after
		/// ending their songs completely.
		/// If loop mode is enabled, it will never dispose itself.
		/// But after disabling loop mode and after the ending the current
		/// playing album or song, it will dispose itself.
		/// This feature is good specially for playing sound effects,
		/// so you don't need to be worry about disposing the
		/// player after ending it's song, because it will dispose itself.
		/// <see cref="IsStable"/> property is <c>true</c> by default, 
		/// but after using this method, it will become <c>false</c>.
		/// After using this method, you won't be able to make the
		/// soundplayer stable again, so be careful when using it.
		/// </summary>
		public void Unstable()
		{
			this.IsStable = false;
		}
		/// <summary>
		/// Set the properties of this sound player to false.
		/// The peroperties are:
		/// <code><see cref="IsPlaying"/></code>
		/// <code><see cref="IsPaused"/></code>
		/// <code><see cref="IsStopped"/></code>
		/// <code><see cref="IsDisposed"/></code>
		/// This method is supposed to be private, because all of the
		/// usages are private usages, but I made it internal so we will
		/// be able to use it in emergency situations :3
		/// </summary>
		internal void StopInner()
		{
			this.IsPlaying = false;
			this.IsPaused = false;
			this.IsStopped = false;
			this.IsDisposed = false;
		}
		private bool IsEndOfAlbum()
		{
			if (TheAlbum is null)
			{
				return true;
			}
			else
			{
				return IndexOfAlbum == TheAlbum.Length - 1;
			}
		}

		private void ResetAlbumIndex()
		{
			if (TheAlbum is null)
			{
				return;
			}
			else
			{
				IndexOfAlbum = 0;
			}
		}
		/// <summary>
		/// Go to the next index of the album.
		/// If we have reached the end of our album, this method
		/// will reset the index of the album.
		/// Which is why you always have to check <see cref="IsEndOfAlbum()"/>
		/// method before calling this method if you are not in any
		/// loop mode, so you can stop the player from playing the wrong music.
		/// </summary>
		private void NextAlbumIndex()
		{
			if (IsEndOfAlbum())
			{
				ResetAlbumIndex();
			}
			else
			{
				IndexOfAlbum++;
			}
		}
		
		
		private void SetAlbumIndex(uint index)
		{
			if (index > TheAlbum.Length - 1)
			{
				IndexOfAlbum = 0;
			}
			else
			{
				IndexOfAlbum = index;
			}
		}

		private void Relive()
		{
			this._player?.Stop();
			this._player = null;
			this._player = WotoAudioPlayer.GeneratePlayer();
			this.InitializeComponent(true);
		}
		#endregion
		//---------------------------------------------
	}
}

#endif //__WINDOWS__