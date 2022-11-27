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
    /// Логика взаимодействия для Glavnaya.xaml
    /// </summary>
    public partial class Glavnaya : Page
    {
        string User;
        public Glavnaya(string user)
        {
            InitializeComponent();
            DgridHotels2.Visibility = Visibility.Collapsed;
            DgridHotels.ItemsSource = Entities.GetContext().reis.ToList();
            Glavnaya customer = (Glavnaya)DgridHotels.SelectedItem;
            DgridHotels1.ItemsSource = Entities.GetContext().planes.ToList();
            Glavnaya customer1 = (Glavnaya)DgridHotels1.SelectedItem;
            User = user;
        }

        private void otloz_Click(object sender, RoutedEventArgs e)
        {
            List<aeroflot.pokupki> otl = new List<aeroflot.pokupki>();
            otl = Entities.GetContext().pokupki.ToList();
            int count = Entities.GetContext().pokupki.Count();
                DgridHotels1.Visibility = Visibility.Collapsed;
                DgridHotels2.Visibility = Visibility.Visible;
                for (int i = 0; i < count; i++)
                {
                    if (otl[i].status!="Отложен")
                    {
                        otl.RemoveAt(i);
                        i--;
                        count--;
                    }
                }
                DgridHotels2.ItemsSource = otl;
                Glavnaya customer2 = (Glavnaya)DgridHotels2.SelectedItem;   
        }

        private void planess_Click(object sender, RoutedEventArgs e)
        {
            DgridHotels1.Visibility = Visibility.Visible;
            DgridHotels2.Visibility = Visibility.Collapsed;
        }

        private void activ_Click(object sender, RoutedEventArgs e)
        {
            List<aeroflot.pokupki> act = new List<aeroflot.pokupki>();
            act = Entities.GetContext().pokupki.ToList();
            int count = Entities.GetContext().pokupki.Count();
            DgridHotels1.Visibility = Visibility.Collapsed;
            DgridHotels2.Visibility = Visibility.Visible;
            for (int i = 0; i < count; i++)
            {
                if (act[i].status != "Активен")
                {
                    act.RemoveAt(i);
                    i--;
                    count--;
                }
            }
            DgridHotels2.ItemsSource = act;
            Glavnaya customer2 = (Glavnaya)DgridHotels2.SelectedItem;
        }

        private void userReis_Click(object sender, RoutedEventArgs e)
        {
            List<aeroflot.pokupki> user = new List<aeroflot.pokupki>();
            user = Entities.GetContext().pokupki.ToList();
            int count = Entities.GetContext().pokupki.Count();
            DgridHotels1.Visibility = Visibility.Collapsed;
            DgridHotels2.Visibility = Visibility.Visible;
            for (int i = 0; i < count; i++)
            {
                if (user[i].klients.klient !=User)
                {
                    user.RemoveAt(i);
                    i--;
                    count--;
                }
            }
            DgridHotels2.ItemsSource = user;
            Glavnaya customer2 = (Glavnaya)DgridHotels2.SelectedItem;
        }
    }
}
