//	New implementations, refactoring and restyling - FactoryMind || http://factorymind.com 
//  Converted to MonoTouch on 1/22/09 - Eduardo Scoz || http://escoz.com
using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace MyTimecapCalendar.Components
{
	class CalendarDayView : UIView
	{
		string _text;
		public DateTime Date {get;set;}
		bool _active, _today, _selected, _marked, _available;
		public bool Available {get {return _available; } set {_available = value; SetNeedsDisplay(); }}
		public string Text {get { return _text; } set { _text = value; SetNeedsDisplay(); } }
		public bool Active {get { return _active; } set { _active = value; SetNeedsDisplay();  } }
		public bool Today {get { return _today; } set { _today = value; SetNeedsDisplay(); } }
		public bool Selected {get { return _selected; } set { _selected = value; SetNeedsDisplay(); } }
		public bool Marked {get { return _marked; } set { _marked = value; SetNeedsDisplay(); }  }

		public UIColor SelectionColor { get; set; }

		public override void Draw(RectangleF rect)
		{
			if (SelectionColor == null)
				SelectionColor = UIColor.Red;

			UIImage img = UIImage.FromFile(TimeCapCalendar.BasePath + "datecell.png");
			UIColor color = UIColor.Black;

			if (!Active || !Available)
			{
				color = UIColor.FromRGBA(0.576f, 0.608f, 0.647f, 1f);
				if(Selected)
					color = SelectionColor;
			} else if (Today && Selected)
			{
				color = UIColor.White;
				img = UIImage.FromFile(TimeCapCalendar.BasePath + "today.png");
			} else if (Today)
			{
				color = UIColor.White;
				img = UIImage.FromFile(TimeCapCalendar.BasePath + "today.png");
			} else if (Selected)
			{
				color = SelectionColor;
			}

			img.Draw(new PointF(0, 0));
			color.SetColor();

			DrawString(Text, RectangleF.Inflate(Bounds, 4, -8),
				UIFont.SystemFontOfSize (22), 
				UILineBreakMode.WordWrap, UITextAlignment.Center);

			if (Marked)
			{
				var context = UIGraphics.GetCurrentContext();
				if (Selected && !Today)
					SelectionColor.SetColor ();
				else if (Today)
					UIColor.White.SetColor ();
				else if (!Active || !Available)
					UIColor.LightGray.SetColor ();
				else
					UIColor.Black.SetColor ();

				context.SetLineWidth(0);
				context.AddEllipseInRect(new RectangleF(Frame.Size.Width/2 - 2, 45-10, 4, 4));
				context.FillPath();

			}
		}
	}
}

