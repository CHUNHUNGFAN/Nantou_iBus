using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace App1
{
    public class GeocoderPage : ContentPage
    {
        Geocoder geoCoder;
        Label l = new Label();

        public GeocoderPage()
        {
            geoCoder = new Geocoder();


            var b1 = new Button { Text = "反定位 ' 23.951, 120.932'" };
            b1.Clicked += async (sender, e) => {
                l.Text = "";
                var fortMasonPosition = new Position(23.9511253, 120.9329996);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(fortMasonPosition);
                foreach (var a in possibleAddresses)
                {
                    l.Text += a + "\n";
                }
            };

            var b2 = new Button { Text = "定位'國立暨南國際大學'" };
            b2.Clicked += async (sender, e) => {
                l.Text = "";
                var xamarinAddress = "545南投縣埔里鎮大學路1號";
                var approximateLocation = await geoCoder.GetPositionsForAddressAsync(xamarinAddress);
                foreach (var p in approximateLocation)
                {
                    l.Text += p.Latitude + ", " + p.Longitude + "\n";
                }
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Children = {
                    b2,
                    b1,
                    l
                }
            };
        }
    }
}