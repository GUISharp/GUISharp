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

namespace GUISharp.SandBox
{
	/// <summary>
	/// The Priority of Sandboxes.
	/// which is used in <see cref="SandBoxBase.SandBoxPriority"/>
	/// </summary>
    public enum SandBoxPriority
    {
		/// <summary>
		/// represents a low priority sandbox.
		/// </summary>
        LowSandBox          = 0,
		/// <summary>
		/// a TopMost Sandbox.
		/// this sandbox is not an error type, so
		/// the Error sandboxes still can be shown on it.
		/// </summary>
        TopMostSandBox      = 1,
		/// <summary>
		/// an Error sandbox with a low priority.
		/// </summary>
        LowErrorSandBox     = 2,
		/// <summary>
		/// an error sandbox with a TopMost priority,
		/// at this rate, another activity of the game will be stopped,
		/// and game will be closed after closing this sandbox.
		/// use it for ConnectionClosedSandBox.
		/// </summary>
        TopMostErrorSandBox = 3,
    }
}
