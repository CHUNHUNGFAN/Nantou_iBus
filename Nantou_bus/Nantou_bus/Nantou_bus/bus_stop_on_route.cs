using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Nantou_bus
{
	public class bus_stop_on_route : TabbedPage
	{
		public bus_stop_on_route (String RouteID,String SubRouteUID,String SubRouteName)
		{
            Children.Add(new RoutePage(RouteID,SubRouteUID) { Title = "詳細站牌" });
            Children.Add(new TimeTablePage(RouteID,SubRouteName) { Title = "時刻表" });
            Children.Add(new PricePage { Title = "票價" });
        }
	}
}