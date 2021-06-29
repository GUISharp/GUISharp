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


namespace GUISharp.Controls
{
    public enum StringAlignmation
    {
		NaN = (0 << 0b0000),
        /// <summary>
        /// Content is vertically aligned at the top, and horizontally aligned on the left.
        /// </summary>
        TopLeft = (1 << 0b0000),
        /// <summary>
        /// Content is vertically aligned at the top, and horizontally aligned at the center.
        /// </summary>
        TopCenter = (1 << 0b0001),
        /// <summary>
        /// Content is vertically aligned at the top, and horizontally aligned on the right.
        /// </summary>
        TopRight = (1 << 0b0010),
        /// <summary>
        /// Content is vertically aligned in the middle, and horizontally aligned on the
        /// left.
        /// </summary>
        MiddleLeft = (1 << 0b0011),
        /// <summary>
        /// Content is vertically aligned in the middle, and horizontally aligned at the
        /// center.
        /// </summary>
        MiddleCenter = (1 << 0b0100),
        /// <summary>
        /// Content is vertically aligned in the middle, and horizontally aligned on the
        /// right.
        /// </summary>
        MiddleRight = (1 << 0b0101),
        /// <summary>
        /// Content is vertically aligned at the bottom, and horizontally aligned on the
        /// left.
        /// </summary>
        BottomLeft = (1 << 0b0110),
        /// <summary>
        /// Content is vertically aligned at the bottom, and horizontally aligned at the
        /// center.
        /// </summary>
        BottomCenter = (1 << 0b0111),
        /// <summary>
        /// Content is vertically aligned at the bottom, and horizontally aligned on the
        /// right.
        /// </summary>
        BottomRight =  (1 << 0b1000)
    }
    
}
