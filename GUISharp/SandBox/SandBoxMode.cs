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


namespace GUISharp.SandBox
{

    public enum SandBoxMode
    {
        MenuMode                    = 0,
        NoConnectionMode            = 1,
        UnknownErrorMode            = 2,
        ProfileMode                 = 3,
        ProfileEditMode             = 4,
        UpdateIsAvailbleMode        = 5,
        ServerOnBreakMode           = 6,
        UpdatingServerMode          = 7,
        UserNameOrPasswordWrongMode = 8,
        UserAlreadyExistMode        = 9,
        ConnectionClosedMode        = 10,
        Cant_LoadYourProfileMode    = 11,
        LoggedOutSuccessfullyMode   = 12,
        LogoutWarningMode           = 13,
        HallSandBoxMode             = 14,
        FirstStoryLineMode          = 15,
        ElementSelectionMode        = 16,
        KingdomInfoMode             = 17,
        CloseWarningMode            = 18,
    };

}
