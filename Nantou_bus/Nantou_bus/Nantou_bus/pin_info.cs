using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nantou_bus
{
    public class pin_info : ContentPage
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
        public pin_info(double pin_lat, double pin_long, String StopID)
        {
            BackgroundColor = Color.LightBlue;

            String pin_lat_string = pin_lat.ToString();
            String pin_long_string = pin_long.ToString();

            MySqlConnection con2 = new MySqlConnection("Server=ms14.voip.edu.tw;Port=3306;database=ibus;User ID=ibus;Password=ibus;charset=utf8");
            MySqlCommand command2 = con2.CreateCommand();
            con2.Open();
            MySqlCommand cmd_2 = new MySqlCommand("SELECT RouteID, RouteName, bus_time FROM `timetable`");
            cmd_2.Connection = con2;
            MySqlDataReader reader_2 = cmd_2.ExecuteReader();

            var StreetView = new Image
            {
                Source = "https://maps.googleapis.com/maps/api/streetview?size=1080x1080&location=" + pin_lat_string + ",%20" + pin_long_string + "&key=AIzaSyDUUf5gsUvFYC-s7D6iCAUvn19Yh09rdMM",
                HeightRequest = 300
            };

            var command = new Label { Text = "即將到達路線" };

            var stack = new StackLayout { Spacing = 10 };
            stack.Children.Add(StreetView);
            stack.Children.Add(command);

            while (reader_2.Read())
            {
                var bus_come = new Button();
                String temp_string = "";
                for (int i = 0; i < 3; i++)
                {
                    String s = reader_2.GetString(i);
                    if (i == 2)
                    {
                        temp_string += s;
                        temp_string += "分鐘";
                    }
                    else
                    {
                        temp_string += s;
                        temp_string += " ";
                    }
                }
                bus_come.Text = temp_string;
                bus_come.Clicked += (object sender, EventArgs e) =>
                {
                    //this.Navigation.PushAsync(new bus_stop_on_route());
                };
                stack.Children.Add(bus_come);
            }
            con2.Close();

            var route = new Label { Text = "行經路線" };
            stack.Children.Add(route);

            var webClient = new System.Net.WebClient();
            var result = webClient.DownloadString("http://ptx.transportdata.tw/MOTC/v2/Bus/StopOfRoute/InterCity?$filter=Stops/any(d:d/StopID%20eq%20%27" + StopID + "%27)&$format=JSON");
            var pin_info_route = JsonConvert.DeserializeObject<List<RootObject>>(result);
            //var bus_pass = new Button { Text = "6670" + "台中 - 埔里" };
            MySqlCommand command3 = con2.CreateCommand();
            con2.Open();
            for (int i = 0; i < pin_info_route.Count; i++)
            {
                var bus_pass = new Button();
                String temp_SubRouteUID = pin_info_route[i].SubRouteUID.Replace(" ", "").ToString();
                String temp_RouteID = pin_info_route[i].RouteID.ToString();
                String temp_SubRouteName = pin_info_route[i].SubRouteName.En.ToString();
                String temp_query = String.Format("SELECT Headsign FROM `bus_routes` WHERE SubRouteUID = '{0}'", temp_SubRouteUID);
                MySqlCommand cmd_3 = new MySqlCommand(temp_query);
                cmd_3.Connection = con2;
                MySqlDataReader reader_3 = cmd_3.ExecuteReader();
                while (reader_3.Read())
                {
                    String subroutename = reader_3.GetString(0);
                    bus_pass.Text = temp_RouteID + "\t" + subroutename;
                    bus_pass.Clicked += (object sender, EventArgs e) =>
                    {
                        this.Navigation.PushAsync(new bus_stop_on_route(temp_RouteID,temp_SubRouteUID,temp_SubRouteName));
                    };
                    stack.Children.Add(bus_pass);

                }
                reader_3.Close();
            }
            con2.Close();
            var scroll = new ScrollView
            {
                Content = stack
            };

            Content = scroll;
        }

    }
}