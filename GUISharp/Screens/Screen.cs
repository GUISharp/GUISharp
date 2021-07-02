using System;
using Microsoft.Xna.Framework.Content;
using GUISharp.Client;
using GUISharp.Controls;
using GUISharp.GUIObjects.Texts;
using GUISharp.Controls.Elements;
using GUISharp.GUIObjects.Graphics;
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
		// some members here
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