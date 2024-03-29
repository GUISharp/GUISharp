﻿/*
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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FontStashSharp;
using GUISharp.Client;
using GUISharp.Controls;
using GUISharp.Constants;
using GUISharp.GUIObjects.Resources;

namespace GUISharp.GUIObjects.Texts
{
	public sealed partial class FontManager : IRes, IDisposable
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		/// Old Story Bold File In Res.
		/// </summary>
		internal const string OSBFileInRes
			= "Old Story Bold";
		/// <summary>
		/// Old Story Bold Italic File In Res.
		/// </summary>
		internal const string OSBIFileInRes
			= "Old Story Bold Italic";
		/// <summary>
		/// GUISharpTT Bold File In Res.
		/// </summary>
		internal const string GUISharpTTBoldFileInRes
			= "GUISharpWelcomeTT-Bold";
		/// <summary>
		/// GUISharpTT Regular File In Res.
		/// </summary>
		internal const string GUISharpTTRFileInRes
			= "GUISharpWelcomeTT-Regular";
		/// <summary>
		/// Noto Sans Regular File In Res.
		/// </summary>
		internal const string NSRFileInRes
			= "NotoSansJP-Regular";

		internal const string RobotoBlackFileInRes
			= "Roboto-Black";
		
		internal const string RobotoBlackItalicFileInRes
			= "Roboto-BlackItalic";
		
		internal const string RobotoBoldFileInRes
			= "Roboto-Bold";

		internal const string RobotoBoldItalicFileInRes
			= "Roboto-BoldItalic";
		
		internal const string RobotoItalicFileInRes
			= "Roboto-Italic";
		
		internal const string RobotoLightFileInRes
			= "Roboto-Light";
		
		internal const string RobotoLightItalicFileInRes
			= "Roboto-LightItalic";
		
		internal const string RobotoMediumFileInRes
			= "Roboto-Medium";
		
		internal const string RobotoMediumItalicFileInRes
			= "Roboto-MediumItalic";
		
		internal const string RobotoRegularFileInRes
			= "Roboto-Regular";
		
		internal const string RobotoThinFileInRes
			= "Roboto-Thin";
		
		internal const string RobotoThinItalicFileInRes
			= "Roboto-ThinItalic";
			
		public const int FontBitmapWidth				= 1024;
		public const int FontBitmapHeight			   	= 1024;
		public const int OLDSTORY_INDEX				 	= 0;
		public const int GUISharp_INDEX					= 1;
		public const int STROKE_AMOUNT					= 1;
		#endregion
		//-------------------------------------------------
		#region static Properties Region

		#endregion
		//-------------------------------------------------
		#region Properties Region
		public WotoRes MyRes { get; set; }
		internal GClient Client { get; }
		public int GraphicsLevel { get; }
		#endregion
		//-------------------------------------------------
		#region field's Region
		private CharacterRange[] _ranges;
		private FontSystem _old_story_bold;
		private FontSystem _old_story_bold_italic;
		private FontSystem _GUISharp_bold;
		private FontSystem _GUISharp_regular;
		private FontSystem _noto_sans_regular;
		private FontSystem _roboto_black;
		private FontSystem _roboto_black_italic;
		private FontSystem _roboto_bold;
		private FontSystem _roboto_bold_italic;
		private FontSystem _roboto_italic;
		private FontSystem _roboto_light;
		private FontSystem _roboto_light_italic;
		private FontSystem _roboto_medium;
		private FontSystem _roboto_medium_italic;
		private FontSystem _roboto_regular;
		private FontSystem _roboto_thin;
		private FontSystem _roboto_thin_italic;


		private FontSystemSettings _settings;
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		private FontManager(GClient _client, int _level = 2)
		{
			Client			= _client;
			GraphicsLevel	= _level;
			InitializeComponents();
		}
		#endregion
		//-------------------------------------------------
		#region Destructor's Region
		~FontManager()
		{
			Dispose();
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		public SpriteFontBase GetSprite(GUISharp_Fonts _s_font, int size)
		{
			switch (_s_font)
			{
				case GUISharp_Fonts.GUISharp_tt_bold:
				{
					if (this._GUISharp_bold != null)
					{
						return this._GUISharp_bold.GetFont(size);
					}
					break;
				}
				case GUISharp_Fonts.GUISharp_tt_regular:
				{
					if (this._GUISharp_regular != null)
					{
						return this._GUISharp_regular.GetFont(size);
					}
					break;
				}
				case GUISharp_Fonts.old_story_bold:
				{
					if (this._old_story_bold != null)
					{
						return this._old_story_bold.GetFont(size);
					}
					break;
				}
				case GUISharp_Fonts.old_story_bold_italic:
				{
					if (this._old_story_bold_italic != null)
					{
						return this._old_story_bold_italic.GetFont(size);
					}
					break;
				}
				case GUISharp_Fonts.noto_sans_JP:
				{
					if (this._noto_sans_regular != null)
					{
						return this._noto_sans_regular.GetFont(size);
					}
					break;
				}
				default:
				{
					// we have to ensure everything goes well, 
					// so if there is a problem here, we should return a
					// default font (instead of null) 
					// which will act in an emergency situation.
					return _getDefault();
				}
			}
			return null;

			// local functions:
			SpriteFontBase _getDefault()
			{
				if (this._GUISharp_bold != null)
				{
					return this._GUISharp_bold.GetFont(size);
				}
				return null;
			}
		}
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		///	Generate a new FontManager.
		/// </summary>
		internal static FontManager GenerateManager(GClient _client)
		{
			// check if client is null or not.
			// if there is no client, we SHOULD NOT create a new font manager.
			if (_client == null)
			{
				// it means the client is not generated yet, so we should 
				// return null.
				return null;
			}
			// check if the client alread has another font manager or not.
			if (_client.FontManager != null)
			{
				// it means a font manager has already been created.
				// so return it instead of creating a new one.
				return _client.FontManager;
			}
			// check if the graphic device of the client
			// has been created or not, and is disposed or not.
			if (_client.GraphicsDevice == null || 
					_client.GraphicsDevice.IsDisposed)
			{
				// for creating fonts, we have to use GraphicsDevice
				// property of the GClient, which is why it's important
				// for it to be present and not disposed.
				// at this rate we can't generate any font manager and will
				// return null.
				return null;
			}
			// create a new font manager object.
			// please do NOT set the properties and fields in here.
			return new FontManager(_client);
		}
		#endregion
		//-------------------------------------------------
	}
}
