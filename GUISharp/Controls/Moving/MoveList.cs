// GUISharp Project
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using GUISharp.GUIObjects.WMath;

namespace GUISharp.Controls.Moving
{
    public sealed class MoveList : ListW<IMoveable>
    {
        //-------------------------------------------------
        #region Constant's Region

        #endregion
        //-------------------------------------------------
        #region Properties Region
        public MoveManager MoveManager { get; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        internal MoveList(in MoveManager _manager_)
        {
            MoveManager = _manager_;
        }
        #endregion
        //-------------------------------------------------
    }
}
