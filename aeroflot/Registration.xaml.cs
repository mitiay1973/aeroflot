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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Frame frame1;
        public Registration(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            string log = login.Text;
            string pas = password.Text;
            string pas1 = password_Copy.Text;
            if(log!="")
            {
                if(pas!="")
                {
                    if(pas1!="")
                    {
                        if(pas==pas1)
                        {
                            List<aeroflot.klients> user = new List<aeroflot.klients>() {new klients()};
                            user[0].klient =log;
                            user[0].password = pas;
                            Entities.GetContext().klients.Add(user[0]);
                        }
                    }
                }
            }

        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void password_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
