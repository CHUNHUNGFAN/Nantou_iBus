using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchHistory2 : ContentPage
	{
		public SearchHistory2 ()
		{
			InitializeComponent ();
		}
        int x;
        public void Refresh(object sender, EventArgs e)
        {

        }

        private void Search_Clicked(object sender, EventArgs e)
        {
            SearchHistory.fooDoggyDatabase.SaveItemH(new History
            {
                SettingName = StartRouteSearchBar.Text,
                Done = false,
            });
            var fooItem2 = SearchHistory.fooDoggyDatabase.GetItemsH().LastOrDefault();
            SearchGH1.Text = $"{fooItem2.SettingName} ";
            x = fooItem2.ID - 1;
            fooItem2 = SearchHistory.fooDoggyDatabase.GetItemH(x);
            SearchGH2.Text = $"{fooItem2.SettingName}";
            fooItem2 = SearchHistory.fooDoggyDatabase.GetItemH(x - 1);
            SearchGH3.Text = $"{fooItem2.SettingName}";
            fooItem2 = SearchHistory.fooDoggyDatabase.GetItemH(x - 2);
            SearchGH4.Text = $"{fooItem2.SettingName}";
            fooItem2 = SearchHistory.fooDoggyDatabase.GetItemH(x - 3);
            SearchGH5.Text = $"{fooItem2.SettingName}";

            StartRouteSearchBar.Text = "";
    
        }
    }
}