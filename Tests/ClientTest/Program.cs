
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
			AppLogger.Log("Step1");
			MainClient test = new MainClient();
			AppLogger.Log("Step2");
			test.Start();
			AppLogger.Log("Step3");
		}
	}
}