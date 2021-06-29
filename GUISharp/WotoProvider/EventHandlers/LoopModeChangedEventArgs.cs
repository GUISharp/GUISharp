// WotoProvider (for GUISharp)
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
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


namespace GUISharp.WotoProvider.EventHandlers
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class LoopModeChangedEventArgs : WotoEventArgs
    {
        //-------------------------------------------------
        #region Properties Region
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public bool LoopModeTurnedOn { get; set; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public LoopModeChangedEventArgs(bool loopModeTurnedOn, WotoCreation wotoCreation) : base(wotoCreation)
        {
            LoopModeTurnedOn = loopModeTurnedOn;
        }
        #endregion
        //-------------------------------------------------
    }
}
