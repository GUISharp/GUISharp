// Copyright (C) ALiwoto 2019 - 2020
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using System;
using GUISharp.GUIObjects.WMath;

namespace GUISharp.Controls.Music
{
	public sealed class Album : ListW<WotoMusic>, IDisposable
	{
		//-------------------------------------------------
		#region Constants Region
		public const string AlbumToStringString =
			"Woto Album - Music Count: ";
		#endregion
		//-------------------------------------------------
		#region Properties Region
		#endregion
		//-------------------------------------------------
		#region Constructors Region
		private Album(WotoMusic[] theMusics) : base(theMusics)
		{
			;
		}
		#endregion
		//-------------------------------------------------
		#region this[] Region
		public WotoMusic this[uint index]
		{
			get
			{
				if (index < Length)
				{
					return this[(int)index];	
				}
				return null;
			}
			set
			{
				if (index >= Length)
				{
					return;
				}
				this[(int)index] = value;
			}
		}
		#endregion
		//-------------------------------------------------
		#region Ordinary Offline Methods
		public void ReplaceMusic(uint index, WotoMusic theNewMusic)
		{
			// just in case check it :/
			// yeah I know double check if not good tho...
			if (index >= Length)
			{
				return;
			}
			this[index] = theNewMusic;
		}
		/// <summary>
		/// Adding a new music to the end of 
		/// the music list of this Album.
		/// </summary>
		/// <param name="theNewMusic">
		/// the new path of the specified music.
		/// NOTICE: if the music already exists in the
		/// music list, the music won't be added unles you set the
		/// second param to true.
		/// </param>
		/// <param name="addAnyway">
		/// use this to specialize to whether add the music
		/// to the music list of this album even if it already exists
		/// in the music list.
		/// the default value of this parameter is false.
		/// </param>
		public void AddMusic(WotoMusic theNewMusic, bool addAnyway = false)
		{
			if (!addAnyway)
			{
				if (Exists(theNewMusic))
				{
					return;
				}
			}
			Add(theNewMusic);
		}
		/// <summary>
		/// Add a music to the specified index 
		/// in the music list of this Album.
		/// </summary>
		/// <param name="index">
		/// the index of the new music.
		/// please calculate the index of the musics from zero,
		/// which means if you enter the 0 for this parameter,
		/// the music will be added to the first of the music list
		/// of this Album.
		/// </param>
		/// <param name="theNewMusic">
		/// the new path of the specified music.
		/// NOTICE: if the music already exists in the
		/// music list, the music won't be added unles you set the
		/// second param to true.
		/// </param>
		/// <param name="addAnyway">
		/// use this to specialize to whether add the music
		/// to the music list of this album even if it already exists
		/// in the music list.
		/// the default value of this parameter is false.
		/// </param>
		public void AddMusic(uint index, WotoMusic theNewMusic, bool addAnyway = false)
		{
			if (!addAnyway)
			{
				if (Exists(theNewMusic))
				{
					return;
				}
			}
			if (index < Length && index >= (uint)default)
			{
				Insert((int)index, theNewMusic);
			}
		}
		/// <summary>
		/// Determine whether a specified music path exists in the
		/// list of this Album or not.
		/// </summary>
		/// <param name="music">
		/// the specified music.
		/// </param>
		/// <returns>
		/// <c>true</c> if the music already exists in the album,
		/// otherwise false.
		/// </returns>
		public override bool Exists(WotoMusic music)
		{
			return base.Exists(music);
		}
		public void Dispose()
		{
			foreach (var music in this)
			{
				music?.Dispose();
			}
		}
		#endregion
		//-------------------------------------------------
		#region Overrided Methods Region
		public override string ToString()
		{
			return AlbumToStringString + Length;
		}
		#endregion
		//-------------------------------------------------
		#region static Methods Region
		public static Album GenerateAlbum(params WotoMusic[] theMusics)
		{
			return new Album(theMusics);
		}
		#endregion
		//-------------------------------------------------
	}
}
