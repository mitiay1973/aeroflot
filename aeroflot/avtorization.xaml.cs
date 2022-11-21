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

namespace aeroflot
{
    /// <summary>
    /// Логика взаимодействия для avtorization.xaml
    /// </summary>
    public partial class avtorization : Page
    {
        public Frame frame1;
        public avtorization(Frame frame)
        {
            frame1 = frame;
            InitializeComponent();
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        List<aeroflot.klients> users = new List<aeroflot.klients>();
        private void vxod_Click(object sender, RoutedEventArgs e)
        {
            string klients = login.Text;
            string pas = password.Password;
            int count = Entities.GetContext().klients.Count();
            users = Entities.GetContext().klients.ToList();
            for (int i = 0; i < count; i++)
            {
                if (users[i].klient == klients)
                {
                    if (users[i].password == pas)
                    {
                        frame1.Navigate(new Glavnaya());
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }

        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Registration(frame1));
        }
    }
}
