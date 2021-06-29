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

namespace GUISharp.Client
{
    /// <summary>
    /// Provide the types of the internal requests
    /// between Universe and GClient.
    /// </summary>
    internal enum RequestType
    {
        /// <summary>
        /// it means there is no request here
        /// and all requests are done.
        /// </summary>
        None = 0,
        /// <summary>
        /// the request for acitvating the holy planet of woto.
        /// </summary>
        Activate = 1,
    }
}
