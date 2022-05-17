using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    public partial class AppWindow : Window
    {
        DataContext context = new DataContext();
        User loggedUser = new User();
        Car selectedCar = new Car();
        


        public AppWindow(User user)
        {

            InitializeComponent();
            PassUser(user);


            foreach (Car c in context.Cars)
            {
                CarControl carControl = new CarControl(c);
            }

        }


        public void PassUser(User user)
        {
            loggedUser.FirstName = user.FirstName;
            loggedUser.LastName = user.LastName;
            loggedUser.Password = user.Password;
            loggedUser.Email = user.Email;
            loggedUser.BirthDate = user.BirthDate;
            loggedUser.BonusPoints = user.BonusPoints;
            userfirstnametxt.Text = loggedUser.FirstName;
            userlastnametxt.Text = loggedUser.LastName;
        }
        
        public void AddRent()
        {
            bool flag = true;

            using (DataContext context = new DataContext())
            {

                if (toDP.SelectedDate > fromDP.SelectedDate && fromDP.SelectedDate > DateTime.Now)
                {
                    

                    foreach(Rent r in context.Rents)
                    {
                       flag = true;

                        if(r.CarID == selectedCar.CarID)
                        {
                            if((toDP.SelectedDate < r.InDate && fromDP.SelectedDate < r.InDate) || (fromDP.SelectedDate > r.OutDate && toDP.SelectedDate > r.OutDate))
                            {
                                return;
                            }
                            else
                            {
                                flag = false;

                                MessageBox.Show("Auto niedostepne");
                                return;
                            }
                        }
                    }

                    if (fromDP.SelectedDate > DateTime.Now)
                    {
                        selectedCar.Availability = false;
                    } 
                }

                else
                {
                    MessageBox.Show("zle daty");
                    flag = false;

                }
                if(flag)
                {
                    Rent rent = new Rent();
                    rent.RentID = new Guid();
                    rent.EmployeeID = "CarRentalOwner";
                    rent.ClientEmail = loggedUser.Email;
                    rent.CarID = selectedCar.CarID;
                    rent.InDate = toDP.SelectedDate;
                    rent.OutDate = fromDP.SelectedDate;
                    TimeSpan? duration = rent.InDate - rent.OutDate;
                    rent.Duration = duration.Value.Days;
                    rent.Prize = rent.Duration * selectedCar.Prize;
                    rent.RentDate = DateTime.Now;
                    context.Rents.Add(rent);
                    MessageBox.Show("dodano wypoz");
                }

                context.SaveChanges();
            }
        }


        private void cb_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCar != null)
            {
                ccarcontent.Visibility = Visibility.Visible;
            }
            shopcontent.Visibility = Visibility.Hidden;
            carscontent.Visibility = Visibility.Visible;
            aboutcontent.Visibility = Visibility.Hidden;
            historycontent.Visibility = Visibility.Hidden;
        }
        private void ab_Click(object sender, RoutedEventArgs e)
        {
            ccarcontent.Visibility = Visibility.Hidden;
            shopcontent.Visibility = Visibility.Hidden;
            carscontent.Visibility = Visibility.Hidden;
            aboutcontent.Visibility = Visibility.Visible;
            historycontent.Visibility = Visibility.Hidden;
        }
        private void hb_Click(object sender, RoutedEventArgs e)
        {
            ccarcontent.Visibility = Visibility.Hidden;
            shopcontent.Visibility = Visibility.Hidden;
            carscontent.Visibility = Visibility.Hidden;
            aboutcontent.Visibility = Visibility.Hidden;
            historycontent.Visibility = Visibility.Visible;
        }
        private void sb_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCar != null)
            {
                ccarcontent.Visibility = Visibility.Visible;
            }
            if (selectedCar != null)
            {
                noCarsLbl.Visibility = Visibility.Hidden;
                SPshop.Visibility = Visibility.Visible;
            }
            else
            {
                noCarsLbl.Visibility = Visibility.Visible;
                SPshop.Visibility = Visibility.Hidden;
            }
            shopcontent.Visibility = Visibility.Visible;
            carscontent.Visibility = Visibility.Hidden;
            aboutcontent.Visibility = Visibility.Hidden;
            historycontent.Visibility = Visibility.Hidden;
        }

        private void rentBt_Click(object sender, RoutedEventArgs e)
        {
            AddRent();
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