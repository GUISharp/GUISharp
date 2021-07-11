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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FontStashSharp;
using GUISharp.WotoProvider.Enums;
using GUISharp.WotoProvider.Interfaces;
using GUISharp.Client;
using GUISharp.Security;
using GUISharp.Constants;
using GUISharp.Controls.Moving;
using GUISharp.GUIObjects.Texts;
using GUISharp.GUIObjects.Resources;

namespace GUISharp.Controls.Elements
{
	/// <summary>
	/// Graphics Element.
	/// this class is abstract.
	/// just inherit your element from this class.
	/// <!--
	/// Since: GUISharp 1.0.1;
	/// By: ALiwoto;
	/// Last edit: Jun 28 05:57;
	/// Sign: ALiwoto;
	/// Verified: Yes;
	/// -->
	/// </summary>
	public abstract partial class GraphicElement : IRes, IDisposable, IMoveable, ILocation
	{
		//-------------------------------------------------
		#region Constant's Region
		/// <summary>
		/// the pictures' suffix in the woto resources manager.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal const string PIC_RES = "_Pic";
		/// <summary>
		/// represent the unsigned base index, which is zero.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal const int BASE_INDEX = 0;
		/// <summary>
		/// represent the pixel base for drawing a pixel on 
		/// an image.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal const int PIXEL_BASE = 1;
		/// <summary>
		/// the default pen width for drawing a text on an image.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal const float DEFAULT_PEN_W = 10.0f;
		/// <summary>
		/// The constants deverge value of all graphic elements.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal const int DEVERGE_VALUE = 2;
		#endregion
		//-------------------------------------------------
		#region static Properties Region
		/// <summary>
		/// The BigClient of the application.
		/// Equal to <see cref="ThereIsGConstants.Forming.GUIClient"/>.
		/// In another words, this is your main form.
		/// <!--
		/// Since: GUISharp 1.0.32;
		/// By: ALiwoto;
		/// Last edit: 5 July 15:15;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public static GUIClient BigClient
		{
			get
			{
				return ThereIsGConstants.Forming.GUIClient;
			}
		}
		/// <summary>
		/// The Content Manager of the GUISharp!
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal static ContentManager Content
		{
			get
			{
				if (BigFather != null)
				{
					return BigFather.Content;
				}
				return null;
			}
		}
		/// <summary>
		/// The internal resources manager of graphic elements.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal static WotoRes BigRes
		{
			get
			{
				if (BigFather != null)
				{
					return BigFather.MyRes;
				}
				return null;
			}
		}
		/// <summary>
		/// The font manager of the GUISharp.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal static FontManager FontManager
		{
			get
			{
				if (BigFather != null)
				{
					return BigFather.FontManager;
				}
				return null;
			}
		}
		/// <summary>
		/// The Big Father of the <see cref="GraphicElement"/>!
		/// <!--
		/// Since: GUISharp 1.0.14;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal static GClient BigFather
		{
			get => ThereIsGConstants.Forming.GClient;
		}
		/// <summary>
		/// The internal Default resources manager for all of 
		/// the graphic elements.
		/// <!--
		/// Since: GUISharp 1.0.14;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		internal static WotoRes DefaultRes
		{
			get
			{
				if (BigFather != null)
				{
					return BigFather.MyRes;
				}
				return null;
			}
		}
		#endregion
		//-------------------------------------------------
		#region Properties Region
		/// <summary>
		/// The resources manager of this graphic element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual WotoRes MyRes { get; set; }
		/// <summary>
		/// NOTICE:
		/// this is not my father!!
		/// this is my own manager, contains my children!
		/// please do NOT use it as it is my father!!!
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual ElementManager Manager { get; protected set; }
		/// <summary>
		/// The owner of this graphic element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual GraphicElement Owner { get; protected set; }
		/// <summary>
		/// The real name of this element.
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
		public virtual StrongString RealName { get; protected set; }
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
		public virtual StrongString Name { get; protected set; }
		/// <summary>
		/// The text of this element.
		/// Please use
		/// <code><see cref="SetLabelText(StrongString)"/></code>
		/// if you want to set this property.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual StrongString Text { get; protected set; }
		/// <summary>
		/// The Font of this graphic element.
		/// This property may be null.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual SpriteFontBase Font { get; protected set; }
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
		public virtual Texture2D Image { get; protected set; }
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
		protected internal virtual Texture2D BackGroundImage { get; protected set; }
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
		public virtual Color ForeColor { get; protected set; }
		/// <summary>
		/// The background color of this graphic element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual Color BackGroundColor { get; set; } = Color.Transparent;
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
		public virtual Color Tint { get; protected set; } = Color.White;
		/// <summary>
		/// The tint color of the background image of this graphic element.
		/// It's <see cref="Color.White"/> by default.
		/// <!--
		/// Since: GUISharp 1.0.31;
		/// By: ALiwoto;
		/// Last edit: 5 July 14:41;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual Color BackTint { get; protected set; } = Color.White;
		/// <summary>
		/// The last point of this graphic element.
		/// Mostly used for movements operations.
		/// Do NOT make this private or protected, as another
		/// classes like <see cref="MoveManager"/> or
		/// <seealso cref="MoveList"/> may need this property.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual Vector2 LastPoint { get; set; }
		/// <summary>
		/// the real position of this element on its owner.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual Vector2 RealPosition { get; protected set; }
		/// <summary>
		/// the position of this element on the big father.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual Vector2 Position { get; set; }
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
		public virtual Point ImageRealLocation { get; protected set; }
		/// <summary>
		/// The rectangle of this element (on big father).
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual Rectangle Rectangle { get; set; }
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
		public virtual Rectangle ImageRectangle { get; protected set; }
		/// <summary>
		/// The move manager of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual IMoveManager MoveManager { get; protected set; }
		/// <summary>
		/// The father location of this element.
		/// Equal to <see cref="Owner"/>.
		/// You can use both.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual ILocation FatherLocation { get; protected set; }
		/// <summary>
		/// The movements of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual ElementMovements Movements { get; protected set; }
		/// <summary>
		/// The priority of this element.
		/// <!--
		/// Since: GUISharp 1.0.11;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual ElementPriority Priority { get; protected set; }
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
		public virtual ImageSizeMode ImageSizeMode { get; protected set; }
		/// <summary>
		/// The x.
		/// Equal to <see cref="Position"/>.X.
		/// <!--
		/// Since: GUISharp 1.0.14;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual float X
		{
			get
			{
				return Position.X;
			}
		}
		/// <summary>
		/// The y.
		/// Equal to <see cref="Position"/>.Y.
		/// <!--
		/// Since: GUISharp 1.0.14;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual float Y
		{
			get
			{
				return Position.Y;
			}
		}
		/// <summary>
		/// The Real x (the x-coordinate of this element on its owner).
		/// Equal to <see cref="RealPosition"/>.X.
		/// <!--
		/// Since: GUISharp 1.0.30;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual float RealX
		{
			get
			{
				return RealPosition.X;
			}
		}
		/// <summary>
		/// The Real y (the y-coordinate of this element on its owner).
		/// Equal to <see cref="RealPosition"/>.Y.
		/// <!--
		/// Since: GUISharp 1.0.30;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual float RealY
		{
			get
			{
				return RealPosition.Y;
			}
		}
		/// <summary>
		/// The width of this element.
		/// equal to <see cref="Rectangle"/>.Width.
		/// <!--
		/// Since: GUISharp 1.0.5;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual float Width
		{
			get
			{
				return Rectangle.Width;
			}
		}
		/// <summary>
		/// The height of this element.
		/// equal to <see cref="Rectangle"/>.Height.
		/// <!--
		/// Since: GUISharp 1.0.5;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual float Height
		{
			get
			{
				return Rectangle.Height;
			}
		}
		/// <summary>
		/// The language of this element.
		/// TODO: localization is still incompleted.
		/// <!--
		/// Since: GUISharp 1.0.30;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual char Language
		{
			get
			{
				return ThereIsGConstants.AppSettings.Language;
			}
			set
			{
				ThereIsGConstants.AppSettings.Language = value;
			}
		}
		/// <summary>
		/// The current status of this element.
		/// <!--
		/// Since: GUISharp 1.0.30;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual uint CurrentStatus { get; set; }
		/// <summary>
		/// Check if this element is already applied or not.
		/// If the element is not applied, it won't trigger its events
		/// and it won't draw itself.
		/// <!--
		/// Since: GUISharp 1.0.1;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool IsApplied { get; protected set; }
		/// <summary>
		/// Check if this element is disposed or not.
		/// If the element is disposed, it won't trigger its events
		/// and it won't draw itself.
		/// <!--
		/// Since: GUISharp 1.0.1;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool IsDisposed { get; protected set; }
		/// <summary>
		/// Check if this element is enabled or not.
		/// If the element is not enables, it won't trigger its events
		/// but it will draw itself.
		/// <!--
		/// Since: GUISharp 1.0.1;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool Enabled { get; protected set; }
		/// <summary>
		/// Check if this element has an owner or not.
		/// The owner can either be a <see cref="SandBox"/> or only a
		/// simple <see cref="GraphicElement"/>.
		/// But notice that Owner of this element, cannot be barren.
		/// <!--
		/// Since: GUISharp 1.0.1;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool HasOwner { get; protected set; }
		/// <summary>
		/// Check if this element has a sandbox owner or not.
		/// The owner is a <see cref="SandBox"/>.
		/// But notice that Owner of this element, cannot be barren.
		/// <!--
		/// Since: GUISharp 1.0.1;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool HasSandBoxOwner { get; protected set; }
		/// <summary>
		/// Check if this element is visible or not.
		/// If this element is not visible, it won't draw itself
		/// and it won't trigger any of its events.
		/// If you wanna set this property, use <see cref="Hide()"/>
		/// or <see cref="Show()"/>.
		/// <!--
		/// Since: GUISharp 1.0.1;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool Visible { get; protected set; }
		/// <summary>
		/// Check if mouse is currently inside of this element or not.
		/// Main usages of this property is internal, but I made it
		/// public just-in-case.
		/// Please use <see cref="MouseEnter"/> or 
		/// <see cref="MouseLeave"/> events instead of this
		/// property.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool IsMouseIn { get; protected set; }
		/// <summary>
		/// Check if left button of the mouse is
		/// currently down inside of this element or not.
		/// Main usages of this property is internal, but I made it
		/// public just-in-case.
		/// Please use <see cref="LeftDown"/> or 
		/// <see cref="LeftUp"/> events instead of this
		/// property.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool IsLeftDown { get; protected set; }
		/// <summary>
		/// Check if left button of the mouse is
		/// currently down (for once) inside of this element or not.
		/// Main usages of this property is internal, but I made it
		/// public just-in-case.
		/// Please use <see cref="LeftDown"/> or 
		/// <see cref="LeftUp"/> events instead of this
		/// property.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool LeftDownOnce { get; protected set; }
		/// <summary>
		/// Check if right button of the mouse is
		/// currently down inside of this element or not.
		/// Main usages of this property is internal, but I made it
		/// public just-in-case.
		/// Please use <see cref="RightDown"/> or 
		/// <see cref="RightUp"/> events instead of this
		/// property.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool IsRightDown { get; protected set; }
		/// <summary>
		/// Check if right button of the mouse is
		/// currently down (for once) inside of this element or not.
		/// Main usages of this property is internal, but I made it
		/// public just-in-case.
		/// Please use <see cref="RightDown"/> or 
		/// <see cref="RightUp"/> events instead of this
		/// property.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual bool RightDownOnce { get; protected set; }
		/// <summary>
		/// Gets a value indicating whether the element has been barrened of.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <value>
		/// true if the element has been barrened of; otherwise, false.
		/// </value>
		public virtual bool IsBarren { get; protected set; }
		/// <summary>
		/// Gets a value indicating whether the element is stable or not.
		/// if the element is not stable, it will disable itself after
		/// <c>Click</c> event (only left button of mouse).
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 9 July 2021, 11:22 AM;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <value>
		/// true if the element is stable; otherwise, false.
		/// </value>
		public virtual bool IsStable { get; protected set; }
		/// <summary>
		/// Gets a value indicating whether the element should
		/// move its owner or not. If it should move its owner,
		/// it will ignore <see cref="Movements"/> property.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <value>
		/// true if the element should move its owner; otherwise, false.
		/// </value>
		public virtual bool OwnerMover { get; protected set; }
		/// <summary>
		/// Gets a value indicating whether the mouse is locked
		/// on this element or not.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <value>
		/// true if the mouse is locked on this element; otherwise, false.
		/// </value>
		public virtual bool IsMouseLocked { get; protected set; }
		#endregion
		//-------------------------------------------------
		#region static field's Region
		/// <summary>
		/// The diverge vector of all elements.
		/// <!--
		/// Since: GUISharp 1.0.2;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public static readonly Vector2 DivergeVector = 
			new(DEVERGE_VALUE, DEVERGE_VALUE);
		/// <summary>
		/// The currently locked element.
		/// <!--
		/// Since: GUISharp 1.0.2;
		/// By: ALiwoto;
		/// Last edit: Jun 28 05:57;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal static GraphicElement LockedElement { get; internal set; }
		#endregion
		//-------------------------------------------------
		#region event field's Region
		/// <summary>
		/// Occurs when the mouse pointer enters the element.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler MouseEnter;
		/// <summary>
		/// Occurs when the mouse pointer leaves the element.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler MouseLeave;
		/// <summary>
		/// Occurs when the mouse pointer is moved over the element.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler MouseMove;
		/// <summary>
		/// Occurs when the mouse pointer is over the element and
		/// left mouse button is pressed.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler LeftDown;
		/// <summary>
		/// Occurs when the mouse pointer is over the element and
		/// left mouse button is released.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler LeftUp;
		/// <summary>
		/// Occurs when the mouse pointer is over the element and
		/// right mouse button is pressed.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler RightDown;
		/// <summary>
		/// Occurs when the mouse pointer is over the element and
		/// right mouse button is released.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler RightUp;
		/// <summary>
		/// Occurs when the element is clicked with the left button of mouse.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler LeftClick;
		/// <summary>
		/// Occurs when the element is clicked with the right button of mouse.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler RightClick;
		/// <summary>
		/// Occurs when the element is clicked with left mouse button
		/// or right.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler Click;
		/// <summary>
		/// Occurs when the mouse pointer enters the element.
		/// This event handler will be called in a separate thread.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler MouseEnterAsync;
		/// <summary>
		/// Occurs when the mouse pointer leaves the element.
		/// This event handler will be called in a separate thread.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler MouseLeaveAsync;
		/// <summary>
		/// Occurs when the mouse pointer is moved over the element.
		/// This event handler will be called in a separate thread.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler MouseMoveAsync;
		/// <summary>
		/// Occurs when the mouse pointer is over the element and
		/// left mouse button is pressed.
		/// This event handler will be called in a separate thread.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler LeftDownAsync;
		/// <summary>
		/// Occurs when the mouse pointer is over the element and
		/// left mouse button is released.
		/// This event handler will be called in a separate thread.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler LeftUpAsync;
		/// <summary>
		/// Occurs when the mouse pointer is over the element and
		/// right mouse button is pressed.
		/// This event handler will be called in a separate thread.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler RightDownAsync;
		/// <summary>
		/// Occurs when the mouse pointer is over the element and
		/// right mouse button is released.
		/// This event handler will be called in a separate thread.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler RightUpAsync;
		/// <summary>
		/// Occurs when the element is clicked with the left button of mouse.
		/// This event handler will be called in a separate thread.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler LeftClickAsync;
		/// <summary>
		/// Occurs when the element is clicked with the right 
		/// button of mouse.
		/// This event handler will be called in a separate thread.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler RightClickAsync;
		/// <summary>
		/// Occurs when the element is clicked with left mouse button
		/// or right.
		/// This event handler will be called in a separate thread.
		/// <!--
		/// Since: GUISharp 1.0.4;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual event EventHandler ClickAsync;
		#endregion
		//-------------------------------------------------
		#region Constructor Region
		/// <summary>
		/// Creates a new instance of <see cref="GraphicElement"/>.
		/// <!--
		/// Since: GUISharp 1.0.1;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected GraphicElement(IRes myRes, bool isBarren = false)
		{
			MyRes = myRes.MyRes;
			CurrentStatus = 1;
			IsBarren = isBarren;
			//Father = _t;
			InitializeComponent();
		}
		/// <summary>
		/// Creates a new instance of <see cref="GraphicElement"/>.
		/// Used only for <see cref="SandBox.SandBoxElement"/>.
		/// <!--
		/// Since: GUISharp 1.0.1;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal GraphicElement()
		{
			CurrentStatus = 1;
			InitializeComponent();
		}
		#endregion
		//-------------------------------------------------
		#region Destructor's Region
		/// <summary>
		/// Destructor of <see cref="GraphicElement"/>.
		/// <!--
		/// Since: GUISharp 1.0.1;
		/// By: ALiwoto;
		/// Last edit: 4 July 17:06;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		~GraphicElement()
		{
			if (Click != null)
			{
				Click = null;
			}
		}
		#endregion
		//-------------------------------------------------
	}
}
