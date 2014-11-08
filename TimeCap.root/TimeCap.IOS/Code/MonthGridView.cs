//	New implementations, refactoring and restyling - FactoryMind || http://factorymind.com 
//  Converted to MonoTouch on 1/22/09 - Eduardo Scoz || http://escoz.com
//  Originally reated by Devin Ross on 7/28/09  - tapku.com || http://github.com/devinross/tapkulibrary
//
/*
 
 Permission is hereby granted, free of charge, to any person
 obtaining a copy of this software and associated documentation
 files (the "Software"), to deal in the Software without
 restriction, including without limitation the rights to use,
 copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the
 Software is furnished to do so, subject to the following
 conditions:
 
 The above copyright notice and this permission notice shall be
 included in all copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 OTHER DEALINGS IN THE SOFTWARE.
 
 */

using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.Foundation;

namespace MyTimecapCalendar.Components
{
	class MonthGridView : UIView
	{
		private TimeCapCalendar _calendarMonthView;

		public DateTime CurrentDate {get;set;}
		private DateTime _currentMonth;
		protected readonly IList<CalendarDayView> _dayTiles = new List<CalendarDayView>();
		public int Lines { get { return 6; } }
		protected CalendarDayView SelectedDayView {get;set;}
		public int weekdayOfFirst;
		public IList<DateTime> Marks { get; set; }

		public MonthGridView(TimeCapCalendar calendarMonthView, DateTime month)
		{
			_calendarMonthView = calendarMonthView;
			_currentMonth = month.Date;
		}

		public void Update(){
			foreach (var v in _dayTiles)
				updateDayView(v);

			this.SetNeedsDisplay();
		}

		public void updateDayView(CalendarDayView dayView){
			dayView.Marked = _calendarMonthView.IsDayMarkedDelegate == null ? 
				false : _calendarMonthView.IsDayMarkedDelegate(dayView.Date);
			dayView.Available = _calendarMonthView.IsDateAvailable == null ? 
				true : _calendarMonthView.IsDateAvailable(dayView.Date);
		}

		private int WeekDayIndex(DayOfWeek day)
		{
			var index = (int)day;

			if (!_calendarMonthView.SundayFirst) {
				if (day == DayOfWeek.Sunday)
					index = (int)DayOfWeek.Saturday;
				else
					index--;
			}

			return index;
		}

		public void BuildGrid()
		{
			DateTime previousMonth = _currentMonth.AddMonths(-1);
			DateTime nextMonth = _currentMonth.AddMonths(1);
			var daysInPreviousMonth = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
			var daysInMonth = DateTime.DaysInMonth(_currentMonth.Year, _currentMonth.Month);
			weekdayOfFirst = WeekDayIndex(_currentMonth.DayOfWeek);
			var lead = daysInPreviousMonth - (weekdayOfFirst - 1);

			// build last month's days
			for (int i = 1; i <= weekdayOfFirst; i++)
			{
				var viewDay = new DateTime(previousMonth.Year, previousMonth.Month, i);
				var dayView = new CalendarDayView() { SelectionColor = _calendarMonthView.SelectionColor };
				dayView.Frame = new RectangleF((i - 1) * 46 - 1, 0, 47, 45);
				dayView.Date = viewDay;
				dayView.Text = lead.ToString();

				AddSubview(dayView);
				_dayTiles.Add(dayView);
				lead++;
			}

			var position = weekdayOfFirst+1;
			var line = 0;

			// current month
			for (int i = 1; i <= daysInMonth; i++)
			{
				var viewDay = new DateTime(_currentMonth.Year, _currentMonth.Month, i);
				var dayView = new CalendarDayView
				{
					Frame = new RectangleF((position - 1) * 46 - 1, line * 44, 47, 45),
					Today = (CurrentDate.Date==viewDay.Date),
					Text = i.ToString(),

					Active = true,
					Tag = i,
					//Selected = (i == CurrentDate.AddDays(1).Day)
					SelectionColor = _calendarMonthView.SelectionColor,
				};
				dayView.Date = viewDay;
				updateDayView(dayView);

				if (dayView.Selected)
					SelectedDayView = dayView;

				AddSubview(dayView);
				_dayTiles.Add(dayView);

				position++;
				if (position > 7)
				{
					position = 1;
					line++;
				}
			}

			//next month
			if (position != 1)
			{
				int dayCounter = 1;
				for (int i = position; i < 8; i++)
				{
					var viewDay = new DateTime(nextMonth.Year, nextMonth.Month, i);
					var dayView = new CalendarDayView
					{
						Frame = new RectangleF((i - 1) * 46 -1, line * 44, 47, 45),
						Text = dayCounter.ToString(),
						SelectionColor = _calendarMonthView.SelectionColor,
					};
					dayView.Date = viewDay;
					updateDayView(dayView);

					AddSubview(dayView);
					_dayTiles.Add(dayView);
					dayCounter++;
				}
			}

			Frame = new RectangleF(Frame.Location, new SizeF(Frame.Width, (line + 1) * 44));

			//Lines = (position == 1 ? line - 1 : line);

			if (SelectedDayView!=null)
				this.BringSubviewToFront(SelectedDayView);
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			if (SelectDayView((UITouch)touches.AnyObject)&& _calendarMonthView.DateSelected!=null)
				_calendarMonthView.DateSelected(new DateTime(_currentMonth.Year, _currentMonth.Month, SelectedDayView.Tag));
		}

		public override void TouchesMoved (NSSet touches, UIEvent evt)
		{
			base.TouchesMoved (touches, evt);
			if (SelectDayView((UITouch)touches.AnyObject)&& _calendarMonthView.DateSelected!=null)
				_calendarMonthView.DateSelected(new DateTime(_currentMonth.Year, _currentMonth.Month, SelectedDayView.Tag));
		}

		public override void TouchesEnded (NSSet touches, UIEvent evt)
		{
			base.TouchesEnded (touches, evt);
			if (_calendarMonthView.DateSelectionFinished==null) return;
			var date = new DateTime(_currentMonth.Year, _currentMonth.Month, SelectedDayView.Tag);
			if (_calendarMonthView.IsDateAvailable == null || _calendarMonthView.IsDateAvailable(date))
				_calendarMonthView.DateSelectionFinished(date);
		}

		private bool SelectDayView(UITouch touch){
			var p = touch.LocationInView(this);

			int index = ((int)p.Y / 44) * 7 + ((int)p.X / 46);
			if(index<0 || index >= _dayTiles.Count) return false;

			var newSelectedDayView = _dayTiles[index];
			if (newSelectedDayView == SelectedDayView) 
				return false;

			if (!newSelectedDayView.Active && touch.Phase!=UITouchPhase.Moved){
				var day = int.Parse(newSelectedDayView.Text);
				if (day > 15)
					_calendarMonthView.MoveCalendarMonths(false, true);
				else
					_calendarMonthView.MoveCalendarMonths(true, true);
				return false;
			} else if (!newSelectedDayView.Active && !newSelectedDayView.Available){
				return false;
			}
			else if (newSelectedDayView.Date.Month != _currentMonth.Month)
			{
				return false;
			}

			if (SelectedDayView!=null)
				SelectedDayView.Selected = false;

			this.BringSubviewToFront(newSelectedDayView);
			newSelectedDayView.Selected = true;

			SelectedDayView = newSelectedDayView;
			SetNeedsDisplay();
			return true;
		}

		public void DeselectDayView(){
			if (SelectedDayView==null) return;
			SelectedDayView.Selected= false;
			SelectedDayView = null;
			SetNeedsDisplay();
		}
	}
}