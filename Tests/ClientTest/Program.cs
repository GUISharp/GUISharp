
using System;
using System.IO;
using GUISharp.Logging;

namespace Tests
{
	public class ClientTest1
	{
		[STAThread]
		public static void Main()
		{
			AppLogger.Enabled = true;
			if (File.Exists(AppContext.BaseDirectory + "xsel"))
			{
				AppLogger.Log("Yes");
			}
			else
			{
				AppLogger.Log(AppContext.BaseDirectory + "/xsel");
			}
			MainClient test = new MainClient();
			test.Start();
		}
	}
}