﻿// WotoProvider (for GUISharp)
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


namespace GUISharp.WotoProvider.Interfaces
{
    public interface IStringProvider<T> where T: class
    {
        //-------------------------------------------------
        #region this Region
        char this[int index] { get; }
        #endregion
        //-------------------------------------------------
        #region Properties Region
        int Length { get; }
        bool IsDisposed { get; }
        #endregion
        //-------------------------------------------------
        #region Methods Region
		/// <summary>
		/// 
		/// 
		/// </summary>
        void ChangeValue(string anotherValue);
		/// <summary>
		/// 
		/// 
		/// </summary>
        string GetValue();
		/// <summary>
		/// 
		/// 
		/// </summary>
        void Dispose();
		/// <summary>
		/// 
		/// 
		/// </summary>
        int IndexOf(string value);
		/// <summary>
		/// 
		/// 
		/// </summary>
        int IndexOf(char value);
		/// <summary>
		/// 
		/// 
		/// </summary>
        int IndexOf(T value);
		/// <summary>
		/// 
		/// 
		/// </summary>
        int ToInt32();
		/// <summary>
		/// 
		/// 
		/// </summary>
        ushort ToUInt16();
		/// <summary>
		/// 
		/// 
		/// </summary>
        ulong ToUInt64();
		/// <summary>
		/// 
		/// 
		/// </summary>
        float ToSingle();
		/// <summary>
		/// 
		/// 
		/// </summary>
        T GetStrong();
		/// <summary>
		/// 
		/// 
		/// </summary>
        T[] Split(params string[] separator);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T[] Split(params T[] separator);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Substring(int startIndex, int length);
		
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Substring(int startIndex);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Remove(char value);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Remove(int startIndex, int count);
		T RemoveSpecial();
		/// <summary>
		/// simply appends a character to the end of the 
		/// string provider.
		/// </summary>
		/// <param name="value"> 
		/// the character which to append.
		/// </param>
        T Append(char value);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(char value, bool _check);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(string value);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(string value, bool _check);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(string value, int count);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(string value, int count, bool _check);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(params string[] values);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(bool _check, params string[] values);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(T value);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(T value, bool _check);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(T value, int count);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(T value, int count, bool _check);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(params T[] value);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(bool _check, params T[] value);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(char value, int count);
		/// <summary>
		/// 
		/// 
		/// </summary>
        T Append(char value, int count, bool _check);
		/// <summary>
		/// 
		/// 
		/// </summary>
		bool HasSpecial();
		bool IsSignedChar(int _index);
        #endregion
        //-------------------------------------------------
    }
}
