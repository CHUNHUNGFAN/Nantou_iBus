using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

using Xamarin.Forms;

namespace Nantou_bus
{
	public class NewsPage : ContentPage
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

        public NewsPage ()
		{
            BackgroundColor = Color.LightBlue;
            var webClient = new System.Net.WebClient();
            var result = webClient.DownloadString("http://www.taiwanbus.tw/app_api/New_N.ashx");
            var news_list = JsonConvert.DeserializeObject<List<RootObject>>(result);
            var stack = new StackLayout { Spacing = 10};
            var table = new TableView();
            table.Intent = TableIntent.Form;
            TableRoot troot = new TableRoot();
            table.Root = troot;
            TableSection section = new TableSection();
            troot.Add(section);
            for (int i = 0; i < news_list.Count; i++)
            {
                String news_id = news_list[i].id.ToString();
                String news_title = news_list[i].title.ToString();
                String news_time = news_list[i].Updatetime.ToString();
             
                var news_time_cell = new TextCell();
                news_time_cell.Text = news_time;
                news_time_cell.TextColor = Color.Red;
                news_time_cell.Detail = news_title;
                news_time_cell.DetailColor = Color.Black;
                news_time_cell.Tapped += (object sender, EventArgs e) =>
                {
                    this.Navigation.PushAsync(new News_id_Page(news_id));
                };
                section.Add(news_time_cell);
            }
            Content = table;
        }
	}
}