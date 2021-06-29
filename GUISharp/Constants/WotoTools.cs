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
using Microsoft.Xna.Framework;
using GUISharp.Security;

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
	}

}
