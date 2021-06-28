using GUISharp.Controls.Elements;

namespace Tests
{
	partial class MainClient
	{
		protected override void InitializeComponents()
		{
			this.ChangeSize(300, 300);
			this.ChangeLocation(10, 10);

			FlatElement test = new FlatElement(this);
			test.ChangeSize(220, 120);
			test.ChangeLocation(0, 0);
			test.ChangeFont(this.FontManager.GetSprite(GUISharp.GUIObjects.Texts.GUISharp_Fonts.noto_sans_JP, 20));
			test.ChangeText("hello!");
			test.ChangeForeColor(Microsoft.Xna.Framework.Color.Aqua);
			test.ChangeBackColor(Microsoft.Xna.Framework.Color.Blue);
			test.Enable();
			test.Apply();
			test.Show();
			this.ElementManager.Add(test);
		}
	}
}