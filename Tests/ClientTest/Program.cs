
using System;
using GUISharp.Logging;

namespace Tests
{
	public class ClientTest1
	{
		[STAThread]
		public static void Main()
		{
			AppLogger.Enabled = true;
			MainClient test = new MainClient();
			test.Start();
		}
	}
}