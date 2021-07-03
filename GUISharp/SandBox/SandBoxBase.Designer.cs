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
using Microsoft.Xna.Framework.Graphics;
using FontStashSharp;
using GUISharp.Security;
using GUISharp.Controls.Moving;
using GUISharp.Controls.Elements;
using GUISharp.GUIObjects.Graphics;

namespace GUISharp.SandBox
{
	partial class SandBoxBase : SandBoxElement
	{
		//-------------------------------------------------
		#region Initialize Method's Region
		private void InitializeComponent()
		{
			//---------------------------------------------
			//news:
			this.MyRes = new(this.GetType());
			this._flat = new FlatElement(this, this);
			this.Manager = new ElementManager(this);
			//---------------------------------------------
			//fontAndTextAligns:
			//priorities:
			this.ChangePriority(ElementPriority.SandBox); // move it to sandbox base
			//sizes:
			//ownering:
			//locations:
			//movements:
			this.ChangeMovements(ElementMovements.VerticalHorizontalMovements);
			//colors:
			this._flat.ChangeBackColor(new Color(Color.Black, 0.7f));
			//enableds:
			this._flat.Enable();
			//texts:
			//images:
			//applyAndShow:
			this._flat.Apply();
			this._flat.Show();
			//events:
			//---------------------------------------------
			//addRanges:
			//---------------------------------------------
			//---------------------------------------------
			//---------------------------------------------
			//---------------------------------------------
		}
		#endregion
		//-------------------------------------------------
		#region Graphical Method's Region
		public override void Draw(GameTime gameTime, SpriteWoto spriteBatch)
		{
			// check if the batch is null or disposed or not
			if (spriteBatch == null || spriteBatch.IsDisposed || !spriteBatch.IsStarted)
			{
				// do NOT draw yourself if the batch is null or disposed!
				return;
			}
			// check if this element is disposed or applied or visible
			if (this.IsDisposed || !this.IsApplied || !this.Visible)
			{
				// it means this element should not draw itself, so return
				return;
			}
			// draw the surface of the sandbox.
			this._flat?.Draw(gameTime, spriteBatch);
			this.Manager?.Draw(gameTime, spriteBatch);
		}
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		protected override void UpdateGraphics()
		{
			;
		}
		public override void Update(GameTime gameTime)
		{
			// do nothing here (just for now!)
			// by ALi.w
			// in : 08 / 03 / 2021
		}
		public override void SetLabelName(StrongString constParam)
		{
			this._flat?.SetLabelName(constParam);
		}
		public override void SetLabelText()
		{
			this._flat?.SetLabelText();
		}
		public override void SetLabelText(StrongString customValue)
		{
			this._flat?.SetLabelText(customValue);
		}
		/// <summary>
		/// change the size of this sandbox.
		/// </summary>
		/// <param name="w">
		/// the width.
		/// </param>
		/// <param name="h">
		/// the height.
		/// </param>
		public override void ChangeSize(float w, float h)
		{
			this._flat?.ChangeSize(w, h);
		}
		/// <summary>
		/// change the size of this sandbox.
		/// </summary>
		/// <param name="w">
		/// the width.
		/// </param>
		/// <param name="h">
		/// the height.
		/// </param>
		public override void ChangeSize(int w, int h)
		{
			this._flat?.ChangeSize(w, h);
		}
		/// <summary>
		/// change the location of this sandbox.
		/// </summary>
		/// <param name="x">
		/// the x-coordinate of the sandbox's new location.
		/// </param>
		/// <param name="y">
		/// the y-coordinate of the sandbox's new location.
		/// </param>
		public override void ChangeLocation(float x, float y)
		{
			this._flat?.ChangeLocation(x, y);
			base.ChangeLocation(x, y);
		}
		/// <summary>
		/// change the location of this sandbox.
		/// </summary>
		/// <param name="x">
		/// the x-coordinate of the sandbox's new location.
		/// </param>
		/// <param name="y">
		/// the y-coordinate of the sandbox's new location.
		/// </param>
		public override void ChangeLocation(int x, int y)
		{
			this._flat?.ChangeLocation(x, y);
			base.ChangeLocation(x, y);
		}
		/// <summary>
		/// change the location of this sandbox.
		/// </summary>
		/// <param name="location">
		/// the vector2 which represent the new location of this sandbox.
		/// </param>
		public override void ChangeLocation(Vector2 location)
		{
			this._flat?.ChangeLocation(location);
			base.ChangeLocation(location);
		}
		/// <summary>
		/// change the default font of this sandbox.
		/// </summary>
		/// <param name="font">
		/// the <see cref="SpriteFont"/> value which will be
		/// the default font of this sandbox.
		/// </param>
		public override void ChangeFont(SpriteFontBase font)
		{
			this._flat?.ChangeFont(font);
		}
		/// <summary>
		/// change the dafualt fore color of this sandbox.
		/// </summary>
		/// <param name="color">
		/// the <see cref="Color"/> value which will be the
		/// default fore color of this sandbox.
		/// </param>
		public override void ChangeForeColor(Color color)
		{
			this._flat?.ChangeForeColor(color);
		}
		/// <summary>
		/// change the default text of this sandbox :|
		/// dunna what will this fucking method do.
		/// probably nothing, so don't use it anyway.
		/// I just overrided it just-in-case.
		/// </summary>
		/// <param name="text">
		/// the <see cref="StrongString"/> value which will be the
		/// default text of this fucking bullshit sandbox.
		/// </param>
		public override void ChangeText(StrongString text)
		{
			this._flat?.ChangeText(text);
		}
		public override void ChangeMovements(ElementMovements movements)
		{
			this._flat?.ChangeMovements(movements);
		}
		public override void ChangeMovements(ElementMovements movements, 
			IMoveManager manager)
		{
			this._flat?.ChangeMovements(movements, manager);
		}
		public override void Shocker()
		{
			this._flat?.Shocker();
		}
		public override void Shocker(GraphicElement child)
		{
			this._flat?.Shocker(child);
		}
		public override void Discharge()
		{
			this._flat?.Discharge();
		}
		public override void LockMouse()
		{
			this._flat?.LockMouse();
		}
		public override void MoveMe(float divergeX, float divergeY)
		{
			this._flat?.MoveMe(divergeX, divergeY);
		}
		public override void MoveMe()
		{
			this._flat?.MoveMe();
		}
		protected internal override void OnLeftClick()
		{
			this._flat?.OnLeftClick();
		}
		protected internal override void OnRightClick()
		{
			this._flat?.OnRightClick();
		}
		protected internal override void OnMouseEnter()
		{
			this._flat?.OnMouseEnter();
		}
		protected internal override void OnMouseLeave()
		{
			this._flat?.OnMouseLeave();
		}
		protected internal override void OnMouseMove()
		{
			this._flat?.OnMouseMove();
		}
		protected internal override void OnLeftDown()
		{
			this._flat?.OnLeftDown();
		}
		protected internal override void OnLeftUp()
		{
			this._flat?.OnLeftUp();
		}
		protected internal override void OnRightDown()
		{
			this._flat?.OnRightDown();
		}
		protected internal override void OnRightUp()
		{
			this._flat?.OnRightUp();
		}

		#endregion
		//-------------------------------------------------
		#region ordinary Method's Region
		/// <summary>
		/// set the location of the sandbox to the
		/// center of the location.
		/// <code>NOTICE:</code>
		/// if you change the size of the sandbox,
		/// you should call this method again in order to 
		/// regain the centering of the sandbox.
		/// </summary>
		public void CenterToScreen()
		{
			var x = (UnderForm.Width / 2) - (this.Width / 2);
			var y = (UnderForm.Height / 2) - (this.Height / 2);
			this.ChangeLocation(x, y);
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		public bool IsErrorSandBox()
		{
			return
				SandBoxPriority == SandBoxPriority.LowErrorSandBox ||
				SandBoxPriority == SandBoxPriority.TopMostErrorSandBox;
		}
		#endregion
		//-------------------------------------------------
		#region Set Method's Region

		#endregion
		//-------------------------------------------------
		#region sealed Method's Region
		protected override sealed Texture2D GetBackGroundTexture(Color color)
		{
			return null;
		}
		#endregion
		//-------------------------------------------------
	}
}
