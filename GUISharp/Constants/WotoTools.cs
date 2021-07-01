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


/*


it might be possible with the help of
https://github.com/StbSharp/StbImageSharp
and
https://github.com/StbSharp/StbImageWriteSharp
The code will be like

static unsafe void Main(string[] args)
{
    using (var input = File.OpenRead(@"C:\Pictures\somersault.gif"))
    {
        var context = new StbImage.stbi__context(input);

        if (StbImage.stbi__gif_test(context) == 0)
        {
            throw new Exception("Input stream is not GIF file.");
        }

        var g = new StbImage.stbi__gif();

        byte[] data = null;
        var frameCount = 1;

        do
        {
            // Read next frame
            int ccomp;
            byte two_back;
            var result = StbImage.stbi__gif_load_next(context, g, &ccomp, (int)StbImageSharp.ColorComponents.RedGreenBlueAlpha, &two_back);
            if (result == null)
            {
                break;
            }

            // Convert result to byte[]
            if (data == null)
            {
                data = new byte[g.w * g.h * 4];
            }
            Marshal.Copy(new IntPtr(result), data, 0, data.Length);

            // Save the frame to image
            using (Stream output = File.OpenWrite(@"c:\Pictures\output\frame" + frameCount + ".png"))
            {
                ImageWriter writer = new ImageWriter();
                writer.WritePng(data, g.w, g.h, StbImageWriteSharp.ColorComponents.RedGreenBlueAlpha, output);
            }

            ++frameCount;
        } while (true);

        Marshal.FreeHGlobal(new IntPtr(g._out_));
    }
}

*/

using System;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GUISharp.Security;
using Image = System.Drawing.Image;

namespace GUISharp.Constants
{
	/// <summary>
	/// this class, contains main extension methods 
	/// for GUISharp game.
	/// </summary>
	public static class WotoTools
	{
		/// <summary>
		/// get a strong value of this string.
		/// </summary>
		/// <param name="value">
		/// the string.
		/// </param>
		/// <returns>
		/// a strong value of this string.
		/// </returns>
		public static StrongString ToStrong(this string value)
		{
			return new StrongString(value);
		}
		/// <summary>
		/// calculate the absolute value of this vector2.
		/// </summary>
		/// <param name="_v">
		/// the vector.
		/// </param>
		/// <returns>
		/// a non-negative <see cref="Vector2"/>.
		/// </returns>
		public static Vector2 Abs(this Vector2 _v)
		{
			float _i1 = _v.X, _i2 = _v.Y;
			_i1 = MathF.Abs(_i1);
			_i2 = MathF.Abs(_i2);
			if (_i1 != _v.X || _i2 != _v.Y)
			{
				return new(_i1, _i2);
			}
			return _v;
		}
		/// <summary>
		/// calculate the absolute value of this point.
		/// </summary>
		/// <param name="v">
		/// the point.
		/// </param>
		/// <returns>
		/// a non-negative <see cref="Point"/>.
		/// </returns>
		public static Point Abs(this Point v)
		{
			int i1 = v.X, i2 = v.Y;
			i1 = Math.Abs(i1);
			i2 = Math.Abs(i2);
			if (1 != v.X || i2 != v.Y)
			{
				return new(i1, i2);
			}
			return v;
		}
		/// <summary>
		/// Converts the specified <see cref="Image"/> object
		/// to a <see cref="Texture2D"/> value using the specified
		/// <see cref="GraphicsDevice"/>.
		/// <!--
		/// Since: GUISharp 1.0.12;
		/// By: ALiwoto;
		/// Last edit: Jun 30 11:30;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public static Texture2D ToTexture2D(this Image i, GraphicsDevice d)
		{
			using (var m = new MemoryStream())
			{
				i.Save(m, ImageFormat.Png);
				return Texture2D.FromStream(d, m);
			}
		}
		/// <summary>
		/// Converts the specified <see cref="Texture2D"/> object
		/// to a <see cref="Image"/> value using the specified
		/// the original image width and height.
		/// <!--
		/// Since: GUISharp 1.0.12;
		/// By: ALiwoto;
		/// Last edit: 30 Jun 11:30;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public static Image ToImage(this Texture2D texture)
		{
			return texture.ToImage(texture.Width, texture.Height);
		}
		/// <summary>
		/// Converts the specified <see cref="Texture2D"/> object
		/// to a <see cref="Image"/> value using the specified
		/// the specified width and height.
		/// <!--
		/// Since: GUISharp 1.0.12;
		/// By: ALiwoto;
		/// Last edit: 30 Jun 11:30;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public static Image ToImage(this Texture2D texture, int w, int h)
		{
			using (var m = new MemoryStream())
			{
				texture.SaveAsPng(m, w, h);
				return Image.FromStream(m);
			}
		}
	}

}
