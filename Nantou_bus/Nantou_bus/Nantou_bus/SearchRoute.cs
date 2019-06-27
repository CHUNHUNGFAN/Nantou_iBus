using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Nantou_bus
{
    public class SearchRoute : TabbedPage
    {
       
        public SearchRoute()
        {
            Title = "從哪裏出發";
            Children.Add(new SearchHistory());
            Children.Add(new PreSet());
            BarBackgroundColor = Color.Orange;
            BarTextColor = Color.Black;
            
        }
    }
}