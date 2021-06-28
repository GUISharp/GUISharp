﻿// WotoProvider (for GUISharp)
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

namespace GUISharp.WotoProvider.EventHandlers
{
    public class TickHandlerEventArgs<T> : WotoEventArgs
        where T : class
    {
        /// <summary>
        /// my Father.
        /// </summary>
        public T Father { get; }
        //-------------------------------------------------
        public TickHandlerEventArgs(WotoCreation creation, T fatherSender) :
            base(creation)
        {
            Father = fatherSender;
        }
        //-------------------------------------------------
    }
}
