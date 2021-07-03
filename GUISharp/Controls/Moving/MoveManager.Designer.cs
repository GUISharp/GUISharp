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

using System;
using System.Collections;
using GUISharp.GUIObjects.WMath;
using GUISharp.Controls.Elements;

namespace GUISharp.Controls.Moving
{
    partial class MoveManager
    {
        //-------------------------------------------------
        #region Initialize Method's Region
        private void InitializeComponent()
        {
            //---------------------------------------------
            this.Elements = new(this);
            //---------------------------------------------
            //Enabled:
            this.Enable();
            //---------------------------------------------
            //---------------------------------------------
        }
        #endregion
        //-------------------------------------------------
        #region ordinary Method's Region
        public virtual void MoveUs()
        {
            foreach (var _e in this.Elements)
            {
                if (_e != null)
                {
                    if (!_e.IsDisposed && _e.Visible)
                    {
                        _e.MoveMe();
                    }
                }
            }
        }
        public virtual void Discharge(IMoveable sender)
        {
            if (this.IsShocked)
            {
                if (this.Activated != null)
                {
                    this.IsShocked = false;
                    this.Activated.MouseMove -= Activated_MouseMove;
                    this.Activated = null;
                }
            }
        }
        public virtual void Shocker(IMoveable sender)
        {
            if (sender != null && !sender.IsDisposed)
            {
                this.IsShocked = true;
                this.Activated = sender;
                this.Activated.MouseMove -= Activated_MouseMove;
                this.Activated.MouseMove += Activated_MouseMove;
            }
        }
        public virtual void AddMe(IMoveable me)
        {
            var i = this.Contains(me);
            if (i != NOT_FOUND)
            {
                this.Elements.Remove(this.Elements[i]);
            }
            this.Elements.Add(me);
        }
        public virtual void Add(IMoveable moveable)
        {
            this.AddMe(moveable);
        }
        public virtual void Remove(IMoveable moveable)
        {
            if (this.Elements.Exists(moveable))
            {
                this.Elements.Remove(moveable);
            }
        }
        public virtual void Enable()
        {
            if (!this.Enabled)
            {
                this.Enabled = true;
            }
        }
        public virtual void Disable()
        {
            if (this.Enabled)
            {
                this.Enabled = false;
            }
        }
        #endregion
        //-------------------------------------------------
        #region Get Method's Region
        public virtual int Contains(IMoveable moveable)
        {
            for (int i = 0; i < this.Elements.Length; i++)
            {
                if (this.Elements[i] != null)
                {
                    if (this.Elements[i].ContainsChild(moveable))
                    {
                        return i;
                    }
                }
            }
            return NOT_FOUND;
        }
        public IEnumerator GetEnumerator()
        {
            return this.Elements.GetEnumerator();
        }
        protected virtual bool IsCorrectSender(object sender)
		{
			if (this.Activated is FlatElement f)
			{
				if (f.Representor == sender)
				{
					return true;
				}
			}
			return this.Activated == sender;
		}
		#endregion
        //-------------------------------------------------
        #region Event Method's Region
        private void Activated_MouseMove(object sender, EventArgs e)
        {
			if (this.Activated == null || !IsCorrectSender(sender))
			{
				return;
			}
			if (this.Activated.IsDisposed || !this.Activated.Visible)
			{
				return;
			}
            if (this.Enabled && this.IsShocked)
            {
                if (this.MustDown)
                {
                    if (!GraphicElement.BigFather.IsLeftDown)
                    {
                        return;
                    }
                }
				if (GraphicElement.LockedElement != null)
				{
					if (GraphicElement.LockedElement != this.Activated)
					{
						return;
					}
				}
                this.MoveUs();
            }
        }
        #endregion
        //-------------------------------------------------
    }
}
