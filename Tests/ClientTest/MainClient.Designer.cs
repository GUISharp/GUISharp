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
			test.ChangeSize(240, 140);
			test.ChangeLocation(10, 10);
			test.ChangeFont(this.FontManager.GetSprite(GUISharp.GUIObjects.Texts.GUISharp_Fonts.old_story_bold, 0x40));
			test.ChangeText("hello!");
			test.ChangeForeColor(Microsoft.Xna.Framework.Color.Red);
			test.ChangeBackColor(Microsoft.Xna.Framework.Color.LightGoldenrodYellow);
			test.ChangeAlignmation(GUISharp.Controls.StringAlignmation.TopRight);
			test.ChangePriority(ElementPriority.VeryLow);
			test.ChangeMovements(ElementMovements.VerticalHorizontalMovements);
			//test.EnableOwnerMover();
			test.Enable();
			test.Apply();
			test.Show();
			
			this.ElementManager.Add(test);
		}
	}
}