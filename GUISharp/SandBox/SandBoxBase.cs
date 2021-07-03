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
using GUISharp.Constants;
using GUISharp.Client;
using GUISharp.Controls.Elements;

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
		public static GUIClient Client
		{
			get => ThereIsGConstants.Forming.GUIClient;
		}
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
		protected FlatElement _flat;
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
