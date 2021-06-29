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
using GUISharp.Client;
using GUISharp.Controls.Elements;

namespace GUISharp.SandBox
{
    public abstract partial class SandBoxBase : SandBoxElement
    {
        //-------------------------------------------------
        #region Constant's Region
        public const int from_the_edge = 10;
        public const int SeparatorLine_Height = 12;
        #endregion
        //-------------------------------------------------
        #region static Property Region
        /// <summary>
        /// in the previos version of the GUISharp,
        /// we had something with this syntax: 
        /// <code>
        /// public GameControl.PageControl UnderForm { get; private set; }
        /// </code>
        /// so, I just wanted to create something similar in this version,
        /// but the difference is that this UnderForm will always return you
        /// the <see cref="GClient"/> of the game.
        /// </summary>
        /// <value>
        /// the <see cref="GClient"/>of the game,
        /// which is also available in <c>ThereIsGConstants</c> class.
        /// </value>
        internal static GClient UnderForm
        {
            get => BigFather;
        }
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public override Rectangle Rectangle
        {
            get
            {
                if (_flat != null)
                {
                    return _flat.Rectangle;
                }
                return Rectangle.Empty;
            }
            set
            {
                if (_flat != null)
                {
                    _flat.Rectangle = value;
                }
            }
        }
        public override Vector2 Position
        {
            get
            {
                if (_flat != null)
                {
                    return _flat.Position;
                }
                return Vector2.Zero;
            }
            set
            {
                if (_flat != null)
                {
                    if (_flat.Position != value)
                    {
                        _flat.Position = value;
                    }
                }
            }
        }
        public override Vector2 RealPosition
        {
            get
            {
                if (_flat != null)
                {
                    return _flat.RealPosition;
                }
                return Vector2.Zero;
            }
            protected set
            {
                if (_flat != null)
                {
                    if (_flat.RealPosition != value)
                    {
                        _flat.ChangeLocation(value);
                    }
                }
            }
        }
        /// <summary>
        /// the priority of this very sandbox.
        /// </summary>
        public virtual SandBoxPriority SandBoxPriority { get; protected set; }
        /// <summary>
        /// a value for checking whether this sandbox was closed
        /// by me or by player.
        /// </summary>
        /// <value><c>true</c> if this sandbox was closed by me;
        /// otherwise <c>false</c>.</value>
        public virtual bool ClosedByMe { get; protected set; }
        #endregion
        //-------------------------------------------------
        #region field's Region
        protected FlatElement _flat;
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        /// <summary>
        /// Constructor of The Great Holy <see cref="SandBoxBase"/>.
        /// </summary>
        protected SandBoxBase() : base()
        {
            InitializeComponent();
        }
        #endregion
        //-------------------------------------------------
    }
}
