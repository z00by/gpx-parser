using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Dialogs;

using ZoobySoft.CyclePlot.Analysis;
using System.ComponentModel;

namespace TripPlotter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BindingList<TripView> Trips { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();

            Trips = new BindingList<TripView>();
            
            TripsListBox.ItemsSource = Trips;
        }

        private void LoadDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {

                GpxTripDirectory.ReadTrips(dialog.FileName).AsParallel().ForAll(trip =>
                Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    Trips.Add(new TripView
                    {
                        StartDateTime = trip.StartTime.ToLongDateString() + " " + trip.StartTime.ToLongTimeString(),
                        Distance = trip.GetTotalDistance().Miles,
                        AverageSpeed = trip.GetAverageSpeed().GetMilesPerHour()
                    }
                    );
                })));


        }
        }
    }

    public class TripView
    {
        public string StartDateTime { get; set; }
        public double Distance { get; set; }
        public double AverageSpeed { get; set; }
    }
}
