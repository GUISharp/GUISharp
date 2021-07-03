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

using Microsoft.Xna.Framework;
using GUISharp.GUIObjects.WMath;
using GUISharp.GUIObjects.Graphics;

namespace GUISharp.Controls.Elements
{
	public class ElementList<T> : ListW<T> 
		where T : GraphicElement
	{
		//-------------------------------------------------
		#region Properties Region
		public ElementManager Manager { get; }
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		internal ElementList(ElementManager _manager_)
		{
			Manager = _manager_;
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		public bool MouseIn()
		{
			for (int i = Length - 1; i >= 0; i--)
			{
				if (this[i].MouseIn())
				{
					return true;
				}
			}
			return false;
		}
		public bool WasMouseIn()
		{
			for (int i = Length - 1; i >= 0; i--)
			{
				if (this[i].WasMouseIn())
				{
					return true;
				}
			}
			return false;
		}
		public void MouseChange()
		{
			for (int i = Length - 1; i >= 0; i--)
			{
				if (this[i] != null)
				{
					if (this[i].WasMouseIn())
					{
						this[i]?.MouseChange();
						return;
					}
				}
			}
		}
		public virtual bool ContainsChild(T item)
		{
			for (int i = 0; i < Length; i++)
			{
				if (this[i] != null)
				{
					if (this[i].ContainsChild(item))
					{
						return true;
					}
				}
			}
			return false;
		}
		#endregion
		//-------------------------------------------------
		#region Ordinary Method's Region
		/// <summary>
		/// dispose all the elements in the list.
		/// </summary>
		public void DisposeAll()
		{
			for (int i = 0; i < Length; i++)
			{
				this[i]?.Dispose();
			}
		}
		/// <summary>
		/// apply all the elements in the list.
		/// </summary>
		public void ApplyAll()
		{
			for (int i = 0; i < Length; i++)
			{
				this[i]?.Apply();
			}
		}
		/// <summary>
		/// disable all the elements in the list.
		/// </summary>
		public void DisableAll()
		{
			for (int i = 0; i < Length; i++)
			{
				this[i]?.Disable();
			}
		}
		/// <summary>
		/// enable all the elements in the list.
		/// </summary>
		public void EnableAll()
		{
			for (int i = 0; i < Length; i++)
			{
				this[i]?.Enable();
			}
		}
		/// <summary>
		/// hide all the elements in the list.
		/// </summary>
		public void HideAll()
		{
			for (int i = 0; i < Length; i++)
			{
				this[i]?.Hide();
			}
		}
		/// <summary>
		/// show all the elements in the list.
		/// </summary>
		public void ShowAll()
		{
			for (int i = 0; i < Length; i++)
			{
				this[i]?.Show();
			}
		}
		#endregion
		//-------------------------------------------------
		#region Graphics Method's Region 
		public void Draw(GameTime gameTime, SpriteWoto spriteBatch)
		{
			for (int i = 0; i < Length; i++)
			{
				this[i]?.Draw(gameTime, spriteBatch);
			}
		}
		#endregion
		//-------------------------------------------------
	}
}
