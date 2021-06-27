
using System;

namespace Tests
{
	public class ClientTest1
	{
		[STAThread]
		public static void Main()
		{
			GUIVoid.Client.GUIClient test = new();
			test.Width = 1000;
			test.Height = 600;
			test.ChangeLocation(0, 0);
			test.MultipleSize(1.1f);
			test.Start();
		}
	}
}