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

using GUISharp.Client;
using GUISharp.SandBox;
using GUISharp.Constants;
using GUISharp.GUIObjects.WMath;
using GUISharp.SandBox.ErrorSandBoxes;

namespace GUISharp.Controls.Elements
{
    public sealed partial class ElementManager
    {
        //-------------------------------------------------
        #region Constant's Region

        #endregion
        //-------------------------------------------------
        #region static Properties Region
        internal static GClient Father
        {
            get => ThereIsGConstants.Forming.GClient;
        }
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public ElementList<GraphicElement> VeryLowElements { get; private set; }
        public ElementList<GraphicElement> LowElements { get; private set; }
        public ElementList<GraphicElement> NormalElements { get; private set; }
        public ElementList<GraphicElement> HighElements { get; private set; }
        public ElementList<GraphicElement> VeryHighElements { get; private set; }
        public ElementList<GraphicElement> SuperHighElements { get; private set; }
        public ElementList<GraphicElement> BeyondHighElements { get; private set; }
        public ElementList<GraphicElement> TopMostElements { get; private set; }
        public ListW<ElementList<GraphicElement>> Elements { get; private set; }
        public ElementList<SandBoxElement> LowSandBoxes { get; private set; }
        public ElementList<SandBoxElement> TopMostSandBoxes { get; private set; }
        public ErrorSandBox LowErrorSandBox { get; private set; }
        public ErrorSandBox TopMostErrorSandBox { get; private set; }
        public GraphicElement Owner { get; }
        /// <summary>
        /// if this manager has a <see cref="GraphicElement"/> Owner,
        /// I mean <see cref="Owner"/>, then,
        /// it cannot have error sandboxes.
        /// </summary>
        public bool HasOwner { get; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public ElementManager()
        {
            HasOwner = false;
            InitializeComponent();
        }
        public ElementManager(GraphicElement _owner_)
        {
            Owner = _owner_;
            HasOwner = true;
            InitializeComponent();
        }
        #endregion
        //-------------------------------------------------
        #region Special Method's Region
#if MOUSE

        public void OnMouseEnter()
        {

        }
#endif
        #endregion
        //-------------------------------------------------
    }
}
