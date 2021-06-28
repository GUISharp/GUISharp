﻿// GUISharp Project
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

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
