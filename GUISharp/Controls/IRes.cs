﻿// GUISharp Project
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using GUISharp.GUIObjects.Resources;

namespace GUISharp.Controls
{
    /// <summary>
    /// Woto Resources Provider.
    /// </summary>
    public interface IRes
    {
        //-------------------------------------------------
        #region Properties Region
        /// <summary>
        /// Woto ResourceManager.
        /// </summary>
        WotoRes MyRes { get; set; }
        #endregion
        //-------------------------------------------------
    }
}
