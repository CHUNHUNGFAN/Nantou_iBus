using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace Nantou_bus
{
    public class RoutePage : ContentPage
    {
        public class RouteName
        {
            public string Zh_tw { get; set; }
            public string En { get; set; }
        }

        public class SubRouteName
        {
            public string Zh_tw { get; set; }
            public string En { get; set; }
        }

        public class StopName
        {
            public string Zh_tw { get; set; }
            public string En { get; set; }
        }

        public class StopPosition
        {
            public double PositionLat { get; set; }
            public double PositionLon { get; set; }
        }

        public class Stop
        {
            public string StopUID { get; set; }
            public string StopID { get; set; }
            public StopName StopName { get; set; }
            public int StopBoarding { get; set; }
            public int StopSequence { get; set; }
            public StopPosition StopPosition { get; set; }
        }

        public class RootObject
        {

            public string RouteUID { get; set; }
            public string RouteID { get; set; }
            public RouteName RouteName { get; set; }
            public string OperatorID { get; set; }
            public bool KeyPattern { get; set; }
            public string SubRouteUID { get; set; }
            public string SubRouteID { get; set; }
            public SubRouteName SubRouteName { get; set; }
            public int Direction { get; set; }
            public List<Stop> Stops { get; set; }
            public string UpdateTime { get; set; }
        }
        public RoutePage(String RouteID,String SubRouteUID)
        {
            BackgroundColor = Color.LightBlue;
            var webClient = new System.Net.WebClient();
            var result = webClient.DownloadString("http://ptx.transportdata.tw/MOTC/v2/Bus/StopOfRoute/InterCity/"+RouteID+"?$format=JSON");
            var route = JsonConvert.DeserializeObject<List<RootObject>>(result);
            var stack = new StackLayout { Spacing = 15 };

            for (int i = 0; i < route.Count; i++)
            {
                if (route[i].SubRouteUID.ToString() == SubRouteUID)
                {
                    for (int j = 0; j < route[i].Stops.Count; j++)
                    {
                        var label = new Label();
                        label.Text = route[i].Stops[j].StopName.Zh_tw;
                        label.TextColor = Color.Black;
                        label.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
                        stack.Children.Add(label);
                    }
                }
            }

            var scroll = new ScrollView{ Content = stack };
            Content = scroll;

        }
    }
}