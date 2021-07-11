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
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FontStashSharp;
using GUISharp.WotoProvider.Enums;
using GUISharp.Logging;
using GUISharp.SandBox;
using GUISharp.Security;
using GUISharp.Constants;
using GUISharp.Controls.Moving;
using GUISharp.GUIObjects.Graphics;
using GUISharp.GUIObjects.Resources;
using M_Manager = GUISharp.Controls.Moving.MoveManager;

namespace GUISharp.Controls.Elements
{
	partial class GraphicElement
	{
		//-------------------------------------------------
		#region Designing Region
		/// <summary>
		/// Initialize the components of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		private void InitializeComponent()
		{
			//----------------------------------
			//News:
			//----------------------------------
			//Names:
			//TabIndexes
			//FontAndTextAligns:
			//Sizes:
			//Locations:
			//Colors:
			//ComboBoxes:
			//Enableds:
			//Texts:
			//AddRanges:
			//ToolTipSettings:
			//----------------------------------
			//Events:
			//----------------------------------
		}
		#endregion
		//-------------------------------------------------
		#region ordinary Methods Region
		/// <summary>
		/// Apply the element, so the element draw itself.
		/// you should call this method only once and only at the start.
		/// </summary>
		public virtual void Apply()
		{
			if (!this.IsApplied)
			{
				this.IsApplied = true;
			}
		}
		/// <summary>
		/// Dispose the elements,
		/// this method will release all the resources used
		/// by the element, so use it carefully!
		/// </summary>
		public virtual void Dispose()
		{
			if (!this.IsDisposed)
			{
				this.IsDisposed = true;
			}
		}
		/// <summary>
		/// Disable the element,
		/// this method will set the <see cref="Enabled"/> property 
		/// to <c>false</c>.
		/// if you want to enable the element, use <see cref="Enable()"/> method.
		/// </summary>
		public virtual void Disable()
		{
			if (this.Enabled)
			{
				this.Enabled = false;
			}
			this.Manager?.DisableAll();
		}
		/// <summary>
		/// Enable the element.
		/// If the element is already enabled, this method
		/// won't ignore `Manager.EnableAll()`.
		/// It will call `Manager.EnableAll()` even if this
		/// element is already enabled.
		/// But if the element is disposed, this method won't
		/// do anything. It won't call `Manager.EnableAll()` at all.
		/// </summary>
		public virtual void Enable()
		{
			if (this.IsDisposed)
			{
				return;
			}
			if (!this.Enabled)
			{
				this.Enabled = true;
			}
			this.Manager?.EnableAll();
		}
		/// <summary>
		/// Unstable the element,
		/// this method will set the <see cref="IsStable"/> property 
		/// to <c>false</c>.
		/// if you want to make the element stable,
		/// use <see cref="Stable()"/> method.
		/// </summary>
		public virtual void Unstable()
		{
			if (this.IsStable)
			{
				this.IsStable = false;
			}
		}
		/// <summary>
		/// Make the element a stable element.
		/// </summary>
		public virtual void Stable()
		{
			if (this.IsStable || this.IsDisposed)
			{
				return;
			}
			this.IsStable = true;
		}
		
		/// <summary>
		/// Enable the element.
		/// If the element is already enabled, this method
		/// won't ignore `Manager.EnableAll()`.
		/// It will call `Manager.EnableAll()` even if this
		/// element is already enabled.
		/// But if the element is disposed, this method won't
		/// do anything. It won't call `Manager.EnableAll()` at all.
		/// </summary>
		/// <param name="childs">
		/// set it to true if you want this method to enable all
		/// children of this elemenet as well (if any exist).
		/// </param>
		public virtual void Enable(bool childs)
		{
			if (this.IsDisposed)
			{
				return;
			}
			if (!this.Enabled)
			{
				this.Enabled = true;
			}
			if (childs) 
			{
				this.Manager?.EnableAll();
			}
		}
		/// <summary>
		/// Enable the owner mover. <code></code>
		/// NOTICE: if you enable the <see cref="OwnerMover"/>,
		/// then it doesn't matter what is the <see cref="Movements"/> 
		/// of this element, the element will shock it's owner
		/// (if the owner is not null).
		/// Please take note that if this element is disposed,
		/// then this method will do nothing.
		/// </summary>
		public virtual void EnableOwnerMover()
		{
			if (this.IsDisposed) 
			{
				return;
			}
			if (!this.OwnerMover)
			{
				this.OwnerMover = true;
			}
		}
		/// <summary>
		/// Disable the owner mover.
		/// this method will set the property 
		/// <see cref="OwnerMover"/> to <c>false</c>.
		/// </summary>
		public virtual void DisableOwnerMover()
		{
			if (this.IsDisposed)
			{
				return;
			}
			if (this.OwnerMover)
			{
				this.OwnerMover = false;
			}
		}
		/// <summary>
		/// Show the element.
		/// If this element is disposed, this method
		/// will do nothing.
		/// </summary>
		public virtual void Show()
		{
			if (this.IsDisposed)
			{
				return;
			}
			if (!this.Visible)
			{
				this.Visible = true;
			}
		}
		/// <summary>
		/// Hide the element.
		/// </summary>
		public virtual void Hide()
		{
			if (this.Visible)
			{
				this.Visible = false;
			}
		}
		/// <summary>
		/// make the element barren, so it cannot have any
		/// child.
		/// it makes the element light so you can use it 
		/// better.
		/// WARNING: if this element has childs, this method will get rid of them.
		/// and barrening the element has no returning, so you won't be able to
		/// reverse it after barrening the element.
		/// </summary>
		public virtual void Barren()
		{
			// please don't check `if (this.IsDisposed)` here,
			// because there is possibility that a user
			// wants to make this element barren after
			// disposing it.
			// it won't do any hurt, but it's useless at this
			// point. so let it be. all the childern will be
			// disposen at this point (of course if they exist
			// in the first place).
			if (!this.IsBarren)
			{
				this.Manager?.DisposeAll();
				this.Manager = null;
			}
		}
		/// <summary>
		/// Shock the <see cref="MoveManager"/> of the element.
		/// If this element is disposed or is hidden, this method
		/// won't do anything.
		/// </summary>
		public virtual void Shocker()
		{
			if (this.IsDisposed || !this.Visible)
			{
				return;
			}
			if (this.WasMouseIn())
			{
				if (this.OwnerMover)
				{
					if (this.HasOwner && this.Owner != null)
					{
						if (this.Owner.Movements != ElementMovements.NoMovements)
						{
							this.Owner.Shocker(this);
						}
					}
				}
				if (this.Movements != ElementMovements.NoMovements)
				{
					if (this.MoveManager != null)
					{
						if (this.MoveManager.Enabled)
						{
							this.LastPoint = M_Manager.Point.ToVector2();
							this.MoveManager?.Shocker(this);
						}
					}
				}
			}
		}

		/// <summary>
		/// Shock the <see cref="MoveManager"/> of the element and
		/// specify which child shocked it.
		/// If this element is disposed or is hidden, this method
		/// won't do anything.
		/// </summary>
		/// <param name="child">
		/// In most situations you have to send `this` for 
		/// this argument.
		/// </param>
		public virtual void Shocker(GraphicElement child)
		{
			if (this.IsDisposed || !this.Visible)
			{
				return;
			}
			if (this.WasMouseIn())
			{
				if (this.OwnerMover)
				{
					if (this.HasOwner && this.Owner != null)
					{
						if (this.Owner.Movements != ElementMovements.NoMovements)
						{
							child.LastPoint = this.LastPoint = 
								M_Manager.Point.ToVector2();
							this.Owner.Shocker(this);
						}
					}
				}
				if (this.Movements != ElementMovements.NoMovements)
				{
					if (this.MoveManager != null)
					{
						if (this.MoveManager.Enabled)
						{
							child.LastPoint = this.LastPoint = 
								M_Manager.Point.ToVector2();
							this.MoveManager?.Shocker(child);
						}
					}
				}
			}
		}
		
		/// <summary>
		/// Lock the mouse on this element, so even if we
		/// change the location of the mouse with high speed,
		/// it doesn't bug out.
		/// If the element is disposed or it's hidden,
		/// this method won't work.
		/// </summary>
		public virtual void LockMouse()
		{
			if (this.IsDisposed || !this.Visible)
			{
				return;
			}
			if (this is FlatElement f && f.HasUnallowedRepresentor())
			{
				return;
			}
			if (!this.IsMouseLocked)
			{
				this.IsMouseLocked = true;
				LockedElement = this;
			}
		}

		/// <summary>
		/// Unlock the mouse so we don't move this element
		/// according to mouse moves.
		/// </summary>
		public virtual void UnLockMouse()
		{
			// please do not check if this element is
			// already disposed or not.
			// it will cause some bugs, because it's possible
			// that we call this method after calling `Dispose` method.
			// so please take note of that.
			if (this.IsMouseLocked)
			{
				this.IsMouseLocked = false;
				LockedElement = null;
			}
		}

		/// <summary>
		/// Discharge the <see cref="MoveManager"/> of the element.
		/// </summary>
		public virtual void Discharge()
		{
			if (this.OwnerMover)
			{
				if (this.HasOwner && this.Owner != null)
				{
					if (this.Owner.Movements != ElementMovements.NoMovements)
					{
						this.Owner.Discharge();
					}
				}
			}
			if (this.Movements != ElementMovements.NoMovements)
			{
				if (this.MoveManager != null)
				{
					if (this.MoveManager.Enabled)
					{
						if (this.MoveManager.IsShocked)
						{
							this.MoveManager.Discharge(this);
						}
					}
				}
			}
		}
		/// <summary>
		/// Move the element with the specified parameters.
		/// </summary>
		/// <param name="divergeX">
		/// x diverge of the element.
		/// </param>
		/// <param name="divergeY">
		/// y diverge of the element.
		/// </param>
		public virtual void MoveMe(float divergeX, float divergeY)
		{
			if (this.Movements != ElementMovements.NoMovements)
			{
				Vector2 pos;
				if (this.HasOwner)
				{
					pos = this.RealPosition;
				}
				else
				{
					pos = this.Position;
				}
				switch (this.Movements)
				{
					case ElementMovements.NoMovements:
						return;
					case ElementMovements.VerticalMovements:
						real().ChangeLocation(pos.X, pos.Y + divergeY);
						break;
					case ElementMovements.HorizontalMovements:
						real().ChangeLocation(pos.X + divergeX, pos.Y);
						break;
					case ElementMovements.VerticalHorizontalMovements:
						real().ChangeLocation(pos.X + divergeX, pos.Y + divergeY);
						break;
					default:
						break;
				}
				this.LastPoint = M_Manager.Point.ToVector2();
			}
			GraphicElement real()
			{
				if (this is FlatElement f)
				{
					if (f.Representor != null)
					{
						return f.Representor;
					}
				}
				return this;
			}
		}
		/// <summary>
		/// Move the element and call 
		/// the <see cref="MoveMe(float, float)"/> method
		/// with the automatic value.
		/// </summary>
		public virtual void MoveMe()
		{
			if (this.Movements != ElementMovements.NoMovements)
			{
				var current = M_Manager.Point;
				var last = this.LastPoint;
				switch (this.Movements)
				{
					case ElementMovements.NoMovements:
						return;
					case ElementMovements.VerticalMovements:
						this.MoveMe(BASE_INDEX, current.Y - last.Y);
						break;
					case ElementMovements.HorizontalMovements:
						this.MoveMe(current.X - last.X, BASE_INDEX);
						break;
					case ElementMovements.VerticalHorizontalMovements:
						this.MoveMe(current.X - last.X, current.Y - last.Y);
						break;
					default:
						break;
				}
				this.LastPoint = current.ToVector2();
			}
		}

		/// <summary>
		/// call this in the game client,
		/// when the mouse moved.
		/// </summary>
		internal virtual void MouseChange()
		{
			if (!this.Enabled || !this.Visible)
			{
				return;
			}
			// check if the mouse only is in the region of this element or not.
			if (!this.MouseHere() && this.MouseIn())
			{
				this.Manager?.MouseChange();
			}
			else
			{
				var locked = this.IsMouseLocked;
				// check if the mouse currently is in the region or not.
				if (this.MouseIn() || locked)
				{
					// check if mouse was in the region in previous update
					// or not.
					if (this.IsMouseIn || locked)
					{
						// it means in the previous update, the mouse pointer
						// was in the region, and now it's also in the region.
						// <----------->
						// check we should raise the mouse move event or not.
						this._checkMouseMove();
						// check we should raise the mouse click event or not.
						this._checkClick();
					}
					else
					{
						// it means the mouse pointer was not in the region of this 
						// graphic element, but now it is in the region.
						// so you should set the property and rase the mouse enter event.
						this.IsMouseIn = true;
						this.OnMouseEnter();
					}
				}
				else
				{
					// it means the mouse pointer currenty is not in the
					// region of this graphic element.
					// check if the mouse pointer was in the region of this 
					// graphic element in the previous update or not.
					if (this.IsMouseIn)
					{
						// it means the mouse pointer was in the region of this
						// graphic element, but it's not.
						// what do you think about it??
						// what does it mean??
						// of course it means that the mouse pointer leaves the
						// region of the graphic element,
						// so you should raise the mouse leave event and
						// also set the IsMouseIn property to false.
						this.IsMouseIn = false;
						this.OnMouseLeave();
						// invalid the current status.
						this.invalidOnce();
					}
					else
					{
						// impossible to reach here!
						// if you reach here, it means some mistakes have been
						// taken.
						// anyway, just in case I will add return here.
						return;
					}
				}
			}

		}

		/// <summary>
		/// rendering the image rectangle by enum 
		/// <see cref="ImageSizeMode"/>.
		/// </summary>
		protected virtual void ImageSizeModeRender()
		{
			; // do nothing here.
		}

		/// <summary>
		/// Raises the <see cref="LeftClick"/> event.
		/// </summary>
		/// <!--
		/// WARNING:
		///		Do NOT use Task.Run for this method!
		///		I've already used it for rasing the event handler in
		///		the method, so you should NOT use it for call this method!
		/// -->
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual void OnLeftClick()
		{
			var sender = GetSender();
			this.LeftClick?.Invoke(sender, EventArgs.Empty);
			this.Click?.Invoke(sender, EventArgs.Empty);
			if (this.LeftClickAsync != null)
			{
				Task.Run(() =>
				{
					// raise the event in another thread.
					this.LeftClickAsync.Invoke(sender, EventArgs.Empty);
				});
			}
			if (this.ClickAsync != null)
			{
				Task.Run(() =>
				{
					// raise the event in another thread.
					this.ClickAsync.Invoke(sender, EventArgs.Empty);
				});
			}
			if (!this.IsStable)
			{
				this.Disable();
			}
		}
		/// <summary>
		/// Raises the <see cref="RightClick"/> event.
		/// </summary>
		/// <!--
		/// WARNING:
		///		Do NOT use Task.Run for this method!
		///		I've already used it for rasing the event handler in
		///		the method, so you should NOT use it for call this method!
		/// -->
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual void OnRightClick()
		{
			var sender = GetSender();
			this.RightClick?.Invoke(sender, EventArgs.Empty);
			this.Click?.Invoke(sender, EventArgs.Empty);
			if (this.RightClickAsync != null)
			{
				Task.Run(() =>
				{
					// raise the event in another thread.
					this.RightClickAsync.Invoke(sender, EventArgs.Empty);
				});
			}
			if (this.ClickAsync != null)
			{
				Task.Run(() =>
				{
					// raise the event in another thread.
					this.ClickAsync.Invoke(sender, EventArgs.Empty);
				});
			}
		}
		/// <summary>
		/// Raises the <see cref="MouseEnter"/> event.
		/// </summary>
		/// <!--
		/// WARNING:
		///		Do NOT use Task.Run for this method!
		///		I've already used it for rasing the event handler in
		///		the method, so you should NOT use it for call this method!
		/// -->
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual void OnMouseEnter()
		{
			var sender = GetSender();
			this.MouseEnter?.Invoke(sender, EventArgs.Empty);
			if (this.MouseEnterAsync != null)
			{
				Task.Run((() =>
				{
					// raise the event in another thread.
					this.MouseEnterAsync.Invoke(sender, EventArgs.Empty);
				}));
			}
		}
		/// <summary>
		/// Raises the <see cref="MouseLeave"/> event.
		/// </summary>
		/// <!--
		/// WARNING:
		///		Do NOT use Task.Run for this method!
		///		I've already used it for rasing the event handler in
		///		the method, so you should NOT use it for call this method!
		/// -->
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual void OnMouseLeave()
		{
			var sender = GetSender();
			this.MouseLeave?.Invoke(sender, EventArgs.Empty);
			if (this.MouseLeaveAsync != null)
			{
				Task.Run((() =>
				{
					// raise the event in another thread.
					this.MouseLeaveAsync.Invoke(sender, EventArgs.Empty);
				}));
			}
		}
		/// <summary>
		/// Raises the <see cref="LeftDown"/> event.
		/// </summary>
		/// <!--
		/// WARNING:
		///		Do NOT use Task.Run for this method!
		///		I've already used it for rasing the event handler in
		///		the method, so you should NOT use it for call this method!
		/// -->
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual void OnLeftDown()
		{
			if (BigFather.InputElement != this)
			{
				if (this != BigFather.InputElement && this.IsBarren)
				{
					if (this is FlatElement flat)
					{
						if (flat.Representor != BigFather.InputElement)
						{
							BigFather.DeactiveInputable();
						}
					}
				}
			}
			// lock the mouse, so even if user changes
			// its mouse location with speed of light,
			// we change the location of this element.
			this.LockMouse();
			// Do NOT Shock the element in another thread.
			// the shocking operation should be done in the current
			// thread.
			this.Shocker();
			var sender = GetSender();
			this.LeftDown?.Invoke(sender, EventArgs.Empty);
			if (this.LeftDownAsync != null)
			{
				Task.Run((() =>
				{
					// raise the event in another thread.
					this.LeftDownAsync.Invoke(sender, EventArgs.Empty);
				}));
			}
		}
		/// <summary>
		/// Raises the <see cref="LeftUp"/> event.
		/// </summary>
		/// <!--
		/// WARNING:
		///		Do NOT use Task.Run for this method!
		///		I've already used it for rasing the event handler in
		///		the method, so you should NOT use it for call this method!
		/// -->
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual void OnLeftUp()
		{
			// please unlock the mouse when user release
			// it's mouse, thanks; but if you don't 
			// unlock it, another graphic elements won't
			// trigger their own events like MouseEnter,
			// MouseDown, etc...
			this.UnLockMouse();
			// discharge the element in another thread.
			this.Discharge();
			var sender = GetSender();
			this.LeftUp?.Invoke(sender, EventArgs.Empty);
			if (this.LeftUpAsync != null)
			{
				Task.Run((() =>
				{
					// raise the event in another thread.
					this.LeftUpAsync.Invoke(sender, EventArgs.Empty);
				}));
			}
		}
		/// <summary>
		/// Raises the <see cref="RightDown"/> event.
		/// </summary>
		/// <!--
		/// WARNING:
		///		Do NOT use Task.Run for this method!
		///		I've already used it for rasing the event handler in
		///		the method, so you should NOT use it for call this method!
		/// -->
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual void OnRightDown()
		{
			if (BigFather.InputElement != this)
			{
				if (this != BigFather.InputElement && this.IsBarren)
				{
					if (this is FlatElement flat)
					{
						if (flat.Representor != BigFather.InputElement)
						{
							BigFather.DeactiveInputable();
						}
					}
				}
			}
			var sender = GetSender();
			this.RightDown?.Invoke(sender, EventArgs.Empty);
			if (this.RightDownAsync != null)
			{
				Task.Run((() =>
				{
					// raise the event in another thread.
					this.RightDownAsync.Invoke(sender, EventArgs.Empty);
				}));
			}
		}
		/// <summary>
		/// Raises the <see cref="RightUp"/> event.
		/// </summary>
		/// <!--
		/// WARNING:
		///		Do NOT use Task.Run for this method!
		///		I've already used it for rasing the event handler in
		///		the method, so you should NOT use it for call this method!
		/// -->
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual void OnRightUp()
		{
			var sender = GetSender();
			this.RightUp?.Invoke(sender, EventArgs.Empty);
			if (this.RightUpAsync != null)
			{
				Task.Run((() =>
				{
					// raise the event in another thread.
					this.RightUpAsync.Invoke(sender, EventArgs.Empty);
				}));
			}
		}
		/// <summary>
		/// Raises the <see cref="MouseMove"/> event.
		/// </summary>
		/// <!--
		/// WARNING:
		///		Do NOT use Task.Run for this method!
		///		I've already used it for rasing the event handler in
		///		the method, so you should NOT use it for call this method!
		/// -->
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected internal virtual void OnMouseMove()
		{
			var sender = GetSender();
			this.MouseMove?.Invoke(sender, EventArgs.Empty);
			if (this.MouseMoveAsync != null)
			{
				Task.Run((() =>
				{
					// raise the event in another thread.
					this.MouseMoveAsync.Invoke(sender, EventArgs.Empty);
				}));
			}
		}
		
		private GraphicElement GetSender()
		{
			if (this is FlatElement f)
			{
				if (f.Representor != null)
				{
					return f.Representor;
				}
			}
			return this;
		}
		/// <summary>
		/// check for mouse move.
		/// </summary>
		private void _checkMouseMove()
		{
			var p1 = BigFather.CurrentState.Position;
			var p2 = BigFather.LastMouseState.Position;
			if (p1 != p2)
			{
				this.OnMouseMove();
			}
		}
		/// <summary>
		/// check for mouse click.
		/// </summary>
		private void _checkClick()
		{
			this._checkLeftDown();
			this._checkRightDown();
			// this._checkLeftClick(); moved to _checkLeftDown
			// this._checkRightClick();
		}
		/// <summary>
		/// check for left click.
		/// </summary>
		private void _checkLeftClick()
		{
			if (this.LeftDownOnce)
			{
				if (!this.IsLeftDown || !BigFather.IsLeftDown)
				{
					this.LeftDownOnce = false;
					var _p1 = BigFather.PreviousLeftDownPoint;
					var _p2 = BigFather.CurrentState.Position;
					if (_p1 == null)
					{
						return;
					}
					var _p3 = (_p1.Value - _p2).Abs();
					if (_p3.X < DivergeVector.X || _p3.Y < DivergeVector.Y)
					{
						// it means the left button of the mouse was clicked.
						this.OnLeftClick();
					}
				}
			}
		}
		/// <summary>
		/// check for right click.
		/// </summary>
		private void _checkRightClick()
		{
			if (this.RightDownOnce)
			{
				if (!this.IsRightDown)
				{
					this.RightDownOnce = false;
					var _p1 = BigFather.PreviousRightDownPoint;
					var _p2 = BigFather.CurrentState.Position;
					if (_p1 == null)
					{
						this.invalidOnce();
						return;
					}
					var _p3 = (_p1.Value - _p2).Abs();
					if (_p3.X < DivergeVector.X || _p3.Y < DivergeVector.Y)
					{
						// it means the left button of the mouse was clicked.
						this.OnRightClick();
					}
				}
			}
		}
		/// <summary>
		/// check for left down.
		/// </summary>
		private void _checkLeftDown()
		{
			if (BigFather.IsLeftDown && !this.IsLeftDown)
			{
				var _p = BigFather.LeftDownPoint;
				if (_p == null)
				{
					return;
				}
				if (_p != null && !this.Rectangle.Contains(_p.Value))
				{
					this.invalidOnce();
					return;
				}
				this.IsLeftDown = true;
				this.LeftDownOnce = true;
				this.OnLeftDown();
				return;
			}
			if (this.IsLeftDown)
			{
				if (!BigFather.IsLeftDown)
				{
					this.IsLeftDown = false;
					this.OnLeftUp();
					this._checkLeftClick();
				}
			}
		}
		/// <summary>
		/// check for right down.
		/// </summary>
		private void _checkRightDown()
		{
			if (BigFather.IsRightDown && !this.IsRightDown)
			{
				var _p = BigFather.RightDownPoint;
				if (_p == null)
				{
					return;
				}
				// check if the rectangle of this element contains current
				// point or not.
				if (!this.Rectangle.Contains(_p.Value))
				{
					return;
				}
				this.IsRightDown = true;
				this.RightDownOnce = true;
				this.OnRightDown();
				return;
			}
			if (this.IsRightDown)
			{
				if (!BigFather.IsRightDown)
				{
					this.IsRightDown = false;
					this.OnRightUp();
					this._checkRightClick();
				}
			}
		}
		/// <summary>
		/// invalid the current status.
		/// </summary>
		private void invalidOnce()
		{
			if (this.LeftDownOnce)
			{
				this.LeftDownOnce = false;
			}
			if (this.RightDownOnce)
			{
				this.RightDownOnce = false;
			}
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		/// <summary>
		/// check if the current mouse state of 
		/// the <see cref="BigFather"/> is in the region 
		/// of this element or not.
		/// </summary>
		/// <returns>true if it is in the region, 
		/// otherwise false.</returns>
		public virtual bool MouseIn()
		{
			bool inChild = false, me;
			if (this.Manager != null)
			{
				inChild = this.Manager.MouseContains();
			}
			me = this.Rectangle.Contains(BigFather.CurrentState.Position);
			return inChild || me;
		}
		public virtual bool WasMouseIn()
		{
			if (!this.Visible || !this.Enabled || !this.IsApplied || 
				this.IsDisposed)
			{
				return false;
			}
			return this.IsMouseIn || this.MouseIn();
		}
		public virtual bool ContainsChild(IMoveable moveable)
		{
			if (moveable == this)
			{
				return true;
			}
			if (this.Manager != null)
			{
				if (moveable is GraphicElement _e)
				{
					return this.Manager.ContainsChild(_e);
				}
			}
			return false;
		}
		/// <summary>
		/// check if the mouse only is in the region of this element or not.
		/// </summary>
		/// <returns></returns>
		protected virtual bool MouseHere()
		{
			if (this.Manager != null)
			{
				if (this.Manager.MouseContains())
				{
					return false;
				}
			}
			return this.Rectangle.Contains(BigFather.CurrentState.Position);
		}
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		/// <summary>
		/// set the status of the element.
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="status">
		/// the status of the element.
		/// this value is unsigned.
		/// </param>
		public virtual void SetStatus(uint status)
		{
			if (this.CurrentStatus != status)
			{
				this.CurrentStatus = status;
			}
		}
		/// <summary>
		/// Set the Label.Name Property with the Constant Parameter writed
		/// in ThereIsGConstants.ResourcesNames.
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="constParam">
		/// The Constant Parameter setted in <code> ThereIsGConstants.ResourcesNames </code> 
		/// and in
		/// MainForm.MyRes.
		/// </param>
		public virtual void SetLabelName(StrongString constParam)
		{
			this.RealName = constParam;
			this.Name = this.RealName +
				ThereIsGConstants.ResourcesName.End_Res_Name;
		}
		/// <summary>
		/// This Method will set the Label.Text Property with the algorithm
		/// from MainForm.MyRes.
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual void SetLabelText()
		{
			this.SetLabelText(this.MyRes == null ? DefaultRes : this.MyRes);
		}
		/// <summary>
		/// This Method will set the Label.Text Property with the algorithm
		/// from MainForm.MyRes.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="myRes"> 
		/// The resources manager that you want to set the text from it.
		/// This method will try to extract the text from this resources
		/// manager. If <see cref="Name"/> is Empty or null, this method
		/// won't do anything.
		/// </param>
		public virtual void SetLabelText(WotoRes myRes)
		{
			if (myRes == null || StrongString.IsNullOrEmpty(this.Name))
			{
				return;
			}
			try
			{
				this.ChangeText(myRes.GetString(
					myRes.GetString(this.Name.GetValue()) +
					ThereIsGConstants.ResourcesName.Separate_Character +
					Language.ToString() + this.CurrentStatus.ToString()));
			}
			catch (Exception ex)
			{
				AppLogger.Log(ex);
			}
		}
		/// <summary>
		/// Setting the Text property to customValue.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="customValue">
		/// the custom Text.
		/// </param>
		public virtual void SetLabelText(StrongString customValue)
		{
			this.ChangeText(customValue);
		}
		/// <summary>
		/// Set the owner of this Graphic element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual void SetOwner(GraphicElement owner, bool dont_add = false)
		{
			if (owner == null || owner.IsDisposed)
			{
				return;
			}
			if (this.Manager != null)
			{
				if (this.Manager.ContainsChild(owner))
				{
					return;
				}
			}
			if (this.HasOwner)
			{
				if (this.Owner == owner)
				{
					return;
				}
				else
				{
					this.Owner.Manager.Remove(this);
				}
			}
			this.Owner = owner;
			this.FatherLocation = this.Owner;
			this.HasOwner = true;
			if (owner is SandBoxElement)
			{
				this.HasSandBoxOwner = true;
			}
			if (this.Owner.Manager != null)
			{
				if (!dont_add)
				{
					this.Owner.Manager.Add(this);
				}
			}
		}
		/// <summary>
		/// Change the size of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="size"> 
		/// The size value that should be set,
		/// which is in Point.
		/// </param>
		public virtual void ChangeSize(Point size)
		{
			this.Rectangle = new Rectangle(this.Rectangle.Location, size);
		}
		/// <summary>
		/// Change the size of this element.
		/// <!--
		/// Since: GUISharp 1.0.13;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="size"> 
		/// The size value that should be set,
		/// which is in Vector2.
		/// </param>
		public virtual void ChangeSize(Vector2 size)
		{
			this.ChangeSize(size.ToPoint());
		}
		/// <summary>
		/// Change the size of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="w"> 
		/// The width.
		/// </param>
		/// <param name="h"> 
		/// The height.
		/// </param>
		public virtual void ChangeSize(int w, int h)
		{
			this.ChangeSize(new Point(w, h));
		}
		/// <summary>
		/// Change the size of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="w"> 
		/// The width.
		/// </param>
		/// <param name="h"> 
		/// The height.
		/// </param>
		public virtual void ChangeSize(float w, float h)
		{
			this.ChangeSize((int)w, (int)h);
		}
		/// <summary>
		/// Change the location (position) of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="location"> 
		/// The location which is in Vector2.
		/// </param>
		public virtual void ChangeLocation(Vector2 location)
		{
			if (this.HasOwner)
			{
				this.RealPosition = location;
				this.Position = this.RealPosition + this.Owner.Position;
			}
			else
			{
				this.Position = location;
			}
			this.ChangeRectangle();
			this.Manager?.UpdateLocations();
		}
		/// <summary>
		/// Change the location (position) of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="location"> 
		/// The location which is in Point.
		/// </param>
		public virtual void ChangeLocation(Point location)
		{
			this.ChangeLocation(location.ToVector2());
		}
		/// <summary>
		/// Change the location of this graphic element
		/// to the specified float coordinates.
		/// This method is currently safe to use and has no problem
		/// at all.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual void ChangeLocation(float x, float y)
		{
			if (this.HasOwner)
			{
				this.RealPosition = new(x, y);
				this.Position = this.RealPosition + this.Owner.Position;
			}
			else
			{
				this.Position = new(x, y);
			}
			this.ChangeRectangle();
			this.Manager?.UpdateLocations();
			// I don't know why the fuck this is happening here,
			// maybe it's C#'s bug? Or maybe I've done something
			// wrong for it...
			// but it will bug out!
			// please do NOT change the code here and do NOT
			// call another method here.
			// if you conver x and y to a Vector2 and then
			// call another ChangeLocation method here, it will bug out.
			// Still I don't know why or how!
			// it's really weird, that's why I'm writing this 
			// note here to redo the debuging again and find out
			// why the fuck this is happening here.
			// for now, the code below works, so don't change it
			// and let it be like this.
			// BY: ALiwoto;
			// In: 28 Jun 2021; 16:35 UTC;
			//this.ChangeLocation(new Vector2(X, y));
		}
		/// <summary>
		/// Change the location (position) of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="x"> 
		/// The new x-coordinate which is an int.
		/// </param>
		/// <param name="y"> 
		/// The new y-coordinate which is an int.
		/// </param>
		public virtual void ChangeLocation(int x, int y)
		{
			this.ChangeLocation(new Vector2(x, y));
		}
		/// <summary>
		/// Call this method when the owner of this element has changed
		/// its position (location).
		/// Usage of this method is mostly internal, but I made it public
		/// just-in-case. Please don't call it if you don't know what
		/// is going on.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual void OwnerLocationUpdate()
		{
			if (this.HasOwner && this.Owner != null)
			{
				this.Position = this.Owner.Position + this.RealPosition;
				this.ChangeRectangle();
			}
		}
		/// <summary>
		/// change the priority of this very <see cref="GraphicElement"/>, 
		/// so it can be added in the right place of the manager.
		/// if this element has an owner, and if the <see cref="Manager"/> 
		/// of it's owner is not null, then it will remove itself
		/// from the manager (before changing the priority),
		/// and then it will change it's priority,
		/// after that, it will add itself to the manager 
		/// (if the add boolean is set to <c>true</c>).
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="priority">
		/// the new priority of this element.
		/// </param>
		/// <param name="add">
		/// if you want to add this element to it's owner's manager, set this arg to 
		/// <c>true</c>, but please notice that if this element has no owner, 
		/// this element will add itself to the <see cref="BigFather"/>'s manager.
		/// but if you don't want this element add itself to any manager, then
		/// set this arg to false. the default value of this arg (as you can see) is
		/// <c>false</c>.
		/// </param>
		public virtual void ChangePriority(ElementPriority priority, 
											in bool add = false)
		{
			if (this.Priority != priority)
			{
				if (this.HasOwner && this.Owner != null)
				{
					this.Owner.Manager?.Remove(this);
					this.Priority = priority;
					if (add)
					{
						this.Owner.Manager?.Add(this);
					}
				}
				else
				{
					// check if the static property,
					// BigFather, is null or not.
					// NOTICE: the BigFather will never be null,
					// but I add this if just-in-case.
					if (BigFather != null)
					{
						BigFather.ElementManager?.Remove(this);
						this.Priority = priority;
						if (add)
						{
							BigFather.ElementManager?.Add(this);
						}
					}
				}
			}
		}
		/// <summary>
		/// change the <see cref="ElementMovements"/> of this 
		/// <see cref="GraphicElement"/>.
		/// this method will set the <see cref="Movements"/> property of this
		/// element and will add this element to the passed-by second arg.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="movements">
		/// the movement of this element.
		/// </param>
		/// <param name="manager">
		/// if this value is null, 
		/// and is the <see cref="MoveManager"/> of this element is not null,
		/// we will remove the element from the manager.
		/// </param>
		public virtual void ChangeMovements(ElementMovements movements,
			IMoveManager manager)
		{
			if (manager == null)
			{
				if (this.MoveManager == null)
				{
					this.MoveManager = new MoveManager(this);
					setMovements();
				}
				else
				{
					this.MoveManager?.Remove(this);
					this.Movements = ElementMovements.NoMovements;
				}
				return;
			}
			if (this.MoveManager != manager)
			{
				this.MoveManager?.Remove(this);
				manager.AddMe(this);
				this.MoveManager = manager;
			}
			setMovements();
			return;
			void setMovements()
			{
				if (this.Movements != movements)
				{
					this.Movements = movements;
				}
			}
		}
		/// <summary>
		/// change the fucking movements of this very fucking 
		/// <see cref="GraphicElement"/>, so it can be moved easily
		/// (very very fucking easily) by the user.
		/// You don't need to do anything else in order to change
		/// the movements of this elemenet.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="movements"></param>
		public virtual void ChangeMovements(ElementMovements movements)
		{
			if (movements == ElementMovements.NoMovements)
			{
				if (this.Movements != movements)
				{
					this.Movements = movements;
					return;
				}
			}
			this.ChangeMovements(movements, this.MoveManager);
		}
		/// <summary>
		/// Change the font of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="font"> 
		/// The new font which has to be set. 
		/// It should be a <see cref="SpriteFontBase"/>.
		/// </param>
		public abstract void ChangeFont(SpriteFontBase font);
		/// <summary>
		/// Change the fore color of this element.
		/// This element will use the new color to draw
		/// texts.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="color"> 
		/// The new color.
		/// </param>
		public virtual void ChangeForeColor(Color color)
		{
			if (this.ForeColor != color)
			{
				this.ForeColor = color;
			}
		}
		/// <summary>
		/// Change the background color of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="color"> 
		/// The new background color of this element.
		/// </param>
		public virtual void ChangeBackColor(Color color)
		{
			if (this.BackGroundColor != color)
			{
				this.BackGroundColor = color;
			}
			this.BackGroundImage = this.GetBackGroundTexture(color);
		}
		/// <summary>
		/// Change the tint color of this element.
		/// <!--
		/// Since: GUISharp 1.0.31;
		/// By: ALiwoto;
		/// Last edit: 5 July 14:41;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="color"> 
		/// The new background color of this element.
		/// </param>
		public virtual void ChangeTint(Color color)
		{
			this.Tint = color;
		}
		/// <summary>
		/// Change the background tint color of this element.
		/// <!--
		/// Since: GUISharp 1.0.31;
		/// By: ALiwoto;
		/// Last edit: 5 July 14:41;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="color"> 
		/// The new background color of this element.
		/// </param>
		public virtual void ChangeBackTint(Color color)
		{
			this.BackTint = color;
		}
		/// <summary>
		/// Change the image of this element.
		/// This method will use <c>this.MyRes</c> if and
		/// only if it's not null, otherwise it will use default
		/// resources manager of this library.
		/// You don't have direct access to default resources manager,
		/// because it is internal.
		/// <!--
		/// Since: GUISharp 1.0.14;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual void ChangeImage()
		{
			this.ChangeImage(this.MyRes == null ? DefaultRes : this.MyRes);
		}
		/// <summary>
		/// Change the image of this element.
		/// This method will use <c>Content</c> if and
		/// only if it's not null, otherwise it will use default
		/// resources manager of this library.
		/// You don't have direct access to default resources manager,
		/// because it is internal.
		/// <!--
		/// Since: GUISharp 1.0.14;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual void ChangeImageContent()
		{
			this.ChangeImageContent(this.MyRes == null ? DefaultRes : this.MyRes);
		}
		/// <summary>
		/// Change the image of this graphic element, with using 
		/// the <see cref="Name"/> property of this graphic element,
		/// which already exists in the specified Woto Resources Manager.
		/// If you would like to change the image of this graphic element
		/// using a custom image from somewhere else, then please
		/// use <see cref="ChangeImage(Texture2D)"/>  instead of this method.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="myRes"> 
		/// The Woto Resources Manager which should not be null and 
		/// should contains an image with the <see cref="Name"/> 
		/// property of this graphic element, it.
		/// if not, this method won't do anything (it won't throw any
		/// exception.)
		/// </param>
		public virtual void ChangeImage(WotoRes myRes)
		{
			this.ChangeImage(myRes, this.Name);
		}
		/// <summary>
		/// Change the image of this graphic element, with using 
		/// the <see cref="Name"/> property of this graphic element,
		/// which already exists in the specified Woto Resources Manager.
		/// If you would like to change the image of this graphic element
		/// using a custom image from somewhere else, then please
		/// use <see cref="ChangeImage(Texture2D)"/>  instead of this method.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="myRes"> 
		/// The Woto Resources Manager which should not be null and 
		/// should contains an image with the <see cref="Name"/> 
		/// property of this graphic element, it.
		/// if not, this method won't do anything (it won't throw any
		/// exception.)
		/// </param>
		public virtual void ChangeImageContent(WotoRes myRes)
		{
			this.ChangeImageContent(myRes, this.Name);
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the specified Woto Resources Manager.
		/// If you would like to change the image of this graphic element
		/// using a custom image from somewhere else, then please
		/// use <see cref="ChangeImage(Texture2D)"/>  instead of this method.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="myRes"> 
		/// The Woto Resources Manager which should not be null and 
		/// should contains an image with the specified name in it.
		/// if not, this method won't do anything (it won't throw any
		/// exception.)
		/// </param>
		/// <param name="name">
		/// The name of the Image which should have <see cref="PIC_RES"/>
		/// suffix to it.
		/// </param>
		/// <param name="parse">
		/// pass false for this argument if you don't want this method to appened
		/// <see cref="PIC_RES"/> suffix to the name.
		/// </param>
		public virtual void ChangeImage(WotoRes myRes, StrongString name,
			bool parse = true)
		{
			if (myRes == null || StrongString.IsNullOrEmpty(name))
			{
				return;
			}
			try
			{
				if (parse)
				{
					// be careful!
					// this.Name is Label1_Name
					this.ChangeImage(myRes.GetAsTexture2D(
						myRes.GetString(name) + PIC_RES));
				}
				else
				{
					this.ChangeImage(myRes.GetAsTexture2D(name));
				}
			}
			catch (Exception ex)
			{
				AppLogger.Log(ex);
			}
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the specified Woto Resources Manager.
		/// If you would like to change the image of this graphic element
		/// using a custom image from somewhere else, then please
		/// use <see cref="ChangeImage(Texture2D)"/>  instead of this method.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="myRes"> 
		/// The Woto Resources Manager which should not be null and 
		/// should contains an image with the specified name in it.
		/// if not, this method won't do anything (it won't throw any
		/// exception.)
		/// </param>
		/// <param name="name">
		/// The name of the Image which should have <see cref="PIC_RES"/>
		/// suffix to it.
		/// </param>
		/// <param name="parse">
		/// pass false for this argument if you don't want this method to appened
		/// <see cref="PIC_RES"/> suffix to the name.
		/// </param>
		public virtual void ChangeImageContent(WotoRes myRes, StrongString name,
			bool parse = true)
		{
			if (myRes == null || StrongString.IsNullOrEmpty(name) || 
				Content == null)
			{
				return;
			}
			try
			{
				StrongString cname;
				if (parse)
				{
					cname = myRes.GetString(myRes.GetString(name) + PIC_RES);
					if (cname == null)
					{
						return;
					}
				}
				else
				{
					cname = myRes.GetString(name + PIC_RES);
					if (cname == null)
					{
						return;
					}
				}
				this.ChangeImage(Content.Load<Texture2D>(cname.GetValue()));
			}
			catch (Exception ex)
			{
				AppLogger.Log(ex);
			}
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the <see cref="MyRes"/> property of this
		/// graphic element.
		/// If you would like to change the image of this graphic element
		/// using a custom image from somewhere else, then please
		/// use <see cref="ChangeImage(Texture2D)"/>  instead of this method.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="name">
		/// The name of the Image which should have <see cref="PIC_RES"/>
		/// suffix to it (it should have this suffix in the resources manager,
		/// not in itself. Take note that we will add this suffix to it 
		/// in this method).
		/// </param>
		public virtual void ChangeImage(StrongString name)
		{
			this.ChangeImage(this.MyRes == null ? DefaultRes :
				this.MyRes, name);
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the <see cref="Content"/> property of this
		/// graphic element.
		/// If you would like to change the image of this graphic element
		/// using a custom image from somewhere else, then please
		/// use <see cref="ChangeImage(Texture2D)"/>  instead of this method.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="name">
		/// The name of the Image which should have <see cref="PIC_RES"/>
		/// suffix to it (it should have this suffix in the resources manager,
		/// not in itself. Take note that we will add this suffix to it 
		/// in this method).
		/// </param>
		public virtual void ChangeImageContent(StrongString name)
		{
			this.ChangeImageContent(this.MyRes == null ? DefaultRes :
				this.MyRes, name);
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the <see cref="Content"/> property of this
		/// graphic element.
		/// If you would like to change the image of this graphic element
		/// using a custom image from somewhere else, then please
		/// use <see cref="ChangeImage(Texture2D)"/>  instead of this method.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="name">
		/// The name of the Image which should have <see cref="PIC_RES"/>
		/// suffix to it (it should have this suffix in the resources manager,
		/// not in itself. Take note that we will add this suffix to it 
		/// in this method).
		/// </param>
		/// <param name="parse">
		/// pass false for this argument if you don't want this method to appened
		/// <see cref="PIC_RES"/> suffix to the name.
		/// </param>
		public virtual void ChangeImageContent(StrongString name, bool parse)
		{
			this.ChangeImageContent(this.MyRes == null ? DefaultRes :
				this.MyRes, name, parse);
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the <see cref="MyRes"/> property of this
		/// graphic element.
		/// If you would like to change the image of this graphic element
		/// using a custom image from somewhere else, then please
		/// use <see cref="ChangeImage(Texture2D)"/>  instead of this method.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="name">
		/// The name of the Image which should have <see cref="PIC_RES"/>
		/// suffix to it (it should have this suffix in the resources manager,
		/// not in itself. Take note that we will add this suffix to it 
		/// in this method).
		/// </param>
		/// <param name="parse">
		/// pass false for this argument if you don't want this method to appened
		/// <see cref="PIC_RES"/> suffix to the name.
		/// </param>
		public virtual void ChangeImage(StrongString name, bool parse)
		{
			this.ChangeImage(this.MyRes == null ? DefaultRes :
				this.MyRes, name, parse);
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the <see cref="DefaultRes"/> property of this
		/// graphic element.
		/// This method is supposed to be internal and it should remains
		/// internal, because users may have no idea what's going on here and
		/// so we have to keep it internal.
		/// The only problem that remains is that how the fuck am I
		/// supposed to accomplish some tasks in LTW-client.
		/// If you would like to change the image of this graphic element
		/// using a custom image from somewhere else, then please
		/// use <see cref="ChangeImage(Texture2D)"/>  instead of this method.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="name">
		/// The name of the Image which should have <see cref="PIC_RES"/>
		/// suffix to it (it should have this suffix in the resources manager,
		/// not in itself. Take note that we will add this suffix to it 
		/// in this method).
		/// </param>
		protected internal virtual void ChangeImageDefault(StrongString name)
		{
			this.ChangeImage(DefaultRes, name, false);
		}
		/// <summary>
		/// Change the image of this element using a texture.
		/// You can pass a null image to this method, but please 
		/// take note that this graphic element will show nothing as
		/// it's image after that.
		/// You can NOT pass a disposed image to this method, if you
		/// do so, this method will ignore it and won't do anything.
		/// So please check the <see cref="Texture2D"/> is disposed 
		/// or not.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="texture">
		/// the image texture. this value can be passed as a null value.
		/// that way, the element won't show any image.
		/// </param>
		public virtual void ChangeImage(Texture2D texture)
		{
			// just check if the texture is not disposed,
			// you don't have to check if the texture is null or not!
			if (!texture.IsDisposed)
			{
				// check if the current image is the same as the 
				// passed texture or not
				if (this.Image != texture)
				{
					// the last Image should NOT be disposed here!
					// if you are not a dumbass and wanna reduce the 
					// memory usage, you should dispose the image
					// before changing it!
					// this.Image?.Dispose();
					this.Image = texture;
					// render the rectangle of the image,
					// by specified enum parameter.
					this.ImageSizeModeRender();
				}
			}
		}
		/// <summary>
		/// Change the image size mode of this graphic element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="mode">
		/// The new iamge size mode of this element.
		/// </param>
		public virtual void ChangeImageSizeMode(ImageSizeMode mode)
		{
			if (this.ImageSizeMode != mode)
			{
				this.ImageSizeMode = mode;
				this.ImageSizeModeRender();
			}
		}
		/// <summary>
		/// Change the rectangle of this element.
		/// You can either use this method or use one of
		/// <code><see cref="ChangeLocation(int, int)"/></code>
		/// or
		/// <code><see cref="ChangeSize(int, int)"/></code>
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="rect">
		/// The new iamge size mode of this element.
		/// </param>
		public virtual void ChangeRectangle(Rectangle rect)
		{
			this.ChangeLocation(rect.Location.ToVector2());
			this.ChangeSize(rect.Size.X, rect.Size.Y);
		}
		/// <summary>
		/// Change (update) the rectangle of this element.
		/// You can either use this method or use one of
		/// <code><see cref="ChangeLocation(int, int)"/></code>
		/// or
		/// <code><see cref="ChangeSize(int, int)"/></code>
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected virtual void ChangeRectangle()
		{
			var location = new Point((int)this.Position.X, (int)this.Position.Y);
			var size = this.Rectangle.Size;
			this.Rectangle = new(location, size);
			if (this.Image != null)
			{
				this.ImageSizeModeRender();
			}
		}
		#endregion
		//-------------------------------------------------
		#region abstract Method's region
		/// <summary>
		/// Update this Graphic Element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="gameTime"></param>
		public abstract void Update(GameTime gameTime);
		/// <summary>
		/// Change the text of this graphic element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="text">
		/// the new text of this graphic element.
		/// if it's null, you won't get any exception.
		/// the text will be considered as an empty text and
		/// nothing will be displayed on the element.
		/// </param>
		public abstract void ChangeText(StrongString text);
		
		/// <summary>
		/// Get a Background <see cref="Texture2D"/> by 
		/// specified <see cref="Color"/> for this 
		/// graphic element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="color">
		/// the <see cref="Color"/> parameter.
		/// </param>
		/// <returns>
		/// A <see cref="Texture2D"/> with 
		/// the equal bound of this element.
		/// </returns>
		protected abstract Texture2D GetBackGroundTexture(Color color);
		/// <summary>
		/// Updating the graphic parameters of this element.
		/// <!--
		/// Since: GUISharp 1.0.7;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected abstract void UpdateGraphics();
		#endregion
		//------------------------------------------------
		#region Graphical Method's Elements
		/// <summary>
		/// draw the surface of this graphic element.
		/// <!--
		/// Since: GUISharp 1.0.7;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="gameTime">
		/// the <see cref="GameTime"/> of the GUISharp.
		/// </param>
		/// <param name="spriteBatch">
		/// the <see cref="SpriteWoto"/> tool 
		/// which is necessary for drawing the graphic surface.
		/// </param>
		public abstract void Draw(GameTime gameTime, SpriteWoto spriteBatch);
		#endregion
		//-------------------------------------------------
	}
}
