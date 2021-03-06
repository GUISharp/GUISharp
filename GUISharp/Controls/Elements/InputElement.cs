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
using GUISharp.Security;
using GUISharp.WotoProvider.Enums;

namespace GUISharp.Controls.Elements
{
	/// <summary>
	/// The Input element. Something like <c>TextBox</c>
	/// or a <c>InputBox</c>.
	/// <!--
	/// Since: GUISharp 1.0.29;
	/// By: ALiwoto;
	/// Last edit: 26 July 05:57;
	/// Sign: ALiwoto;
	/// Verified: Yes;
	/// -->
	/// </summary>
	public partial class InputElement : GraphicElement, IInputable
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal const string DarkGreen_Border_FileName	= "f_210620210257";
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal const string Gold_Border_FileName		= "f_210620210258";
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal const string Goldenrod_Border_FileName	= "f_210620210259";
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal const string Gray_Border_FileName		= "f_210620210260";
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal const string Green_Border_FileName		= "f_210620210261";
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal const string Nothing_Border_FileName	= "f_210620210262";
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal const string Red_Border_FileName		= "f_210620210263";
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal const string SkyBlue_Border_FileName	= "f_210620210264";
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal const string Line_Violet_FileName		= "f_210620210265";
		public const char DEFAULT_PASS_CHAR				= '*';
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public const int DEFAULT_WIDTH					= 190;
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public const int DEFAULT_HEIGHT					= 50;
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public const int LINER_INTERVAL					= 650;
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public const int LINER_EDGE 					= 7;
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// WARNING: The InputElement does NOT have any childrens!
		/// you should not add any graphic elements to an input element!
		/// if you try to get the value of this property, you will get null,
		/// so be carefull about it!
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override ElementManager Manager
		{
			get
			{
				// the intput elements should not have any children, so 
				// the manager should be null.
				return null;
			}
			protected set
			{
				// check if the base manager is null or not.
				if (base.Manager != null)
				{
					// it means the base manager is not null,
					// but rule is rule, the manager of the input elements 
					// SHOULD be null!
					// don't ever forget it!
					// and also don't use the value passed-by here.
					base.Manager?.DisposeAll();
					base.Manager = null;
				}
			}
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
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
				; // do nothing here.
			}
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
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
				; // do nothing here.
			}
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
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
				if (_flat != null)
				{
					_flat.Rectangle = value;
				}
			}
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
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
				if (_flat != null)
				{
					_flat.Position = value;
				}
			}
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override Vector2 RealPosition { get; protected set; }
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override StrongString Text
		{
			get
			{
				if (this._flat == null)
				{
					return StrongString.Empty;
				}
				return this._flat.Text;
			}
			protected set
			{
				this._flat?.ChangeText(value);
			}
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override SpriteFontBase Font
		{
			get
			{
				if (this._flat == null)
				{
					return null;
				}
				return this._flat.Font;
			}
			protected set
			{
				this._flat?.ChangeFont(value);
			}
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public override Color BackGroundColor
		{
			get
			{
				if (_flat != null)
				{
					return _flat.BackGroundColor;
				}
				return Color.Transparent;
			}
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual InputBorders BorderColor { get; protected set; }
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual int MaxLength { get; protected set; }
		public virtual char PasswordChar { get; protected set; } = DEFAULT_PASS_CHAR;
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool UseMouseEnterEffect { get; protected set; }
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool InMouseEnterEffect { get; protected set; }
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool IsMultiLine { get; protected set; } // TODO
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool Focused { get; protected set; }
		public virtual bool IsPasswordMode { get; protected set; }
		public override bool Enabled
		{
			get
			{
				if (_flat != null)
				{
					return _flat.Enabled;
				}
				return default;
			}
			protected set
			{
				; // do nothing here
			}
		}
		public override bool IsApplied
		{
			get
			{
				if (_flat != null)
				{
					return _flat.IsApplied;
				}
				return default;
			}
			protected set
			{
				; // do nothing here
			}
		}
		public override bool IsDisposed
		{
			get
			{
				if (_flat != null)
				{
					return _flat.IsDisposed;
				}
				return default;
			}
			protected set
			{
				; // do nothing here
			}
		}
		public override bool IsStable
		{
			get
			{
				if (_flat != null)
				{
					return _flat.IsStable;
				}
				return default;
			}
			protected set
			{
				; // do nothing here
			}
		}
		public override bool NoClick
		{
			get
			{
				if (_flat != null)
				{
					return _flat.NoClick;
				}
				return default;
			}
			protected set
			{
				; // do nothing here
			}
		}
		
		#endregion
		//-------------------------------------------------
		#region field's Region
		/// <summary>
		/// the flat element (surface) of the input element.
		/// use this to draw the surface graphics.
		/// </summary>
		private FlatElement _flat;
		#endregion
		//-------------------------------------------------
		#region static field's Region
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		private static Texture2D _linerTexture;
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		private static Trigger _lineTrigger;
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		private static Vector2 _linerPosition;
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		private static Vector2 _linerSize;
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		private static Rectangle _linerRect;
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		private static bool _showLiner;
		#endregion
		//-------------------------------------------------
		#region event field's Region
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
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
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
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
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
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
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
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
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
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
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
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
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
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
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public InputElement(IRes myRes) : base(myRes, true)
		{
			InitializeComponent();
		}
		#endregion
		//-------------------------------------------------
		#region Destructor's Region
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.29;
		/// By: ALiwoto;
		/// Last edit: 26 July 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		~InputElement()
		{
			if (_flat != null)
			{
				_flat?.Dispose();
				_flat = null;
			}
			if (Manager != null)
			{
				Manager?.DisposeAll();
				Manager = null;
			}
		}
		#endregion
		//-------------------------------------------------
	}
}
