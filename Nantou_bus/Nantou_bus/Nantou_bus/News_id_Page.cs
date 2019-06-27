using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Nantou_bus
{
	public class News_id_Page : ContentPage
	{
        public class RootObject
        {
            public string id { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public string Updatetime { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public List<object> Stop { get; set; }
        }

        public News_id_Page (String news_id)
		{
            BackgroundColor = Color.LightBlue;
            var webClient = new System.Net.WebClient();
            var result = webClient.DownloadString("http://www.taiwanbus.tw/app_api/Marquee_N.ashx?id="+news_id);
            var news_list = JsonConvert.DeserializeObject<List<RootObject>>(result);
            var stack = new StackLayout { Spacing = 10 };
            stack.Children.Add(new Label());
            String news_title = news_list[0].title.ToString();
            String news_content = news_list[0].content.ToString();
            String news_from = news_list[0].name.ToString();
            stack.Children.Add(new Label { TextColor = Color.Red, Text = news_title, FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))});
            stack.Children.Add(new Label { TextColor = Color.Black, Text = news_content,FontSize = Device.GetNamedSize(NamedSize.Medium,typeof(Label))});
            stack.Children.Add(new Label { Text = " " });
            stack.Children.Add(new Label { TextColor = Color.Gray, Text = "資料來源:" + news_from ,FontSize = Device.GetNamedSize(NamedSize.Small,typeof(Label))});
            var scroll = new ScrollView { Content = stack };
            Content = scroll;
        }
	}
}