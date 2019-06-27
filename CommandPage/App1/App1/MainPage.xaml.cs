using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
	public partial class MainPage : TabbedPage
    {
		public MainPage()
		{
			InitializeComponent();
		}

        public void ButtonClicked01(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string text = "http://www.ntbus.com.tw/callus.html";
            browser.Source = text;
        }

        public void ButtonClicked02(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string text = "感謝您的寶貴建議，您的建議是我們成長的動力";
            lable01.Text = text;
        }

        public void ButtonClicked03(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string text = "";
            entry02.Text = text;
            lable01.Text = text;
        }
    }
}
