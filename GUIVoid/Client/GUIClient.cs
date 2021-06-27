using Microsoft.Xna.Framework;
using GUIVoid.Controls.Elements;
using GUIVoid.GUIObjects.Texts;


namespace GUIVoid.Client
{
	public partial class GUIClient
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		/// The minimum amount of client width.
		/// please take note that it won't be applied
		/// to <see cref="GraphicElement"/> objects.
		/// <!--
		/// Since: GUIVoid 1.0.10;
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
		/// Since: GUIVoid 1.0.10;
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
		/// Since: GUIVoid 1.0.9;
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
		/// <see cref="GUIVoid.GUIObjects.Texts.FontManager"/> for it.
		/// But if you don't have the knowledge on how it works,
		/// please don't override it.
		/// <!--
		/// Since: GUIVoid 1.0.10;
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
		/// <summary>
		/// Get or set the size of this Client.
		/// The size should be in <see cref="Point"/> format.
		/// You can also use <see cref="GUIClient.ChangeSize(Point)" />
		/// for changing the size.
		/// <!--
		/// Since: GUIVoid 1.0.10;
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
		/// Since: GUIVoid 1.0.10;
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
		/// Since: GUIVoid 1.0.10;
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
		/// Since: GUIVoid 1.0.10;
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
		/// It's true if the application has already been
		/// started, otherwise it will be false.
		/// <!--
		/// Since: GUIVoid 1.0.9;
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
		/// Since: GUIVoid 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool RunSingleInstance { get; protected set; }
		/// <summary>
		/// Determines whether the border of the window is 
		/// visible or not.
		/// It returns <c>true</c> if the current client is borderless,
		/// but if it has border or it's not supported, it will return
		/// <c>false</c>.
		/// <!--
		/// Since: GUIVoid 1.0.9;
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
						catch
						{
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
							catch
							{
								;
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
		/// Since: GUIVoid 1.0.10;
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
		/// Since: GUIVoid 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summar>
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
		/// Since: GUIVoid 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 26 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public GUIClient()
		{
			InitializaComponent();
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