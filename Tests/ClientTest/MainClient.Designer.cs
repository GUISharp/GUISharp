using System;
using GUISharp.Controls.Elements;

namespace Tests
{
	partial class MainClient
	{
		protected override void InitializeComponents()
		{
			this.ChangeSize(700, 700);
			this.ChangeLocation(10, 10);

			FlatElement test = new FlatElement(this);
			ButtonElement b = new ButtonElement(this);
			test.ChangeSize(240, 140);
			b.ChangeSize();
			test.ChangeLocation(10, 10);
			b.ChangeLocation(270, 270);
			test.ChangeFont(this.FontManager.GetSprite(GUISharp.GUIObjects.Texts.GUISharp_Fonts.old_story_bold, 0x40));
			b.ChangeFont(this.FontManager.GetSprite(GUISharp.GUIObjects.Texts.GUISharp_Fonts.old_story_bold, 30));
			test.ChangeText("hello!");
			b.ChangeText("test button!");
			b.ChangeBorder(GUISharp.WotoProvider.Enums.ButtonColors.DarkGreen);
			test.ChangeForeColor(Microsoft.Xna.Framework.Color.Red);
			test.ChangeBackColor(Microsoft.Xna.Framework.Color.LightGoldenrodYellow);
			test.ChangeAlignmation(GUISharp.Controls.StringAlignmation.TopRight);
			b.ChangeAlignmation(GUISharp.Controls.StringAlignmation.MiddleCenter);
			test.ChangePriority(ElementPriority.VeryLow);
			b.ChangePriority(ElementPriority.VeryHigh);
			test.ChangeMovements(ElementMovements.VerticalHorizontalMovements);
			//test.EnableOwnerMover();
			b.EnableMouseEnterEffect();
			test.Enable();
			test.Apply();
			test.Show();
			b.Enable();
			b.Show();
			b.Apply();
			b.Click += Button1_Click;
			b.RightDown += (object sender, EventArgs e) =>
			{
				Console.WriteLine("RightDown");
			};
			b.RightClick += (object sender, EventArgs e) =>
			{
				Console.WriteLine("RightClick");
			};
			b.LeftClick += (object sender, EventArgs e) =>
			{
				Console.WriteLine("LeftClick");
			};
			this.ElementManager.AddRange(test, b);
			b.ClickAsync += (object sender, EventArgs e) =>
			{
				;
			};
		}
		private void Button1_Click(object sender, EventArgs e)
		{
			Console.WriteLine("Click");
		}
	}
}