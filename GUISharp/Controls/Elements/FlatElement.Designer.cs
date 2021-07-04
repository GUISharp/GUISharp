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
using GUISharp.WotoProvider.Enums;
using GUISharp.Security;
using GUISharp.Controls.Moving;
using GUISharp.GUIObjects.Graphics;

namespace GUISharp.Controls.Elements
{
	partial class FlatElement
	{
		//-------------------------------------------------
		#region Initialize Method's Region
		private void InitializeComponent()
		{
			//---------------------------------------------
			//news:
			if (!this.IsBarren)
			{
				this.Manager = new ElementManager(this);
			}
			//---------------------------------------------
			if (Movements != ElementMovements.NoMovements)
			{
				this.MoveManager = new MoveManager(this);
			}
			//---------------------------------------------
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
			// check if the texture and text are null or not
			if (this.Image == null && this.FixedText == null && this.BackGroundImage == null)
			{
				// it means this elements does not have anything to draw,
				// so it should not being the BigFather's sprite batch.
				Manager?.Draw(gameTime, spriteBatch);
				return;
			}
			
			// begin the spriteBatch tool to drawing the graphic surface.
			// spriteBatch.Start();
			// check if the background image is null or disposed or not.
			if (this.BackGroundImage != null && !this.BackGroundImage.IsDisposed)
			{
				// check if the current background color is transparent of not.
				// if the color is transparent you don't have to draw anything.
				if (this.BackGroundColor != Color.Transparent)
				{
					// it means the current background color of this flat element
					// is not transparent, so you should draw the background color 
					// of this flat element.
					spriteBatch.Draw(this.BackGroundImage, this.Rectangle, this.Tint);
				}
			}
			// check if the Image property of this flat element is null or disposed
			// or not.
			if (this.Image != null && !this.Image.IsDisposed)
			{
				// draw the Image
				spriteBatch.Draw(this.Image, this.ImageRectangle, this.Image.Bounds, this.Tint);
			}
			// check if the fixed text is null or healthy.
			if (!StrongString.IsNullOrEmpty(this.FixedText))
			{
				// check if the Font is null or not.
				if (this.Font != null)
				{
					// draw the fixed-text using spriteBatch tool
					// and specified location.
					spriteBatch.DrawString(this.Font,
							this.FixedText.GetValue(),
							this.TextLocation,
							this.ForeColor);
				}
			}
			// Call the End method of spriteBatch tool.
			//spriteBatch.Finish();
			// call the Draw Method of the manager (it it's not null), 
			// so the children can draw their surface (if any exists).
			this.Manager?.Draw(gameTime, spriteBatch);
		}
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		/// <summary>
		/// Let this flat element update itself.
		/// This method has no usage (right now).
		/// But it will be used in the future.
		/// for now, please override <see cref="Draw(GameTime, SpriteWoto)"/>
		/// instead of overriding this method.
		/// <!--
		/// Since: GUISharp 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override void Update(GameTime gameTime)
		{
			;
		}
		/// <summary>
		/// Set the label text of this flat element automatically.
		/// please notice that you have to set 
		/// <!--
		/// Since: GUISharp 1.0.10;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override void SetLabelText()
		{
			base.SetLabelText();
			this.ChangeTextLocation();
		}
		public override void SetLabelText(StrongString customValue)
		{
			base.SetLabelText(customValue);
			this.ChangeTextLocation();
		}
		public override void ChangeSize(float w, float h)
		{
			base.ChangeSize(w, h);
			this.ChangeTextLocation();
			if (this.Image != null)
			{
				this.ImageSizeModeRender();
			}
		}
		public override void ChangeSize(int w, int h)
		{
			base.ChangeSize(w, h);
			this.ChangeTextLocation();
			if (this.Image != null)
			{
				this.ImageSizeModeRender();
			}
		}
		public override void ChangeLocation(float x, float y)
		{
			base.ChangeLocation(x, y);
			this.ChangeTextLocation();
		}
		public override void ChangeLocation(int x, int y)
		{
			base.ChangeLocation(x, y);
			this.ChangeTextLocation();
		}
		public override void ChangeLocation(Vector2 location)
		{
			base.ChangeLocation(location);
			this.ChangeTextLocation();
		}
		public override void OwnerLocationUpdate()
		{
			base.OwnerLocationUpdate();
			this.ChangeTextLocation();
		}
		public override void ChangeFont(SpriteFontBase font)
		{
			if (font == null || this.Font == font)
			{
				return;
			}
			this.Font = font;
		}
		public override void ChangeForeColor(Color color)
		{
			this.ChangeForeColor(color, DEFAULT_PEN_W);
		}
		/// <summary>
		/// Change the background color of this flat element to
		/// the specified <see cref="Color"/> value.
		/// </summary>
		public override void ChangeBackColor(Color color)
		{
			base.ChangeBackColor(color);
		}
		public override void ChangeText(StrongString text)
		{
			if (this.Text == text)
			{
				return;
			}
			this.Text = text;
			this.ChangeTextLocation();
		}
		protected override Texture2D GetBackGroundTexture(Color color)
		{
			if (color != Color.Transparent)
			{
				Texture2D t = new Texture2D(BigFather.GraphicsDevice, PIXEL_BASE, PIXEL_BASE);
				t.SetData<Color>(new Color[] { color });
#if BACKGROUND_TEXTURE

				var g = BigFather.GetGraphics();
				using (var image = new Bitmap(PIXEL_BASE, PIXEL_BASE))
				{
					g = Graphics.FromImage(image);
					g.SmoothingMode = SmoothingMode.HighQuality;
					g.FillRectangle(new SolidBrush(color), BASE_INDEX, BASE_INDEX, PIXEL_BASE, PIXEL_BASE);
					var m = new MemoryStream();
					image.Save(m, ImageFormat.Png);
					t = Texture2D.FromStream(BigFather.GraphicsDevice, m);
					g.Dispose();
					m.Dispose();
				}
#endif
				this.BackGroundImage = t;
				return t;
			}
			return null;
		}


		protected override void UpdateGraphics()
		{
			;
		}
		protected override void ImageSizeModeRender()
		{
			switch (this.ImageSizeMode)
			{
				case ImageSizeMode.Strengthen:
					if (this.ImageRectangle != this.Rectangle)
					{
						this.ImageRectangle = this.Rectangle;
					}
					break;
				case ImageSizeMode.Center:
					if (this.Image != null)
					{
						var x = (int)(this.Width / 2) - (this.Image.Width / 2);
						var y = (int)(this.Height / 2) - (this.Image.Height / 2);
						var w = this.Image.Width;
						var h = this.Image.Height;
						this.ImageRealLocation = new(x, y);
						var loc = this.Rectangle.Location + this.ImageRealLocation;
						var size = new Point(w, h);
						this.ImageRectangle = new(loc, size);
					}
					break;
				default:
					break;
			}
		}
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		public virtual void SetRepresentor(GraphicElement element)
		{
			this.Representor = element;
		}
		public virtual void ChangeAlignmation(StringAlignmation alignmation)
		{
			if (this.Alignmation != alignmation)
			{
				this.Alignmation = alignmation;
				this.ChangeTextLocation();
			}
		}
		public virtual void ChangeForeColor(Color color, float w)
		{
			base.ChangeForeColor(color);
		}

		private void ChangeTextLocation()
		{
			if (this.Font == null || this.Text == null)
			{
				return;
			}
			this.FixedText = this.Text.FixMe(this.Font, this.Rectangle.Width);
			if (this.FixedText == null)
			{
				return;
			}
			var s = this.Font.MeasureString(this.FixedText.GetValue());
			switch (this.Alignmation)
			{
				case StringAlignmation.TopLeft:
				{
					this.TextLocation = this.Position;
					break;
				}
				case StringAlignmation.TopCenter:
				{
					var w = this.Position.X + (this.Width / 2) - (s.X / 2);
					var h = this.Position.Y;
					this.TextLocation = new Vector2(w, h);
					break;
				}
				case StringAlignmation.TopRight:
				{
					var w = this.Position.X + this.Width - s.X;
					var h = this.Position.Y;
					this.TextLocation = new Vector2(w, h);
					break;
				}
				case StringAlignmation.MiddleLeft:
				{
					var w = this.Position.X;
					var h = this.Position.Y + (this.Height / 2) - (s.Y / 2);
					this.TextLocation = new Vector2(w, h);
					break;
				}
				case StringAlignmation.MiddleCenter:
				{
					var w = this.Position.X + (this.Width / 2) - (s.X / 2);
					var h = this.Position.Y + (this.Height / 2) - (s.Y / 2);
					this.TextLocation = new Vector2(w, h);
					break;
				}
				case StringAlignmation.MiddleRight:
				{
					var w = this.Position.X + this.Width - s.X;
					var h = this.Position.Y + (this.Height / 2) - (s.Y / 2);
					this.TextLocation = new Vector2(w, h);
					break;
				}
				case StringAlignmation.BottomLeft:
				{
					var w = this.Position.X;
					var h = this.Position.Y + this.Height - s.Y;
					this.TextLocation = new Vector2(w, h);
					break;
				}
				case StringAlignmation.BottomCenter:
				{
					var w = this.Position.X + (this.Width / 2) - (s.X / 2);
					var h = this.Position.Y + this.Height - s.Y;
					this.TextLocation = new Vector2(w, h);
					break;
				}
				case StringAlignmation.BottomRight:
				{
					var w = this.Position.X + this.Width - s.X;
					var h = this.Position.Y + this.Height - s.Y;
					this.TextLocation = new Vector2(w, h);
					break;
				}
				default:
					break;
			}
		}
		
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		public virtual Vector2 GetTextLocation()
		{
			return this.TextLocation;
		}
		public virtual Vector2 GetFinalTextLocation()
		{
			if (StrongString.IsNullOrEmpty(this.FixedText) ||
				this.Font == null)
			{
				return this.GetTextLocation();
			}

			var l = this.GetTextLocation();
			var fl = this.FixedText.MeasureString(this.Font);
			return new(l.X + fl.X, l.Y);
		}
		/// <summary>
		/// Checks if this <see cref="FlatElement"/> contains
		/// and unallowed Representor or not.
		/// </summary>
		/// <returns>
		/// <c>true</c> if the <see cref="Representor"/> of this element
		/// is a <see cref="ButtonElement"/> or an <see cref="InputElement"/>.
		/// These two elements are unallowed because they should not be moved.
		/// </returns>
		protected internal bool HasUnallowedRepresentor()
		{
			return this.Representor is ButtonElement || 
				this.Representor is InputElement;
		}
		#endregion
		//-------------------------------------------------
	}
}
