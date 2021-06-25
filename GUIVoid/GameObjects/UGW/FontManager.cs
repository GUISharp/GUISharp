// Last Testament of Wanderers 
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FontStashSharp;
using GUIVoid.Client;
using GUIVoid.Controls;
using GUIVoid.Constants;
using GUIVoid.GameObjects.Resources;

namespace GUIVoid.GameObjects.UGW
{
	public sealed partial class FontManager : IRes, IDisposable
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		/// Old Story Bold File In Res.
		/// </summary>
		public const string OSBFileInRes		= "Old Story Bold";
		/// <summary>
		/// Old Story Bold Italic File In Res.
		/// </summary>
		public const string OSBIFileInRes		= "Old Story Bold Italic";
		/// <summary>
		/// GUIVoidTT Bold File In Res.
		/// </summary>
		public const string GUIVoidTTBoldFileInRes	= "GUIVoidWelcomeTT-Bold";
		/// <summary>
		/// GUIVoidTT Regular File In Res.
		/// </summary>
		public const string GUIVoidTTRFileInRes		= "GUIVoidWelcomeTT-Regular";
		/// <summary>
		/// Noto Sans Regular File In Res.
		/// </summary>
		public const string NSRFileInRes		= "NotoSansJP-Regular";
		public const int FontBitmapWidth				= 1024;
		public const int FontBitmapHeight			   	= 1024;
		public const int OLDSTORY_INDEX				 	= 0;
		public const int GUIVoid_INDEX					  	= 1;
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
		private FontSystem _GUIVoid_bold;
		private FontSystem _GUIVoid_regular;
		private FontSystem _noto_sans_regular;
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
		public SpriteFontBase GetSprite(GUIVoid_Fonts _s_font, int size)
		{
			switch (_s_font)
			{
				case GUIVoid_Fonts.GUIVoid_tt_bold:
				{
					if (this._GUIVoid_bold != null)
					{
						return this._GUIVoid_bold.GetFont(size);
					}
					break;
				}
				case GUIVoid_Fonts.GUIVoid_tt_regular:
				{
					if (this._GUIVoid_regular != null)
					{
						return this._GUIVoid_regular.GetFont(size);
					}
					break;
				}
				case GUIVoid_Fonts.old_story_bold:
				{
					if (this._old_story_bold != null)
					{
						return this._old_story_bold.GetFont(size);
					}
					break;
				}
				case GUIVoid_Fonts.old_story_bold_italic:
				{
					if (this._old_story_bold_italic != null)
					{
						return this._old_story_bold_italic.GetFont(size);
					}
					break;
				}
				case GUIVoid_Fonts.noto_sans_JP:
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
				if (this._GUIVoid_bold != null)
				{
					return this._GUIVoid_bold.GetFont(size);
				}
				return null;
			}
		}
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		///	Generate a new FontManager.
		/// <summary>
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
