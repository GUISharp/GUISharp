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
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FontStashSharp;
using GUISharp.WotoProvider.Enums;
using GUISharp.Security;
using GUISharp.Controls.Moving;
using GUISharp.GUIObjects.Graphics;

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
			Task.Run((() =>
			{
				this._flat?.OnLeftClick();
			}));
		}
		protected internal override void OnRightClick()
		{
			Task.Run(() =>
			{
				this._flat?.OnRightClick();
			});
		}
		protected internal override void OnMouseEnter()
		{
			Task.Run(() =>
			{
				this._flat?.OnMouseEnter();
			});
		}
		protected internal override void OnMouseLeave()
		{
			Task.Run(() =>
			{
				this._flat?.OnMouseLeave();
			});
		}
		protected internal override void OnLeftDown()
		{
			Task.Run((() =>
			{
				this._flat?.OnLeftDown();
			}));
		}
		protected internal override void OnLeftUp()
		{
			Task.Run((() =>
			{
				this._flat?.OnLeftUp();
			}));
		}
		protected internal override void OnRightDown()
		{
			Task.Run((() =>
			{
				this._flat?.OnRightDown();
			}));
		}
		protected internal override void OnRightUp()
		{
			Task.Run(() =>
			{
				this._flat?.OnRightUp();
			});

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
			if (this.BorderColor != color)
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
			if (this._flat == null || this._flat.IsDisposed)
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
