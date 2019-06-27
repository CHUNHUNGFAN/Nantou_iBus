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
	public partial class PreSet : ContentPage
	{
		public PreSet ()
		{
			InitializeComponent ();
		}

        public void Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new SettingHome());

        }

        public void Button_Clicked_1(object sender, EventArgs e)
        {
            var fooItem = SearchHistory.fooDoggyDatabase.GetItems().Last();
            HomeButton.Text = $"住家: {fooItem.UserName} ";
        }
    }
}