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
using GUISharp.WotoProvider.Enums;
using GUISharp.SandBox;
using GUISharp.Controls;
using GUISharp.GUIObjects.Texts;
using GUISharp.Controls.Elements;
using GUISharp.GUIObjects.Graphics;

namespace ClientTest.SandBoxes
{
	partial class LoginProfileSandBox
	{
		public const int Woto_WRate = 1;
		public const int Woto_HRate = 1;
		//-------------------------------------------------
		#region Initialize Method's Region
		private void InitializeComponent()
		{
			//---------------------------------------------
			//news:
			this.TitleElement = new FlatElement(this, true);
			this.UnameElement = new FlatElement(this, true);
			this.PassElement = new FlatElement(this, true);
			this.UnameInputElement = new InputElement(this);
			this.PassInputElement = new InputElement(this);
			this.ExitButton = new ButtonElement(this);
			this.LoginButton = new ButtonElement(this);
			//---------------------------------------------
			//loading:
			this.LeftTexture = BigRes.GetAsTexture2D(LEFT_BABYLONIA_ENTRANCE);
			this.RightTexture = BigRes.GetAsTexture2D(RIGHT_BABYLONIA_ENTRANCE);
			this.LineTexture = BigRes.GetAsTexture2D(LINE_BABYLONIA_ENTRANCE);
			//names:
			this.TitleElement.SetLabelName(SandBoxLabel1NameInRes);
			this.UnameElement.SetLabelName(SandBoxLabel2NameInRes);
			this.PassElement.SetLabelName(SandBoxLabel3NameInRes);
			this.ExitButton.SetLabelName(SandBoxButton1NameInRes);
			this.LoginButton.SetLabelName(SandBoxButton2NameInRes);
			//status:
			this.TitleElement.SetStatus(1);
			this.UnameElement.SetStatus(1);
			this.PassElement.SetStatus(1);
			this.UnameInputElement.SetStatus(1);
			this.PassInputElement.SetStatus(1);
			this.ExitButton.SetStatus(1);
			this.LoginButton.SetStatus(1);
			//fontAndTextAligns:
			this.TitleElement.ChangeFont(FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 28));
			this.UnameElement.ChangeFont(FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 24));
			this.PassElement.ChangeFont(this.UnameElement.Font);
			this.UnameInputElement.ChangeFont(this.UnameElement.Font);
			this.PassInputElement.ChangeFont(this.UnameElement.Font);
			this.ExitButton.ChangeFont(FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 23));
			this.LoginButton.ChangeFont(ExitButton.Font);
			this.TitleElement.ChangeAlignmation(StringAlignmation.MiddleCenter);
			this.UnameElement.ChangeAlignmation(StringAlignmation.MiddleLeft);
			this.PassElement.ChangeAlignmation(StringAlignmation.MiddleLeft);
			this.UnameInputElement.ChangeAlignmation(StringAlignmation.MiddleCenter);
			this.PassInputElement.ChangeAlignmation(StringAlignmation.MiddleCenter);
			this.ExitButton.ChangeAlignmation(StringAlignmation.MiddleCenter);
			this.LoginButton.ChangeAlignmation(StringAlignmation.MiddleCenter);
			//priorities:
			this.SandBoxPriority = SandBoxPriority.LowSandBox;
			this.TitleElement.ChangePriority(ElementPriority.Normal);
			this.UnameElement.ChangePriority(ElementPriority.Normal);
			this.PassElement.ChangePriority(ElementPriority.Normal);
			this.UnameInputElement.ChangePriority(ElementPriority.VeryHigh);
			this.PassInputElement.ChangePriority(ElementPriority.VeryHigh);
			this.ExitButton.ChangePriority(ElementPriority.High);
			this.LoginButton.ChangePriority(ElementPriority.High);
			//sizes:
			this.ChangeSize(Woto_WRate * (2f * (BigClient.Width / 5)), 
				Woto_HRate * (3f * (BigClient.Height / 5)));
			this.TitleElement.ChangeSize(Width - from_the_edge,
				Woto_HRate * ((Height / 4) - (SeparatorLine_Height / 2)));
			this.UnameElement.ChangeSize(Woto_WRate * (Width - 
				(3 * from_the_edge)),
				Woto_HRate * ((2 * (Height / 15)) -
				(SeparatorLine_Height / 2)));
			this.UnameInputElement.ChangeSize();
			this.UnameInputElement.ChangeSize(Woto_WRate * (this.UnameElement.Width - 
				(2 * from_the_edge)),
				Woto_HRate * this.UnameInputElement.Height);
			this.PassInputElement.ChangeSize();
			this.PassInputElement.ChangeSize(this.UnameInputElement.Rectangle.Size);
			this.PassElement.ChangeSize(this.UnameElement.Rectangle.Size);
			this.ExitButton.ChangeSize();
			this.LoginButton.ChangeSize();
			//ownering:
			this.TitleElement.SetOwner(this);
			this.UnameElement.SetOwner(this);
			this.UnameInputElement.SetOwner(this);
			this.PassInputElement.SetOwner(this);
			this.PassElement.SetOwner(this);
			this.ExitButton.SetOwner(this);
			this.LoginButton.SetOwner(this);
			//locations:
			this.CenterToScreen();
			this.TitleElement.ChangeLocation(from_the_edge / 2, 0);
			this.UnameElement.ChangeLocation(TitleElement.RealPosition.X +
				from_the_edge, 
				TitleElement.RealPosition.Y + TitleElement.Height + 
				SeparatorLine_Height);
			this.UnameInputElement.ChangeLocation(this.UnameElement.RealPosition.X +
				from_the_edge, this.UnameElement.RealPosition.Y + 
				this.UnameElement.Height + (from_the_edge / 2));
			this.PassElement.ChangeLocation(this.UnameElement.RealPosition.X,
				this.UnameInputElement.RealPosition.Y + 
				this.UnameInputElement.Height + from_the_edge);
			this.PassInputElement.ChangeLocation(this.UnameInputElement.RealPosition.X,
				this.PassElement.RealPosition.Y + 
				this.PassElement.Height + (from_the_edge / 2));
			this.ExitButton.ChangeLocation((this.Width / 2) -
				this.ExitButton.Width - (from_the_edge / 2),
				this.Height - this.ExitButton.Height -
				(2 * from_the_edge));
			this.LoginButton.ChangeLocation((this.Width / 2) +
				(from_the_edge / 2),
				this.ExitButton.RealPosition.Y);
			//rectangles:
			this.CalculateTexturesRect();
			//movements:
			this.TitleElement.ChangeMovements(ElementMovements.NoMovements);
			this.UnameElement.ChangeMovements(ElementMovements.NoMovements);
			this.PassElement.ChangeMovements(ElementMovements.NoMovements);
			//colors:
			//this.ChangeTint(Color.Transparent);
			this.TitleElement.ChangeForeColor(Color.White);
			this.UnameElement.ChangeForeColor(Color.White);
			this.PassElement.ChangeForeColor(Color.White);
			this.UnameInputElement.ChangeBorder(InputBorders.NoBorder);
			this.PassInputElement.ChangeBorder(InputBorders.NoBorder);
			this.ExitButton.ChangeBorder(ButtonColors.SpecialRed);
			this.LoginButton.ChangeBorder(ButtonColors.SpecialGreenYellow);
			//enableds:
			this.TitleElement.EnableOwnerMover();
			this.UnameElement.EnableOwnerMover();
			this.PassElement.EnableOwnerMover();
			this.UnameInputElement.Enable();
			this.PassInputElement.Enable();
			this.UnameInputElement.EnableMouseEnterEffect();
			this.PassInputElement.EnableMouseEnterEffect();
			this.ExitButton.EnableMouseEnterEffect();
			this.LoginButton.EnableMouseEnterEffect();
			this.PassInputElement.EnablePasswordMode();
			
			//texts:
			this.TitleElement.SetLabelText();
			this.UnameElement.SetLabelText();
			this.PassElement.SetLabelText();
			this.ExitButton.SetLabelText();
			this.LoginButton.SetLabelText();
			//images:
			this.ChangeImage(SandBoxBackGNameInRes, false);
			this.ChangeImageSizeMode(ImageSizeMode.Center);
			//applyAndShow:
			this.TitleElement.Apply();
			this.TitleElement.Show();
			this.UnameElement.Apply();
			this.UnameElement.Show();
			this.UnameInputElement.Apply();
			this.UnameInputElement.Show();
			this.PassElement.Apply();
			this.PassElement.Show();
			this.PassInputElement.Apply();
			this.PassInputElement.Show();
			this.ExitButton.Apply();
			this.ExitButton.Show();
			this.LoginButton.Apply();
			this.LoginButton.Show();
			//events:
			//---------------------------------------------
			//addRanges:

			//---------------------------------------------
			//finalBlow:
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
			base.Draw(gameTime, spriteBatch);
			//spriteBatch.Start();
			if (this.LeftTexture != null && !this.LeftTexture.IsDisposed)
			{
				spriteBatch.Draw(this.LeftTexture, this.LeftTextureRectangle, this.Tint);
			}
			if (this.LineTexture != null && !this.LineTexture.IsDisposed)
			{
				spriteBatch.Draw(this.LineTexture, this.LineTextureRectangle, this.Tint);
			}
			if (this.RightTexture != null && !this.RightTexture.IsDisposed)
			{
				spriteBatch.Draw(this.RightTexture, this.RightTextureRectangle, this.Tint);
			}
			//spriteBatch.Finish();
			// draw the manager
			this.Manager?.Draw(gameTime, spriteBatch);
		}
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		public override void ChangeLocation(float x, float y)
		{
			base.ChangeLocation(x, y);
			this.CalculateTexturesRect(false);
			this.Manager?.UpdateLocations();
		}
		public override void ChangeLocation(int x, int y)
		{
			base.ChangeLocation(x, y);
			this.CalculateTexturesRect(false);
			this.Manager?.UpdateLocations();
		}
		public override void ChangeLocation(Vector2 location)
		{
			base.ChangeLocation(location);
			this.CalculateTexturesRect(false);
			this.Manager?.UpdateLocations();
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region

		#endregion
		//-------------------------------------------------
		#region Set Method's Region

		#endregion
		//-------------------------------------------------
		#region ordinary Method's Region
		/// <summary>
		/// calculate the rectangles of the 
		/// <see cref="LeftTexture"/>, 
		/// <see cref="RightTexture"/>,
		/// <see cref="LineTexture"/> for their drawing.
		/// </summary>
		/// <param name="first">
		/// this value should be <c>true</c> if you are calling this mathod
		/// from <see cref="InitializeComponent()"/>;
		/// otherwise it should be false.
		/// </param>
		private void CalculateTexturesRect(bool first = true)
		{
			if (first)
			{
				const int start_point = from_the_edge * 2;
				const int off_set = (2 * from_the_edge / 5) + (4 * from_the_edge);
				int x, y, w, h;
				int c_y = (int)(Height / 6) - (SeparatorLine_Height / 2);
				int max1 = MathHelper.Max(this.LeftTexture.Height, this.RightTexture.Height);
				max1 = MathHelper.Max(max1, this.LineTexture.Height);
				int find_c = c_y + (max1 / 2);
				//---------------------------------------------
				w = this.LeftTexture.Width / 2;
				h = this.LeftTexture.Height / 2;
				x = start_point;
				y = find_c - (h / 2);
				this.LeftTextureRealLocation = new(x, y);
				this.LeftTextureRectangle = new(x, y, w, h);
				//---------------------------------------------
				w = (int)(this.Width - off_set) - (2 * w);
				h = this.LineTexture.Height / 2;
				x = x + this.LeftTextureRectangle.Width + (from_the_edge / 5);
				y = find_c - (h / 2);
				this.LineTextureRealLocation = new(x, y);
				this.LineTextureRectangle = new(x, y, w, h);
				//---------------------------------------------
				w = this.RightTexture.Width / 2;
				h = this.RightTexture.Height / 2;
				x = x + this.LineTextureRectangle.Width + (from_the_edge / 5);
				y = find_c - (h / 2);
				this.RightTextureRealLocation = new(x, y);
				this.RightTextureRectangle = new(x, y, w, h);
				//---------------------------------------------
				FinalBlow();
			}
			else
			{
				AnotherBlow();
			}

			void FinalBlow()
			{
				Point loc;
				//-----------------------------------------
				loc = this.Rectangle.Location + this.LeftTextureRectangle.Location;
				this.LeftTextureRectangle = new(loc, this.LeftTextureRectangle.Size);
				//-----------------------------------------
				loc = this.Rectangle.Location + this.LineTextureRectangle.Location;
				this.LineTextureRectangle = new(loc, this.LineTextureRectangle.Size);
				//-----------------------------------------
				loc = this.Rectangle.Location + this.RightTextureRectangle.Location;
				this.RightTextureRectangle = new(loc, this.RightTextureRectangle.Size);
				//-----------------------------------------
			}
			void AnotherBlow()
			{
				Point loc;
				//-----------------------------------------
				loc = this.Rectangle.Location + this.LeftTextureRealLocation;
				this.LeftTextureRectangle = new(loc, this.LeftTextureRectangle.Size);
				//-----------------------------------------
				loc = this.Rectangle.Location + this.LineTextureRealLocation;
				this.LineTextureRectangle = new(loc, this.LineTextureRectangle.Size);
				//-----------------------------------------
				loc = this.Rectangle.Location + this.RightTextureRealLocation;
				this.RightTextureRectangle = new(loc, this.RightTextureRectangle.Size);
				//-----------------------------------------
			}
		}
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		public override void Update(GameTime gameTime)
		{

		}
		protected override void UpdateGraphics()
		{

		}
		#endregion
		//-------------------------------------------------
		#region static Method's Region

		#endregion
		//-------------------------------------------------
	}
}
