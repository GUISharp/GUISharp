using System;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using GUISharp.Logging;
using GUISharp.Controls.Elements;
using GUISharp.SandBox;
using GUISharp.SandBox.ErrorSandBoxes;
using Color = Microsoft.Xna.Framework.Color;

// sudo apt install libgdiplus

namespace Tests
{
	partial class MainClient
	{
		protected override void InitializeComponents()
		{
			//this.ToggleFullScreen();
			//this.ChangeSize(700, 700);
			//this.ChangeLocation(10, 10);
			this.ChangeBackground(Texture2D.FromFile(this.GetDevice(), "/home/mrwoto/Ali/Programming/Projects/LTW/LTW-client/LTW-client/LTW/Resources/screens/first_loadoing_screen/BackEntry0.bin"));

			FlatElement test = new FlatElement(this);
			//LoginProfileSandBox l = new();
			ConnectionClosedSandBox l = new();
			ButtonElement b = new ButtonElement(this);
			FlatElement fImage = new FlatElement(this);
			InputElement testInput = new(this);
			test.ChangeSize(240, 140);
			fImage.ChangeSize(240, 140);
			testInput.ChangeSize();
			b.ChangeSize();
			test.ChangeLocation(10, 10);
			testInput.ChangeLocation(10, 20);
			fImage.ChangeLocation(400, 400);
			b.ChangeLocation(270, 270);
			test.ChangeFont(this.FontManager.GetSprite(GUISharp.GUIObjects.Texts.GUISharp_Fonts.old_story_bold, 0x40));
			fImage.ChangeFont(this.FontManager.GetSprite(GUISharp.GUIObjects.Texts.GUISharp_Fonts.old_story_bold, 0x40));
			testInput.ChangeFont(this.FontManager.GetSprite(GUISharp.GUIObjects.Texts.GUISharp_Fonts.old_story_bold, 24));
			b.ChangeFont(this.FontManager.GetSprite(GUISharp.GUIObjects.Texts.GUISharp_Fonts.noto_sans_JP, 45));
			test.ChangeText("hello!");
			fImage.ChangeText("hello!");
			b.ChangeText("test button!");
			b.ChangeSize(2);
			b.ChangeBorder(GUISharp.WotoProvider.Enums.ButtonColors.NormalGrayWhiteSmoke);
			b.ChangeForeColor(Microsoft.Xna.Framework.Color.IndianRed);
			testInput.ChangeBorder(GUISharp.WotoProvider.Enums.InputBorders.Goldenrod);
			test.ChangeForeColor(Microsoft.Xna.Framework.Color.Red);
			fImage.ChangeForeColor(Microsoft.Xna.Framework.Color.Red);
			testInput.ChangeForeColor(Color.Red);
			test.ChangeBackColor(Microsoft.Xna.Framework.Color.LightGoldenrodYellow);
			fImage.ChangeBackColor(Microsoft.Xna.Framework.Color.LightGoldenrodYellow);
			test.ChangeAlignmation(GUISharp.Controls.StringAlignmation.TopRight);
			fImage.ChangeAlignmation(GUISharp.Controls.StringAlignmation.TopRight);
			testInput.ChangeAlignmation(GUISharp.Controls.StringAlignmation.MiddleCenter);
			b.ChangeAlignmation(GUISharp.Controls.StringAlignmation.MiddleCenter);
			test.ChangePriority(ElementPriority.VeryLow);
			testInput.ChangePriority(ElementPriority.SuperHigh);
			fImage.ChangePriority(ElementPriority.VeryHigh);
			b.ChangePriority(ElementPriority.VeryLow);
			test.ChangeMovements(ElementMovements.VerticalHorizontalMovements);
			fImage.ChangeMovements(ElementMovements.VerticalHorizontalMovements);
			//test.EnableOwnerMover();
			b.EnableMouseEnterEffect();
			testInput.EnableMouseEnterEffect();
			


			Image image = new Bitmap(100, 100);
			Graphics g = Graphics.FromImage(image);
			g.DrawLine(new Pen(System.Drawing.Color.Aqua), new(1, 1), new(10, 10));
			g.Save();
			MemoryStream m = new MemoryStream();
			image.Save(m, System.Drawing.Imaging.ImageFormat.Png);



			test.Enable();
			test.Apply();
			test.Show();
			l.Enable();
			l.Apply();
			l.Show();
			fImage.Enable();
			fImage.Apply();
			fImage.Show();
			testInput.Apply();
			testInput.Show();
			testInput.Enable();
			testInput.Focus(true);
			//Texture2D image = Texture2D.FromFile(this.GetDevice(), "/home/mrwoto/Pictures/JPEG-scaled.jpg");
			//Texture2D imageT = Texture2D.FromFile(this.GetDevice(), "/home/mrwoto/Ali/Programming/profiles/aliwoto/aliwoto/resources/801872469010808873.gif");
			Texture2D imageT = Texture2D.FromStream(this.GetDevice(), m);
			fImage.ChangeImage(imageT);



			b.Enable();
			b.Show();
			b.Apply();
			b.Click += Button1_Click;
			AppLogger.Enabled = true;
			l.RightDown += (object sender, EventArgs e) =>
			{
				AppLogger.Log("RightDown");
			};
			l.MouseMove += (object sender, EventArgs e) =>
			{
				AppLogger.Log("Moved");
			};
			b.RightClick += (object sender, EventArgs e) =>
			{
				AppLogger.Log("RightClick");
			};
			l.LeftUp += (object sender, EventArgs e) =>
			{
				AppLogger.Log("LeftUp");
			};
			
			this.ElementManager.AddRange(testInput, l);
			b.ClickAsync += (object sender, EventArgs e) =>
			{
				var s = Microsoft.Xna.Framework.Media.Song.FromUri("test", new("Egoist - Departures.mp3", UriKind.Relative));
				Microsoft.Xna.Framework.Media.MediaPlayer.Play(s);
			};
			
		}



		private void Button1_Click(object sender, EventArgs e)
		{
			AppLogger.Log("Click");
		}
	}
}