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
using GUISharp.Controls.Elements;

namespace GUISharp.SandBox
{
    public sealed partial class LoginProfileSandBox : SandBoxBase
    {
        //-------------------------------------------------
        #region Constant's Region
        /// <summary>
        /// The name of MessageLabel1 in the Resources without _name,
        /// 
        /// </summary>
        public const string SandBoxLabel1NameInRes = "SandBoxLabel1";
        /// <summary>
        /// The name of MessageLabel2 in the Resources without _name,
        /// 
        /// </summary>
        public const string SandBoxLabel2NameInRes = "SandBoxLabel2";
        /// <summary>
        /// The name of Button1 in the Resources without _name,
        /// 
        /// </summary>
        public const string SandBoxButton1NameInRes = "SandBoxButton1";
        /// <summary>
        /// The background Image key in the <see cref="GraphicElement.MyRes"/>.
        /// </summary>
        public const string SandBoxBackGNameInRes = "BackGName";
		public const string LEFT_BABYLONIA_ENTRANCE     = "f_080320212007";
        public const string RIGHT_BABYLONIA_ENTRANCE    = "f_080320212008";
        public const string LINE_BABYLONIA_ENTRANCE     = "f_080320212009";
        #endregion
        //-------------------------------------------------
        #region Properties Region
        /// <summary>
        /// the title flat element of this sandbox.
        /// </summary>
        public FlatElement TitleElement { get; private set; }
        /// <summary>
        /// the body element of this sandbox.
        /// </summary>
        public FlatElement BodyElement { get; private set; }
        /// <summary>
        /// the exit button of this sandbox.
        /// </summary>
        public ButtonElement ExitButton { get; private set; }
        public Texture2D LeftTexture { get; private set; }
        public Texture2D RightTexture { get; private set; }
        public Texture2D LineTexture { get; private set; }
        public Point LeftTextureRealLocation { get; private set; }
        public Point LineTextureRealLocation { get; private set; }
        public Point RightTextureRealLocation { get; private set; }
        public Rectangle LeftTextureRectangle { get; private set; }
        public Rectangle LineTextureRectangle { get; private set; }
        public Rectangle RightTextureRectangle { get; private set; }
        public bool ClosedForRetry
        {
            get
            {
                return ClosedByMe;
            }
            set
            {
                ClosedByMe = value;
            }
        }
        #endregion
        //-------------------------------------------------
        #region field's Region

        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        internal LoginProfileSandBox() : base()
        {
            InitializeComponent();
        }
        #endregion
        //-------------------------------------------------
        #region Destructor's Region
        ~LoginProfileSandBox()
        {
            return;
        }
        #endregion
        //-------------------------------------------------
    }
}
