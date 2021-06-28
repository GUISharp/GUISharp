using System;

namespace GUISharp.Logging
{
	public static class AppLogger
	{
		//-------------------------------------------------
		#region static Properties Region
		public static bool Enabled { get; set; }
		#endregion
		//-------------------------------------------------
		#region ordinary Method's Region
		public static void Log(params object[] objs)
		{
			if (!Enabled || objs == null)
			{
				return;
			}
			var d = DateTime.Now;
			foreach (var obj in objs)
			{
				switch (obj)
				{
					case Exception ex:
					{
						LogException(ex);
						break;
					}
					default:
					{
						Console.Write(d.ToString() + ": ");
						Console.WriteLine(obj);
						break;
					}
				}
			}
		}
		public static void LogException(Exception ex)
		{
			Console.WriteLine("An exception is here: ");
			Console.WriteLine("With Stack Trace: ");
			Console.WriteLine(ex.StackTrace);
			Console.WriteLine("With Source: ");
			Console.WriteLine(ex.Source);
			Console.WriteLine("With Message: ");
			Console.WriteLine(ex.Message);
		}
		#endregion
		//-------------------------------------------------
	}
}