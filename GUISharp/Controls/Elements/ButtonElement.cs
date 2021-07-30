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
using FontStashSharp;
using GUISharp.Security;
using GUISharp.WotoProvider.Enums;

namespace GUISharp.Controls.Elements
{
	/// <summary>
	/// The Button provider of the GUISharp game.
	/// this will provide you a high quality of the button.
	/// </summary>
	public partial class ButtonElement : GraphicElement
	{
		//-------------------------------------------------
		#region Constant's Region
		internal const string WhiteSmoke_Border_FileName  = "f_010320212340";
		internal const string Red_Border_FileName			= "f_010320212341";
		internal const string GreenYellow_Border_FileName = "f_010320212342";
		internal const string DarkGreen_Border_FileName   = "f_010320212343";
		internal const string NormalTransparentGreen_Border_FileName   = "f_290620210264";
		internal const string NormalGreenGreen_Border_FileName   = "f_290620210265";
		internal const string NormalBlackWhiteSmoke_Border_FileName   = "f_290620210266";
		internal const string NormalTransparentWhiteSmoke_Border_FileName   = "f_290620210267";
		internal const string NormalWhiteWhiteSmoke_Border_FileName   = "f_290620210268";
		internal const string NormalGrayWhiteSmoke_Border_FileName   = "f_290620210269";
		internal const string NormalGrayLightSlateGray_Border_FileName   = "f_290620210270";
		internal const string NormalLightGrayBlack_Border_FileName   = "f_290620210271";
		internal const string NormalGrayBlack_Border_FileName   = "f_290620210272";
		internal const string NormalRedBlack_Border_FileName   = "f_290620210273";
		internal const string NormalWhiteBlack_Border_FileName   = "f_290620210274";
		internal const string NormalWheatBlack_Border_FileName   = "f_290620210275";
		internal const string NormalWhiteRed_Border_FileName   = "f_290620210276";
		internal const string NormalLightGrayRed_Border_FileName   = "f_290620210277";
		internal const string NormalGrayRed_Border_FileName   = "f_290620210278";
		internal const string NormalDarkGrayRed_Border_FileName   = "f_290620210279";
		internal const string NormalWhiteOrange_Border_FileName   = "f_290620210280";
		internal const string NormalLightGrayOrange_Border_FileName   = "f_290620210281";
		internal const string NormalGrayOrange_Border_FileName   = "f_290620210282";
		internal const string NormalDarkGrayOrange_Border_FileName   = "f_290620210283";
		internal const string NormalWhiteOrangered_Border_FileName   = "f_290620210284";
		internal const string NormalLightGrayOrangered_Border_FileName   = "f_290620210285";
		internal const string NormalGrayOrangered_Border_FileName   = "f_290620210286";
		internal const string NormalDarkGrayOrangered_Border_FileName   = "f_290620210287";
		internal const string NormalWhiteGreen_Border_FileName   = "f_290620210288";
		internal const string NormalLightGrayGreen_Border_FileName   = "f_290620210289";
		internal const string NormalGrayGreen_Border_FileName   = "f_290620210290";
		internal const string NormalDarkGrayGreen_Border_FileName   = "f_290620210291";
		internal const float ME_EFFECT_OFFSET				= 1.06f;
		internal const float ME_EFFECT_OFFSHORT				= 0.04f;
		internal const int DEFAULT_WIDTH					= 150;
		internal const int DEFAULT_HEIGHT					= 46;
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// WARNING: The Button Elements does NOT have any childrens!
		/// you should not add any graphic elements to a button element!
		/// if you try to get the value of this property, you will get null,
		/// so be carefull about it!
		/// </summary>
		public override ElementManager Manager
		{
			get
			{
				// the button elements should not have any children, so 
				// the manager should be null.
				return null;
			}
			protected set
			{
				// check if the base manager is null or not.
				if (base.Manager != null)
				{
					// it means the base manager is not null,
					// but rule is rule, the manager of the button elements 
					// SHOULD be null!
					// don't ever forget it!
					// and also don't use the value passed-by here.
					base.Manager?.DisposeAll();
					base.Manager = null;
				}
			}
		}
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
		public override SpriteFontBase Font
		{
			get
			{
				if (_flat != null)
				{
					return _flat.Font;
				}
				return null;
			}
			protected set
			{
				ChangeFont(value);
			}
		}
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
		public override Vector2 RealPosition { get; protected set; }
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
		public virtual ButtonColors BorderColor { get; protected set; }
		public virtual bool UseMouseEnterEffect { get; protected set; }
		public virtual bool InMouseEnterEffect { get; protected set; }
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
		/// the flat element (surface) of the button.
		/// use this to draw the surface graphics.
		/// </summary>
		private FlatElement _flat;
		private Rectangle _real_rect;
		#endregion
		//-------------------------------------------------
		#region event field's Region
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
		public override event EventHandler LeftDown
		{
			add
			{
				if (_flat != null)
				{
					_flat.LeftDown += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.LeftDown -= value;
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
		public override event EventHandler RightClick
		{
			add
			{
				if (_flat != null)
				{
					_flat.RightClick += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.RightClick -= value;
				}
			}
		}
		public override event EventHandler Click
		{
			add
			{
				if (_flat != null)
				{
					_flat.Click += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.Click -= value;
				}
			}
		}
		public override event EventHandler MouseEnterAsync
		{
			add
			{
				if (_flat != null)
				{
					_flat.MouseEnterAsync += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.MouseEnterAsync -= value;
				}
			}
		}
		public override event EventHandler MouseLeaveAsync
		{
			add
			{
				if (_flat != null)
				{
					_flat.MouseLeaveAsync += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.MouseLeaveAsync -= value;
				}
			}
		}
		public override event EventHandler MouseMoveAsync
		{
			add
			{
				if (_flat != null)
				{
					_flat.MouseMoveAsync += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.MouseMoveAsync -= value;
				}
			}
		}
		public override event EventHandler LeftDownAsync
		{
			add
			{
				if (_flat != null)
				{
					_flat.LeftDownAsync += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.LeftDownAsync -= value;
				}
			}
		}
		public override event EventHandler LeftUpAsync
		{
			add
			{
				if (_flat != null)
				{
					_flat.LeftUpAsync += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.LeftUpAsync -= value;
				}
			}
		}
		public override event EventHandler LeftClickAsync
		{
			add
			{
				if (_flat != null)
				{
					_flat.LeftClickAsync += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.LeftClickAsync -= value;
				}
			}
		}
		public override event EventHandler RightDownAsync
		{
			add
			{
				if (_flat != null)
				{
					_flat.RightDownAsync += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.RightUpAsync -= value;
				}
			}
		}
		public override event EventHandler RightUpAsync
		{
			add
			{
				if (_flat != null)
				{
					_flat.RightUpAsync += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.RightUpAsync -= value;
				}
			}
		}
		public override event EventHandler RightClickAsync
		{
			add
			{
				if (_flat != null)
				{
					_flat.RightClickAsync += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.RightClickAsync -= value;
				}
			}
		}
		public override event EventHandler ClickAsync
		{
			add
			{
				if (_flat != null)
				{
					_flat.ClickAsync += value;
				}
			}
			remove
			{
				if (_flat != null)
				{
					_flat.ClickAsync -= value;
				}
			}
		}
		
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		public ButtonElement(IRes myRes) : base(myRes, true)
		{
			InitializeComponent();
		}
		#endregion
		//-------------------------------------------------
		#region Destructor's Region
		~ButtonElement()
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
