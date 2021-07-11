using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;
using GUISharp.Logging;
using GUISharp.Controls.Elements;

namespace GUISharp.Screens
{
	partial class Screen
	{
		//-------------------------------------------------
		#region Initialize Method's Region
		public abstract void InitializeComponents();
		#endregion
		//-------------------------------------------------
		#region Graphical Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region event Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region ordinary Method's Region
		public virtual void AddElement(GraphicElement element)
		{
			this.ElementManager?.Add(element);
		}
		public virtual void AddElements(params GraphicElement[] elements)
		{
			this.ElementManager?.AddRange(elements);
		}
		public virtual void RemoveElement(GraphicElement element, 
			bool dispose = true)
		{
			this.ElementManager?.Remove(element, dispose);
		}
		public virtual void RemoveElements(bool dispose = true)
		{
			this.ElementManager?.RemoveAll(dispose);
		}
		public virtual void ClearElements()
		{
			this.ElementManager?.Clear();
		}
		public virtual void HideElements()
		{
			this.ElementManager?.HideAll();
		}
		public virtual void DisposeElements()
		{
			this.ElementManager?.DisposeAll();
		}
		public abstract void Dispose();
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		public virtual GraphicsDevice GetDevice()
		{
			if (Client != null)
			{
				return Client.GetDevice();
			}
			return null;
		}
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		public virtual void ChangeSize(int w, int h)
		{
			this.Client?.ChangeSize(w, h);
		}
		public virtual void ChangeSize(Point size)
		{
			this.Client?.ChangeSize(size);
		}
		public virtual void ChangeSize(float w, float h)
		{
			this.Client?.ChangeSize(w, h);
		}
		public virtual void ChangeLocation(int x, int y)
		{
			this.Client.ChangeLocation(x, y);
		}
		public virtual void ChangeLocation(float x, float y)
		{
			this.Client?.ChangeLocation(x, y);
		}
		public virtual void ChangeLocation(Point location)
		{
			this.Client?.ChangeLocation(location);
		}
		public virtual void ChangeBackground(Texture2D t)
		{
			this.Client?.ChangeBackground(t);
		}
		public virtual void ChangeBackgroundContent(string contentName)
		{
			var c = this.ContentManager;
			if (string.IsNullOrWhiteSpace(contentName) || c == null)
			{
				return;
			}
			try
			{
				this.Client?.ChangeBackground(c.Load<Texture2D>(contentName));
			}
			catch (Exception ex)
			{
				AppLogger.Log(ex);
			}
		}
		public virtual void ChangeBackgroundRes(string resName)
		{
			var r = this.MyRes;
			var c = this.Client;
			if (string.IsNullOrWhiteSpace(resName) || r == null || c == null)
			{
				return;
			}
			var d = c.GetDevice();
			if (d == null || d.IsDisposed)
			{
				return;
			}
			try
			{
				c.ChangeBackground(r.GetAsTexture2D(d, resName));
			}
			catch (Exception ex)
			{
				AppLogger.Log(ex);
			}
		}
		public virtual void ChangeBackgroundRes(string resName, int num)
		{
			this.ChangeBackgroundRes(resName + num);
		}
		public virtual void ChangeBackColor(Color color)
		{
			this.Client?.ChangeBackColor(color);
		}
		
		#endregion
		//-------------------------------------------------
	}
}