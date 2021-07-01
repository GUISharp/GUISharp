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
using System.IO;
using System.Globalization;
using System.ComponentModel;
using Microsoft.Xna.Framework.Graphics;
using GUISharp.Logging;
using GUISharp.Security;
using GUISharp.Constants;

namespace GUISharp.GUIObjects.Resources
{
	public sealed class WotoRes : ComponentResourceManager
	{
		//-------------------------------------------------
		#region Constants Region
		public const string WotoResStringName = "WotoRes from: ";
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
			if (string.IsNullOrWhiteSpace(name))
			{
				return false;
			}
			try
			{
				return !(GetString(name) is null);	
			}
			catch
			{
				return false;
			}
			
		}
		public bool ObjectExists(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return false;
			}
			try
			{
				return !(GetObject(name) is null);	
			}
			catch
			{
				return false;
			}
		}
		public StrongString GetString(StrongString name)
		{
			if (name == null)
			{
				return null;
			}
			var v = name.GetValue();
			if (string.IsNullOrWhiteSpace(v))
			{
				return null;
			}
			try
			{
				return base.GetString(v);	
			}
			catch (Exception ex)
			{
				AppLogger.Log(ex);
				return null;
			}
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

			using (var m = AllocateMemoryStream(name))
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
		public MemoryStream AllocateMemoryStream(string nameStr)
		{
			if (string.IsNullOrWhiteSpace(nameStr))
			{
				return null;
			}
			var b = GetBytes(nameStr);
			if (b == null || b.Length == default)
			{
				return null;
			}
			return new(b);
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
