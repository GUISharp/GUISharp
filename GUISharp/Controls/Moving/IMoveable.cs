// GUISharp Project
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using Microsoft.Xna.Framework;
using GUISharp.Controls.Elements;

namespace GUISharp.Controls.Moving
{
    public interface IMoveable
    {
        //-------------------------------------------------
        #region Properties Region
        bool IsDisposed { get; }
		bool Visible { get; }
        Vector2 LastPoint { get; }
        ElementMovements Movements { get; }
        IMoveManager MoveManager { get; }
        #endregion
        //-------------------------------------------------
        #region event field's Region
        event EventHandler MouseMove;
        #endregion
        //-------------------------------------------------
        #region Method's Region
        void Shocker();
        void Discharge();
        void MoveMe();
        void MoveMe(float divergeX, float divergeY);
        void ChangeLocation(Vector2 location);
        void ChangeLocation(float x, float y);
        void ChangeLocation(int x, int y);
        bool ContainsChild(IMoveable moveable);
        #endregion
        //-------------------------------------------------
    }
}
