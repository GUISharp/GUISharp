/*
 * This file is part of GUISharp Project (https://github.com/GUISharp/GUISharp).
 * Copyright (c) 2021 GUISharp Authors.
 *
 * This library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 3.
 *
 * This library is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this source code of library. 
 * If not, see <http://www.gnu.org/licenses/>.
 */

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