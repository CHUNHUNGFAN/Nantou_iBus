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
	public partial class SettingHome : ContentPage
	{
        public SettingHome ()
		{
			InitializeComponent ();

        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            SearchHistory.fooDoggyDatabase.DeleteAll();
            SearchHistory.fooDoggyDatabase.SaveItem(new MyRecord
            {
                UserName = HomeEntry1.Text,
                SettingName = HomeEntry2.Text,
                Done = false,
            });
            this.Navigation.PopAsync();

        }

    }
}