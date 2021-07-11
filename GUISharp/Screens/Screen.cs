using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using GUISharp.Client;
using GUISharp.Controls;
using GUISharp.GUIObjects.Texts;
using GUISharp.Controls.Elements;
using GUISharp.GUIObjects.Resources;

namespace GUISharp.Screens
{
	public abstract partial class Screen : IRes, IDisposable
	{
		//-------------------------------------------------
		#region Constant's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region static Properties Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region Properties Region
		public virtual WotoRes MyRes { get; set; }
		public virtual GUIClient Client { get; }
		public virtual string Title
		{
			get
			{
				if (Client != null)
				{
					return Client.Title;
				}
				return string.Empty;
			}
			set
			{
				if (Client != null)
				{
					Client.Title = value;
				}
			}
		}
		public virtual ElementManager ElementManager
		{
			get
			{
				if (Client != null)
				{
					return Client.ElementManager;
				}
				return null;
			}
		}
		public virtual FontManager FontManager
		{
			get
			{
				if (Client != null)
				{
					return Client.FontManager;
				}
				return null;
			}
		}
		public virtual ContentManager ContentManager
		{
			get
			{
				if (Client != null)
				{
					return Client.ContentManager;
				}
				return null;
			}
		}
		public virtual Point Location
		{
			get
			{
				if (Client != null)
				{
					return Client.Location;
				}
				return default;
			}
		}
		public virtual int Width
		{
			get
			{
				if (Client != null)
				{
					return Client.Width;
				}
				return default;
			}
		}
		public virtual int Height
		{
			get
			{
				if (Client != null)
				{
					return Client.Height;
				}
				return default;
			}
		}
		public virtual int X
		{
			get
			{
				return Location.X;
			}
		}
		public virtual int Y
		{
			get
			{
				return Location.Y;
			}
		}
		#endregion
		//-------------------------------------------------
		#region static field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region static event field's Region
		// some members here
		#endregion
		//-------------------------------------------------
		#region event field's Region
		public event EventHandler Done;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		protected Screen(GUIClient client)
		{
			Client = client;
		}
		#endregion
		//-------------------------------------------------
		#region Destructor's Region
		// some members here
		#endregion
		//-------------------------------------------------
	}
}