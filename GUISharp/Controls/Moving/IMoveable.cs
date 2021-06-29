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
