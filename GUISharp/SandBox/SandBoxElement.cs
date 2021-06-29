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


using GUISharp.Controls;
using GUISharp.Controls.Elements;
using GUISharp.GUIObjects.Resources;

namespace GUISharp.SandBox
{
	public abstract partial class SandBoxElement : GraphicElement
	{
		//-------------------------------------------------
		#region Constant's Region

		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The Woto Resources Manager of this Sandbox.
		/// NOTICE: the sandbox elements, should have 
		/// separate <see cref="WotoRes"/>, and will not 
		/// accept passed-by values of <see cref="IRes"/>.
		/// </summary>
		public override WotoRes MyRes { get; set; }
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		public SandBoxElement() : base()
		{

		}
		#endregion
		//-------------------------------------------------
	}
}
