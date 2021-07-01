// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

#if __WINDOWS__

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

#endif //__WINDOWS__