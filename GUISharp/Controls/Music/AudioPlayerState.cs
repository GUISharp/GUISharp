// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUISharp.Controls.Music
{
    /// <summary>
    /// State of the audio player.
    /// </summary>
    public enum AudioPlayerState
    {
        /// <summary>
        /// The player is stopped (default).
        /// </summary>
        Stopped,

        /// <summary>
        /// The player is playing a sound.
        /// </summary>
        Playing,

        /// <summary>
        /// The player is paused.
        /// </summary>
        Paused,
    }
}
