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
using Microsoft.Xna.Framework.Content;
using GUISharp.Logging;
using GUISharp.Screens;
using GUISharp.Controls;
using GUISharp.Constants;
using GUISharp.GUIObjects.Texts;
using GUISharp.Controls.Elements;
using GUISharp.GUIObjects.Resources;


namespace GUISharp.Client
{
	public partial class GUIClient : IRes
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		/// The minimum amount of client width.
		/// please take note that it won't be applied
		/// to <see cref="GraphicElement"/> objects.
		/// <!--
		/// Since: GUISharp 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public const int MIN_WIDTH = 80;
		/// <summary>
		/// The minimum amount of client height.
		/// please take note that it won't be applied
		/// to <see cref="GraphicElement"/> objects.
		/// <!--
		/// Since: GUISharp 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public const int MIN_HEIGHT = 80;
		#endregion
		//-------------------------------------------------
		#region static Properties Region
			// some members here
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// Get the element manager of this client.
		/// It is read-only and you can only add or remove
		/// graphic elements from it.
		/// If you want, you can override this element manager
		/// and use your own, but please be careful about it,
		/// if you have no knowledge about it, do NOT override it
		/// in the first place.
		/// <!--
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual ElementManager ElementManager
		{
			get
			{
				if (_g != null)
				{
					return _g.ElementManager;
				}
				return null;
			}
		}
		/// <summary>
		/// The FontManager of this client.
		/// You can't set it, since it's read-only, but
		/// you can override it and use your own 
		/// <see cref="GUISharp.GUIObjects.Texts.FontManager"/> for it.
		/// But if you don't have the knowledge on how it works,
		/// please don't override it.
		/// <!--
		/// Since: GUISharp 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		public virtual FontManager FontManager
		{
			get
			{
				if (_g != null)
				{
					return _g.FontManager;
				}
				return null;
			}
		}
		public virtual WotoRes MyRes
		{
			get
			{
				if (_g != null)
				{
					return _g.MyRes;
				}
				return null;
			}
			set
			{
				;
			}
		}
		public virtual string Title
		{
			get
			{
				if (_g != null)
				{
					return _g.Title;
				}
				return string.Empty;
			}
			set
			{
				if (_g != null)
				{
					_g.Title = value;
				}
			}
		}
		/// <summary>
		/// The current active screen in the application.
		/// It is null by default.
		/// </summary>
		public virtual Screen CurrentScreen { get; protected set; }
		/// <summary>
		/// Get the content manager (if it exists)
		/// </summary>
		public virtual ContentManager ContentManager 
		{
			get
			{
				if (_g != null)
				{
					return _g.Content;
				}
				return null;
			}
		}
		/// <summary>
		/// Get or set the size of this Client.
		/// The size should be in <see cref="Point"/> format.
		/// You can also use <see cref="GUIClient.ChangeSize(Point)" />
		/// for changing the size.
		/// <!--
		/// Since: GUISharp 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 06:57;
		/// -->
		/// </summary>
		public virtual Point Size
		{
			get
			{
				if (_g != null)
				{
					if (_g.GraphicsDM != null)
					{
						var w = _g.GraphicsDM.PreferredBackBufferWidth;
						var h = _g.GraphicsDM.PreferredBackBufferHeight;
						return new(w, h);
					}
				}
				return default;
			}
			set
			{
				ChangeSize(value);
			}
		}
		/// <summary>
		/// The location of this client on the screen, 
		/// eg: global coordinate space which stretches across all screens.
		/// You can override this property in your own client.
		/// You can change the location either with 
		/// <see cref="GUIClient.ChangeLocation(int, int)"/> method or
		/// setting this property directly to a <see cref="Point"/>
		/// value.
		/// <!--
		/// Since: GUISharp 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 06:57;
		/// -->
		/// </summary>
		public virtual Point Location
		{
			get
			{
				if (Window != null)
				{
					return Window.Position;
				}
				return default;
			}
			set
			{
				ChangeLocation(value);
			}
		}
		/// <summary>
		/// The width of this client on the screen, 
		/// eg: global coordinate space which stretches across all screens.
		/// You can override this property in your own client.
		/// You can change the location either with 
		/// <see cref="GUIClient.ChangeLocation(int, int)"/> method or
		/// setting this property directly to an <see cref="System.Int32"/>
		/// value.
		/// <!--
		/// Since: GUISharp 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 11:13;
		/// -->
		/// </summary>
		public virtual int Width
		{
			get
			{
				if (GraphicsDM != null)
				{
					return GraphicsDM.PreferredBackBufferWidth;
				}
				return default;
			}
			set
			{
				ChangeSize(value, Height);
			}
		}
		/// <summary>
		/// The height of this client on the screen, 
		/// eg: global coordinate space which stretches across all screens.
		/// You can override this property in your own client.
		/// You can change the location either with 
		/// <see cref="GUIClient.ChangeLocation(int, int)"/> method or
		/// setting this property directly to an <see cref="System.Int32"/>
		/// value.
		/// <!--
		/// Since: GUISharp 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 11:13;
		/// -->
		/// </summary>
		public virtual int Height
		{
			get
			{
				if (GraphicsDM != null)
				{
					return GraphicsDM.PreferredBackBufferHeight;
				}
				return default;
			}
			set
			{
				ChangeSize(Width, value);
			}
		}
		/// <summary>
		/// The prefered Width of the application. up to you to set it.
		/// by default it will be zero.
		/// <!--
		/// Since: GUISharp 1.0.32;
		/// By: ALiwoto;
		/// Last edit: 5 July 15:07;
		/// -->
		/// </summary>
		public virtual int PWidth { get; set; }
		/// <summary>
		/// The prefered Height of the application. up to you to set it.
		/// by default it will be zero.
		/// <!--
		/// Since: GUISharp 1.0.32;
		/// By: ALiwoto;
		/// Last edit: 5 July 15:07;
		/// -->
		/// </summary>
		public virtual int PHeight { get; set;}
		/// <summary>
		/// It's true if the application has already been
		/// started, otherwise it will be false.
		/// <!--
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57
		/// -->
		/// </summary>
		public bool IsStarted { get; private set; }
		/// <summary>
		/// Set this to true when you want to run only one instance
		/// of your application at the same time. It is supported on 
		/// windows and linux. If user starts your application for second
		/// try, the application won't create a new instance of it and it will
		/// close itself with code 0x0 (no error will be reported.)
		/// On windows, it supposed to give focus to your main client,
		/// but it's not guaranteed.
		/// This property is protected, but you can get the value outside
		/// of GUIClient. If you want to set this propery to true, you have
		/// to create your own class and inheritance it from GUIClient,
		/// otherwise you have to use 
		/// <see cref="GUIClient.MakeSingleRunner()"/> method.
		/// <!--
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool RunSingleInstance { get; protected set; }
		public virtual bool IsFullScreen
		{
			get
			{
				if (_g != null)
				{
					return _g.IsFullScreen;
				}
				return default;
			}
		}
		/// <summary>
		/// Determines whether the border of the window is 
		/// visible or not.
		/// It returns <c>true</c> if the current client is borderless,
		/// but if it has border or it's not supported, it will return
		/// <c>false</c>.
		/// <!--
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool IsBorderless
		{
			get
			{
				if (_g != null)
				{
					if (_g.Window != null)
					{
						try
						{
							return _g.Window.IsBorderless;
						}
						catch (Exception ex)
						{
							AppLogger.Log(ex);
							return false;
						}
					}
				}
				return false;
			}
			protected set
			{
				if (_g != null)
				{
					if (_g.Window != null)
					{
						if (_g.Window.IsBorderless != value)
						{
							try
							{
								_g.Window.IsBorderless = value;
							}
							catch (Exception ex)
							{
								AppLogger.Log(ex);
							}
						}
					}
				}
			}
		}
		/// <summary>
		/// The window of the application.
		/// This property is internal and it shouldn't be
		/// changed in the future.
		/// Please do NOT change it.
		/// <!--
		/// Since: GUISharp 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 27 11:07;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal virtual GameWindow Window
		{
			get
			{
				if (_g != null)
				{
					return _g.Window;
				}
				return null;
			}
		}
		internal virtual GraphicsDeviceManager GraphicsDM
		{
			get
			{
				if (_g != null)
				{
					return _g.GraphicsDM;
				}
				return null;
			}
		}
		#endregion
		//-------------------------------------------------
		#region static field's Region
			// some members here
		#endregion
		//-------------------------------------------------
		#region field's Region
		/// <summary>
		/// The private GClient of our GUIClient.
		/// In other words, the Core.
		/// This should remain private, please do NOT make
		/// it public or internal.
		/// <!--
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		private GClient _g;
		#endregion
		//-------------------------------------------------
		#region static event field's Region
			// some members here
		#endregion
		//-------------------------------------------------
		#region event field's Region
			// some members here
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// create a new instance of GUIClient.
		/// You don't need to pass something to it, just
		/// simply call this. But we recommend you to create
		/// your own class and derive this class if you want to
		/// have more customization power.
		/// That way, you will call this constructor as `base()`.
		/// Of course there is no need for you to call `base()` directly,
		/// it will be done automatically.
		/// <!--
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public GUIClient(ClientSizeMode mode = ClientSizeMode.HalfMiddle)
		{
			ThereIsGConstants.Forming.GUIClient = this;
			InitializeMyComponent(mode);
		}
			// some members here
		#endregion
		//-------------------------------------------------
		#region Destructor's Region
			// some members here
		#endregion
		//-------------------------------------------------
	}
}