
using System;

namespace Tests
{
	public class ClientTest1
	{
		[STAThread]
		public static void Main()
		{
			GUIVoid.Client.GUIClient test = new();
			test.Start();
		}
	}
}