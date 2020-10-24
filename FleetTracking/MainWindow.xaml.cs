using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace FleetTracking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Coordinates> coordinatesVehicle01;
        MapPolygon polygon;
        readonly Pushpin pinVehicle01;
        readonly bool isReading = true;

        public MainWindow()
        {
            InitializeComponent();

            coordinatesVehicle01 = new List<Coordinates>
            {
                new Coordinates { Latitude = -22.550193, Longitude = -48.572813 },
                new Coordinates { Latitude = -22.550514, Longitude = -48.572872 },
                new Coordinates { Latitude = -22.550816, Longitude = -48.572925 },
                new Coordinates { Latitude = -22.551123, Longitude = -48.573011 },
                new Coordinates { Latitude = -22.551386, Longitude = -48.573161 },
                new Coordinates { Latitude = -22.551723, Longitude = -48.573301 },
                new Coordinates { Latitude = -22.551980, Longitude = -48.573376 },
                new Coordinates { Latitude = -22.552223, Longitude = -48.573419 },
                new Coordinates { Latitude = -22.552450, Longitude = -48.573344 },
                new Coordinates { Latitude = -22.552673, Longitude = -48.573183 },
                new Coordinates { Latitude = -22.552886, Longitude = -48.572990 },
                new Coordinates { Latitude = -22.553248, Longitude = -48.572684 },
                new Coordinates { Latitude = -22.553176, Longitude = -48.572436 },
                new Coordinates { Latitude = -22.553106, Longitude = -48.572135 },
                new Coordinates { Latitude = -22.553037, Longitude = -48.571846 },
                new Coordinates { Latitude = -22.552958, Longitude = -48.571583 },
                new Coordinates { Latitude = -22.552889, Longitude = -48.571283 },
                new Coordinates { Latitude = -22.552799, Longitude = -48.570977 },
                new Coordinates { Latitude = -22.552735, Longitude = -48.570703 },
                new Coordinates { Latitude = -22.552651, Longitude = -48.570344 },
                new Coordinates { Latitude = -22.552547, Longitude = -48.569909 },
                new Coordinates { Latitude = -22.552453, Longitude = -48.569558 },
                new Coordinates { Latitude = -22.552359, Longitude = -48.569204 },
                new Coordinates { Latitude = -22.552309, Longitude = -48.568979 },
                new Coordinates { Latitude = -22.552235, Longitude = -48.568652 },
                new Coordinates { Latitude = -22.552180, Longitude = -48.568389 },
                new Coordinates { Latitude = -22.552146, Longitude = -48.568206 },
                new Coordinates { Latitude = -22.552106, Longitude = -48.568018 },
                new Coordinates { Latitude = -22.552076, Longitude = -48.567782 },
                new Coordinates { Latitude = -22.552037, Longitude = -48.567541 },
                new Coordinates { Latitude = -22.552022, Longitude = -48.567358 },
                new Coordinates { Latitude = -22.551947, Longitude = -48.567101 },
                new Coordinates { Latitude = -22.551918, Longitude = -48.566790 },
                new Coordinates { Latitude = -22.551839, Longitude = -48.566286 },
                new Coordinates { Latitude = -22.551769, Longitude = -48.565964 },
                new Coordinates { Latitude = -22.551731, Longitude = -48.565616 },
                new Coordinates { Latitude = -22.551691, Longitude = -48.565272 },
                new Coordinates { Latitude = -22.551374, Longitude = -48.565219 },
                new Coordinates { Latitude = -22.551037, Longitude = -48.565219 },
                new Coordinates { Latitude = -22.550711, Longitude = -48.565187 },
                new Coordinates { Latitude = -22.550354, Longitude = -48.565154 },
                new Coordinates { Latitude = -22.549869, Longitude = -48.565144 },
                new Coordinates { Latitude = -22.549492, Longitude = -48.565144 },
                new Coordinates { Latitude = -22.549146, Longitude = -48.565079 },
                new Coordinates { Latitude = -22.548789, Longitude = -48.565069 },
                new Coordinates { Latitude = -22.548403, Longitude = -48.565058 },
                new Coordinates { Latitude = -22.547957, Longitude = -48.565036 },
                new Coordinates { Latitude = -22.547710, Longitude = -48.565015 },
                new Coordinates { Latitude = -22.547829, Longitude = -48.565498 },
                new Coordinates { Latitude = -22.547928, Longitude = -48.565991 },
                new Coordinates { Latitude = -22.548056, Longitude = -48.566474 },
                new Coordinates { Latitude = -22.548185, Longitude = -48.566925 },
                new Coordinates { Latitude = -22.548324, Longitude = -48.567397 },
                new Coordinates { Latitude = -22.548462, Longitude = -48.567965 },
                new Coordinates { Latitude = -22.548601, Longitude = -48.568480 },
                new Coordinates { Latitude = -22.548740, Longitude = -48.568995 },
                new Coordinates { Latitude = -22.548740, Longitude = -48.568996 },
                new Coordinates { Latitude = -22.548892, Longitude = -48.569458 },
                new Coordinates { Latitude = -22.549011, Longitude = -48.569951 },
                new Coordinates { Latitude = -22.549090, Longitude = -48.570456 },
                new Coordinates { Latitude = -22.549209, Longitude = -48.570992 },
                new Coordinates { Latitude = -22.549347, Longitude = -48.571400 },
                new Coordinates { Latitude = -22.549476, Longitude = -48.571850 },
                new Coordinates { Latitude = -22.549634, Longitude = -48.572226 },
            };

            AddArea();

            pinVehicle01 = new Pushpin
            {
                Background = new SolidColorBrush(Colors.Blue),
                ToolTip = "Vehicle 01"
            };
            MapPrincipal.Children.Add(pinVehicle01);

            var thread = new Thread(ChangeCoordinates);
            thread.Start();
        }

        private void AddArea()
        {
            polygon = new MapPolygon
            {
                Stroke = new SolidColorBrush(Colors.Yellow),
                StrokeThickness = 5,
                Opacity = 0.3,
                Locations = new LocationCollection() {
                   new Location(-22.544214, -48.567242),
                   new Location(-22.547873, -48.574131),
                   new Location(-22.548981, -48.573238),
                   new Location(-22.550472, -48.573582),
                   new Location(-22.551849, -48.574451),
                   new Location(-22.553062, -48.574013),
                   new Location(-22.553484, -48.573177),
                   new Location(-22.556208, -48.571564),
                   new Location(-22.555804, -48.569514),
                   new Location(-22.552171, -48.568404),
                   new Location(-22.551022, -48.568061),
                   new Location(-22.549408, -48.567874),
                   new Location(-22.548584, -48.568276),
                   new Location(-22.547673, -48.565048),
                }
            };

            MapPrincipal.Children.Add(polygon);
        }

        private void ChangeCoordinates()
        {
            var listAux = new List<Coordinates>(coordinatesVehicle01);

            while (isReading)
            {
                var latitude = listAux.FirstOrDefault().Latitude;
                var longitude = listAux.FirstOrDefault().Longitude;

                MapPrincipal.Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(delegate ()
                {
                    pinVehicle01.Location = new Location(latitude, longitude);
                    if (CheckPinInPolygon(polygon.Locations, pinVehicle01.Location.Latitude, pinVehicle01.Location.Longitude))
                    {
                        lblNotification.Content = "O veículo 01 está dentro da área.";
                        lblNotification.Foreground = new SolidColorBrush(Colors.Green);
                    }
                    else
                    {
                        lblNotification.Content = "O veículo 01 está fora da área.";
                        lblNotification.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }));

                listAux.RemoveAt(0);

                if (listAux.Count == 0)
                    listAux = new List<Coordinates>(coordinatesVehicle01);

                Thread.Sleep(500);
            }
        }

        private bool CheckPinInPolygon(LocationCollection points, double latitude, double longitude)
        {
            int j = points.Count - 1;
            bool inPolygon = false;

            int i;
            for (i = 0; i < points.Count; i++)
            {
                if (points[i].Longitude < longitude && points[j].Longitude >= longitude ||
                    points[j].Longitude < longitude && points[i].Longitude >= longitude)
                {
                    if (points[i].Latitude + (longitude - points[i].Longitude) / (points[j].Longitude - points[i].Longitude) * (points[j].Latitude - points[i].Latitude) < latitude)
                    {
                        inPolygon = !inPolygon;
                    }
                }
                j = i;
            }
            return inPolygon;
        }
    }
}
