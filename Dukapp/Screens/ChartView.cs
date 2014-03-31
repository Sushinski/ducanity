using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using OxyPlot;
using OxyPlot.MonoTouch;
using System.Collections.Generic;
using DukappCore.BL.Records;

namespace Dukapp
{
	using System.Collections.ObjectModel;
	using System.Globalization;
	public partial class ChartView : UIView
	{

		public class DateValue
		{
			public DateTime Date { get; set; }
			public int Weight { get; set; }
		}

		List<ScheduleRecord> m_sch_list;
		private readonly PlotModel plotModel;
		RectangleF plotFrame;
		public GraphView image_plotted_by_OxyPlot;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public ChartView ( List<ScheduleRecord> sch_list, RectangleF rect )
			: base (rect)
		{
			m_sch_list = sch_list;
			plotModel = DateTimeaxisPlotModel();
            //this.BackgroundColor = UIColor.Clear;
			plotFrame = this.Bounds;
			image_plotted_by_OxyPlot = new GraphView(plotModel);
			image_plotted_by_OxyPlot.Frame = plotFrame;
			this.AddSubview(image_plotted_by_OxyPlot);
			image_plotted_by_OxyPlot.SetAllowPinchScaling(true);
		}
            

		public PlotModel DateTimeaxisPlotModel()
		{

			var start = m_sch_list[0].m_date ;
			var end = m_sch_list[m_sch_list.Count-1].m_date;

			var data = new Collection<DateValue>();
			foreach (ScheduleRecord schr in m_sch_list)
			{
				data.Add(new DateValue { Date = schr.m_date, Weight = schr.m_weight });
			}

			var plotModel1 = new PlotModel("");
			plotModel1.TitleFontSize = 30;
            plotModel1.TextColor = OxyColors.White;
            plotModel1.PlotAreaBorderColor = OxyColors.Transparent;
			var dateTimeAxis1 = new DateTimeAxis (start, start.AddDays(7),AxisPosition.Bottom, "", null, DateTimeIntervalType.Days);
			dateTimeAxis1.CalendarWeekRule = CalendarWeekRule.FirstDay;
			dateTimeAxis1.MajorStep = 1.0;
            /*dateTimeAxis1.Position = AxisPosition.Bottom;
			dateTimeAxis1.TitleFontSize = 20;*/
            dateTimeAxis1.MajorGridlineStyle = LineStyle.None;
			dateTimeAxis1.MajorTickSize = 20;
            dateTimeAxis1.ShowMinorTicks = false;
			dateTimeAxis1.StringFormat = "dd.MM";
            //dateTimeAxis1.Str
            dateTimeAxis1.FontSize = (double)21.0;
            dateTimeAxis1.TicklineColor = OxyColors.White;
            dateTimeAxis1.ShowMinorTicks = false;
            dateTimeAxis1.AxislineStyle = LineStyle.None;
            dateTimeAxis1.MajorGridlineColor = OxyColors.White;
            dateTimeAxis1.AxislineThickness = 5.0f;
            dateTimeAxis1.AxislineColor = OxyColors.White;
            dateTimeAxis1.TicklineColor = OxyColors.White;
            DateTime td = DateTime.Today;
            dateTimeAxis1.Zoom((td - new TimeSpan(3, 0, 0, 0)).ToOADate(), (td + new TimeSpan(3, 0, 0, 0)).ToOADate());
            
            //dateTimeAxis1.

			plotModel1.Axes.Add(dateTimeAxis1);
			var linearAxis1 = new LinearAxis();
			linearAxis1.Title = "";
			linearAxis1.MajorTickSize = 20;
			linearAxis1.TitlePosition = 1.0;
			linearAxis1.TitleFontSize = 20;
			linearAxis1.ClipTitle = true;
            linearAxis1.TicklineColor = OxyColors.White;
            linearAxis1.AxislineStyle = LineStyle.None;
            linearAxis1.MajorGridlineStyle = LineStyle.Dot;
            linearAxis1.MajorGridlineColor = OxyColors.White;
            linearAxis1.AxislineColor = OxyColors.White;
            linearAxis1.FontSize = (double)21.0;
            linearAxis1.AxislineThickness = 5.0f;
			plotModel1.Axes.Add(linearAxis1);

			//plotModel1.Axes[1].
			var lineSeries1 = new LineSeries
			{
                Color = OxyColors.White,
                MarkerFill = OxyColors.White,
                MarkerStroke = OxyColors.White,
				MarkerType = MarkerType.Circle,
                MarkerSize = 8,
                StrokeThickness = 6,
				DataFieldX = "Date",
				DataFieldY = "Weight",
                ItemsSource = data,
                LineStyle = LineStyle.Solid
			};
			plotModel1.Series.Add(lineSeries1);
			return plotModel1;
		}
	}
}

