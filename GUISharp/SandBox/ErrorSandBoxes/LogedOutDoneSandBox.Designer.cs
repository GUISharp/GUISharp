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
using GUISharp.Controls;
using GUISharp.GUIObjects.Texts;
using GUISharp.Controls.Elements;
using GUISharp.GUIObjects.Graphics;

namespace GUISharp.SandBox.ErrorSandBoxes
{
    partial class LogedOutDoneSandBox
    {
        //-------------------------------------------------
        #region Initialize Method's Region
        private void InitializeComponent()
        {
            //---------------------------------------------
            //news:
            this.TitleElement = new FlatElement(this, true);
            this.BodyElement = new FlatElement(this, true);
            this.BackButton = new ButtonElement(this);
            //---------------------------------------------
            //loading:
            this.LeftTexture = BigRes.GetAsTexture2D(LEFT_BABYLONIA_ENTRANCE);
            this.RightTexture = BigRes.GetAsTexture2D(RIGHT_BABYLONIA_ENTRANCE);
            this.LineTexture = BigRes.GetAsTexture2D(LINE_BABYLONIA_ENTRANCE);
            //names:
            this.TitleElement.SetLabelName(SandBoxLabel1NameInRes);
            this.BodyElement.SetLabelName(SandBoxLabel2NameInRes);
            this.BackButton.SetLabelName(SandBoxButton1NameInRes);
            //status:
            this.TitleElement.SetStatus(1);
            this.BodyElement.SetStatus(1);
            this.BackButton.SetStatus(1);
            //fontAndTextAligns:
            this.TitleElement.ChangeFont(FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 18));
            this.BodyElement.ChangeFont(FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 16));
            this.BackButton.ChangeFont(FontManager.GetSprite(GUISharp_Fonts.GUISharp_tt_regular, 15));
            this.TitleElement.ChangeAlignmation(StringAlignmation.MiddleCenter);
            this.BodyElement.ChangeAlignmation(StringAlignmation.MiddleCenter);
            this.BackButton.ChangeAlignmation(StringAlignmation.MiddleCenter);
            //priorities:
            this.SandBoxPriority = SandBoxPriority.LowErrorSandBox;
            this.TitleElement.ChangePriority(ElementPriority.Normal);
            this.BodyElement.ChangePriority(ElementPriority.Normal);
            this.BackButton.ChangePriority(ElementPriority.High);
            //sizes:
            this.ChangeSize(2f * (UnderForm.Width / 5), UnderForm.Height / 3);
            this.TitleElement.ChangeSize(Width - from_the_edge,
                        (Height / 3) - (SeparatorLine_Height / 2));
            this.BodyElement.ChangeSize(Width - from_the_edge,
                (1 * (Height / 3)) - (SeparatorLine_Height / 2));
            this.BackButton.ChangeSize();
            //ownering:
            this.TitleElement.SetOwner(this);
            this.BodyElement.SetOwner(this);
            this.BackButton.SetOwner(this);
            //locations:
            this.CenterToScreen();
            this.TitleElement.ChangeLocation(from_the_edge / 2, 0);
            this.BodyElement.ChangeLocation(TitleElement.RealPosition.X, TitleElement.RealPosition.Y +
                TitleElement.Height + SeparatorLine_Height);
            this.BackButton.ChangeLocation((this.Width / 2) -
                (this.BackButton.Width / 2),
                this.BodyElement.RealPosition.Y + this.BodyElement.Height +
                (2 * from_the_edge));
            //rectangles:
            this.CalculateTexturesRect();
            //movements:
            this.TitleElement.ChangeMovements(ElementMovements.NoMovements);
            this.BodyElement.ChangeMovements(ElementMovements.NoMovements);
            //colors:
            this.TitleElement.ChangeForeColor(Color.White);
            this.BodyElement.ChangeForeColor(Color.White);
            this.BackButton.ChangeBorder(ButtonColors.SpecialDarkGreen);
            //enableds:
            this.TitleElement.EnableOwnerMover();
            this.BodyElement.EnableOwnerMover();
            this.BackButton.EnableMouseEnterEffect();
            //texts:
            this.TitleElement.SetLabelText();
            this.BodyElement.SetLabelText();
            this.BackButton.SetLabelText();
            //images:
            this._flat.ChangeImageSizeMode(ImageSizeMode.Center);
            this._flat.ChangeImageDefault(this.MyRes.GetString(SandBoxBackGNameInRes));
            //applyAndShow:
            this.TitleElement.Apply();
            this.TitleElement.Show();
            this.BodyElement.Apply();
            this.BodyElement.Show();
            this.BackButton.Apply();
            this.BackButton.Show();
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
            this._flat?.Draw(gameTime, spriteBatch);
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
                int c_y = (int)(Height / 4) - (SeparatorLine_Height / 2);
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
