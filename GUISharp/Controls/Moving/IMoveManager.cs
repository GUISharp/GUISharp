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


namespace GUISharp.Controls.Moving
{
    /// <summary>
    /// represent a MoveManager interface for using as
    /// a manager of movements for a graphic element in GUISharp.
    /// </summary>
    public interface IMoveManager
    {
        //-------------------------------------------------
        #region Properties Region
        bool IsShocked { get; }
        bool Enabled { get; }
        bool MustDown { get; set; }
        IMoveable Activated { get; }
        #endregion
        //-------------------------------------------------
        #region Method's Region
        void MoveUs();
        void Enable();
        void Disable();
        void AddMe(IMoveable me);
        void Remove(IMoveable moveable);
        void Shocker(IMoveable sender);
        void Discharge(IMoveable sender);
        #endregion
        //-------------------------------------------------
    }
}
