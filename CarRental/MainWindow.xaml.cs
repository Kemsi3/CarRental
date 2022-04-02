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
using Microsoft.EntityFrameworkCore;

namespace CarRental
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public int xd = 4;


        public void Loging()
        {
            var log = emailtxtb.Text;

            var pass = passwordtxtb.Password;

            using (DataContext context = new DataContext())
            {
                bool userFound = context.Users.Any(user => user.Email == log && user.Password == pass);

                                


                if(userFound)
                {
                    
                    User user = context.Users.FirstOrDefault(u => u.Email == log);

                    context.loggedUser.FirstName = user.FirstName;
                    context.loggedUser.LastName = user.LastName;
                    context.loggedUser.Password = user.Password;
                    context.loggedUser.Email = user.Email;
                    context.loggedUser.BirthDate = user.BirthDate;
                    context.loggedUser.BonusPoints = user.BonusPoints;
                    context.SaveChanges();

                    AppWindow app = new AppWindow();

                    app.Show();
                }

                else
                {
                    MessageBox.Show("User Not Found");
                }
            }

        }

       

        public void Adding()
        {

            using (DataContext context = new DataContext())
            {
                var log = emailtxtb.Text;

                bool userFound = context.Users.Any(user => user.Email == log);
                if (userFound)
                {
                    MessageBox.Show("Podana nazwa uzytkownika jest zajeta");
                }
                else
                {
                    if (emailtxtb.Text != null && passwordtxtb.Password != null && firstnametxtb.Text != null && lastnametxtb.Text != null && birthdatepicker.SelectedDate != null)
                    {

                        User newuser = new User();
                        newuser.Email = emailtxtb.Text;
                        newuser.Password = passwordtxtb.Password;
                        newuser.FirstName = firstnametxtb.Text;
                        newuser.LastName = lastnametxtb.Text;
                        newuser.BirthDate = birthdatepicker.SelectedDate;

                        context.Add(newuser);
                        context.SaveChanges();
                        MessageBox.Show("Dodano uzytkownika");
                        MainWindow main = new MainWindow();
                        main.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Nie wszystkie pola zostaly uzupelnione");
                    }

                }

            }


        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Loging();
        }


        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Adding();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Logingpanel.Visibility = Visibility.Collapsed;
            registrationpanel.Visibility = Visibility.Visible;
        }

        public void Back_Click(object sender, RoutedEventArgs e)
        {
            Logingpanel.Visibility = Visibility.Visible;
            registrationpanel.Visibility = Visibility.Collapsed;
        }

      
    }
}
