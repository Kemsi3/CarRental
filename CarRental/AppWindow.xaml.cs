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
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CarRental
{
    /// <summary>
    /// Logika interakcji dla klasy AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        DataContext context = new DataContext();
        public static DataGrid datagrid;

        
            

        public AppWindow()
        {
            InitializeComponent();
            loaditemTemplate();
            
        }

     

        private void loaditemTemplate()
        {
            User luser = new User();
            luser.FirstName = ((MainWindow)App).xd
            luser.LastName = context.loggedUser.LastName;
            luser.Password = context.loggedUser.Password;
            luser.Email = context.loggedUser.Email;
            luser.BirthDate = context.loggedUser.BirthDate;
            luser.BonusPoints = context.loggedUser.BonusPoints;

            

            myDataGrid.ItemsSource = context.Cars.ToList();
            datagrid = myDataGrid;
            usertxtb.DataContext = luser.FirstName;


        }

        private void cb_Click(object sender, RoutedEventArgs e)
        {
            carscontent.Visibility = Visibility.Visible;
            aboutcontent.Visibility = Visibility.Hidden;
            historycontent.Visibility = Visibility.Hidden;

        }
        private void ab_Click(object sender, RoutedEventArgs e)
        {
            carscontent.Visibility = Visibility.Hidden;
            aboutcontent.Visibility = Visibility.Visible;
            historycontent.Visibility = Visibility.Hidden;
        }
        private void hb_Click(object sender, RoutedEventArgs e)
        {
            carscontent.Visibility = Visibility.Hidden;
            aboutcontent.Visibility = Visibility.Hidden;
            historycontent.Visibility = Visibility.Visible;
        }
    }
}
