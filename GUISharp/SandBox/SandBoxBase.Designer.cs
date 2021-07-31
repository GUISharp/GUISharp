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
using GUISharp.WotoProvider.Enums;
using GUISharp.GUIObjects.Graphics;
using GUISharp.GUIObjects.Resources;

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
			//base.ChangeLocation(x, y);
			this.Manager?.UpdateLocations();
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
			//base.ChangeLocation(x, y);
			this.Manager?.UpdateLocations();
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
			//base.ChangeLocation(location);
			this.Manager?.UpdateLocations();
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
		public override void ChangeBackColor(Color color)
		{
			this._flat?.ChangeBackColor(color);
		}
		/// <summary>
		/// Change the tint color of this sandbox.
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
		public override void ChangeTint(Color color)
		{
			this._flat?.ChangeTint(color);
		}
		/// <summary>
		/// Change the background tint color of this sandbox.
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
		public override void ChangeBackTint(Color color)
		{
			this._flat?.ChangeBackTint(color);
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
		public override void ChangeImage()
		{
			this._flat?.ChangeImage();
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
		public override void ChangeImage(WotoRes myRes)
		{
			this._flat?.ChangeImage(myRes);
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
		/// The name of the Image which should have <see cref="GraphicElement.PIC_RES"/>
		/// suffix to it.
		/// </param>
		/// <param name="parse">
		/// pass false for this argument if you don't want this method to appened
		/// <see cref="GraphicElement.PIC_RES"/> suffix to the name.
		/// </param>
		public override void ChangeImage(WotoRes myRes, StrongString name,
			bool parse = true)
		{
			this._flat?.ChangeImage(myRes, name, parse);
		}
		
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the <see cref="GraphicElement.MyRes"/> property of this
		/// graphic element.
		/// The parse mode will be enabled in this method.
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
		/// The name of the Image which should have <see cref="GraphicElement.PIC_RES"/>
		/// suffix to it (it should have this suffix in the resources manager,
		/// not in itself. Take note that we will add this suffix to it 
		/// in this method).
		/// </param>
		public override void ChangeImage(StrongString name)
		{
			this._flat?.ChangeImage(name);
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the DefaultRes property of this
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
		/// The name of the Image which should have 
		/// <see cref="GraphicElement.PIC_RES"/>
		/// suffix to it (it should have this suffix in the resources manager,
		/// not in itself. Take note that we will add this suffix to it 
		/// in this method).
		/// </param>
		protected internal override void ChangeImageDefault(StrongString name)
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
		public override void ChangeImage(Texture2D texture)
		{
			this._flat?.ChangeImage(texture);
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
		public override void ChangeImageSizeMode(ImageSizeMode mode)
		{
			this._flat?.ChangeImageSizeMode(mode);
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
