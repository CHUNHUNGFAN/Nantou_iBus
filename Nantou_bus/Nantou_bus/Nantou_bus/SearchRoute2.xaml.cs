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
	public partial class SearchRoute2 : TabbedPage
	{
		public SearchRoute2 ()
		{
			InitializeComponent ();
            Title = "想要抵達哪裏？";
            Children.Add(new SearchHistory2());
            Children.Add(new PreSet2());
        }
	}
}