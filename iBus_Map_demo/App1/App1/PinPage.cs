using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace App1
{
    public class PinPage : ContentPage
    {
        Map map;

        public PinPage()
        {
            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(23.9511253, 120.9329996), Distance.FromMiles(3))); // Santa Cruz golf course

            var position = new Position(23.9511253, 120.9329996); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "國立暨南國際大學"/*,
                Address = "南投縣埔里鎮大學路一號"*/
            };
            map.Pins.Add(pin);

            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(23.9707932, 120.9477666),
                Label = "岐下",
            });

            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(23.9693696, 120.9616426),
                Label = "埔里酒廠"
            });
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(23.9697301, 120.9581528),
                Label = "仁愛公園"
            });
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(23.9634265, 120.9687761),
                Label = "埔里客運總站"
            });

            /*
                        // create buttons
                        var morePins = new Button { Text = "加入更多 位置標示" };
                        morePins.Clicked += (sender, e) => {
                            map.Pins.Add(new Pin
                            {
                                Position = new Position(36.9641949, -122.0177232),
                                Label = "Boardwalk"
                            });
                            map.Pins.Add(new Pin
                            {
                                Position = new Position(36.9571571, -122.0173544),
                                Label = "Wharf"
                            });
                            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                                new Position(36.9628066, -122.0194722), Distance.FromMiles(1.5)));

                        };*/
            var reLocate = new Button { Text = "定位目前位置" };
            reLocate.Clicked += (sender, e) => {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(23.9511253, 120.9329996), Distance.FromMiles(3)));
            };
            var buttons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    /*morePins,*/ reLocate
                }
            };

            // put the page together
            Content = new StackLayout
            {

                Spacing = 0,
                Children = {
                    map,
                    buttons
                }
            };
        }
    }
}