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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FontStashSharp;
using GUISharp.Client;
using GUISharp.Security;
using GUISharp.Constants;
using GUISharp.Controls.Elements;
using GUISharp.WotoProvider.Enums;

namespace GUISharp.SandBox
{
	public abstract partial class SandBoxBase : SandBoxElement
	{
		//-------------------------------------------------
		#region Constant's Region
		public const int from_the_edge = 10;
		public const int SeparatorLine_Height = 12;
		#endregion
		//-------------------------------------------------
		#region static Property Region
		/// <summary>
		/// in the previos version of the GUISharp,
		/// we had something with this syntax: 
		/// <code>
		/// public GameControl.PageControl UnderForm { get; private set; }
		/// </code>
		/// so, I just wanted to create something similar in this version,
		/// but the difference is that this UnderForm will always return you
		/// the <see cref="GClient"/> of the game.
		/// </summary>
		/// <value>
		/// the <see cref="GClient"/>of the game,
		/// which is also available in <c>ThereIsGConstants</c> class.
		/// </value>
		internal static GClient UnderForm
		{
			get => BigFather;
		}
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The movements of this sandbox.
		/// </summary>
		public override ElementMovements Movements
		{
			get
			{
				if (_flat != null)
				{
					return _flat.Movements;
				}
				return ElementMovements.NoMovements;
			}
			protected set
			{
				;
				// do nothing here, because we want to prevent from
				// stackoverflow.
				// if you want to set it, then use ChangeLocation.
			}
		}
		/// <summary>
		/// The rectangle bounds of this sandbox.
		/// </summary>
		public override Rectangle Rectangle
		{
			get
			{
				if (_flat != null)
				{
					return _flat.Rectangle;
				}
				return Rectangle.Empty;
			}
			set
			{
				;
				// do nothing here, because we want to prevent from
				// stackoverflow.
				// if you want to set it, then use ChangeLocation.
			}
		}
		/// <summary>
		/// The position of this sandbox,
		/// if and only if it's a child.
		/// </summary>
		public override Vector2 Position
		{
			get
			{
				if (_flat != null)
				{
					return _flat.Position;
				}
				return Vector2.Zero;
			}
			set
			{
				;
				// do nothing here, because we want to prevent from
				// stackoverflow.
				// if you want to set it, then use ChangeLocation.
			}
		}
		/// <summary>
		/// The real position of this sandbox.
		/// </summary>
		public override Vector2 RealPosition
		{
			get
			{
				if (_flat != null)
				{
					return _flat.RealPosition;
				}
				return Vector2.Zero;
			}
			protected set
			{
				;
				// do nothing here, because we want to prevent from
				// stackoverflow.
				// if you want to set it, then use ChangeLocation.
			}
		}
		/// <summary>
		/// The name of this element.
		/// Please use
		/// <code><see cref="SetLabelName(StrongString)"/></code>
		/// if you want to set this property.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override StrongString Name
		{
			get
			{
				if (_flat != null)
				{
					return _flat.Name;
				}
				return StrongString.Empty;
			}
			protected set
			{
				; // do NOT allow setting the name.
				// use ChangeName instead (which is overrided.)
			}
		}
		/// <summary>
		/// The real name of this sandbox.
		/// Please use
		/// <code><see cref="SetLabelName(StrongString)"/></code>
		/// if you want to set this property.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override StrongString RealName
		{
			get
			{
				if (_flat != null)
				{
					return _flat.RealName;
				}
				return StrongString.Empty;
			}
			protected set
			{
				; // do NOT allow setting the name.
				// use ChangeName instead (which is overrided.)
			}
		}
		/// <summary>
		/// The text of this element.
		/// Please use
		/// <code><see cref="SetLabelText(StrongString)"/></code>
		/// if you want to set this property.
		/// <!--
		/// Since: GUISharp 1.0.32;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override StrongString Text 
		{
			get
			{
				if (_flat != null)
				{
					return _flat.Text;
				}
				return StrongString.Empty;
			}
			protected set
			{
				;; // do NOT allow setting the text.
				// use ChangeText instead (which is overrided.)
			}
		}
		/// <summary>
		/// The Font of this sandbox.
		/// This property may be null.
		/// <!--
		/// Since: GUISharp 1.0.32;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override SpriteFontBase Font
		{
			get
			{
				if (_flat != null)
				{
					return _flat.Font;
				}
				return null; //TODO: return default font.
			}
			protected set
			{
				;; // do NOT allow setting the font.
				// use ChangeFont instead (which is overrided.)
			}
		}
		/// <summary>
		/// the texture which should be draw on the background of the element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override Texture2D Image
		{
			get
			{
				if (_flat != null)
				{
					return _flat.Image;
				}
				return null;
			}
			protected set
			{
				; // do NOT allow setting the image.
				// use ChangeImage instead (which is overrided.)
			}
		}
		/// <summary>
		/// if the back color is transparent, this texture should be 
		/// null.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal override Texture2D BackGroundImage
		{
			get
			{
				if (_flat != null)
				{
					return _flat.BackGroundImage;
				}
				return null;
			}
			protected set
			{
				; // do NOT allow setting the image.
				// use ChangeImage instead (which is overrided.)
			}
		}
		/// <summary>
		/// ForeColor of this graphic element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override Color ForeColor
		{
			get
			{
				if (_flat != null)
				{
					return _flat.ForeColor;
				}
				return default;
			}
			protected set
			{
				; // do NOT allow setting the image.
				// use ChangeImage instead (which is overrided.)
			}
		}
		/// <summary>
		/// The tint color of this graphic element.
		/// It's <see cref="Color.White"/> by default.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override Color Tint
		{
			get
			{
				if (_flat != null)
				{
					return _flat.Tint;
				}
				return default;
			}
			protected set
			{
				; // do NOT allow setting the tint color directly.
				// use ChangeTint instead (which is overrided.)
			}
		}
		/// <summary>
		/// The background tint color of this sandbox.
		/// It's <see cref="Color.White"/> by default.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override Color BackTint
		{
			get
			{
				if (_flat != null)
				{
					return _flat.Tint;
				}
				return default;
			}
			protected set
			{
				; // do NOT allow setting the background tint color directly.
				// use ChangeTint instead (which is overrided.)
			}
		}
		/// <summary>
		/// The last point of this graphic element.
		/// Mostly used for movements operations.
		/// Do NOT make this private or protected, as another
		/// classes like MoveManager or
		/// MoveList may need this property.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override Vector2 LastPoint
		{
			get
			{
				if (_flat != null)
				{
					return _flat.LastPoint;
				}
				return default;
			}
			set
			{
				if (_flat != null)
				{

					_flat.LastPoint = value;
				}
			}
		}
		/// <summary>
		/// The real location of this element on its owner.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override Point ImageRealLocation
		{
			get
			{
				if (_flat != null)
				{
					return _flat.ImageRealLocation;
				}
				return default;
			}
			protected set
			{
				; // do NOT allow setting the image location.
				// use ChangeImage instead (which is overrided.)
			}
		}
		/// <summary>
		/// The image rectangle of this element (on big father).
		/// Used to draw the image of this element (if it exists).
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override Rectangle ImageRectangle
		{
			get
			{
				if (_flat != null)
				{
					return _flat.ImageRectangle;
				}
				return default;
			}
			protected set
			{
				; // do NOT allow setting the image rectangle.
				// use ChangeImage instead (which is overrided.)
			}
		}
		/// <summary>
		/// The image size mode of this element.
		/// Use 
		/// <code><see cref="ChangeImageSizeMode(ImageSizeMode)"/> </code>
		/// if you wanna change it.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override ImageSizeMode ImageSizeMode
		{
			get
			{
				if (_flat != null)
				{
					return _flat.ImageSizeMode;
				}
				return default;
			}
			protected set
			{
				; // do NOT allow setting the image rectangle.
				// use ChangeImage instead (which is overrided.)
			}
		}

		/// <summary>
		/// the priority of this very sandbox.
		/// </summary>
		public virtual SandBoxPriority SandBoxPriority { get; protected set; }
		public override bool IsMouseLocked
		{
			get
			{
				if (_flat != null)
				{
					return _flat.IsMouseLocked;
				}
				return default;
			}
			protected set
			{
				LockMouse();
			}
		}
		/// <summary>
		/// a value for checking whether this sandbox was closed
		/// by me or by player.
		/// </summary>
		/// <value><c>true</c> if this sandbox was closed by me;
		/// otherwise <c>false</c>.</value>
		public virtual bool ClosedByMe { get; protected set; }
		#endregion
		//-------------------------------------------------
		#region field's Region
		private FlatElement _flat;
		#endregion
		//-------------------------------------------------
		#region event field's Region
		public override event EventHandler LeftClick
		{
			add
			{
				if (_flat != null)
				{
					_flat.LeftClick += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.LeftClick -= value;
				}
			}
		}
		public override event EventHandler LeftUp
		{
			add
			{
				if (_flat != null)
				{
					_flat.LeftUp += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.LeftUp -= value;
				}
			}
		}
		public override event EventHandler RightDown
		{
			add
			{
				if (_flat != null)
				{
					_flat.RightDown += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.RightUp -= value;
				}
			}
		}
		public override event EventHandler RightUp
		{
			add
			{
				if (_flat != null)
				{
					_flat.RightUp += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.RightUp -= value;
				}
			}
		}
		public override event EventHandler MouseEnter 
		{
			add
			{
				if (_flat != null)
				{
					_flat.MouseEnter += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.MouseEnter -= value;
				}
			}
		}
		public override event EventHandler MouseLeave
		{
			add
			{
				if (_flat != null)
				{
					_flat.MouseLeave += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.MouseLeave -= value;
				}
			}
		}
		public override event EventHandler MouseMove
		{
			add
			{
				if (_flat != null)
				{
					_flat.MouseMove += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.MouseMove -= value;
				}
			}
		}
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		/// <summary>
		/// Constructor of The Great Holy <see cref="SandBoxBase"/>.
		/// </summary>
		protected SandBoxBase() : base()
		{
			InitializeComponent();
		}
		#endregion
		//-------------------------------------------------
	}
}
