// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

#if __WINDOWS__

using System;
using System.IO;
using GUISharp.Logging;
using GUISharp.GUIObjects.Resources;

namespace GUISharp.Controls.Music
{
	public sealed partial class WotoMusic : IRes, IDisposable
	{
		//-------------------------------------------------
		#region Constants Region
		public const string MusicToStringString =
			"Woto Music - Music Name: ";
		#endregion
		//-------------------------------------------------
		//-------------------------------------------------
		#region Properties Region
		public string Name { get; set; }
		public WotoRes MyRes { get; set; }
		public Stream TheStream { get; private set; }
		public bool IsDisposed { get; private set; }
		#endregion
		//-------------------------------------------------
		#region Constructors Region
		private WotoMusic(string path)
		{
			try
			{
				TheStream = File.OpenRead(path);
			}
			catch (Exception ex)
			{
				AppLogger.Log(ex);
				return;
			}
			IsDisposed = TheStream == null;
			InitializeComponent();
		}
		private WotoMusic(Stream stream)
		{
			if (stream == null)
			{
				IsDisposed = true;
				return;
			}
			TheStream = stream;
			InitializeComponent();
		}
		private WotoMusic(byte[] buffers)
		{
			if (buffers == null)
			{
				return;
			}
			try
			{
				TheStream = new MemoryStream(buffers);
			}
			catch (Exception ex)
			{
				AppLogger.Log(ex);
				return;
			}
			InitializeComponent();
		}
		#endregion
		//-------------------------------------------------
		#region Ordinary Methods Region
		public void Dispose()
		{
			IsDisposed = true;
			TheStream?.Dispose();
		}
		public Stream GetStream()
		{
			return TheStream;
		}
		public bool HasFileStream()
		{
			return TheStream is FileStream;
		}
		#endregion
		//-------------------------------------------------
		#region static Methods Region
		public static WotoMusic GenerateWotoMusic(string path)
		{
			return new WotoMusic(path);
		}
		#endregion
		//-------------------------------------------------
		#region Overrided Methods Region
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		public override string ToString()
		{
			return MusicToStringString + Name;
		}
		#endregion
		//-------------------------------------------------
		#region Operators Region
		public static bool operator ==(WotoMusic left, WotoMusic right)
		{
			if(left is null)
			{
				return right is null;
			}
			else if(right is null)
			{
				return false;
			}
			if (left.Name == null || right.Name == null)
			{
				return left.Equals(right) ||
					left.TheStream == left.TheStream;
			}

			return left.Name == right.Name ||
				left.TheStream == left.TheStream;
		}

		public static bool operator !=(WotoMusic left, WotoMusic right)
		{
			if (left is null)
			{
				return !(right is null);
			}
			else if (right is null)
			{
				return true;
			}
			if (left.Name == null || right.Name == null)
			{
				return !left.Equals(right) &&
					left.TheStream != left.TheStream;
			}

			return left.Name != right.Name &&
				left.TheStream != left.TheStream;
		}
		#endregion
		//-------------------------------------------------
	}
}

#endif //__WINDOWS__