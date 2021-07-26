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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GUISharp.Security;
using GUISharp.Constants;
using static GUISharp.Client.Universe;
using Image = System.Drawing.Image;
using Graphic = System.Drawing.Graphics;

namespace GUISharp.GUIObjects.Graphics
{
	/// <summary>
	/// Provides methods for graphic 2D drawing.
	/// </summary>
	public partial class Illusion : IDisposable
	{
		//-------------------------------------------------
		#region Constants Region
		
		#endregion
		//-------------------------------------------------
		#region field's Region
        /// <summary>
	    /// the texture of this illusion.
		/// NOTICE: our normal way of doing stuff
		/// here is: 
		/// <c> Bitmap -> Texture2D </c>
		/// in <see cref="AsyncComponents(bool)"/>, we always
		/// async them like this.
		/// The reason is really clear:
		/// we can do stuff on a <c>Bitmap</c>,
		/// so the real core is our bitmap.
		/// but we <bold>NEED</bold> a <see cref="Texture2D"/>
		/// output, that's why we have to do things like this.
		/// Now, if user give us a <see cref="Image"/>, we
		/// won't convert it to a <see cref="Texture2D"/>
		/// <bold>UNLESS</bold> we need to give it an output.
		/// Now lets see another situations:
		/// user gives us a <see cref="Texture2D"/> input,
		/// we won't allocate memory to create a <see cref="Image"/>
		/// from it, <bold>UNLESS</bold> we need to do a graphical
		/// operations, such as Drawing.
		/// This way, we don't need to allocate memory for every fucking
		/// things.
		/// The size of most of the images may be less than 1MB,
		/// but still user maybe wants to use a 100MB image, in that
		/// case we need to allocate another 100MB, which is 
		/// not acceptable at all.
	    /// </summary>
		private Texture2D _texture;
		private Image _bit_map;
		private Graphic _g;
		private bool _changed;
		#endregion
		//-------------------------------------------------
		#region Properties Region
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		private Illusion(Texture2D t)
		{
			_texture = t;
			// async all components by force
			this.AsyncComponents(true);
		}
		private Illusion(Image image)
		{
			_bit_map = image;
			// async all components by force
			this.AsyncComponents(true);
		}
		#endregion
		//-------------------------------------------------
		#region Destructor's Region

		#endregion
		//-------------------------------------------------
	}
}
