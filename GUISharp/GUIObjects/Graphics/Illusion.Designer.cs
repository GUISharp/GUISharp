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
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GUISharp.Security;
using GUISharp.Constants;
using static GUISharp.Client.Universe;
using Pen			= System.Drawing.Pen;
using Bitmap		= System.Drawing.Bitmap;
using Image			= System.Drawing.Image;
using Icon			= System.Drawing.Icon;
using Graphic		= System.Drawing.Graphics;
using DPoint		= System.Drawing.Point;
using DPointF		= System.Drawing.PointF;
using DColor		= System.Drawing.Color;
using DRectangle	= System.Drawing.Rectangle;
using DRectangleF 	= System.Drawing.RectangleF;
using GraphicsUnit	= System.Drawing.GraphicsUnit;
using DFillMode 	= System.Drawing.Drawing2D.FillMode;


namespace GUISharp.GUIObjects.Graphics
{
	partial class Illusion
	{
		//-------------------------------------------------
		#region Initialize Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region Graphical Method's Region
		/// <summary>
		/// Clears the entire drawing surface and fills it with 
		/// the specified background color.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="color">
		/// <see cref="Color"/> structure that 
		/// represents the background color of the drawing
		/// surface.
		/// </param>
		public virtual void Clear(Color color)
		{
			this.Clear(color.ToDColor());
		}

		/// <summary>
		/// Clears the entire drawing surface and fills it with 
		/// the specified background color.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="color">
		/// <see cref="DColor"/> structure that 
		/// represents the background color of the drawing
		/// surface.
		/// </param>
		public virtual void Clear(DColor color)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.Clear(color);
		}
		
		/// <summary>
		/// Clears the entire drawing surface and fills it with 
		/// the specified background color.
		/// This method will call <see cref="SaveChanges"/> after
		/// the operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="color">
		/// <see cref="Color"/> structure that 
		/// represents the background color of the drawing
		/// surface.
		/// </param>
		public virtual void ClearAndSave(Color color)
		{
			this.Clear(color);
			this.SaveChanges();
		}
		
		/// <summary>
		/// Clears the entire drawing surface and fills it with 
		/// the specified background color.
		/// This method will call <see cref="SaveChanges"/> after
		/// the operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="color">
		/// <see cref="Color"/> structure that 
		/// represents the background color of the drawing
		/// surface.
		/// </param>
		public virtual void ClearAndSave(DColor color)
		{
			this.Clear(color);
			this.SaveChanges();
		}
		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Rectangle"/> structure.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="rect">
		/// <see cref="Rectangle"/> structure that defines the boundaries
		/// of the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArc(Pen pen, Rectangle rect, 
			float startAngle, float sweepAngle)
		{
			this.DrawArc(pen, rect.ToDRectangle(), startAngle, sweepAngle);
		}
		
		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Rectangle"/> structure.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="rect">
		/// <see cref="Rectangle"/> structure that defines the boundaries
		/// of the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArcAndSave(Pen pen, Rectangle rect, 
			float startAngle, float sweepAngle)
		{
			this.DrawArc(pen, rect, startAngle, sweepAngle);
			this.SaveChanges();
		}

		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Rectangle"/> structure.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="rect">
		/// <see cref="Rectangle"/> structure that defines the boundaries
		/// of the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArc(Pen pen, DRectangle rect, 
			float startAngle, float sweepAngle)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawArc(pen, rect, startAngle, sweepAngle);
		}
		
		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Rectangle"/> structure.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="rect">
		/// <see cref="Rectangle"/> structure that defines the boundaries
		/// of the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArcAndSave(Pen pen, DRectangle rect, 
			float startAngle, float sweepAngle)
		{
			this.DrawArc(pen, rect, startAngle, sweepAngle);
			this.SaveChanges();
		}
		
		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Vector4"/> structure as a Rectangle with 
		/// float parameter of (x, y, w, h).
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="rect">
		/// <see cref="Vector4"/> structure that defines the boundaries
		/// of the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArc(Pen pen, Vector4 rect, 
			float startAngle, float sweepAngle)
		{
			this.DrawArc(pen, rect.ToDRectangleF(), startAngle, sweepAngle);
		}
		
		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Rectangle"/> structure.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="rect">
		/// <see cref="Rectangle"/> structure that defines the boundaries
		/// of the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArcAndSave(Pen pen, Vector4 rect, 
			float startAngle, float sweepAngle)
		{
			this.DrawArc(pen, rect, startAngle, sweepAngle);
			this.SaveChanges();
		}

		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Rectangle"/> structure.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="rect">
		/// <see cref="Rectangle"/> structure that defines the boundaries
		/// of the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArc(Pen pen, DRectangleF rect, 
			float startAngle, float sweepAngle)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawArc(pen, rect, startAngle, sweepAngle);
		}
		
		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Rectangle"/> structure.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="rect">
		/// <see cref="Rectangle"/> structure that defines the boundaries
		/// of the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArcAndSave(Pen pen, DRectangleF rect, 
			float startAngle, float sweepAngle)
		{
			this.DrawArc(pen, rect, startAngle, sweepAngle);
			this.SaveChanges();
		}
		
		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Rectangle"/> structure.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="x">
		/// The x-coordinate of the upper-left corner of the 
		/// rectangle that defines the ellipse.
		/// </param>
		/// <param name="y">
		/// The y-coordinate of the upper-left corner of the 
		/// rectangle that defines the ellipse.
		/// </param>
		/// <param name="w">
		/// Width of the rectangle that defines the ellipse.
		/// </param>
		/// <param name="h">
		/// Height of the rectangle that defines the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArc(Pen pen, int x, int y, int w, int h,
			float startAngle, float sweepAngle)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawArc(pen, x, y, w, h, startAngle, sweepAngle);
		}
		
		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Rectangle"/> structure.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="x">
		/// The x-coordinate of the upper-left corner of the 
		/// rectangle that defines the ellipse.
		/// </param>
		/// <param name="y">
		/// The y-coordinate of the upper-left corner of the 
		/// rectangle that defines the ellipse.
		/// </param>
		/// <param name="w">
		/// Width of the rectangle that defines the ellipse.
		/// </param>
		/// <param name="h">
		/// Height of the rectangle that defines the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArcAndSave(Pen pen, int x, int y, int w, int h,
			float startAngle, float sweepAngle)
		{
			this.DrawArc(pen, x, y, w, h, startAngle, sweepAngle);
			this.SaveChanges();
		}
		
		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Rectangle"/> structure.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="x">
		/// The x-coordinate of the upper-left corner of the 
		/// rectangle that defines the ellipse.
		/// </param>
		/// <param name="y">
		/// The y-coordinate of the upper-left corner of the 
		/// rectangle that defines the ellipse.
		/// </param>
		/// <param name="w">
		/// Width of the rectangle that defines the ellipse.
		/// </param>
		/// <param name="h">
		/// Height of the rectangle that defines the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArc(Pen pen, float x, float y, 
			float w, float h, float startAngle, float sweepAngle)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawArc(pen, x, y, w, h, startAngle, sweepAngle);
		}
		
		/// <summary>
		/// Draws an arc representing a portion of an ellipse specified by a
		/// <see cref="Rectangle"/> structure.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="x">
		/// The x-coordinate of the upper-left corner of the 
		/// rectangle that defines the ellipse.
		/// </param>
		/// <param name="y">
		/// The y-coordinate of the upper-left corner of the 
		/// rectangle that defines the ellipse.
		/// </param>
		/// <param name="w">
		/// Width of the rectangle that defines the ellipse.
		/// </param>
		/// <param name="h">
		/// Height of the rectangle that defines the ellipse.
		/// </param>
		/// <param name="startAngle">
		/// Angle in degrees measured clockwise from the x-axis 
		/// to the starting point of the arc.
		/// </param>
		/// <param name="sweepAngle">
		/// Angle in degrees measured clockwise from the startAngle 
		/// parameter to ending point of the arc.
		/// </param>
		public virtual void DrawArcAndSave(Pen pen, float x, float y, 
			float w, float h, float startAngle, float sweepAngle)
		{
			this.DrawArc(pen, x, y, w, h, startAngle, sweepAngle);
			this.SaveChanges();
		}
		



		/// <summary>
		/// Draws a Bézier spline defined by four Point structures.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="pt1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="pt2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="pt3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="pt4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		public virtual void DrawBezier(Pen pen, Point pt1, Point pt2, 
			Point pt3, Point pt4)
		{
			this.DrawBezier(pen, pt1.ToDPoint(), pt1.ToDPoint(),
				pt3.ToDPoint(), pt4.ToDPoint());
		}

		/// <summary>
		/// Draws a Bézier spline defined by four Point structures.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="pt1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="pt2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="pt3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="pt4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		public virtual void DrawBezierAndSave(Pen pen, Point pt1, Point pt2, 
			Point pt3, Point pt4)
		{
			this.DrawBezier(pen, pt1, pt2, pt3, pt4);
			this.SaveChanges();
		}

		/// <summary>
		/// Draws a Bézier spline defined by four Point structures.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="pt1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="pt2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="pt3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="pt4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		public virtual void DrawBezier(Pen pen, DPoint pt1, DPoint pt2, 
			DPoint pt3, DPoint pt4)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawBezier(pen, pt1, pt2, pt3, pt4);
		}

		/// <summary>
		/// Draws a Bézier spline defined by four Point structures.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="pt1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="pt2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="pt3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="pt4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		public virtual void DrawBezierAndSave(Pen pen, DPoint pt1, DPoint pt2, 
			DPoint pt3, DPoint pt4)
		{
			this.DrawBezier(pen, pt1, pt2, pt3, pt4);
			this.SaveChanges();
		}




		/// <summary>
		/// Draws a Bézier spline defined by four Point structures.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="x1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="y1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="x2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="y2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="x3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="y3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="x4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		/// <param name="y4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		public virtual void DrawBezier(Pen pen, float x1, float y1, 
			float x2, float y2, float x3, float y3, float x4, float y4)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawBezier(pen, x1, y1, x2, y2, x3, y3, x4, y4);
		}

		/// <summary>
		/// Draws a Bézier spline defined by four Point structures.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="x1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="y1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="x2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="y2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="x3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="y3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="x4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		/// <param name="y4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		public virtual void DrawBezierAndSave(Pen pen, float x1, float y1, 
			float x2, float y2, float x3, float y3, float x4, float y4)
		{
			this.DrawBezier(pen, x1, y1, x2, y2, x3, y3, x4, y4);
			this.SaveChanges();
		}




		/// <summary>
		/// Draws a Bézier spline defined by four Point structures.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="pt1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="pt2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="pt3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="pt4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		public virtual void DrawBezier(Pen pen, Vector2 pt1, Vector2 pt2, 
			Vector2 pt3, Vector2 pt4)
		{
			this.DrawBezier(pen, pt1.ToDPointF(), pt1.ToDPointF(),
				pt3.ToDPointF(), pt4.ToDPointF());
		}

		/// <summary>
		/// Draws a Bézier spline defined by four Point structures.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="pt1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="pt2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="pt3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="pt4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		public virtual void DrawBezierAndSave(Pen pen, Vector2 pt1, Vector2 pt2, 
			Vector2 pt3, Vector2 pt4)
		{
			this.DrawBezier(pen, pt1, pt2, pt3, pt4);
			this.SaveChanges();
		}

		/// <summary>
		/// Draws a Bézier spline defined by four Point structures.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="pt1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="pt2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="pt3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="pt4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		public virtual void DrawBezier(Pen pen, DPointF pt1, DPointF pt2, 
			DPointF pt3, DPointF pt4)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawBezier(pen, pt1, pt2, pt3, pt4);
		}

		/// <summary>
		/// Draws a Bézier spline defined by four Point structures.
		/// This method will call <see cref="SaveChanges()"/> after operation.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		/// <param name="pen">
		/// <see cref="Pen"/> that determines the color, width, 
		/// and style of the arc.
		/// </param>
		/// <param name="pt1">
		/// Point structure that represents the starting point of the curve.
		/// </param>
		/// <param name="pt2">
		/// Point structure that represents the first control point for the
		/// curve.
		/// </param>
		/// <param name="pt3">
		/// Point structure that represents the second control point for the
		/// curve.
		/// </param>
		/// <param name="pt4">
		/// Point structure that represents the ending point of the curve.
		/// </param>
		public virtual void DrawBezierAndSave(Pen pen, DPointF pt1, DPointF pt2, 
			DPointF pt3, DPointF pt4)
		{
			this.DrawBezier(pen, pt1, pt2, pt3, pt4);
			this.SaveChanges();
		}


		public virtual void DrawBeziers(Pen pen, Point[] points)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawBeziers(pen, points.ToDPoints());
		}

		public virtual void DrawBeziersAndSave(Pen pen, Point[] points)
		{
			this.DrawBeziers(pen, points);
			this.SaveChanges();
		}

		public virtual void DrawBeziers(Pen pen, DPoint[] points)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawBeziers(pen, points);
		}

		public virtual void DrawBeziersAndSave(Pen pen, DPoint[] points)
		{
			this.DrawBeziers(pen, points);
			this.SaveChanges();
		}

		public virtual void DrawBeziers(Pen pen, Vector2[] points)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawBeziers(pen, points.ToDPoints());
		}

		public virtual void DrawBeziersAndSave(Pen pen, Vector2[] points)
		{
			this.DrawBeziers(pen, points);
			this.SaveChanges();
		}

		public virtual void DrawBeziers(Pen pen, DPointF[] points)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawBeziers(pen, points);
		}

		public virtual void DrawBeziersAndSave(Pen pen, DPointF[] points)
		{
			this.DrawBeziers(pen, points);
			this.SaveChanges();
		}

		
		public virtual void DrawClosedCurve(Pen pen, Vector2[] points)
		{
			this.DrawClosedCurve(pen, points.ToDPoints());
		}

		public virtual void DrawClosedCurveAndSave(Pen pen, Vector2[] points)
		{
			this.DrawClosedCurve(pen, points);
			this.SaveChanges();
		}

		public virtual void DrawClosedCurve(Pen pen, DPointF[] points)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawClosedCurve(pen, points);
		}

		public virtual void DrawClosedCurveAndSave(Pen pen, DPointF[] points)
		{
			this.DrawClosedCurve(pen, points);
			this.SaveChanges();
		}

		public virtual void DrawClosedCurve(Pen pen, Vector2[] points, 
			float tension, DFillMode fillmode)
		{
			this.DrawClosedCurve(pen, points.ToDPoints(), 
				tension, fillmode);
		}

		public virtual void DrawClosedCurveAndSave(Pen pen, Vector2[] points,
			float tension, DFillMode fillmode)
		{
			this.DrawClosedCurve(pen, points, tension, fillmode);
			this.SaveChanges();
		}

		public virtual void DrawClosedCurve(Pen pen, DPointF[] points, 
			float tension, DFillMode fillmode)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawClosedCurve(pen, points, tension, fillmode);
		}

		public virtual void DrawClosedCurveAndSave(Pen pen, DPointF[] points,
			float tension, DFillMode fillmode)
		{
			this.DrawClosedCurve(pen, points);
			this.SaveChanges();
		}


		public virtual void DrawClosedCurve(Pen pen, Point[] points)
		{
			this.DrawClosedCurve(pen, points.ToDPoints());
		}

		public virtual void DrawClosedCurveAndSave(Pen pen, Point[] points)
		{
			this.DrawClosedCurve(pen, points);
			this.SaveChanges();
		}

		public virtual void DrawClosedCurve(Pen pen, DPoint[] points)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawClosedCurve(pen, points);
		}

		public virtual void DrawClosedCurveAndSave(Pen pen, DPoint[] points)
		{
			this.DrawClosedCurve(pen, points);
			this.SaveChanges();
		}


		public virtual void DrawClosedCurve(Pen pen, Point[] points, 
			float tension, DFillMode fillmode)
		{
			this.DrawClosedCurve(pen, points.ToDPoints(), 
				tension, fillmode);
		}

		public virtual void DrawClosedCurveAndSave(Pen pen, Point[] points,
			float tension, DFillMode fillmode)
		{
			this.DrawClosedCurve(pen, points, tension, fillmode);
			this.SaveChanges();
		}

		public virtual void DrawClosedCurve(Pen pen, DPoint[] points, 
			float tension, DFillMode fillmode)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawClosedCurve(pen, points, tension, fillmode);
		}

		public virtual void DrawClosedCurveAndSave(Pen pen, DPoint[] points,
			float tension, DFillMode fillmode)
		{
			this.DrawClosedCurve(pen, points);
			this.SaveChanges();
		}




		public virtual void DrawCurve(Pen pen, Vector2[] points, 
			int offset, int numberOfSegments, float tension)
		{
			this.DrawCurve(pen, points.ToDPoints(),
				offset, numberOfSegments, tension);
		}

		public virtual void DrawCurveAndSave(Pen pen, Vector2[] points,
			int offset, int numberOfSegments, float tension)
		{
			this.DrawCurve(pen, points, offset, numberOfSegments, tension);
			this.SaveChanges();
		}

		public virtual void DrawCurve(Pen pen, DPointF[] points, 
			int offset, int numberOfSegments, float tension)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawCurve(pen, points, offset, numberOfSegments, tension);
		}

		public virtual void DrawCurveAndSave(Pen pen, DPointF[] points,
			int offset, int numberOfSegments, float tension)
		{
			this.DrawCurve(pen, points, offset, numberOfSegments, tension);
			this.SaveChanges();
		}


		public virtual void DrawCurve(Pen pen, Vector2[] points)
		{
			this.DrawCurve(pen, points.ToDPoints());
		}

		public virtual void DrawCurveAndSave(Pen pen, Vector2[] points)
		{
			this.DrawCurve(pen, points);
			this.SaveChanges();
		}

		public virtual void DrawCurve(Pen pen, DPointF[] points)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawCurve(pen, points);
		}

		public virtual void DrawCurveAndSave(Pen pen, DPointF[] points)
		{
			this.DrawCurve(pen, points);
			this.SaveChanges();
		}



		public virtual void DrawCurve(Pen pen, Vector2[] points, 
			int offset, int numberOfSegments)
		{
			this.DrawCurve(pen, points.ToDPoints(), offset, numberOfSegments);
		}

		public virtual void DrawCurveAndSave(Pen pen, Vector2[] points,
			int offset, int numberOfSegments)
		{
			this.DrawCurve(pen, points, offset, numberOfSegments);
			this.SaveChanges();
		}

		public virtual void DrawCurve(Pen pen, DPointF[] points, 
			int offset, int numberOfSegments)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawCurve(pen, points, offset, numberOfSegments);
		}

		public virtual void DrawCurveAndSave(Pen pen, DPointF[] points,
			int offset, int numberOfSegments)
		{
			this.DrawCurve(pen, points, offset, numberOfSegments);
			this.SaveChanges();
		}


		public virtual void DrawCurve(Pen pen, Vector2[] points, float tension)
		{
			this.DrawCurve(pen, points.ToDPoints(), tension);
		}

		public virtual void DrawCurveAndSave(Pen pen, Vector2[] points, 
			float tension)
		{
			this.DrawCurve(pen, points, tension);
			this.SaveChanges();
		}

		public virtual void DrawCurve(Pen pen, DPointF[] points, float tension)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawCurve(pen, points, tension);
		}

		public virtual void DrawCurveAndSave(Pen pen, DPointF[] points,
			float tension)
		{
			this.DrawCurve(pen, points, tension);
			this.SaveChanges();
		}


		public virtual void DrawCurve(Pen pen, Point[] points, 
			int offset, int numberOfSegments, float tension)
		{
			this.DrawCurve(pen, points.ToDPoints(),
				offset, numberOfSegments, tension);
		}

		public virtual void DrawCurveAndSave(Pen pen, Point[] points,
			int offset, int numberOfSegments, float tension)
		{
			this.DrawCurve(pen, points, offset, numberOfSegments, tension);
			this.SaveChanges();
		}

		public virtual void DrawCurve(Pen pen, DPoint[] points, 
			int offset, int numberOfSegments, float tension)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawCurve(pen, points, offset, numberOfSegments, tension);
		}

		public virtual void DrawCurveAndSave(Pen pen, DPoint[] points,
			int offset, int numberOfSegments, float tension)
		{
			this.DrawCurve(pen, points, offset, numberOfSegments, tension);
			this.SaveChanges();
		}



		public virtual void DrawCurve(Pen pen, Point[] points, float tension)
		{
			this.DrawCurve(pen, points.ToDPoints(), tension);
		}

		public virtual void DrawCurveAndSave(Pen pen, Point[] points, 
			float tension)
		{
			this.DrawCurve(pen, points, tension);
			this.SaveChanges();
		}

		public virtual void DrawCurve(Pen pen, DPoint[] points, float tension)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawCurve(pen, points, tension);
		}

		public virtual void DrawCurveAndSave(Pen pen, DPoint[] points,
			float tension)
		{
			this.DrawCurve(pen, points, tension);
			this.SaveChanges();
		}


		public virtual void DrawCurve(Pen pen, Point[] points)
		{
			this.DrawCurve(pen, points.ToDPoints());
		}

		public virtual void DrawCurveAndSave(Pen pen, Point[] points)
		{
			this.DrawCurve(pen, points);
			this.SaveChanges();
		}

		public virtual void DrawCurve(Pen pen, DPoint[] points)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawCurve(pen, points);
		}

		public virtual void DrawCurveAndSave(Pen pen, DPoint[] points)
		{
			this.DrawCurve(pen, points);
			this.SaveChanges();
		}



		public virtual void DrawEllipse(Pen pen, int x, int y, 
			int width, int height)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawEllipse(pen, x, y, width, height);
		}
		public virtual void DrawEllipseAndSave(Pen pen, int x, int y,
			int width, int height)
		{
			this.DrawEllipse(pen, x, y, width, height);
			this.SaveChanges();
		}

		public virtual void DrawEllipse(Pen pen, float x, float y, 
			float width, float height)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawEllipse(pen, x, y, width, height);
		}
		public virtual void DrawEllipseAndSave(Pen pen, float x, float y,
			float width, float height)
		{
			this.DrawEllipse(pen, x, y, width, height);
			this.SaveChanges();
		}



		public virtual void DrawEllipse(Pen pen, Vector4 rect)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawEllipse(pen, rect.ToDRectangleF());
		}
		public virtual void DrawEllipseAndSave(Pen pen, Vector4 rect)
		{
			this.DrawEllipse(pen, rect);
			this.SaveChanges();
		}
		public virtual void DrawEllipse(Pen pen, DRectangleF rect)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawEllipse(pen, rect);
		}
		public virtual void DrawEllipseAndSave(Pen pen, DRectangleF rect)
		{
			this.DrawEllipse(pen, rect);
			this.SaveChanges();
		}



		public virtual void DrawEllipse(Pen pen, Rectangle rect)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawEllipse(pen, rect.ToDRectangle());
		}

		public virtual void DrawEllipseAndSave(Pen pen, Rectangle rect)
		{
			this.DrawEllipse(pen, rect);
			this.SaveChanges();
		}
		public virtual void DrawEllipse(Pen pen, DRectangle rect)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawEllipse(pen, rect);
		}

		public virtual void DrawEllipseAndSave(Pen pen, DRectangle rect)
		{
			this.DrawEllipse(pen, rect);
			this.SaveChanges();
		}


		public virtual void DrawIcon(Icon icon, int x, int y)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawIcon(icon, x, y);
		}
		public virtual void DrawIconAndSave(Icon icon, int x, int y)
		{
			this.DrawIcon(icon, x, y);
			this.SaveChanges();
		}


		public virtual void DrawIcon(Icon icon, Rectangle rect)
		{
			this.DrawIcon(icon, rect.ToDRectangle());
		}
		public virtual void DrawIconAndSave(Icon icon, Rectangle rect)
		{
			this.DrawIcon(icon, rect);
			this.SaveChanges();
		}

		public virtual void DrawIcon(Icon icon, DRectangle rect)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawIcon(icon, rect);
		}
		public virtual void DrawIconAndSave(Icon icon, DRectangle rect)
		{
			this.DrawIcon(icon, rect);
			this.SaveChanges();
		}



		public virtual void DrawIconUnstretched(Icon icon, Rectangle rect)
		{
			this.DrawIconUnstretched(icon, rect.ToDRectangle());
		}
		public virtual void DrawIconUnstretchedAndSave(Icon icon, 
			Rectangle rect)
		{
			this.DrawIconUnstretched(icon, rect);
			this.SaveChanges();
		}

		public virtual void DrawIconUnstretched(Icon icon, 
			DRectangle rect)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawIconUnstretched(icon, rect);
		}
		public virtual void DrawIconUnstretchedAndSave(Icon icon, 
			DRectangle rect)
		{
			this.DrawIconUnstretched(icon, rect);
			this.SaveChanges();
		}

		public virtual void DrawImage(Image image, float x, float y, 
			float width, float height)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawImage(image, x, y, width, height);
		}
		public virtual void DrawImageAndSave(Image image, float x, float y, 
			float width, float height)
		{
			this.DrawImage(image, x, y, width, height);
			this.SaveChanges();
		}



		public virtual void DrawImage(Image image, float x, float y, 
			Vector4 srcRect, GraphicsUnit srcUnit)
		{
			this.DrawImage(image, x, y, srcRect.ToDRectangleF(), srcUnit);
		}

		public virtual void DrawImageAndSave(Image image, float x, float y, 
			Vector4 srcRect, GraphicsUnit srcUnit)
		{
			this.DrawImage(image, x, y, srcRect, srcUnit);
			this.SaveChanges();
		}

		public virtual void DrawImage(Image image, float x, float y, 
			DRectangleF srcRect, GraphicsUnit srcUnit)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawImage(image, x, y, srcRect, srcUnit);
		}

		public virtual void DrawImageAndSave(Image image, float x, float y, 
			DRectangleF srcRect, GraphicsUnit srcUnit)
		{
			this.DrawImage(image, x, y, srcRect, srcUnit);
			this.SaveChanges();
		}


		public virtual void DrawImage(Image image, int x, int y,
			int width, int height)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawImage(image, x, y, width, height);
		}
		public virtual void DrawImageAndSave(Image image, int x, int y, 
			int width, int height)
		{
			this.DrawImage(image, x, y, width, height);
			this.SaveChanges();
		}


		public virtual void DrawImage(Image image, Vector2 point)
		{
			this.DrawImage(image, point.ToDPointF());
		}
		public virtual void DrawImageAndSave(Image image, Vector2 point)
		{
			this.DrawImage(image, point);
			this.SaveChanges();
		}
		public virtual void DrawImage(Image image, DPointF point)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawImage(image, point);
		}
		public virtual void DrawImageAndSave(Image image, DPointF point)
		{
			this.DrawImage(image, point);
			this.SaveChanges();
		}
		

		public virtual void DrawImage(Image image, Vector2[] destPoints)
		{
			this.DrawImage(image, destPoints.ToDPoints());
		}
		public virtual void DrawImageAndSave(Image image, Vector2[] destPoints)
		{
			this.DrawImage(image, destPoints);
			this.SaveChanges();
		}
		public virtual void DrawImage(Image image, DPointF[] destPoints)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawImage(image, destPoints);
		}
		public virtual void DrawImageAndSave(Image image, DPointF[] destPoints)
		{
			this.DrawImage(image, destPoints);
			this.SaveChanges();
		}
		

		public virtual void DrawImage(Image image, Point point)
		{
			this.DrawImage(image, point.ToDPoint());
		}
		public virtual void DrawImageAndSave(Image image, Point point)
		{
			this.DrawImage(image, point);
			this.SaveChanges();
		}
		public virtual void DrawImage(Image image, DPoint point)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawImage(image, point);
		}
		public virtual void DrawImageAndSave(Image image, DPoint point)
		{
			this.DrawImage(image, point);
			this.SaveChanges();
		}
		



		public virtual void DrawImage(Image image, Vector2[] destPoints, 
			Vector4 srcRect, GraphicsUnit srcUnit, ImageAttributes imageAttr, 
			Graphic.DrawImageAbort callback, int callbackData)
		{
			this.DrawImage(image, destPoints.ToDPoints(),
				srcRect.ToDRectangleF(), srcUnit, imageAttr, 
				callback, callbackData);
		}
		public virtual void DrawImageAndSave(Image image, 
			Vector2[] destPoints, Vector4 srcRect,
			GraphicsUnit srcUnit, ImageAttributes imageAttr, 
			Graphic.DrawImageAbort callback, int callbackData)
		{
			this.DrawImage(image, destPoints, 
				srcRect, srcUnit, imageAttr, callback, callbackData);
			this.SaveChanges();
		}
		public virtual void DrawImage(Image image, DPointF[] destPoints,
			DRectangleF srcRect, GraphicsUnit srcUnit, 
			ImageAttributes imageAttr, Graphic.DrawImageAbort callback, 
			int callbackData)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawImage(image, destPoints, 
				srcRect, srcUnit, imageAttr, callback, callbackData);
		}
		public virtual void DrawImageAndSave(Image image, DPointF[] destPoints,
			DRectangleF srcRect, GraphicsUnit srcUnit, 
			ImageAttributes imageAttr, Graphic.DrawImageAbort callback,
			int callbackData)
		{
			this.DrawImage(image, destPoints, 
				srcRect, srcUnit, imageAttr, callback, callbackData);
			this.SaveChanges();
		}
		

		public virtual void DrawImage(Image image, float x, float y)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawImage(image, x, y);
		}
		public virtual void DrawImageAndSave(Image image, float x, float y)
		{
			this.DrawImage(image, x, y);
			this.SaveChanges();
		}







		
		
		
		
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual void DrawLineAndSave(Pen pen, Point pt1, Point pt2)
		{
			this.DrawLine(pen, pt1, pt2);
			this.SaveChanges();
		}
		/// <summary>
		///  Draws a line connecting two <see cref="Point"/> structures.
		/// This method is good when you want to use a lot of
		/// drawing operations (like drawing multiple lines, 
		/// rectangles, etc...), and at the end you have to save them all.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual void DrawLine(Pen pen, Point pt1, Point pt2)
		{
			if (this._g == null)
			{
				this.AllocateGraphics();
			}
			this._g.DrawLine(pen, pt1.ToDPoint(), pt1.ToDPoint());
		}
		/// <summary>
		/// Saves the changes applied to the graphical component of
		/// this <see cref="Illusion"/>.
		/// Normally you don't need to use this method.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		public virtual void SaveChanges()
		{
			this._g?.Save();
		}
		#endregion
		//-------------------------------------------------
		#region event Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region overrided Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region ordinary Method's Region
		public void Dispose()
		{
			this._bit_map?.Dispose();
			this._texture?.Dispose();
		}

		/// <summary>
		/// Async the Texture component of this <see cref="Illusion"/>
		/// if and only if <c>_changed</c> value of it is true.
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal virtual void AsyncComponent(bool force = false)
		{
			if (_changed || force && (_bit_map != null || _texture != null))
			{
				if (_texture == null)
				{
					_bit_map = _texture.ToBitmap();
				}
				else
				{
					_texture = _bit_map.ToTexture2D();
				}
			}
			_changed = false;
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal virtual void AsyncNormal(bool force = false)
		{
			if ((_changed || force) && 
					_bit_map != null && _texture != null)
			{
				_texture = _bit_map.ToTexture2D();
				_changed = false;
			}
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal virtual void AllocateTexture2D()
		{
			if (_texture == null && _bit_map != null)
			{
				_texture = _bit_map.ToTexture2D();
			}
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal virtual void AllocateBitmap()
		{
			if (_bit_map == null && _texture != null)
			{
				_bit_map = _texture.ToBitmap();
			}
		}
		/// <summary>
		///
		/// <!--
		/// Since: GUISharp 1.0.36;
		/// By: ALiwoto;
		/// Last edit: 11 July 13:37;
		/// Sign: ALiwoto;
		/// Verified: Yes;
		/// -->
		/// </summary>
		protected internal virtual void AllocateGraphics(bool force = false)
		{
			if (this._g == null || force)
			{
				this._g?.Dispose();
				if (this._bit_map == null)
				{
					this.AllocateBitmap();
				}
				this._g = Graphic.FromImage(_bit_map);
			}
		}
		#endregion
		//-------------------------------------------------
		#region Get Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region Set Method's Region
		// some methods here
		#endregion
		//-------------------------------------------------
		#region static Method's Region
		/// <summary>
		/// Get an illusion by passed-by texture parameter
		/// as its component.
		/// </summary>
		/// <param name="_texture"> 
		/// the texture component.
		/// </param>
		public static Illusion GetIllusion(Texture2D _texture)
		{
			if (_texture != null && !_texture.IsDisposed)
			{
				return new(_texture);
			}
			return null;
		}
		
		/// <summary>
		/// Get an illusion by passed-by texture parameter
		/// as its component with specified with and height.
		/// </summary>
		/// <param name="_texture"> 
		/// the texture component.
		/// </param>
		/// <param name="_w"> 
		/// the with.
		/// </param>
		/// <param name="_h"> 
		/// the height.
		/// </param>
		public static Illusion GetIllusion(Texture2D _texture, 
											int _w, int _h)
		{
			if (_texture != null && _texture.IsDisposed)
			{
				var _rect = 
					new Rectangle(DEFAULT_Z_BASE, DEFAULT_Z_BASE, _w, _h);
				if (_texture.Bounds.Contains(_rect))
				{
					return GetIllusion(_texture, _rect);
				}	
			}
			return null;
		}
		
		/// <summary>
		/// Get an illusion by passed-by texture parameter
		/// as its component with specified region.
		/// </summary>
		/// <param name="_texture"> 
		/// the texture component.
		/// </param>
		/// <param name="_rect"> 
		/// the region.
		/// </param>
		public static Illusion GetIllusion(Texture2D _texture, 
											in Rectangle _rect)
		{
			if (_texture != null && !_texture.IsDisposed)
			{
				var client = ThereIsGConstants.Forming.GClient;
				var g = client.GraphicsDevice;
				if (g != null && !g.IsDisposed)
				{
					if (!_texture.Bounds.Contains(_rect))
					{
						return null;
					}
					var _t = new Texture2D(g, _rect.Width, _rect.Height);
					var _data = new Color[_rect.Width * _rect.Height];
					_texture.GetData(_data, DEFAULT_Z_BASE, _data.Length);
					_t.SetData(_data, DEFAULT_Z_BASE, _data.Length);
					return GetIllusion(_t);
				}
			}
			return null;
		}
		
		/// <summary>
		/// Get an illusion by passed-by path to texture parameter
		/// as its component.
		/// </summary>
		/// <param name="_full_path"> 
		/// the texture full path in the local storage.
		/// </param>
		public static Illusion GetIllusion(StrongString _full_path)
		{
			if (_full_path == null)
			{
				return null;
			}
			var _b1 = !_full_path.IsHealthy();
			var _b2 = !File.Exists(_full_path.GetValue());
			if (_b1 || _b2)
			{
				return null;
			}
			var client = ThereIsGConstants.Forming.GClient;
			if (client != null && client.Verified)
			{
				var g = client.GraphicsDevice;
				if (g != null && !g.IsDisposed)
				{
					var _t = Texture2D.FromFile(g, _full_path.GetValue());
					return GetIllusion(_t);
				}
			}
			return null;
		}
		
		/// <summary>
		/// Get an illusion by passed-by path to texture parameter
		/// as its component with specified with and height.
		/// </summary>
		/// <param name="_full_path"> 
		/// the texture full path in the local storage.
		/// </param>
		/// <param name="w"> 
		/// the with.
		/// </param>
		/// <param name="h"> 
		/// the height.
		/// </param>
		public static Illusion GetIllusion(StrongString _full_path, 
											int w, int h)
		{
			if (_full_path == null)
			{
				return null;
			}
			var _b1 = !_full_path.IsHealthy();
			var _b2 = !File.Exists(_full_path.GetValue());
			if (_b1 || _b2)
			{
				return null;
			}
			var client = ThereIsGConstants.Forming.GClient;
			if (client != null && client.Verified)
			{
				var g = client.GraphicsDevice;
				if (g != null && !g.IsDisposed)
				{
					var t1 = Texture2D.FromFile(g, _full_path.GetValue());
					return GetIllusion(t1, w, h);
				}
			}
			return null;
		}
		
		/// <summary>
		/// Get an illusion by passed-by path to texture parameter
		/// as its component with specified region.
		/// </summary>
		/// <param name="_full_path"> 
		/// the texture full path in the local storage.
		/// </param>
		/// <param name="_rect"> 
		/// the region.
		/// </param>
		public static Illusion GetIllusion(StrongString _full_path, 
											in Rectangle _rect)
		{
			if (_full_path == null)
			{
				return null;
			}
			var _b1 = !_full_path.IsHealthy();
			var _b2 = !File.Exists(_full_path.GetValue());
			if (_b1 || _b2)
			{
				return null;
			}
			var client = ThereIsGConstants.Forming.GClient;
			if (client != null && client.Verified)
			{
				var g = client.GraphicsDevice;
				if (g != null && !g.IsDisposed)
				{
					var _t = Texture2D.FromFile(g, _full_path.GetValue());
					return GetIllusion(_t, _rect);
				}
			}
			return null;
		}
		
		/// <summary>
		/// Get an illusion by passed-by stream.
		/// notice that the stream should be readable.
		/// </summary>
		/// <param name="_stream"> 
		/// the stream which contains the data for the texture component.
		/// </param>
		public static Illusion GetIllusion(Stream _stream)
		{
			if (_stream == null || !_stream.CanRead)
			{
				return null;
			}
			var client = ThereIsGConstants.Forming.GClient;
			if (client != null && client.Verified)
			{
				var g = client.GraphicsDevice;
				if (g != null && !g.IsDisposed)
				{
					var _t = Texture2D.FromStream(g, _stream);
					return GetIllusion(_t);
				}
			}
			return null;
		}
		
		/// <summary>
		/// Get an illusion by passed-by stream with the specified width
		/// and height.
		/// notice that the stream should be readable.
		/// </summary>
		/// <param name="_stream"> 
		/// the stream which contains the data for the texture component.
		/// </param>
		/// <param name="w"> 
		/// the width.
		/// </param>
		/// <param name="h"> 
		/// the height.
		/// </param>
		public static Illusion GetIllusion(Stream _stream, 
											int w, int h)
		{
			var client = ThereIsGConstants.Forming.GClient;
			if (client != null && client.Verified)
			{
				var g = client.GraphicsDevice;
				if (g != null && !g.IsDisposed)
				{
					var _t = Texture2D.FromStream(g, _stream);
					return GetIllusion(_t, w, h);
				}
			}
			return null;
		}
		
		/// <summary>
		/// Get an illusion by passed-by stream with the specified region.
		/// notice that the stream should be readable.
		/// </summary>
		/// <param name="_stream"> 
		/// the stream which contains the data for the texture component.
		/// </param>
		/// <param name="_rect"> 
		/// the region.
		/// </param>
		public static Illusion GetIllusion(Stream _stream, 
											in Rectangle _rect)
		{
			var client = ThereIsGConstants.Forming.GClient;
			if (client != null && client.Verified)
			{
				var g = client.GraphicsDevice;
				if (g != null && !g.IsDisposed)
				{
					var _t = Texture2D.FromStream(g, _stream);
					return GetIllusion(_t, _rect);
				}
			}
			return null;
		}
		
		/// <summary>
		/// Get an illusion by passed-by byte data.
		/// notice that the byte data is not the texture's data,
		/// it's the file data.
		/// </summary>
		/// <param name="_file_data"> 
		/// the byte data.
		/// </param>
		public static Illusion GetIllusion(byte[] _file_data)
		{
			Stream m = new MemoryStream(_file_data);
			if (_file_data != null && m.CanRead)
			{
				return GetIllusion(m);
			}
			return null;
		}

		/// <summary>
		/// Get an illusion by passed-by byte data with specified width
		/// and height.
		/// notice that the byte data is not the texture's data,
		/// it's the file data.
		/// </summary>
		/// <param name="_file_data"> 
		/// the byte data.
		/// </param>
		/// <param name="_w"> 
		/// the width.
		/// </param>
		/// <param name="_h"> 
		/// the height.
		/// </param>
		public static Illusion GetIllusion(byte[] _file_data, 
											int _w, int _h)
		{
			var m = new MemoryStream(_file_data);
			if (m != null && m.CanRead)
			{
				return GetIllusion(m, _w, _h);
			}
			return null;
		}

		/// <summary>
		/// Get an illusion by passed-by byte data with specified region.
		/// notice that the byte data is not the texture's data,
		/// it's the file data.
		/// </summary>
		/// <param name="_file_data"> 
		/// the byte data.
		/// </param>
		/// <param name="_rect"> 
		/// the region.
		/// </param>
		public static Illusion GetIllusion(byte[] _file_data, 
											in Rectangle _rect)
		{
			var m = new MemoryStream(_file_data);
			if (m != null && m.CanRead)
			{
				return GetIllusion(m, _rect);
			}
			return null;
		}
		
		#endregion
		//-------------------------------------------------
	}
}