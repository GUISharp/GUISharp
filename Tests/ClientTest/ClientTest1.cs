
using System;

namespace Tests
{
	public class ClientTest1
	{
		[STAThread]
		public static void Main()
		{
			MainClient test = new MainClient();
			test.Start();
		}
	}
}