using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HighSign.Common.Drawing
{
	public static class ImageHelper
	{
		#region Static Methods

		public static void DrawRoundedRectangle(Graphics gfx, Rectangle Bounds, int CornerRadius, Pen DrawPen, Color FillColor)
		{
			int strokeOffset = Convert.ToInt32(Math.Ceiling(DrawPen.Width / 2F));
			Bounds = Rectangle.Inflate(Bounds, -strokeOffset, -strokeOffset);

			DrawPen.EndCap = DrawPen.StartCap = LineCap.Round;

			GraphicsPath gfxPath = new GraphicsPath();
			gfxPath.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
			gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
			gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
			gfxPath.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
			gfxPath.CloseAllFigures();

			gfx.FillPath(new SolidBrush(FillColor), gfxPath);
			gfx.DrawPath(DrawPen, gfxPath);
		}

		public static Image AlignImage(Image Input, Size OutputSize, ContentAlignment Align)
		{
			// Create new bitmap of given size
			Bitmap bmpMap = new Bitmap(OutputSize.Width, OutputSize.Height);
			// Create graphics from bitmap
			Graphics gfxBitmap = Graphics.FromImage((Image)bmpMap);

			// Define point that will hold the calculated offset
			Point pntOffset = new Point();

			// Where does the user want to draw the image
			switch (Align)
			{
				case ContentAlignment.BottomCenter:
					pntOffset.X = (int)((OutputSize.Width / 2) - (Input.Width / 2));
					pntOffset.Y = (int)(OutputSize.Height - Input.Height);

					break;
				case ContentAlignment.BottomLeft:
					pntOffset.X = 0;
					pntOffset.Y = (int)(OutputSize.Height - Input.Height);

					break;
				case ContentAlignment.BottomRight:
					pntOffset.X = (int)(OutputSize.Width - Input.Width);
					pntOffset.Y = (int)(OutputSize.Height - Input.Height);

					break;
				case ContentAlignment.MiddleCenter:
					pntOffset.X = (int)((OutputSize.Width / 2) - (Input.Width / 2));
					pntOffset.Y = (int)((OutputSize.Height / 2) - (Input.Width / 2));

					break;
				case ContentAlignment.MiddleLeft:
					pntOffset.X = 0;
					pntOffset.Y = (int)((OutputSize.Height / 2) - (Input.Width / 2));

					break;
				case ContentAlignment.MiddleRight:
					pntOffset.X = (int)(OutputSize.Width - Input.Width);
					pntOffset.Y = (int)((OutputSize.Height / 2) - (Input.Width / 2));

					break;
				case ContentAlignment.TopCenter:
					pntOffset.X = (int)((OutputSize.Width / 2) - (Input.Width / 2));
					pntOffset.Y = 0;

					break;
				case ContentAlignment.TopLeft:
					pntOffset.X = 0;
					pntOffset.Y = 0;

					break;
				case ContentAlignment.TopRight:
					pntOffset.X = (int)(OutputSize.Width - Input.Width);
					pntOffset.Y = 0;

					break;
				default:
					pntOffset = Point.Empty;

					break;
			}

			// Draw image in new position
			gfxBitmap.DrawImageUnscaled(Input, pntOffset);

			// Return results
			return (Image)bmpMap;
		}

		#endregion
	}
}
