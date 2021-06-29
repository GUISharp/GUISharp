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
		public const string WhiteSmoke_Border_FileName  = "f_010320212340";
		public const string Red_Border_FileName			= "f_010320212341";
		public const string GreenYellow_Border_FileName = "f_010320212342";
		public const string DarkGreen_Border_FileName   = "f_010320212343";
		public const float ME_EFFECT_OFFSET				= 1.06f;
		public const float ME_EFFECT_OFFSHORT			= 0.04f;
		public const int DEFAULT_WIDTH					= 150;
		public const int DEFAULT_HEIGHT					= 46;
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// WARNING: The Button Elements does NOT have ant childrens!
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
		#endregion
		//-------------------------------------------------
		#region field's Region
		/// <summary>
		/// the flat element (surface) of the button.
		/// use this to draw the surface graphics.
		/// </summary>
		private FlatElement _flat;
		private Rectangle _real_rect;
#nullable enable
		private Rectangle? _eff_rect;
#nullable disable
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
