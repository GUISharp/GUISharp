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


using FontStashSharp;
using GUISharp.GUIObjects.Resources;

namespace GUISharp.GUIObjects.Texts
{
	partial class FontManager
	{
		//-------------------------------------------------
		#region Initialize Method's Region
		/// <summary>
		/// Initializ the components.
		/// </summary>
		private void InitializeComponents()
		{
			//---------------------------------------------
			//news:
			this.MyRes 						= new WotoRes(typeof(FontManager));
			this._settings 					= _getSettings();
			this._ranges 					= _getRanges();
			this._old_story_bold 			= _generate();
			this._old_story_bold_italic 	= _generate();
			this._GUISharp_bold				= _generate();
			this._GUISharp_regular			= _generate();
			this._noto_sans_regular			= _generate();
			byte[] _old_story_bold_ 		= _fromRes(OSBFileInRes);
			byte[] _old_story_bold_italic_	= _fromRes(OSBIFileInRes);
			byte[] _GUISharp_bold_ 			= _fromRes(GUISharpTTBoldFileInRes);
			byte[] _GUISharp_regular_ 		= _fromRes(GUISharpTTRFileInRes);
			byte[] _noto_sans_regular_ 		= _fromRes(NSRFileInRes);

			//---------------------------------------------
			//add colection fonts:
			this._old_story_bold?.AddFont(_old_story_bold_);
			this._old_story_bold?.AddFont(_noto_sans_regular_);
			this._old_story_bold_italic?.AddFont(_old_story_bold_italic_);
			this._old_story_bold_italic?.AddFont(_noto_sans_regular_);
			this._GUISharp_bold?.AddFont(_GUISharp_bold_);
			this._GUISharp_bold?.AddFont(_noto_sans_regular_);
			this._GUISharp_regular?.AddFont(_GUISharp_regular_);
			this._GUISharp_regular?.AddFont(_noto_sans_regular_);
			this._noto_sans_regular?.AddFont(_noto_sans_regular_);
			this._noto_sans_regular?.AddFont(_GUISharp_bold_);
			//---------------------------------------------
			//localFunctions:
			FontSystem _generate()
			{
				return new(this._settings);
			}
			FontSystemSettings _getSettings()
			{
				return new()
				{
					TextureWidth = this.GraphicsLevel * FontBitmapWidth,
					TextureHeight = this.GraphicsLevel * FontBitmapHeight,
					Effect = FontSystemEffect.Stroked,
					EffectAmount = STROKE_AMOUNT,
				};
			}
			//---------------------------------------------
		}
		#endregion
		//-------------------------------------------------
		#region Ordinary Method's Region
		public void Dispose()
		{
			if (this.MyRes != null)
			{
				this.MyRes = null;
			}
			#if (OLD_GUISharp)
			if (this._collection != null)
			{
				this._collection = null;
			}
			#endif
		}
		public bool Contains(char c)
		{
			for (int i = 0; i < _ranges.Length; i++)
			{
				if (_ranges[i].Contains(c))
				{
					return true;
				}
			}	
			return false;
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// Get a byte array from the resource manager with 
		/// the specified name.
		/// </summary>
		private byte[] _fromRes(string _name)
		{
			if (this.MyRes != null && _name != null)
			{
				return this.MyRes.GetBytes(_name);
			}
			return null;
		}
		private CharacterRange[] _getRanges()
		{
			return new[] 
			{
				CharacterRange.BasicLatin,
				CharacterRange.Latin1Supplement,
				CharacterRange.LatinExtendedA,
				CharacterRange.LatinExtendedB,
				CharacterRange.Cyrillic,
				CharacterRange.CyrillicSupplement,
				CharacterRange.Hiragana,
				CharacterRange.Katakana,
				CharacterRange.Kanji,
			};
			
		}
		#endregion
		//-------------------------------------------------
	}
}