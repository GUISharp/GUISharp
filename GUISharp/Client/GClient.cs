/*
 * This file is part of GUISharp Project (https://github.com/GUISharp/GUISharp).
 * Copyright (c) 2021 GUISharp Authors.
 *
 * This library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 3.
 *
 * This library is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this source code of library. 
 * If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using GUISharp.Logging;
using GUISharp.Controls;
using GUISharp.Security;
using GUISharp.Constants;
#if __WINDOWS__
using GUISharp.Controls.Music;
#endif //__WINDOWS__
using GUISharp.GUIObjects.Texts;
using GUISharp.Controls.Elements;
using GUISharp.GUIObjects.Graphics;
using GUISharp.GUIObjects.Resources;
using GUISharp.WotoProvider.EventHandlers;

namespace GUISharp.Client
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	internal partial class GClient : Game, IRes
	{
		//-------------------------------------------------
		#region Constant's Region
		public const string ToStringValue = "-- GUISharp CLIENT --";
		public const string FirstLabelNameInRes = "Label1";

		/// <summary>
		/// Memory Map File Name.
		/// <!--
		/// ReSharper disable once InconsistentNaming
		/// -->
		/// </summary>
		public const string MMF_NAME = "GUISharp_MMF_LOADER_FILE_ASSIST";
		/// <summary>
		/// This is 8.
		/// </summary>
		public const uint EntryCount = 0b1000;
		#endregion
		//-------------------------------------------------
		#region Properties Region
		public WotoRes MyRes { get; set; }
		/// <summary>
		/// Graphics Device Manager of the GUISharp GClient.
		/// </summary>
		public GraphicsDeviceManager GraphicsDM { get; private set; }
		/// <summary>
		/// Sprite Batch of the GUISharp GClient.
		/// </summary>
		public SpriteWoto MySprite { get; private set; }
		public GUIClient GUIClient { get; }
		/// <summary>
		/// The Universe of the GUISharp client.
		/// </summary>
		public Universe GameUniverse { get; }
		/// <summary>
		/// The Font Manager of the game.
		/// </summary>
		public FontManager FontManager { get; private set; }
		public ElementManager ElementManager { get; private set; }
		/// <summary>
		/// the First FlatElement, which shows the player:
		/// "Connecting... " and "Checking for Updates..."
		/// </summary>
		public FlatElement FirstFlatElement { get; private set; }
		public Texture2D BackGroundTexture { get; private set; }
		#if __WINDOWS__
		internal MusicManager MusicManager { get; private set; }
		#endif //__WINDOWS__
		internal RequestType Request { get; set; }
		internal MouseState LastMouseState { get; private set; }
		internal IInputable InputElement { get; private set; }
		internal MouseState CurrentState { get; private set; }
	#nullable enable
		internal Point? LeftDownPoint { get; private set; }
		internal Point? PreviousLeftDownPoint { get; private set; }
		internal Point? RightDownPoint { get; private set; }
		internal Point? PreviousRightDownPoint { get; private set; }
	#nullable disable
		public Color BackColor { get; set; } = Color.Black;
		public Rectangle BackgroundRectangle { get; set; }
		public string Title
		{
			get
			{
				if (Window != null)
				{
					return Window.Title;
				}
				return string.Empty;
			}
			set
			{
				if (Window != null)
				{
					Window.Title = value;
				}
			}
		}
		public int Width
		{
			get
			{
				if (GameUniverse != null)
				{
					return GameUniverse.Width;
				}
				return Universe.DEFAULT_Z_BASE;
			}
		}
		public int Height
		{
			get
			{
				if (GameUniverse != null)
				{
					return GameUniverse.Height;
				}
				return Universe.DEFAULT_Z_BASE;
			}
		}
		public bool Verified { get; set; }
		public bool IsCtrlDown { get; private set; }
		public bool IsFullScreen
		{
			get
			{
				if (GraphicsDM != null)
				{
					return GraphicsDM.IsFullScreen;
				}
				return default;
			}
		}
		public bool IsDisposed
		{
			get
			{
				if (this.GraphicsDevice != null)
				{
					return this.GraphicsDevice.IsDisposed || _disposed;
				}
				
				return Verified;
			}
		}
		public bool IsLeftDown { get; private set; }
		public bool IsRightDown { get; private set; }
		public bool Universe_Request { get; set; }
		#endregion
		//-------------------------------------------------
		#region events Region
		public event SimpleEventHandler Unloading;
		#endregion
		//-------------------------------------------------
		#region field's Region
		private bool _disposed = false;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		public GClient(bool verify, GUIClient gUIClient, 
			ClientSizeMode mode = ClientSizeMode.HalfMiddle)
		{
			if (!verify)
			{
				return;
			}
			GUIClient = gUIClient;
			try
			{
				
				var w = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
				var h = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
				switch (mode)
				{
					case ClientSizeMode.MinimumMiddle:
					{
						w = GUIClient.MIN_WIDTH;
						h = GUIClient.MIN_HEIGHT;
						break;
					}
					case ClientSizeMode.HalfMiddle:
					{
						w = w / 2;
						h = h / 2;
						break;
					}
					case ClientSizeMode.FullScreen:
					{
						break;
					}
				}
				GraphicsDM = new GraphicsDeviceManager(this)
				{
					PreferredBackBufferWidth = w,
					PreferredBackBufferHeight = h,
				};
				if (mode == ClientSizeMode.FullScreen)
				{
					FullScreen();
					Window.IsBorderless = true;
				}
				IsMouseVisible = true;
				GameUniverse = new Universe(Window.Handle, this, mode);
				Content.RootDirectory = ThereIsGConstants.Path.Content;
			}
			catch (NoSuitableGraphicsDeviceException ex)
			{
				Verified = false;
				AppLogger.Fatal("It seems you can't run this application", ex);
				return;
			}
			catch (Exception ex)
			{
				Verified = false;
				AppLogger.Log(ex);
				return;
			}
			//---------------------------------------------
			//IsConnecting				= true;
			//IsShowingSandBox			= false;
			//IsCheckingForUpdate		 = false;
			//IsCheckingForUpdateEnded	= false;
			//IsTheLastVer				= false;
			//IsServerOnBreak			 = false;
			//IsServerUpdating			= false;
			//IsServerOnline			  = false;
			//IsTheFirstTime			  = false;
			//MainMenuLoaded			  = false;
			//ReleasingDate			   = null;
			//---------------------------------------------
			Verified = verify;
			ThereIsGConstants.Forming.GClient = this;
			this.InitializeComponents();
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		
		#endregion
		//-------------------------------------------------
	}
}
