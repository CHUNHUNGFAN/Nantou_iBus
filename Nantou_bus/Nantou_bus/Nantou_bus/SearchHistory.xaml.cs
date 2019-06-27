using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nantou_bus
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchHistory : ContentPage
	{
        public SearchHistory()
        {
            InitializeComponent();
            //HistoryRouteListView.ItemsSource= names;
            fooDoggyDatabase = new DoggyDatabase();
        }
        public static DoggyDatabase fooDoggyDatabase;

        private readonly List<string> names = new List<string>
        {
            "SunMoonLake","NCNU","NCNUSecondarySchool","PuliBrewery","PuliStation","QiXia"
        };

        //private void StartRouteSearchBar_SearchButtonPressed(object sender, EventArgs e)
        //{
        //    string keyword = StartRouteSearchBar.Text;
        //    IEnumerable<string> SearchResult = names.Where(names => names.ToLower().Contains(keyword.ToLower()));
        //    //HistoryRouteListView.ItemsSource = SearchResult;
        //}


        int x;
        public void Refresh(object sender, EventArgs e)
        {

        }

        private void Search_Clicked(object sender, EventArgs e)
        {
            fooDoggyDatabase.SaveItemH(new History
            {
                SettingName = StartRouteSearchBar.Text,
                Done = false,
            });
            var fooItem2 = fooDoggyDatabase.GetItemsH().LastOrDefault();
            SearchH1.Text = $"{fooItem2.SettingName} ";
            /*x = fooItem2.ID - 1;
            fooItem2 = fooDoggyDatabase.GetItemH(x);
            SearchH2.Text = $"{fooItem2.SettingName}";
            fooItem2 = fooDoggyDatabase.GetItemH(x - 1);
            SearchH3.Text = $"{fooItem2.SettingName}";
            fooItem2 = fooDoggyDatabase.GetItemH(x - 2);
            SearchH4.Text = $"{fooItem2.SettingName}";
            fooItem2 = fooDoggyDatabase.GetItemH(x - 3);
            SearchH5.Text = $"{fooItem2.SettingName}";*/

            StartRouteSearchBar.Text = "";
            this.Navigation.PushAsync(new SearchRoute2());
        }
    }
}