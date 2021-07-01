// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

#define SAO_SOUND_PLAYER

using System;
using System.IO;
using System.ComponentModel;
using System.Threading.Tasks;
using GUISharp.Client;
using GUISharp.Logging;
using GUISharp.Constants;
using GUISharp.GUIObjects.Resources;
using GUISharp.WotoProvider.EventHandlers;

namespace GUISharp.Controls.Music
{
	/// <summary>
	///  Controls playback of a sound from a file or a stream.
	/// </summary>
	public sealed partial class SoundPlayer : IDisposable, IRes
	{
		//-------------------------------------------------
		#region Constant's Region
		public const string FaultString = "SharpDX.MediaFoundation";
		public const int WorkerTimeout = 300; //ms
		#endregion
		//-------------------------------------------------
		#region Properties Region
		public WotoRes MyRes { get; set; }
		public Album TheAlbum { get; private set; }
		public TimeSpan Position
		{
			get
			{
				if (_player != null)
				{
					return _player.Position;
				}
				return default;
			}
		}
		public Stream TheStream { get; private set; }
		public float Volume { get; private set; }
		public uint IndexOfAlbum { get; private set; }
		/// <summary>
		/// Gets a value indicating whether the control has been disposed of.
		/// </summary>
		/// <value>true if the control has been disposed of; otherwise, false.</value>
		/// [Browsable(false)]
		public bool IsDisposed { get; private set; }
		public bool IsLoopMode { get; private set; }
		public bool IsPlaying { get; private set; }
		public bool IsPaused { get; private set; }
		public bool IsStopped { get; private set; }
		public bool IsStable { get; private set; } = true;
		public LoopMode TheMode { get; private set; }
		internal EventArgs SoundPlayerEventArgs { get; }
		#endregion
		//-------------------------------------------------
		#region field's Region
		private WotoAudioPlayer _player;
		#endregion
		//-------------------------------------------------
		#region Event Handler's Region
		//public event SoundPlayerDisposedEventHandler SoundPlayerDisposed;
		public event LoopModeChangedEventHandler LoopModeChanged;
		public event VolumeChangedEventHandler VolumeChanged;
		/// <summary>
		/// Occurs when a new audio source path for this 
		/// <see cref="SoundPlayer"/> has been set.
		/// </summary>
		public event SoundLocationChangedEventHandler SoundLocationChanged;
		#endregion
		//-------------------------------------------------
		#region static Properties Region
		internal static GClient Father
		{
			get
			{
				return ThereIsGConstants.Forming.GClient;
			}
		}
		internal static MusicManager Manager
		{
			get
			{
				if (Father != null)
				{
					return Father.MusicManager;
				}
				return null;
			}
		}
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="SoundPlayer"/> class.
		/// Use Play method for playing,
		/// or <seealso cref="PlayLooping"/> for PlayLoop.
		/// But Before that, you should set <see cref="TheStream"/>
		/// property of this player.
		/// otherwise it won't play anything.
		/// </summary>
		public SoundPlayer(IRes myRes)
		{
			if (ThereIsGConstants.Forming.GClient == null)
			{
				return;
			}

			MyRes = myRes.MyRes;
			
			_player = WotoAudioPlayer.GeneratePlayer();
			InitializeComponent();
		}
		/// <summary>
		/// Initializes a new instance of the 
		/// <see cref="SoundPlayer"/> class, and attaches
		/// the specified file.
		/// </summary>
		/// <param name="soundLocation">
		/// The location of a file to load.
		/// </param>
		/// <param name="myRes">
		/// the resources manager.
		/// </param>
		public SoundPlayer(string soundLocation, IRes myRes)
		{
			try
			{
				TheStream = File.OpenRead(soundLocation);
			}
			catch (Exception ex)
			{
				AppLogger.Log(ex);
			}
			MyRes = myRes.MyRes;
			_player = WotoAudioPlayer.GeneratePlayer();
			InitializeComponent();
		}
		public SoundPlayer(Album myAlbum, IRes myRes)
		{
			TheAlbum = myAlbum;
			MyRes = myRes.MyRes;
			_player = WotoAudioPlayer.GeneratePlayer();
			InitializeComponent();
		}
		public SoundPlayer(string location)
		{
			if (string.IsNullOrWhiteSpace(location))
			{
				IsDisposed = true;
				return;
			}
			try
			{
				TheStream = File.OpenRead(location);
			}
			catch (Exception ex)
			{
				IsDisposed = true;
				AppLogger.Log(ex);
				return;
			}
			if (TheStream == null)
			{
				IsDisposed = true;
				return;
			}
			_player = WotoAudioPlayer.GeneratePlayer();
		}
		public SoundPlayer(Stream stream)
		{
			if (stream == null)
			{
				IsDisposed = true;
				return;
			}
			TheStream = stream;
			_player = WotoAudioPlayer.GeneratePlayer();
		}
		public SoundPlayer(byte[] buffers)
		{
			if (buffers == null || buffers.Length == default)
			{
				IsDisposed = true;
				return;
			}
			try
			{
				TheStream = new MemoryStream(buffers);
			}
			catch (Exception ex)
			{
				IsDisposed = true;
				AppLogger.Log(ex);
				return;
			}
			if (TheStream == null)
			{
				IsDisposed = true;
				return;
			}
			_player = WotoAudioPlayer.GeneratePlayer();
		}
		
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		public static void MakeNoise(Noises noise)
		{
			if (noise == Noises.NoNoise || IsManagerNull())
			{
				return;
			}
			SoundPlayer myPlayer;
			switch (noise)
			{
				case Noises.ClickNoise:
				{
					var m = Manager.GetNoiceStream(noise);
					if (m == null)
					{
						return;
					}
					myPlayer = new SoundPlayer(m);
					myPlayer.Play();
					break;
				}
				default:
					break;
			}
		}
		public static bool IsOurFault(Exception ex)
		{
			switch (ex)
			{
				case NullReferenceException exception:
					if (exception.Source == FaultString)
					{
						return true;
					}
					break;
				default:
					break;
			}
			return false;
		}
		internal static bool IsManagerNull()
		{
			return Manager == null;
		}
		#endregion
		//-------------------------------------------------
	}
}
