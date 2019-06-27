using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Nantou_bus
{
    public class SetWalkSpeedPage : ContentPage
    {
        String speed_string;
        int speed_int;
        public SetWalkSpeedPage()
        {
            BackgroundColor = Color.LightBlue;

            ToolbarItem tbi = new ToolbarItem();
            tbi.Text = "儲存";
            //tbi.Clicked += tbi_Clicked;

            this.ToolbarItems.Add(tbi);

            var RunImage = new Image { HeightRequest = 250 };
            RunImage.Source = ImageSource.FromFile("run.png");

            var speed_label = new Label
            {
                Text = "您調整後的步伐速度:"
            };

            var speed = new Entry { Placeholder = "請輸入您的步伐速度" };
            speed_string = speed.Text;
            speed_int = Convert.ToInt32(speed_string);

            tbi.Clicked += (object sender, EventArgs e) =>
            {
                this.Navigation.PopAsync();
            };

            var adult = new Button
            {
                Text = "一般成人4公里"
            };

            adult.Clicked += (object sender, EventArgs e) =>
            {
                speed.Text = "4";
            };

            var stack = new StackLayout { Spacing = 30 };
            stack.Children.Add(RunImage);
            stack.Children.Add(speed_label);
            stack.Children.Add(speed);
            stack.Children.Add(adult);
            Content = stack;
        }

        /*void tbi_Clicked(object sender, EventArgs e)
        {
          
            this.Navigation.PopAsync(new MapPage(speed_string));
        }*/
    }
}