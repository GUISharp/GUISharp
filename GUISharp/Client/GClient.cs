// GUISharp Project
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using GUISharp.Controls;
using GUISharp.Security;
using GUISharp.Constants;
using GUISharp.GUIObjects.Texts;
using GUISharp.Controls.Elements;
using GUISharp.GUIObjects.Graphics;
using GUISharp.GUIObjects.Resources;

namespace GUISharp.Client
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	internal partial class GClient : Game, IRes
	{
		//-------------------------------------------------
		#region Constant's Region
		public const string ToStringValue = "-- GUISharp GAME CLIENT --";
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
		internal RequestType Request { get; set; }
		internal MouseState LastMouseState { get; private set; }
		internal IInputable InputElement { get; private set; }
		internal MouseState CurrentState { get; private set; }
	#nullable enable
		internal Point? LeftDownPoint { get; private set; }
		internal Point? PreviousLeftDownPoint { get; private set; }
		internal Point? RightDownPoint { get; private set; }
		internal Point? PreviousRightDownPoint { get; private set; }
		public GUIClient GUIClient { get; }
	#nullable disable
		//public SoundPlayer SoundPlayer { get; set; }
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
		internal bool IsLeftDown { get; private set; }
		internal bool IsRightDown { get; private set; }
		public bool Verified { get; set; }
		//public bool IsConnecting { get; set; }
		//public bool IsShowingSandBox { get; set; }
		//public bool IsCheckingForUpdate { get; set; }
		//public bool IsCheckingForUpdateEnded { get; set; }
		//public bool IsTheLastVer { get; set; }
		//public bool IsServerOnBreak { get; set; }
		//public bool IsServerUpdating { get; set; }
		//public bool IsServerOnline { get; set; }
		//public bool IsTheFirstTime { get; set; }
		public bool IsCtrlDown { get; private set; }
		/// <summary>
		/// NOTE: this value is just a bool for the DateTimeWorker
		/// </summary>
		public bool MainMenuLoaded { get; set; }
		public bool Universe_Request { get; set; }
		public StrongString ReleasingDate { get; set; } = null;
		#endregion
		//-------------------------------------------------
		#region field's Region

		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		public GClient(bool verify, GUIClient gUIClient)
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
				GraphicsDM = new GraphicsDeviceManager(this)
				{
					PreferredBackBufferWidth = w / 2,
					PreferredBackBufferHeight = h / 2,
				};
				IsMouseVisible = true;
				GameUniverse = new Universe(Window.Handle, this);
				Content.RootDirectory = ThereIsGConstants.Path.Content;
			}
			catch (NoSuitableGraphicsDeviceException ex)
			{
				Verified = false;
				Console.WriteLine(ex.Message);
				return;
			}
			catch (Exception ex)
			{
				Verified = false;
				Console.WriteLine("Another exception:\n " + ex.Message);
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
