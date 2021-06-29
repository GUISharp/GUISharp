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


using System.Drawing;

namespace GUISharp.Controls.GameGraphics
{
    public class ColorW
    {
        //-------------------------------------------------
        #region Constant's Region

        #endregion
        //-------------------------------------------------
        #region field's Region
        private Color _color;
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public ColorW(Color color)
        {
            _color = color;
        }
        #endregion
        //-------------------------------------------------
        #region Set Method's Region
        public void ChangeColor(Color color)
        {
            _color = color;
        }
        #endregion
        //-------------------------------------------------
        #region Get Method's Region
        public Color GetColor()
        {
            return _color;
        }
        #endregion
        //-------------------------------------------------
        #region static Method's Region
        public static ColorW ConvertToColorW(Color color)
        {
            return new ColorW(color);
        }
        #endregion
        //-------------------------------------------------
        #region static operator's Region
        public static implicit operator Color(ColorW v)
        {
            return v.GetColor();
        }
        #endregion
        //-------------------------------------------------
    }
}
