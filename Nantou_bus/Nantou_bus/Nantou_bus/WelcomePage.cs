using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Nantou_bus
{
	public class WelcomePage : TabbedPage
	{
		public WelcomePage ()
		{
            Title = "南投客運通";
            Children.Add(new MapPage { Title = "首頁", Icon = "glyphish_74_location.png" });
            // Children.Add(new SearchRoute { Title = "查詢路線", Icon = "glyphish_07_map_marker.png" });
            Children.Add(new NumRoute { Title = "查詢路線", Icon = "glyphish_07_map_marker.png" });
            Children.Add(new CommandPage { Title = "評分系統", Icon = "glyphish_103_map.png" });
        }
	}
}