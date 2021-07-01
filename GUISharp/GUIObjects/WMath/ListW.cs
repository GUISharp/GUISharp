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

using System.Collections.Generic;

namespace GUISharp.GUIObjects.WMath
{
    public class ListW<T> : List<T>
    {
        //-------------------------------------------------
        #region Properties Region
        public virtual int Length { get => Count; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public ListW()
        {

        }
        public ListW(IEnumerable<T> e) : base(e)
        {

        }
        public ListW(int cap) : base(cap)
        {

        }
        #endregion
        //-------------------------------------------------
        #region Get Method's Region
        public virtual bool Exists(T item)
        {
            return Contains(item);
        }
        public virtual T[] GetArray()
        {
            return ToArray();
        }
        #endregion
        //-------------------------------------------------
    }
}
