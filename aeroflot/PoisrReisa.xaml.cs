using System;
using System.Collections;
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
    /// Логика взаимодействия для PoisrReisa.xaml
    /// </summary>
    public partial class PoisrReisa : Page
    {
        public Frame frame1;
        string user;
        public PoisrReisa(Frame frame, string User)
        {
            InitializeComponent();
            frame1 = frame;
            var city_otpr = Entities.GetContext().citys.ToList();
            ComboType.ItemsSource = city_otpr;
            city_otpr.Insert(0, new citys
            {
                city = "Город отправки"
            });
            ComboType.SelectedIndex = 0;
            var city_prib = Entities.GetContext().citys.ToList();
            ComboType1.ItemsSource = city_prib;
            city_prib.Insert(0, new citys
            {
                city = "Город прибытия"
            });
            ComboType1.SelectedIndex = 0;
            user = User;
        }

        private void ppoisk_Click(object sender, RoutedEventArgs e)
        {
            List<aeroflot.reis> reisii = new List<aeroflot.reis>();
            reisii = Entities.GetContext().reis.ToList();
            int counts = Entities.GetContext().reis.Count();
            for (int i = 0; i < counts; i++)
            {
                if (reisii[i].citys.city!=ComboType.Text || reisii[i].citys1.city != ComboType1.Text)
                {
                        reisii.RemoveAt(i);
                        i--;
                        counts--;
                }
            }
            Dgridreis.ItemsSource = reisii;
            Glavnaya customer1 = (Glavnaya)Dgridreis.SelectedItem;
        }

        private void back_poisk_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Glavnaya(user, frame1));
        }
        public int rel = 0;
        private void Dgridreis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rel == 0)
            {
                if (MessageBox.Show($"Вы хотите забронировать этот рейс?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    List<aeroflot.reis> r = new List<aeroflot.reis>();
                    r = Entities.GetContext().reis.ToList();
                    int count11 = Entities.GetContext().reis.Count();
                    int count111 = Entities.GetContext().klients.Count();
                    IList rows = Dgridreis.SelectedItems;
                    object a = rows[0];
                    for (int i = 0; i < count11; i++)
                    {
                        if (r[i].reis1 == ((aeroflot.reis)a).reis1)
                        {
                            int index = r[i].id;
                            List<aeroflot.pokupki> rr = new List<aeroflot.pokupki>() { new pokupki() };
                            List<aeroflot.klients> rrr = new List<aeroflot.klients>();
                            rrr = Entities.GetContext().klients.ToList();
                            rr[0].id_reis = index;
                            for (int j = 0; j < count11; j++)
                            {
                                if (rrr[j].klient == user)
                                {
                                    rr[0].id_klient = rrr[j].id;
                                    break;
                                }
                            }
                            rr[0].status = "Активен";
                            rr[0].statusOplati = "Не оплачен";
                            Entities.GetContext().pokupki.Add(rr[0]);
                            Entities.GetContext().SaveChanges();
                            rel = 1;
                        }
                    }
                }
                else
                {
                    rel = 1;
                }
            }

            Dgridreis.ItemsSource = null;
            List<aeroflot.reis> reisiiii = new List<aeroflot.reis>();
            reisiiii = Entities.GetContext().reis.ToList();
            int counts1 = Entities.GetContext().reis.Count();
            for (int j = 0; j < counts1; j++)
            {
                if (reisiiii[j].date < DateTime.Now && reisiiii[j].citys.city != ComboType.Text || reisiiii[j].citys1.city != ComboType1.Text)
                {
                    reisiiii.RemoveAt(j);
                    j--;
                    counts1--;
                }
            }
            Dgridreis.ItemsSource = reisiiii;
            Glavnaya customer = (Glavnaya)Dgridreis.SelectedItem;
            rel = 0;
        }
    }
}
