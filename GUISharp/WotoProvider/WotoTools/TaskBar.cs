// WotoProvider (for GUISharp)
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
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


#if __WINDOWS__
using System.Runtime.InteropServices;

namespace GUISharp.WotoProvider.WotoTools
{
	public class Taskbar
	{
		/// <summary>
		/// Checking status of Showing of TaskBar in windows.
		/// true: it is showing , false: it is hide.
		/// </summary>
		public static bool IsShowing { get; set; } = true;
		[DllImport("user32.dll")]
		private static extern int FindWindow(string className, string windowText);

		[DllImport("user32.dll")]
		private static extern int ShowWindow(int hwnd, int command);

		[DllImport("user32.dll")]
		public static extern int FindWindowEx(int parentHandle, int childAfter, string className, int windowTitle);

		[DllImport("user32.dll")]
		private static extern int GetDesktopWindow();

		private const int SW_HIDE = 0;
		private const int SW_SHOW = 1;

		protected static int Handle
		{
			get
			{
				return FindWindow("Shell_TrayWnd", "");
			}
		}

		protected static int HandleOfStartButton
		{
			get
			{
				int handleOfDesktop = GetDesktopWindow();
				int handleOfStartButton = FindWindowEx(handleOfDesktop, 0, "button", 0);
				return handleOfStartButton;
			}
		}

		private Taskbar()
		{
			// hide ctor
		}

		public static void Show()
		{
			IsShowing = true;
			ShowWindow(Handle, SW_SHOW);
			ShowWindow(HandleOfStartButton, SW_SHOW);
		}

		public static void Hide()
		{
			IsShowing = false;
			ShowWindow(Handle, SW_HIDE);
			ShowWindow(HandleOfStartButton, SW_HIDE);
		}
	}
}
#endif