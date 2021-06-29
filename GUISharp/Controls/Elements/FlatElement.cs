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


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GUISharp.Security;

namespace GUISharp.Controls.Elements
{
    /// <summary>
    /// a flat and light element which is good for showing a text.
    /// the size of this element on the memory will be too low,
    /// which is why you can use it anywhere.
    /// also you can use this for graphical effects such as 
    /// outline of the texts.
	/// Please before adding an object of this element to your
	/// element manager, set some of the properties using these
	/// methods:
	/// <see cref="FlatElement.ChangeSize(float, float)"/>
	/// <see cref="FlatElement.ChangeLocation(int, int)"/>
	/// <see cref="FlatElement.ChangeFont(FontStashSharp.SpriteFontBase)"/>
	/// <see cref="FlatElement.ChangeText(StrongString)"/>
	/// <see cref="FlatElement.ChangeForeColor(Color)"/>
	/// <see cref="FlatElement.ChangeBackColor(Color)"/>
	/// and then use 
	///	test.Enable();
	///	test.Apply();
	///	test.Show();
    /// </summary>
    public partial class FlatElement : GraphicElement
    {
        //-------------------------------------------------
        #region Constant's Region
        public const float TEXT_OFFSET = 0.0f;
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public StrongString FixedText { get; protected set; }
        public Vector2 TextLocation { get; protected set; }
        public StringAlignmation Alignmation { get; protected set; } = StringAlignmation.TopLeft;
		public GraphicElement Representor { get; protected set; }
        #endregion
        //-------------------------------------------------
        #region field's Region
        //private int _text_sfont;
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="myRes"></param>
        /// <param name="isBarren"></param>
        public FlatElement(IRes myRes, bool isBarren = false) : base(myRes, isBarren)
        {
            InitializeComponent();
        }
        public FlatElement(IRes myRes, ElementMovements movements, bool isBarren = false) :
            base(myRes, isBarren)
        {
            Movements = movements;
            InitializeComponent();
        }
		internal FlatElement(IRes myRes, GraphicElement representor) : base(myRes, true)
		{
			SetRepresentor(representor);
			InitializeComponent();
		}
        #endregion
        //-------------------------------------------------
    }
}
