using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
	public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        public void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string text = MainEntry.Text;
            MainLabel.Text = text;
           

        }

           
        

    }
}
