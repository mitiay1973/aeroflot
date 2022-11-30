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
    /// Логика взаимодействия для print.xaml
    /// </summary>
    public partial class print : Page
    {
        public Frame frame1;
        public List<aeroflot.pokupki> user = new List<aeroflot.pokupki>();
        public print(Frame frame, List<aeroflot.pokupki> pokupkis)
        {
            InitializeComponent();
            frame1 = frame;
            user = pokupkis;
            Name.Text = user[0].klients.klient;
            otkuda.Text = user[0].reis.citys.city;
            kuda.Text = user[0].reis.citys1.city;
            data.Text = user[0].reis.date.Date.ToString();
            time.Text = user[0].reis.date.TimeOfDay.ToString();
        }

        private void backPrint_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Glavnaya(user[0].klients.klient, frame1));
        }

        private void prints_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Билет отправлен на печать");
            frame1.Navigate(new Glavnaya(user[0].klients.klient, frame1));
        }
    }
}
