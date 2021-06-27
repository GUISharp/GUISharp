// Last Testament of Wanderers 
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using GUIVoid.WotoProvider.Enums;
using GUIVoid.WotoProvider.EventHandlers;
using GUIVoid.Controls;
using GUIVoid.Security;
using GUIVoid.Constants;
using GUIVoid.Controls.Workers;
using XRectangle = Microsoft.Xna.Framework.Rectangle;

namespace GUIVoid.Client
{
	/// <summary>
	/// Window Manager of the GUIVoid.
	/// </summary>
	public sealed class Universe
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		/// windows manager of the GUIVoid world.
		/// </summary>
		public const string ToStringValue = "UNIVERSE_MANAGER -- GUIVoid";
		public const string UnknownCommandError = "ERR: Unknown Command Entered: ";
		public const string Config_File_Name = 
			"UNIVERSE_CONFIG" + ThereIsGConstants.Path.FilesEnd_Name;
		public const string Config_Filter = 
			"*" + ThereIsGConstants.Path.FilesEnd_Name;
		public const string DEFAULT_CONFIG_TEXT = "-- GUIVoid UNIVERSE -- V1.0.0";
		public const string CONFIG_UP_COMMAND = "universe_request(up)";
		public const string CONFIG_CLOSE_COMMAND1 = "close";
		public const string CONFIG_CLOSE_COMMAND2 = "close()";
		public const string CONFIG_CLOSE_COMMAND3 = "close(force)";
		public const string CONFIG_CLOSE_COMMAND4 = "close() --f";
		public const string CONFIG_CLOSE_COMMAND5 = "/close";
		public const string CONFIG_CLOSE_COMMAND6 = "/close --f";
		public const string CONFIG_CLOSE_COMMAND7 = "/close -force";
		public const int DEFAULT_Z_BASE		   = 0b0;
		public const int DEFAULT_A_BASE		   = 0b1;
		public const int DEFAULT_B_BASE		   = 0b10;
		/// <summary>
		/// The internal of worker which is for linux only.
		/// </summary>
		internal const int WORKER_INTERVAL = 0b111110100;
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// Handle of the Windows.
		/// </summary>
		public IntPtr Handle { get; }
		/// <summary>
		/// the main window of the GClient,
		/// casted to the c# window currency (WindowsForm).
		/// </summary>
		public GameWindow WotoPlanet { get; }
		internal GClient Client { get; }
		public Trigger WatcherWorkerLinux { get; private set; }
		public Worker WatcherWorkerWindows { get; private set; }
		public FileSystemWatcher Watcher { get; private set; }
		public StrongString ConfigPath { get; private set; }
		public StrongString ConfigDir { get; private set; }
		public StrongString LastCommand { get; private set; }
		public XRectangle XRectangle { get; }
		public Point DefaultPoint { get; set; }
		public int DefaultWidth { get; set; }
		public int DefaultHeight { get; set; }
		public int Width
		{
			get
			{
				if (Client != null)
				{
					return Client.GraphicsDM.PreferredBackBufferWidth;
				}
				return DEFAULT_Z_BASE;
			}
		}
		public int Height
		{
			get
			{
				if (Client != null)
				{
					return Client.GraphicsDM.PreferredBackBufferHeight;
				}
				return DEFAULT_Z_BASE;
			}
		}
		public int X
		{
			get
			{
				if (WotoPlanet != null)
				{
					return WotoPlanet.Position.X;
				}
				return DEFAULT_Z_BASE;
			}
		}
		public int Y
		{
			get
			{
				if (WotoPlanet != null)
				{
					return WotoPlanet.Position.Y;
				}
				return DEFAULT_Z_BASE;
			}
		}
		/// <summary>
		/// use this to check if the operation of the 
		/// getting and setting of the planet handle was succesful 
		/// or not,
		/// and if it's completed or not.
		/// </summary>
		public bool Completed { get; }
		#endregion
		//-------------------------------------------------
		#region static Properties Region
		public static bool IsWindows { get; set; }
		public static bool IsUnix { get; set; }
		internal static FileStream _mapped { get; set; }
		internal bool _checkFile { get; set; }
		#endregion
		//-------------------------------------------------
		#region field's Region
		private bool _left_pressed;
		private bool _right_pressed;
		/// <summary>
		/// the mmf value which is linux-only.
		/// do NOT delete.
		/// </summary>
		private readonly string __mmf__;
		#endregion
		//-------------------------------------------------
		#region Events Region
		internal event MouseEventHandler MouseDown;
		internal event MouseEventHandler MouseUp;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// create a new instance of <see cref="Universe"/> 
		/// for GUIVoid library.
		/// <!--BY: ALi.w-->
		/// </summary>
		/// <param name="_handle_">
		/// the handler.
		/// </param>
		/// <param name="_client_">
		/// the client.
		/// </param>
		internal Universe(IntPtr _handle_, GClient _client_)
		{
			Handle = _handle_;
			Client = _client_;
			WotoPlanet = _client_.Window;
			SetLocation();
			SetWatcher();
			if (IsUnix)
			{
				__mmf__ = ThereIsGConstants.Path.Here + 
						  GClient.MMF_NAME;  
			}
			Completed = true;
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		private void SetLocation()
		{
			var w = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			var h = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
			var ww = Client.GraphicsDM.PreferredBackBufferWidth;
			var wh = Client.GraphicsDM.PreferredBackBufferHeight;
			DefaultWidth = ww;
			DefaultHeight = wh;
			DefaultPoint = new((w / 2) - (ww / 2), (h / 2) - (wh / 2));
			WotoPlanet.Position = DefaultPoint;
		}
		/// <summary>
		/// Set the watcher so they will start watching.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		private void SetWatcher()
		{
			if (ConfigPath == null)
			{
				ConfigDir = ThereIsGConstants.Path.Here;
				ConfigPath = ConfigDir + Config_File_Name;
			}
			if (!File.Exists(ConfigPath.GetValue()))
			{
				var _f = File.Create(ConfigPath.GetValue());
				_f.Dispose();
			}
			File.WriteAllText(ConfigPath.GetValue(), DEFAULT_CONFIG_TEXT);
			if (IsUnix)
			{
				WatcherWorkerLinux ??= new Trigger();
				WatcherWorkerLinux.Tick += LinuxWatcher_Worker;
				WatcherWorkerLinux.SetInterval(WORKER_INTERVAL);
				WatcherWorkerLinux.Start();
			}
			else if (IsWindows)
			{
				WatcherWorkerWindows ??= new Worker(WindowsWatcher_Worker, DEFAULT_Z_BASE);
				WatcherWorkerWindows.Start();
			}
		}
		#endregion
		//-------------------------------------------------
		#region Worker Method's Region
		/// <summary>
		/// Worker event method for linux watcher.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		private void LinuxWatcher_Worker(Trigger sender, TickHandlerEventArgs<Trigger> handler)
		{
			if (_checkFile)
			{
				__checkFiles__();   
			}
			else
			{
				if (sender != this.WatcherWorkerLinux)
				{
					sender?.Stop();
					sender?.Dispose();
				}
				this.WatcherWorkerLinux?.Stop();
				this.WatcherWorkerLinux?.Dispose();
			}
		}
		/// <summary>
		/// Worker event method for windows watcher.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		private void WindowsWatcher_Worker(Trigger sender, TickHandlerEventArgs<Trigger> handler)
		{
			Watcher ??= new FileSystemWatcher(ConfigDir.GetValue(), Config_Filter)
			{
				EnableRaisingEvents = true
			};
			Watcher.Changed -= Watcher_Changed;
			Watcher.Changed += Watcher_Changed;
		}
		/// <summary>
		/// Event for watcher.
		/// Only for windows.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		private void Watcher_Changed(object sender, FileSystemEventArgs e)
		{
			if (e.ChangeType == WatcherChangeTypes.Changed)
			{
				try
				{
					LastCommand = File.ReadAllText(e.FullPath);
					switch (LastCommand.ToLower().GetValue())
					{
						case CONFIG_CLOSE_COMMAND1:
						case CONFIG_CLOSE_COMMAND2:
						case CONFIG_CLOSE_COMMAND3:
						case CONFIG_CLOSE_COMMAND4:
						case CONFIG_CLOSE_COMMAND5:
						case CONFIG_CLOSE_COMMAND6:
						case CONFIG_CLOSE_COMMAND7:
							Close();
							break;
						case CONFIG_UP_COMMAND:
							ComeOnUp();
							break;
						default:
							// it means the command is unknown to us.
							Debug.Print( UnknownCommandError +
										 LastCommand.GetValue());
							break;
					}
				}
				catch (Exception _e)
				{
					// it means there was an error here ..
					// so, never mind it and just continue the game :|
					Debug.Print(_e.Message);
					return;
				}
			}
		}
		#endregion
		//-------------------------------------------------
		#region Ordinary Method's Region
		/// <summary>
		/// come on up!
		/// for activating the holy planet of woto,
		/// after a non-single-one proccess of game has runned.
		/// </summary>
		public void ComeOnUp()
		{
			if (WotoPlanet == null)
			{
				return;
			}
			// try if we can access to the cross-threading holy planet of woto
			// or not.
			try
			{
				
			}
			catch
			{
				// it means the access here is denied!
				// so send a request to the client,
				// which is definitely on the main thread,
				// so it has access and the request will be done.
				Client.Request = RequestType.Activate;
				Client.Universe_Request = true;
			}
		}
		/// <summary>
		/// Close the application and terminate the client.
		/// This will completely close the loop, so be careful when using it.
		/// Tho it won't exit it right now, it will exit it after the end of
		/// this tick.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		public void Close()
		{
			if (!this.Completed)
			{
				return;
			}
			Watcher?.Dispose();
			Client?.Exit();
		}
		/// <summary>
		/// Call this method in <see cref="GClient.Update(GameTime)"/>.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		internal void UpdateUniverse()
		{
			var state = Mouse.GetState();
			checkMouseButtons(MouseButtons.Left, state);
			checkMouseButtons(MouseButtons.Right, state);
		}
		/// <summary>
		/// check the MouseButton states.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		/// <param name="b">the button</param>
		/// <param name="state">the state of the button.</param>
		private void checkMouseButtons(MouseButtons b, MouseState state)
		{
			switch (b)
			{
				case MouseButtons.Left:
					if (state.LeftButton == ButtonState.Pressed)
					{
						if (!_left_pressed)
						{
							_left_pressed	  = true;
							var _cr = ThereIsGConstants.AppSettings.WotoCreation;
							//var _arg		   = new MouseEventArgs(_cr, b);
							MouseDown?.Invoke(this, null);
						}
					}
					else
					{
						if (_left_pressed)
						{
							_left_pressed	  = false;
							var _cr = ThereIsGConstants.AppSettings.WotoCreation;
							//var _arg		   = new MouseEventArgs(_cr, b);
							MouseUp?.Invoke(this, null);
						}
					}
					break;
				case MouseButtons.Right:
					if (state.RightButton == ButtonState.Pressed)
					{
						if (!_right_pressed)
						{
							_right_pressed	 = true;
							var _cr = ThereIsGConstants.AppSettings.WotoCreation;
							//var _arg		   = new MouseEventArgs(_cr, b);
							MouseDown?.Invoke(this, null);
						}
					}
					else
					{
						if (_right_pressed)
						{
							_right_pressed	  = false;
							var _cr  = ThereIsGConstants.AppSettings.WotoCreation;
							//var _arg			= new MouseEventArgs(_cr, b);
							MouseUp?.Invoke(this, null);
						}
					}
					break;
				// ReSharper disable once RedundantEmptySwitchSection
				default:
					/*
					 * TODO: in the future you have to add more options.
					 */
					return;
			}
			
		}
		/// <summary>
		/// check the <see cref="__mmf__"/> file.
		/// do NOT make this method public.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		private void __checkFiles__()
		{
			// check if the __mmf__ exists or not.
			if (!File.Exists(__mmf__))
			{
				// it means that the __mmf__ file has been deleted.
				// so you have to close the game!
				Client.Exit();
			}
		}
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		/// send a request to another existing universe for 
		/// activating their woto planet.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		public static void Universe_Request()
		{
			var path = Directory.GetCurrentDirectory() + Config_File_Name;
			File.WriteAllText(path, CONFIG_UP_COMMAND);
		}
		/// <summary>
		/// pre-setup the universe of the game.
		/// <!--
		/// Since: GUIVoid 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		internal static void SetUpUniverse()
		{
			var p	= Environment.OSVersion.Platform;
			IsWindows	=	p	== PlatformID.Win32NT;
			IsUnix		=	p	== PlatformID.Unix;
		}
		#endregion
		//-------------------------------------------------
	}
}
