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

namespace CarRental
{
    /// <summary>
    /// Logika interakcji dla klasy CarControl.xaml
    /// </summary>
    public partial class CarControl : UserControl
    {
        public Car selectedCar = new Car();

        public CarControl(Car c)
        {
            InitializeComponent();

            

            BrandTxtB.Content = c.Brand;
            ModelTxtB.Content = c.Model;
            PrizeTxtB.Content = c.Prize.ToString();
            CapacityTxtB.Content = c.Capacity.ToString();
            PYTxtB.Content = c.ProductionYear.ToString();
            OdoTxtB.Content = c.Odometer.ToString();
            DoorsTxtB.Content = c.Doors.ToString();
            CarImage.Source = new BitmapImage(c.Uri);
            RentBT.Tag = c;

        }


        private void addCarBT_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            { 
    
                    selectedCar = (Car)(sender as Button).Tag;


            }
        }

    }
}
