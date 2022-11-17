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
        public avtorization()
        {
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
            MainWindow mainWindow = new MainWindow();
            string klients = login.Text;
            string[] k=new string[1];
            k[0] = Convert.ToString(Entities.GetContext().klients.ToList().ToArray());
            users = Entities.GetContext().klients.ToList();
            for (int i = 0; i < 1; i++)
            {
            //    if ( == klients)
            //    {
            //    mainWindow.MainFrame.Navigate(new Glavnaya());
            //}
        }

        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
