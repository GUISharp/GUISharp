// WotoProvider (for GUIVoid)
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

namespace GUIVoid.WotoProvider.EventHandlers
{
    public delegate void TickHandler<T>(T sender, TickHandlerEventArgs<T> handler) where T : class;
}
