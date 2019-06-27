using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Nantou_bus
{
    public class MapPage : ContentPage
    {
        Map map;
        public MapPage()
        {
            //設定背景顏色
            BackgroundColor = Color.LightBlue;

            //建立一個新的地圖
            map = new Map(
              MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(23.949644, 120.934703), Distance.FromMiles(1)))
            {
                IsShowingUser = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 300
            };

            //連接ms14的MySQL資料庫
            MySqlConnection con = new MySqlConnection("Server=ms14.voip.edu.tw;Port=3306;database=ibus;User ID=ibus;Password=ibus;charset=utf8");
            MySqlCommand command = con.CreateCommand();
            con.Open();

            //下SQL的指令
            MySqlCommand cmd = new MySqlCommand("SELECT StopID, StopName, LAT, LON FROM `bus_stops`");
            cmd.Connection = con;
            MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader

            //從資料庫中取出資料並放入地圖中
            while (reader.Read())
            {
                double temp_lat, temp_long;
                String StopID = "";
                var temp = new Pin { Type = PinType.Place };
                List<double> temp_double = new List<double>();
                for (int i = 0; i < 4; i++)
                {
                    String s = reader.GetString(i);
                    if (i == 0)
                    {
                        StopID = s;
                    }
                    else if (i == 1)
                    {
                        temp.Label = s;
                    }
                    else if (i == 2)
                    {
                        temp_lat = Convert.ToDouble(s);
                        temp_double.Add(temp_lat);
                    }
                    else if (i == 3)
                    {
                        temp_long = Convert.ToDouble(s);
                        temp_double.Add(temp_long);
                        var temp_position = new Position(temp_double[0], temp_double[1]);
                        temp.Position = temp_position;
                        temp.Address = "6670 台中-日月潭[台灣好行日月潭線] 20分鐘";
                    }
                }

                map.Pins.Add(temp);
                temp.Clicked += (object sender, EventArgs e) =>
                {
                    this.Navigation.PushAsync(new pin_info(temp_double[0], temp_double[1], StopID));
                };
            }

            //結束資料庫連結
            con.Close();

            var where = new Button { Text = "您要去哪裡呢?" };
            var set_walk = new Button { Text = "設定您的步伐速度?" };
            var news = new Button { Text = "最新消息" };

            set_walk.Clicked += set_walk_Clicked;
            where.Clicked += where_Clicked;
            news.Clicked += news_Clicked;

            //將資料放入頁面
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            stack.Children.Add(set_walk);
            stack.Children.Add(where);
            stack.Children.Add(news);

            Content = stack;
        }

        void set_walk_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new SetWalkSpeedPage());
        }

        void where_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new SearchRoute());
        }
        
        void news_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new NewsPage());
        }

    }
}