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


namespace GUISharp.WotoProvider.Enums
{
	/// <summary>
	/// The button colors supported by GUISharp library.
	/// Please before using this enum, be aware how it works:
	/// 1. All the enum values will be started with their type:
	/// Special or Normal. (TODO: Round)
	/// Special borders are created for games, but you may want to
	/// use them anywhere. In front of Special name, you can see
	/// only one color name.
	/// 2. Normal borders, have two color name in front of
	/// them. something like: <see cref="NormalTransparentGreen"/>.
	/// It means this normal border, has a transparent background and
	/// Green border.
	/// <!--
	/// Since: GUISharp 1.0.9;
	/// By: ALiwoto;
	/// Last edit: Jun 29 10:03;
	/// Sign: ALiwoto;
	/// Verified: Yes;
	/// -->
	/// </summary>
	public enum ButtonColors
	{
		//-------------------------------------------------
		#region Special Region
		/// <summary>
		/// The WhiteSmoke Color.
		/// <!--
		/// texture: f_010320212340.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		SpecialWhiteSmoke = 0,
		/// <summary>
		/// The Red Color.
		/// <!--
		/// texture: f_010320212341.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		SpecialRed = 1,
		/// <summary>
		/// The GreenYellow Color.
		/// <!--
		/// texture: f_010320212342.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		SpecialGreenYellow = 2,
		/// <summary>
		/// The DarkGreen Color.
		/// <!--
		/// texture: f_010320212343.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		SpecialDarkGreen = 3,
		#endregion
		//-------------------------------------------------
		#region Normal Region
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalTransparentGreen = 4,
		/// <summary>
		/// A button with Green background and green borders.
		/// <!--
		/// texture: f_290620210265.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalGreenGreen = 5,
		/// <summary>
		/// A button with Black background and 
		/// whitesmoke borders.
		/// <!--
		/// texture: f_290620210266.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalBlackWhiteSmoke = 6,
		/// <summary>
		/// A button with transparent background and 
		/// whitesmoke borders.
		/// <!--
		/// texture: f_290620210267.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalTransparentWhiteSmoke = 7,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210268.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalWhiteWhiteSmoke = 8,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210269.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalGrayWhiteSmoke = 9,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210270.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalGrayLightSlateGray = 10,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210271.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalLightGrayBlack = 11,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210272.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalGrayBlack = 12,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210273.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalRedBlack = 13,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210274.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalWhiteBlack = 14,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210275.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalWheatBlack = 15,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210276.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalWhiteRed = 16,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210277.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalLightGrayRed = 17,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210278.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalGrayRed = 18,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210279.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalDarkGrayRed = 19,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalWhiteOrange = 20,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalLightGrayOrange = 21,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalGrayOrange = 22,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalDarkGrayOrange = 23,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalWhiteOrangered = 24,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalLightGrayOrangered = 25,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalGrayOrangered = 26,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalDarkGrayOrangered = 27,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalWhiteGreen = 28,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalLightGrayGreen = 29,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalGrayGreen = 30,
		/// <summary>
		/// A button with transparent background and green borders.
		/// <!--
		/// texture: f_290620210264.
		/// Since: GUISharp 1.0.9;
		/// By: ALiwoto;
		/// Last edit: Jun 29 10:03;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		NormalDarkGrayGreen = 31,
		#endregion
		//-------------------------------------------------
	}
}
