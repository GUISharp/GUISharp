// GUISharp Project
// Copyright (C) 2019 - 2021 ALiwoto
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO.MemoryMappedFiles;
using System.Globalization;
using GUISharp.WotoProvider;
using GUISharp.WotoProvider.Interfaces;
using GUISharp.Client;
using GUISharp.Controls;
using GUISharp.Security;
using DEType =  GUISharp.WotoProvider.Interfaces.IDECoderProvider
	<GUISharp.Security.StrongString, GUISharp.Security.QString>;

namespace GUISharp.Constants
{
#pragma warning disable CA1401
	[ComVisible(false)]
	public static class ThereIsGConstants
	{
		public struct Actions
		{
			//[DllImport("user32.dll")]
			//public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
			/// <summary>
			/// check if the current process 
			/// </summary>
			/// <returns>
			/// true if the current proccess is the single-one, otherwise false.
			/// </returns>
			internal static bool IsSingleOne()
			{
				if (Universe.IsUnix)
				{
					return IsSingleOneLinux();
				}
				else if (Universe.IsWindows)
				{
					return IsSingleOneWindows();
				}
				return false; // not supported for now.
			}
			internal static bool IsSingleOneLinux()
			{
				var _p = Path.Here + GClient.MMF_NAME;
				if (File.Exists(_p))
				{
					try
					{
						Universe._mapped = new FileStream(_p,
							FileMode.Open, FileAccess.ReadWrite, FileShare.None);
						return true;
					}
					catch (Exception _e)
					{
						if (_e is IOException _io)
						{
							return false;
						}
						//Console.WriteLine(_e.Message);
						throw;
					}
				}
				else
				{
					return true;
				}
			}
			internal static bool IsSingleOneWindows()
			{
				try
				{
#pragma warning disable CA1416
					using (AppSettings.Memory = MemoryMappedFile.OpenExisting(GClient.MMF_NAME))
					{
						if (AppSettings.Memory == null)
						{
							return true;
						}
					}
#pragma warning restore CA1416
					return false;
				}
				catch (FileNotFoundException)
				{
					return true;
				}
				catch(Exception e)
				{
					Console.WriteLine(e);
					return false;
				}
			}

			/// <summary>
			/// create a single-one provider.
			/// </summary>
			/// <returns>
			/// true if success, otherwise false.
			/// </returns>
			internal static bool CreateSingleOne()
			{
				if (Universe.IsUnix)
				{
					return CreateSingleOneLinux();
				}
				else if (Universe.IsWindows)
				{
					return CreateSingleOneWindows();
				}
				return false;
			}
			internal static bool CreateSingleOneLinux()
			{
				var _p = Path.Here + GClient.MMF_NAME;
				try
				{
					if (Universe._mapped == null)
					{
						Universe._mapped ??= File.Create(_p);
						Universe._mapped?.Lock(0, 0);
					}
					return true;
				}
				catch (Exception _e) 
				{
					Debug.Print(_e.ToString());
					Console.WriteLine(_e.Message);
					return false;
				}
			}
			internal static bool CreateSingleOneWindows()
			{
				try
				{
					AppSettings.Memory = MemoryMappedFile.CreateNew(GClient.MMF_NAME, 10000);
					var s = AppSettings.Memory.CreateViewStream();
					BinaryWriter writer = new BinaryWriter(s);
					writer.Write(AppSettings.CompanyName);
					writer.Close();
					writer.Dispose();
					s.Dispose();
					return true;
				}
				catch
				{
					return false;
				}
			}
			internal static IDateProvider<DateTime, Trigger, StrongString> ToDateTime(StrongString strongString)
			{
				throw new NotImplementedException();
			}
		}
		public struct Path
		{
			//---------------------------------------------
			/// <summary>
			/// The Application name.
			/// </summary>
			public const string App_Name = "GUISharp";
			/// <summary>
			/// The Format Flies.
			/// </summary>
			public const string FilesEnd_Name = ".GUISharp";
			/// <summary>
			/// Use it in the <see cref="SerializableAttribute"/> Classes.
			/// </summary>
			public const string NotSet = "notSet";

			/// <summary>
			/// The Double Slash that you should use before the names in paths.
			/// if and only if the os is Unix.
			/// </summary>
			public const string DoubleSlashLinux = "/";
			/// <summary>
			/// The Double Slash that you should use before the names in paths.
			/// if and only if the os is windows.
			/// </summary>
			public const string DoubleSlashWin = @"\";
			public const string Content = "GUIContent";
			//---------------------------------------------
			public static string DoubleSlash
			{
				get
				{
					if (Universe.IsWindows)
					{
						return DoubleSlashWin;
					}
					else if (Universe.IsUnix)
					{
						return DoubleSlashWin;
					}
					return null;
				}
			}
			public static string Here
			{
				//get => Directory.GetCurrentDirectory();
				get => AppContext.BaseDirectory;
			}
			public static string Datas_Path
			{
				get => Here + Content;
			}
			public static string AccountInfo_File_Path { get; internal set; }
			public static string ProfileInfo_File_Path { get; internal set; }
			public static string Profile_Folder_Path { get; internal set; }
			//---------------------------------------------
		}
		public struct ResourcesName
		{
			/// <summary>
			/// With Separate Character, please do NOT use it again.
			/// </summary>
			public const string End_Res_Name = Separate_Character + "Name";
			/// <summary>
			/// The name of FirstLable for Form1 in the Resources without _name;
			/// </summary>
			public const string FirstLabelNameInRes = "Label1";
			public const string Separate_Character = "_";
			//--------------------Labels----------------------------------

			//----------------------------------------------
			public const string Item1ForMainMenuNameInRes = "Item1";
			public const string Item2ForMainMenuNameInRes = "Item2";
			public const string Item3ForMainMenuNameInRes = "Item3";
			public const string Item4ForMainMenuNameInRes = "Item4";
			//-------------------Buttons----------------------------------
		}
		public struct Forming
		{
			internal static GClient GClient
			{
				get
				{
					return AppSettings.GClient;
				}
				set
				{
					AppSettings.GClient = value;
				}
			}
		}
		public struct AppSettings
		{
			//--------------------------------------
			//-----------------
			/// <summary>
			/// E = English, J = Japanese
			/// </summary>
			public static char Language { get; set; } = 'E';
			/// <summary>
			/// Please Notice that this is not an Index,
			/// so it should start with 1,
			/// and also the maximum value of this int would be: 
			/// <see cref="MAXIMUM_PROFILE"/>. <code></code>
			/// Use it in ???
			/// </summary>
			public static int CurrentProfileNum { get; set; } = 1;
			
			public static CultureInfo CultureInfo { get; set; } = new CultureInfo("en-US");
			//-----------------
			//--------------------------------------
			public static bool IsShowingClosedSandBox { get; set; } = false;
			//public static NoInternetConnectionSandBox ConnectionClosedSandBox { get; set; }
			//--------------------------------------
			//-----------------
			public const string AppVersion = "1.1.1.5014";
			public const string AppVerCodeName = "5014Re";
			public const string AppVerToken = "";
			public const string CompanyName = "wotoTeam";
			public const string CompanyCopyRight = "© wotoTeam - 2021";
			public const string DateTimeFormat = "ddd, dd MMM yyyy HH:mm:ss 'GMT'";
			public const string TimeFormat = "HH:mm:ss";
			public const string TimeRequestURL = @"https://microsoft.com";
			public const string ConnectionURL = @"http://google.com/generate_204";
			public const string DateHeaderKey = "date";
			//-----------------
			public const int MAXIMUM_PROFILE = 64;
			//-----------------
			public const StringSplitOptions SplitOption = StringSplitOptions.RemoveEmptyEntries;
			//-------------------------------------
			/// <summary>
			/// Determine whether <see cref="GlobalTiming"/>, has been set with 
			/// interner: <see cref="TimeRequestURL"/>, or not.
			/// </summary>
			public static bool DateTimeSettedWithNet { get; set; } = false;
			/// <summary>
			/// The Time Worker.
			/// </summary>
			public static Trigger TimeWorker { get; set; } = new Trigger();
			/// <summary>
			/// Global Timing worker.
			/// it will add seconds to the 
			/// <see cref="GlobalTiming"/>
			/// </summary>
			public static Trigger GlobalTimingWorker { get; set; }
			public static MemoryMappedFile Memory { get; internal set; }
			/// <summary>
			/// Global Date and Time Parameter.
			/// </summary>
			public static IDateProvider<DateTime, Trigger, StrongString> GlobalTiming { get; set; }
			/// <summary>
			/// the default time out for database.
			/// </summary>
			public static TimeSpan DefaultDataBaseTimeOut { get; } = new TimeSpan(0, 0, 6);
			/// <summary>
			/// The Game Client of the game.
			/// this is after the main form.
			/// </summary>
			internal static GClient GClient { get; set; }
			public static WotoCreation WotoCreation { get; set; }
			//--------------------------------------
			public static DEType DECoder
			{
				get
				{
					if (deCoder == null)
					{
						deCoder = new DECoder();
					}
					return deCoder;
				}
			}
			private static DEType deCoder;
			//--------------------------------------
			/// <summary>
			/// The Spaces between two GameControls in the game.
			/// the unit is pixel.
			/// </summary>
			public const int Between_GameControls = 4;
			//--------------------------------------
		}
	}
#pragma warning restore CA1401
}
