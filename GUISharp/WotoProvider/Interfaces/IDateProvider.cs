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


namespace GUISharp.WotoProvider.Interfaces
{
    
    public interface IDateProvider<T1, T2, T3>
        where T1 : struct
        where T2 : class
        where T3 : class
    {
        //-------------------------------------------------
        #region Properties Region
        bool IsTicking { get; }
        T2 TheTrigger { get; }
        int TickingInterval { get; }
        bool IsDisposed { get; }
        bool IsUnlimited { get; }
        #endregion
        //-------------------------------------------------
        #region Method's Region
        T1 GetDateTime();
        void StartTicking();
        void StopTicking();
        void StartTicking(int milliseconds);
        void ChangeTicking(int miliseconds);
        void Dispose();
        T3 GetString(bool onlyHour);
        T3 GetForServer();
        bool IsEqual(IDateProvider<T1, T2, T3> provider);
        bool IsAfterMe(IDateProvider<T1, T2, T3> provider);
        bool IsBeforeMe(IDateProvider<T1, T2, T3> provider);
        #endregion
        //-------------------------------------------------
    }
}
