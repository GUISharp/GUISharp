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

namespace GUISharp.GUIObjects.WMath
{
    public struct Range
    {
        //-------------------------------------------------
        #region Properties Region
        public int Minimum { get; }
        public int Maximum { get; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public Range(int minimum, int maximum)
        {
            if (minimum > maximum)
            {
                Maximum = minimum;
                Minimum = maximum;
            }
            else
            {

                Minimum = minimum;
                Maximum = maximum;
            }
        }
        public Range(float minimum, float maximum) : this((int)minimum, (int)maximum)
        {
            // ;
        }
        #endregion
        //-------------------------------------------------
    }
}
