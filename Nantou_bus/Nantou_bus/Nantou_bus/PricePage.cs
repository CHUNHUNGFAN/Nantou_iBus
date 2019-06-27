using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Nantou_bus
{
	public class PricePage : ContentPage
	{
		public PricePage ()
		{
            var web_price = new WebView
            {
                Source = "http://web.taiwanbus.tw/eBUS/subsystem/ticket/TMSquery.aspx?run_id=5140"
            };

            Content = web_price;
        }
	}
}