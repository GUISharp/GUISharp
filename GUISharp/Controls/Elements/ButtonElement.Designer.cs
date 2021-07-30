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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FontStashSharp;
using GUISharp.WotoProvider.Enums;
using GUISharp.Security;
using GUISharp.Controls.Moving;
using GUISharp.GUIObjects.Graphics;
using GUISharp.GUIObjects.Resources;

namespace GUISharp.Controls.Elements
{
	partial class ButtonElement
	{
		//-------------------------------------------------
		#region Initialize Region
		/// <summary>
		/// Initializer of this <see cref="ButtonElement"/>.
		/// </summary>
		private void InitializeComponent()
		{
			//---------------------------------------------
			//news:
			this._flat = new FlatElement(this, this);
			if (this.Manager != null)
			{
				this.Manager?.DisposeAll();
				this.Manager = null;
			}
			
			//---------------------------------------------
			//Border:
			this.ChangeBorderF(ButtonColors.NormalWhiteWhiteSmoke);
			//priorities:
			this.ChangePriority(ElementPriority.Normal);
			//---------------------------------------------
			//Applies:
			this._flat.Apply();
			//shows:
			this._flat.Show();
			//---------------------------------------------
			//events:
			this._flat.MouseEnter -= _flat_MouseEnter;
			this._flat.MouseLeave -= _flat_MouseLeave;
			this._flat.MouseEnter += _flat_MouseEnter;
			this._flat.MouseLeave += _flat_MouseLeave;
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
			// draw the surface of the button.
			this._flat?.Draw(gameTime, spriteBatch);
		}
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		/// <summary>
		/// Apply the element, so the element draw itself.
		/// you should call this method only once and only at the start.
		/// </summary>
		public override void Apply()
		{
			this._flat?.Apply();
		}
		/// <summary>
		/// Dispose the elements,
		/// this method will release all the resources used
		/// by the element, so use it carefully!
		/// </summary>
		public override void Dispose()
		{
			this._flat?.Dispose();
		}
		/// <summary>
		/// Disable the element,
		/// this method will set the <see cref="Enabled"/> property 
		/// to <c>false</c>.
		/// if you want to enable the element, use <see cref="Enable()"/> method.
		/// </summary>
		public override void Disable()
		{
			this._flat?.Disable();
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
		public override void Enable()
		{
			this._flat?.Enable();
		}
		/// <summary>
		/// Unstable the element,
		/// this method will set the <see cref="IsStable"/> property 
		/// to <c>false</c>.
		/// if you want to make the element stable,
		/// use <see cref="Stable()"/> method.
		/// </summary>
		public override void Unstable()
		{
			this._flat?.Unstable();
		}
		/// <summary>
		/// Make the element a stable element.
		/// </summary>
		public override void Stable()
		{
			this._flat?.Stable();
		}
		
		protected override Texture2D GetBackGroundTexture(Color color)
		{
#if BUTTON_BACKGROUND
			// w: 75, h: 23.
			// the respect is 0.3066666666666667 .
			DColor back = DColor.FromArgb(170, DColor.Black);
			const float w = 300, h = 92;
			PointF[] unlimitedPointWorks = new[]
			{
				new PointF((w / 10), 0),
				new PointF(w - 1, 0),
				new PointF(w - 1, 2 * (h / 3)),
				new PointF(9 * (w / 10), h - 1),
				new PointF(0, h - 1),
				new PointF(0, 1 * (h / 3)),
			};
			using (var i = new Bitmap(Rectangle.Width, Rectangle.Height))
			{
				Graphics g = Graphics.FromImage(i);
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				g.FillPolygon(new SolidBrush(back), unlimitedPointWorks);
				g.DrawPolygon(new Pen(DColor.WhiteSmoke, 1.25f), unlimitedPointWorks);
				i.Save(@"C:\Users\mrwoto\Programming\Project\GUISharp\GUISharp_IMAGES\f_010320212340.bin", 
					System.Drawing.Imaging.ImageFormat.Png);
			}
#endif
			return null;
		}
		protected override void UpdateGraphics()
		{
			;
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
		public override void ChangeSize(float w, float h)
		{
			this._flat?.ChangeSize(w, h);
		}
		public override void ChangeSize(int w, int h)
		{
			this._flat?.ChangeSize(w, h);
		}
		/// <summary>
		/// Locking the mouse on a button element is now allowed,
		/// so even if you call it directly, it will just ignore you.
		/// </summary>
		public sealed override void LockMouse()
		{
			return;
		}
		/// <summary>
		/// Locking the mouse on a button element is now allowed,
		/// so even if you call it directly, it will just ignore you.
		/// </summary>
		public sealed override void UnLockMouse()
		{
			return;
		}
		public override void ChangeLocation(float x, float y)
		{
			this.RealPosition = new(x, y);
			if (this.HasOwner && this.Owner != null)
			{
				var r_x = this.Owner.Rectangle.Location.X + x;
				var r_y = this.Owner.Rectangle.Location.Y + y;
				this._flat?.ChangeLocation(r_x, r_y);
			}
			else
			{
				this._flat?.ChangeLocation(x, y);
			}
		}
		public override void ChangeLocation(int x, int y)
		{
			this.RealPosition = new(x, y);
			if (this.HasOwner && this.Owner != null)
			{
				var r_x = this.Owner.Rectangle.Location.X + x;
				var r_y = this.Owner.Rectangle.Location.Y + y;
				this._flat?.ChangeLocation(r_x, r_y);
			}
			else
			{
				this._flat?.ChangeLocation(x, y);
			}
		}
		public override void ChangeLocation(Vector2 location)
		{
			this.RealPosition = location;
			if (this.HasOwner && this.Owner != null)
			{
				var loc = this.Owner.Rectangle.Location.ToVector2() + location;
				this._flat?.ChangeLocation(loc);
			}
			else
			{
				this._flat?.ChangeLocation(location);
			}
		}
		public override void OwnerLocationUpdate()
		{
			this.ChangeLocation(this.RealPosition);
		}
		public override void ChangeFont(SpriteFontBase font)
		{
			this._flat?.ChangeFont(font);
		}
		public override void ChangeForeColor(Color color)
		{
			this._flat.ChangeForeColor(color);
		}
		public override void ChangeText(StrongString text)
		{
			this._flat?.ChangeText(text);
		}
		/// <summary>
		/// WARNING: since the button elements cannot be moveable, 
		/// using this method is useless and the button's movements 
		/// property will always be <see cref="ElementMovements.NoMovements"/>.
		/// </summary>
		/// <param name="movements">
		/// no matter what is this value, the movements of a button elements will
		/// never change!
		/// </param>
		public override void ChangeMovements(ElementMovements movements)
		{
			// do nothing here!
			// you shall not move the button elements!
			// I won't let this happens!
			// You shall NOT pass!
		}
		/// <summary>
		/// WARNING: since the button elements cannot be moveable, 
		/// using this method is useless and the button's movements 
		/// property will always be <see cref="ElementMovements.NoMovements"/>.
		/// PLEASE do NOT use this method.
		/// </summary>
		/// <param name="movements"></param>
		/// <param name="manager"></param>
		public override void ChangeMovements(ElementMovements movements, IMoveManager manager)
		{
			// do nothing here!
			// you shall not move the button elements!
			// I won't let this happens!
			// You shall NOT pass!
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
		/// Change the tint color of this button.
		/// <!--
		/// Since: GUISharp 1.0.31;
		/// By: ALiwoto;
		/// Last edit: 5 July 14:41;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="color"> 
		/// The new tint color of this button.
		/// </param>
		public override void ChangeTint(Color color)
		{
			this._flat?.ChangeTint(color);
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
		/// The new background tint color of this element.
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
		public override void ChangeImageContent()
		{
			this._flat?.ChangeImageContent();
		}
		/// <summary>
		/// Change the image of this button element, with using 
		/// the <see cref="Name"/> property of this button element,
		/// which already exists in the specified Woto Resources Manager.
		/// If you would like to change the image of this button element
		/// using a custom image from somewhere else, then please
		/// use <see cref="ChangeImage(Texture2D)"/>  instead of this method.
		/// <!--
		/// Since: GUISharp 1.0.39;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="myRes"> 
		/// The Woto Resources Manager which should not be null and 
		/// should contains an image with the <see cref="Name"/> 
		/// property of this button element, it.
		/// if not, this method won't do anything (it won't throw any
		/// exception.)
		/// </param>
		public override void ChangeImage(WotoRes myRes)
		{
			this._flat?.ChangeImage(myRes);
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
		public override void ChangeImageContent(WotoRes myRes)
		{
			this._flat?.ChangeImageContent(myRes);
		}
		/// <summary>
		/// Change the image of this button element, with using a name
		/// which already exists in the specified Woto Resources Manager.
		/// If you would like to change the image of this button element
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
		/// The name of the Image which should have 
		/// <see cref="GraphicElement.PIC_RES"/>
		/// suffix to it.
		/// </param>
		/// <param name="parse">
		/// pass false for this argument if you don't want this method 
		/// to appened <see cref="GraphicElement.PIC_RES"/> 
		/// suffix to the name.
		/// </param>
		public override void ChangeImage(WotoRes myRes, StrongString name,
			bool parse = true)
		{
			this._flat?.ChangeImage(myRes, name, parse);
		}
		/// <summary>
		/// Change the image of this button element, with using a name
		/// which already exists in the specified Woto Resources Manager.
		/// If you would like to change the image of this button element
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
		/// The name of the Image which should have 
		/// <see cref="GraphicElement.PIC_RES"/>
		/// suffix to it.
		/// </param>
		/// <param name="parse">
		/// pass false for this argument if you don't want this method 
		/// to appened <see cref="GraphicElement.PIC_RES"/> 
		/// suffix to the name.
		/// </param>
		public override void ChangeImageContent(WotoRes myRes, StrongString name,
			bool parse = true)
		{
			this._flat?.ChangeImageContent(myRes, name, parse);
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the <see cref="GraphicElement.MyRes"/> 
		/// property of this graphic element.
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
		public override void ChangeImage(StrongString name)
		{
			this._flat?.ChangeImage(name);
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the <see cref="GraphicElement.Content"/>
		/// property of this button element.
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
		public override void ChangeImageContent(StrongString name)
		{
			this._flat?.ChangeImageContent(name);
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the 
		/// <see cref="GraphicElement.Content"/> property of this
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
		/// The name of the Image which should have 
		/// <see cref="GraphicElement.PIC_RES"/>
		/// suffix to it (it should have this suffix in the resources manager,
		/// not in itself. Take note that we will add this suffix to it 
		/// in this method).
		/// </param>
		/// <param name="parse">
		/// pass false for this argument if you don't want this method to appened
		/// <see cref="GraphicElement.PIC_RES"/> suffix to the name.
		/// </param>
		public override void ChangeImageContent(StrongString name, bool parse)
		{
			this._flat?.ChangeImageContent(name, parse);
		}
		/// <summary>
		/// Change the image of this graphic element, with using a name
		/// which already exists in the <see cref="GraphicElement.MyRes"/>
		///  property of this
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
		/// The name of the Image which should have 
		/// <see cref="GraphicElement.PIC_RES"/>
		/// suffix to it (it should have this suffix in the resources manager,
		/// not in itself. Take note that we will add this suffix to it 
		/// in this method).
		/// </param>
		/// <param name="parse">
		/// pass false for this argument if you don't want this method 
		/// to appened
		/// <see cref="GraphicElement.PIC_RES"/> suffix to the name.
		/// </param>
		public override void ChangeImage(StrongString name, bool parse)
		{
			this._flat?.ChangeImage(name, parse);
		}
		/// <summary>
		/// Change the image of this button element, with using a name
		/// which already exists in the <see cref="GraphicElement.DefaultRes"/>
		/// property of this button element.
		/// This method is supposed to be internal and it should remains
		/// internal, because users may have no idea what's going on here and
		/// so we have to keep it internal.
		/// The only problem that remains is that how the fuck am I
		/// supposed to accomplish some tasks in LTW-client.
		/// If you would like to change the image of this button element
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
			this._flat?.ChangeImageDefault(name);
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
		public override void ChangeImageSizeMode(ImageSizeMode mode)
		{
			this._flat?.ChangeImageSizeMode(mode);
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
		public override void ChangeRectangle(Rectangle rect)
		{
			this._flat?.ChangeRectangle(rect);
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
		protected override void ChangeRectangle()
		{
			// this method is not required in a button element.
			// since the core (_flat) itself has this method
			// and will take care of it.
			return;
		}
		
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		public void ChangeAlignmation(StringAlignmation alignmation)
		{
			_flat?.ChangeAlignmation(alignmation);
		}
		public void ChangeForeColor(Color color, float w)
		{
			this._flat?.ChangeForeColor(color, w);
		}
		public void ChangeBorder(ButtonColors color)
		{
			if (this.BorderColor != color && 
				this.BorderColor != ButtonColors.Custom)
			{
				this.BorderColor = color;
				this.ChangeBorder();
			}
		}
		/// <summary>
		/// change the size of this button to it's default value.
		/// </summary>
		public void ChangeSize()
		{
			this.ChangeSize(DEFAULT_WIDTH, DEFAULT_HEIGHT);
		}
		/// <summary>
		/// multiple the current width and height of this button element.
		/// </summary>
		/// <param name="multiple">
		/// the float multiple number.
		/// please do note that if this number is 0 or 1, there will be no
		/// change applied to this element.
		/// </param>
		public void ChangeSize(float multiple)
		{
			if (multiple == BASE_INDEX || multiple == PIXEL_BASE)
			{
				return;
			}
			float w = this.Width != BASE_INDEX ? this.Width :
			DEFAULT_WIDTH;
			float h = this.Height != BASE_INDEX ? this.Height :
			DEFAULT_HEIGHT;
			this.ChangeSize(multiple * w, multiple * h);
		}
		private void ChangeBorderF(ButtonColors color)
		{
			this.BorderColor = color;
			this.ChangeBorder();
		}
		private void ChangeBorder()
		{
			if (this._flat == null || this._flat.IsDisposed || 
				this.BorderColor == ButtonColors.Custom)
			{
				return;
			}
			this._flat.ChangeImage(DefaultRes, GetContentBorderName(), false);
			switch (this.BorderColor)
			{
				case ButtonColors.SpecialWhiteSmoke:
					this.ChangeForeColor(Color.WhiteSmoke);
					break;
				case ButtonColors.SpecialRed:
					this.ChangeForeColor(Color.Red);
					break;
				case ButtonColors.SpecialGreenYellow:
					this.ChangeForeColor(Color.GreenYellow);
					break;
				case ButtonColors.SpecialDarkGreen:
					this.ChangeForeColor(Color.DarkGreen);
					break;
				default:
					this.ChangeForeColor(Color.White);
					break;
			}
		}
		private StrongString GetContentBorderName()
		{
			switch (this.BorderColor)
			{
				case ButtonColors.SpecialWhiteSmoke:
					return WhiteSmoke_Border_FileName;
				case ButtonColors.SpecialRed:
					return Red_Border_FileName;
				case ButtonColors.SpecialGreenYellow:
					return GreenYellow_Border_FileName;
				case ButtonColors.SpecialDarkGreen:
					return DarkGreen_Border_FileName;
				case ButtonColors.NormalTransparentGreen:
					return NormalTransparentGreen_Border_FileName;
				case ButtonColors.NormalGreenGreen:
					return NormalGreenGreen_Border_FileName;
				case ButtonColors.NormalBlackWhiteSmoke:
					return NormalBlackWhiteSmoke_Border_FileName;
				case ButtonColors.NormalTransparentWhiteSmoke:
					return NormalTransparentWhiteSmoke_Border_FileName;
				case ButtonColors.NormalWhiteWhiteSmoke:
					return NormalWhiteWhiteSmoke_Border_FileName;
				case ButtonColors.NormalGrayWhiteSmoke:
					return NormalGrayWhiteSmoke_Border_FileName;
				case ButtonColors.NormalGrayLightSlateGray:
					return NormalGrayLightSlateGray_Border_FileName;
				case ButtonColors.NormalLightGrayBlack:
					return NormalLightGrayBlack_Border_FileName;
				case ButtonColors.NormalGrayBlack:
					return NormalGrayBlack_Border_FileName;
				case ButtonColors.NormalRedBlack:
					return NormalRedBlack_Border_FileName;
				case ButtonColors.NormalWhiteBlack:
					return NormalWhiteBlack_Border_FileName;
				case ButtonColors.NormalWheatBlack:
					return NormalWheatBlack_Border_FileName;
				case ButtonColors.NormalWhiteRed:
					return NormalWhiteRed_Border_FileName;
				case ButtonColors.NormalLightGrayRed:
					return NormalLightGrayRed_Border_FileName;
				case ButtonColors.NormalGrayRed:
					return NormalGrayRed_Border_FileName;
				case ButtonColors.NormalDarkGrayRed:
					return NormalDarkGrayRed_Border_FileName;
				case ButtonColors.NormalWhiteOrange:
					return NormalWhiteOrange_Border_FileName;
				case ButtonColors.NormalLightGrayOrange:
					return NormalLightGrayOrange_Border_FileName;
				case ButtonColors.NormalGrayOrange:
					return NormalGrayOrange_Border_FileName;
				case ButtonColors.NormalDarkGrayOrange:
					return NormalDarkGrayOrange_Border_FileName;
				case ButtonColors.NormalWhiteOrangered:
					return NormalWhiteOrangered_Border_FileName;
				case ButtonColors.NormalLightGrayOrangered:
					return NormalLightGrayOrangered_Border_FileName;
				case ButtonColors.NormalGrayOrangered:
					return NormalGrayOrangered_Border_FileName;
				case ButtonColors.NormalDarkGrayOrangered:
					return NormalDarkGrayOrangered_Border_FileName;
				case ButtonColors.NormalWhiteGreen:
					return NormalWhiteGreen_Border_FileName;
				case ButtonColors.NormalLightGrayGreen:
					return NormalLightGrayGreen_Border_FileName;
				case ButtonColors.NormalGrayGreen:
					return NormalGrayGreen_Border_FileName;
				case ButtonColors.NormalDarkGrayGreen:
					return NormalDarkGrayGreen_Border_FileName;
			}
			return null;
		}
		#endregion
		//-------------------------------------------------
		#region ordinary Method's Region
		public void EnableMouseEnterEffect()
		{
			this.UseMouseEnterEffect = true;
		}
		#endregion
		//-------------------------------------------------
		#region event Method's Region
		private void _flat_MouseLeave(object sender, EventArgs e)
		{
			if (this.InMouseEnterEffect)
			{
				this.InMouseEnterEffect = false;
				this.ChangeRectangle(_real_rect);
			}
		}
		private void _flat_MouseEnter(object sender, EventArgs e)
		{
			if (this.UseMouseEnterEffect && !this.InMouseEnterEffect)
			{
				var pos = this.RealPosition.ToPoint();
				var size = this.Rectangle.Size;
				this._real_rect = new(pos, size);
				if (this._eff_rect.HasValue && !this.HasOwner)
				{
					this.ChangeRectangle(this._eff_rect.Value);
					this.InMouseEnterEffect = true;
				}
				else
				{
					var offSet_x = ME_EFFECT_OFFSET * this.Width;
					var offSet_y = ME_EFFECT_OFFSET * this.Height;
					this.ChangeSize(offSet_x, offSet_y);
					var offShort_x = ME_EFFECT_OFFSHORT * this.Width;
					var offShort_y = ME_EFFECT_OFFSHORT * this.Height;
					float pos_x, pos_y;
					if (this.HasOwner && this.Owner != null)
					{
						pos_x = this.RealPosition.X - offShort_x;
						pos_y = this.RealPosition.Y - offShort_y;
					}
					else
					{
						pos_x = this.Position.X - offShort_x;
						pos_y = this.Position.Y - offShort_y;
					}
					this.ChangeLocation(pos_x, pos_y);
					this._eff_rect = this._flat.Rectangle;
					this.InMouseEnterEffect = true;
				}
			}
		}
		#endregion
		//-------------------------------------------------
	}
}
