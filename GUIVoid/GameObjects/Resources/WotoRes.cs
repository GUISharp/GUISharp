// Last Testament of Wanderers 
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.IO;
using System.Globalization;
using System.ComponentModel;
using Microsoft.Xna.Framework.Graphics;
using GUIVoid.Security;
using GUIVoid.Constants;

namespace GUIVoid.GameObjects.Resources
{
    public sealed class WotoRes : ComponentResourceManager
    {
        //-------------------------------------------------
        #region Constants Region
        public const string WotoResStringName = "WotoRes from :";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public string Name { get; private set; }
        #endregion
        //-------------------------------------------------
        #region Costructor Region
        public WotoRes(Type t) : base(t)
        {
            ;
        }
        #endregion
        //-------------------------------------------------
        #region Ordinary Methods Region

        #endregion
        //-------------------------------------------------
        #region Get Method's Region
        public bool StringExists(string name)
        {
			if (name == null)
			{
				return false;
			}
            return !(GetString(name) is null);
        }
        public bool ObjectExists(string name)
        {
			if (name == null)
			{
				return false;
			}
            return !(GetObject(name) is null);
        }
        public StrongString GetString(StrongString name)
        {
			if (name == null)
			{
				return null;
			}
            return base.GetString(name.GetValue());
        }
		public Texture2D GetAsTexture2D(GraphicsDevice device, string name)
		{
			if (name == null || device == null || device.IsDisposed)
			{
				return null;
			}
			var b = GetBytes(name);
			if (b == null)
			{
				return null;
			}

			using (var m = new MemoryStream(b))
			{
				if (m == null)
				{
					return null;
				}
				
				return Texture2D.FromStream(device, m);
			}
		}
		public Texture2D GetAsTexture2D(string nameStr)
		{
			if (ThereIsGConstants.Forming.GClient == null)
			{
				return null;
			}
			var d = ThereIsGConstants.Forming.GClient.GraphicsDevice;
			return GetAsTexture2D(d, nameStr);
		}
		public Texture2D GetAsTexture2D(StrongString nameStrong)
		{
			return GetAsTexture2D(nameStrong.GetValue());
		}
		public byte[] GetBytes(StrongString name)
		{
			return GetBytes(name.GetValue());
		}
		public byte[] GetBytes(string nameStr)
		{
			var r = base.GetObject(nameStr);
			if (r is byte[] b)
			{
				return b;
			}
			return null;
		}
        public object GetObject(StrongString name)
        {
            return base.GetObject(name.GetValue());
        }
        #endregion
        //-------------------------------------------------
        #region Overrided Methods Region
        public override string GetString(string strName)
        {
            return base.GetString(strName);
        }
        public override object GetObject(string name)
        {
            return base.GetObject(name);
        }
        public override void ApplyResources(object value, string objectName, CultureInfo culture)
        {
            base.ApplyResources(value, objectName, culture);
        }
        public override string ToString()
        {
            return WotoResStringName + BaseName;
        }
        #endregion
        //-------------------------------------------------
    }
}
