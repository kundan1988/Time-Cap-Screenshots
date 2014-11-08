using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using MyTimecapCalendar.Components;

namespace MyTimecapCalendar
{
	public delegate void DateSelected(DateTime date);
	public delegate void MonthChanged(DateTime monthSelected);

	public class TimeCapCalendar : UIView
	{
		public static String BasePath = "images/";

		/// <summary>
		/// Fired when new date selected.
		/// </summary>
		public Action<DateTime> DateSelected;

		/// <summary>
		/// Fired when date selection finished
		/// </summary>
		public Action<DateTime> DateSelectionFinished;

		/// <summary>
		/// Fired when Selected month changed
		/// </summary>
		public Action<DateTime> MonthChanged;

		/// <summary>
		/// Mark with a dot dates that fulfill the predicate
		/// </summary>
		public Func<DateTime, bool> IsDayMarkedDelegate;

		/// <summary>
		/// Turn gray dates that fulfill the predicate
		/// </summary>
		public Func<DateTime, bool> IsDateAvailable;

		public DateTime CurrentMonthYear;

		protected DateTime CurrentDate { get; set; }

		private UIScrollView _scrollView;
		private bool calendarIsLoaded;

		private MonthGridView _monthGridView;
		private UIButton _leftButton, _rightButton;

		// User Customizations

		/// <summary>
		/// If true, Sunday will be showed as the first day of the week, otherwise the first one will be Monday
		/// </summary>
		/// <value><c>true</c> if sunday first; otherwise, <c>false</c>.</value>
		public Boolean SundayFirst { get; set; }

		/// <summary>
		/// Format string used to display the month's name
		/// </summary>
		/// <value>The month format string.</value>
		public String MonthFormatString { get; set; }

		/// <summary>
		/// Specify the color for the selected date
		/// </summary>
		/// <value>The color of the selection.</value>
		public UIColor SelectionColor { get; set; }

		/// <summary>
		/// Gets or sets the left arrow image (32x32 px).
		/// </summary>
		/// <value>The left arrow.</value>
		public UIImage LeftArrow { get; set; }

		/// <summary>
		/// Gets or sets the right arrow image (32x32 px).
		/// </summary>
		/// <value>The right arrow.</value>
		public UIImage RightArrow { get; set; }

		/// <summary>
		/// Gets or sets the top bar image (320x44 px).
		/// </summary>
		/// <value>The top bar.</value>
		public UIImage TopBar { get; set; }
		public TimeCapCalendar() : base(new RectangleF(0, 0, 320, 400))
		{
			CurrentDate = DateTime.Now;
			CurrentMonthYear = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
			BackgroundColor = UIColor.White;

			// Defaults

			SundayFirst = false;

			MonthFormatString = "MMMM yyyy";

			SelectionColor = UIColor.Red;

			LeftArrow = UIImage.FromBundle(BasePath + "leftArrow");
			RightArrow = UIImage.FromBundle(BasePath + "rightArrow");
			TopBar = UIImage.FromBundle(BasePath + "topbar");
		}

		public override void SetNeedsDisplay ()
		{
			base.SetNeedsDisplay();

			AdjustBackgroundColor ();

			if (_monthGridView!=null)
				_monthGridView.Update();
		}

		public override void LayoutSubviews ()
		{
			AdjustBackgroundColor ();

			if (calendarIsLoaded) return;

			_scrollView = new UIScrollView(new RectangleF(0, 44, 320, 460 - 44))
			{
				ContentSize = new SizeF(320, 260),
				ScrollEnabled = false,
				Frame = new RectangleF(0, 44, 320, 460-44),
				BackgroundColor = UIColor.White
			};

			LoadButtons();

			LoadInitialGrids();

			AddSubview(_scrollView);
			_scrollView.AddSubview(_monthGridView);

			calendarIsLoaded = true;
		}

		public void DeselectDate(){
			if (_monthGridView!=null)
				_monthGridView.DeselectDayView();
		}

		private void LoadButtons()
		{
			_leftButton = UIButton.FromType(UIButtonType.Custom);
			_leftButton.TouchUpInside += HandlePreviousMonthTouch;
			_leftButton.SetImage(LeftArrow, UIControlState.Normal);
			AddSubview(_leftButton);
			_leftButton.Frame = new RectangleF(10, 0, 44, 42);

			_rightButton = UIButton.FromType(UIButtonType.Custom);
			_rightButton.TouchUpInside += HandleNextMonthTouch;
			_rightButton.SetImage(RightArrow, UIControlState.Normal);
			AddSubview(_rightButton);
			_rightButton.Frame = new RectangleF(320 - 56, 0, 44, 42);
		}

		private void HandlePreviousMonthTouch(object sender, EventArgs e)
		{
			MoveCalendarMonths(false, true);
		}
		private void HandleNextMonthTouch(object sender, EventArgs e)
		{
			MoveCalendarMonths(true, true);
		}

		public void MoveCalendarMonths(bool upwards, bool animated)
		{
			CurrentMonthYear = CurrentMonthYear.AddMonths(upwards? 1 : -1);
			UserInteractionEnabled = false;

			if (MonthChanged != null)
				MonthChanged(CurrentMonthYear);

			var gridToMove = CreateNewGrid(CurrentMonthYear);
			var pointsToMove = (upwards? 0 + _monthGridView.Lines : 0 - _monthGridView.Lines) * 44;

			if (upwards && gridToMove.weekdayOfFirst==0)
				pointsToMove += 44;
			if (!upwards && _monthGridView.weekdayOfFirst==0)
				pointsToMove -= 44;

			gridToMove.Frame = new RectangleF(new PointF(0, pointsToMove), gridToMove.Frame.Size);

			_scrollView.AddSubview(gridToMove);

			if (animated){
				UIView.BeginAnimations("changeMonth");
				UIView.SetAnimationDuration(0.4);
				UIView.SetAnimationDelay(0.1);
				UIView.SetAnimationCurve(UIViewAnimationCurve.EaseInOut);
			}

			_monthGridView.Center = new PointF(_monthGridView.Center.X, _monthGridView.Center.Y - pointsToMove);
			gridToMove.Center = new PointF(gridToMove.Center.X, gridToMove.Center.Y - pointsToMove);

			_monthGridView.Alpha = 0;

			_scrollView.Frame = new RectangleF(
				_scrollView.Frame.Location,
				new SizeF(_scrollView.Frame.Width, (gridToMove.Lines) * 44));

			_scrollView.ContentSize = _scrollView.Frame.Size;
			SetNeedsDisplay();

			if (animated)
				UIView.CommitAnimations();

			_monthGridView = gridToMove;

			UserInteractionEnabled = true;

			AdjustBackgroundColor ();
		}

		private void AdjustBackgroundColor()
		{
			if (_scrollView != null)
				_scrollView.BackgroundColor = UIColor.White;
			BackgroundColor = UIColor.White;
		}

		private MonthGridView CreateNewGrid(DateTime date){
			var grid = new MonthGridView(this, date);
			grid.CurrentDate = CurrentDate;
			grid.BuildGrid();
			grid.Frame = new RectangleF(0, 0, 320, 400);
			return grid;
		}

		private void LoadInitialGrids()
		{
			_monthGridView = CreateNewGrid(CurrentMonthYear);

			var rect = _scrollView.Frame;
			rect.Size = new SizeF { Height = (_monthGridView.Lines) * 44, Width = rect.Size.Width };
			_scrollView.Frame = rect;

			Frame = new RectangleF(Frame.X, Frame.Y, _scrollView.Frame.Size.Width, _scrollView.Frame.Size.Height+44);
		}

		public override void Draw(RectangleF rect)
		{
			TopBar.Draw(new PointF(0,0));
			DrawDayLabels(rect);
			DrawMonthLabel(rect);
		}

		private void DrawMonthLabel(RectangleF rect)
		{
			var r = new RectangleF(new PointF(0, 5), new SizeF {Width = 320, Height = 42});
			UIColor.Black.SetColor ();
			DrawString(CurrentMonthYear.ToString(MonthFormatString, new CultureInfo(NSLocale.CurrentLocale.LanguageCode)), 
				r, UIFont.SystemFontOfSize(20),
				UILineBreakMode.WordWrap, UITextAlignment.Center);
		}

		private void DrawDayLabels(RectangleF rect)
		{
			var font = UIFont.SystemFontOfSize(10);
			UIColor.Black.SetColor ();
			var context = UIGraphics.GetCurrentContext();
			context.SaveState();
			var i = 0;

			var cultureInfo = new CultureInfo(NSLocale.CurrentLocale.LanguageCode);

			cultureInfo.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
			var dayNames = cultureInfo.DateTimeFormat.DayNames;

			if (!SundayFirst) 
			{
				// Shift Sunday to the end of the week
				var firstDay = dayNames [0];
				for (int count = 0; count < dayNames.Length - 1; count++)
					dayNames [count] = dayNames [count + 1];
				dayNames [dayNames.Length - 1] = firstDay;
			}

			foreach (var d in dayNames)
			{
				DrawString(d.Substring(0, 3), new RectangleF(i*46, 44 - 12, 45, 10), font,
					UILineBreakMode.WordWrap, UITextAlignment.Center);
				i++;
			}
			context.RestoreState();
		}
	}
}