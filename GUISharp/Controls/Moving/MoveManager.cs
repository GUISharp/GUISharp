﻿// GUISharp Project
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System.Collections;
using Microsoft.Xna.Framework;
using GUISharp.Constants;
using GUISharp.GUIObjects.WMath;

namespace GUISharp.Controls.Moving
{
    public partial class MoveManager : IMoveManager, IEnumerable
    {
        //-------------------------------------------------
        #region Constant's Region
        public const int NOT_FOUND = -1;
        #endregion
        //-------------------------------------------------
        #region static Properties Region
        /// <summary>
        /// get the current point of the mouse pointer.
        /// </summary>
        public static Point Point
        {
            get
            {
                var g = ThereIsGConstants.Forming.GClient;
                if (g != null)
                {
                    return g.CurrentState.Position;
                }
                return Point.Zero;
            }
        }
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public virtual bool Enabled { get; protected set; }
        public virtual bool IsShocked { get; protected set; }
        /// <summary>
        /// set this property to false if the move manager didn't work.
        /// if this property is true, it means for moving the 
        /// elements, the Left button of the mouse should be down.
        /// </summary>
        public virtual bool MustDown { get; set; } = true;
        public virtual MoveList Elements { get; protected set; }
        public virtual IMoveable Activated { get; protected set; }
        #endregion
        //-------------------------------------------------
        #region field's Region

        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        internal MoveManager()
        {
            InitializeComponent();
        }
        internal MoveManager(IMoveable moveable) : this()
        {
            Add(moveable);
        }
        #endregion
        //-------------------------------------------------
        #region Destructor's Region
        ~MoveManager()
        {
            if (Elements != null)
            {
                Elements = null;
            }
        }
        #endregion
        //-------------------------------------------------
    }
}
