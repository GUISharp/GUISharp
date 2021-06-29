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


namespace GUISharp.GUIObjects.Texts
{
    public struct CharacterRange
    {
        //-------------------------------------------------
        #region Properties Region
        public char Start { get; private set; }
        public char End { get; private set; }
        #endregion
        //-------------------------------------------------
        #region static field's Region
        public static readonly CharacterRange BasicLatin = 
            new CharacterRange((char)0x0020, (char)0x007F);

        public static readonly CharacterRange Latin1Supplement =
            new CharacterRange((char)0x00A0, (char)0x00FF);
        
        public static readonly CharacterRange LatinExtendedA =
            new CharacterRange((char)0x0100, (char)0x017F);

        public static readonly CharacterRange LatinExtendedB =
            new CharacterRange((char)0x0180, (char)0x024F);

        public static readonly CharacterRange Cyrillic = 
            new CharacterRange((char)0x0400, (char)0x04FF);

        public static readonly CharacterRange CyrillicSupplement =
            new CharacterRange((char)0x0500, (char)0x052F);

        public static readonly CharacterRange Hiragana =
            new CharacterRange((char)0x3040, (char)0x309F);

        public static readonly CharacterRange Katakana =
            new CharacterRange((char)0x30A0, (char)0x30FF);

        public static readonly CharacterRange Kanji =
            new((char)0x4E00, (char)0x9FBF);
			// 4e00-9fbf, 3040-309f and 30a0-30ff
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public CharacterRange(char start, char end)
        {
            Start = start;
            End = end;
        }
        public CharacterRange(char single) : this(single, single)
        {
        }
        #endregion
        //-------------------------------------------------
        #region GetMethod's Region
        public bool Contains(char c)
        {
            return c >= Start && c <= End;
        }
        #endregion
        //-------------------------------------------------
    }
}
