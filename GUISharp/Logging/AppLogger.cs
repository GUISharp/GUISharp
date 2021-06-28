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
				Console.Write(d.ToString() + ": ");
				Console.WriteLine(obj);
			}
		}
		#endregion
		//-------------------------------------------------
	}
}