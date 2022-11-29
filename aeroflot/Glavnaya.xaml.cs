using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static DateTime Today { get; }
        string User;
        public Glavnaya(string user)
        {
            InitializeComponent();
            DgridHotels2.Visibility = Visibility.Collapsed;
             
            List<aeroflot.reis> reisii = new List<aeroflot.reis>();
            reisii = Entities.GetContext().reis.ToList();
            int counts = Entities.GetContext().reis.Count();
            for (int i = 0; i < counts; i++)
            {
                if (reisii[i].date < DateTime.Now)
                {
                    reisii.RemoveAt(i);
                    i--;
                    counts--;
                }
            }
            DgridHotels.ItemsSource = reisii;
            Glavnaya customer = (Glavnaya)DgridHotels.SelectedItem;
            DgridHotels1.ItemsSource = Entities.GetContext().planes.ToList();
            Glavnaya customer1 = (Glavnaya)DgridHotels1.SelectedItem;
            User = user;
        }

        private void otloz_Click(object sender, RoutedEventArgs e)
        {
            List<aeroflot.pokupki> otl = new List<aeroflot.pokupki>();
            List<aeroflot.prazdniki> pr = new List<aeroflot.prazdniki>();
            pr= Entities.GetContext().prazdniki.ToList();
            otl = Entities.GetContext().pokupki.ToList();
            int count = Entities.GetContext().pokupki.Count();
            int countpr = Entities.GetContext().prazdniki.Count();
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
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < countpr; j++)
                {
                    if (otl[i].reis.date.Day == pr[j].prazdnik.Day)
                    {
                        if (otl[i].reis.date.Month == pr[j].prazdnik.Month)
                        {
                            if (otl[i].reis.date.Year == pr[j].prazdnik.Year)
                            {
                                otl[i].stoimost = otl[i].reis.zena / 100 * 80;
                                j = countpr - 1;
                            }
                            else
                            {
                                otl[i].stoimost = otl[i].reis.zena;
                            }
                        }
                        else
                        {
                            otl[i].stoimost = otl[i].reis.zena;
                        }
                    }
                    else
                    {
                        otl[i].stoimost = otl[i].reis.zena;
                    }
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
            List<aeroflot.prazdniki> pr1 = new List<aeroflot.prazdniki>();
            pr1 = Entities.GetContext().prazdniki.ToList();
            int count = Entities.GetContext().pokupki.Count();
            int countpr1 = Entities.GetContext().prazdniki.Count();
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
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < countpr1; j++)
                {
                    if (act[i].reis.date.Day == pr1[j].prazdnik.Day)
                    {
                        if (act[i].reis.date.Month == pr1[j].prazdnik.Month)
                        {
                            if (act[i].reis.date.Year == pr1[j].prazdnik.Year)
                            {
                                act[i].stoimost = act[i].reis.zena / 100 * 80;
                                j = countpr1 - 1;
                            }
                            else
                            {
                                act[i].stoimost = act[i].reis.zena;
                            }
                        }
                        else
                        {
                            act[i].stoimost = act[i].reis.zena;
                        }
                    }
                    else
                    {
                        act[i].stoimost = act[i].reis.zena;
                    }
                }
            }
            DgridHotels2.ItemsSource = act;
            Glavnaya customer2 = (Glavnaya)DgridHotels2.SelectedItem;
        }

        private void userReis_Click(object sender, RoutedEventArgs e)
        {
            List<aeroflot.pokupki> user = new List<aeroflot.pokupki>();
            List<aeroflot.prazdniki> pr2 = new List<aeroflot.prazdniki>();
            pr2 = Entities.GetContext().prazdniki.ToList();
            user = Entities.GetContext().pokupki.ToList();
            int count = Entities.GetContext().pokupki.Count();
            int countpr2 = Entities.GetContext().prazdniki.Count();
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
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < countpr2; j++)
                {
                    if (user[i].reis.date.Day == pr2[j].prazdnik.Day)
                    {
                        if (user[i].reis.date.Month == pr2[j].prazdnik.Month)
                        {
                            if (user[i].reis.date.Year == pr2[j].prazdnik.Year)
                            {
                                user[i].stoimost = user[i].reis.zena / 100 * 80;
                                j = countpr2 - 1;
                            }
                            else
                            {
                                user[i].stoimost = user[i].reis.zena;
                            }
                        }
                        else
                        {
                            user[i].stoimost = user[i].reis.zena;
                        }
                    }
                    else
                    {
                        user[i].stoimost = user[i].reis.zena;
                    }
                }
            }
                DgridHotels2.ItemsSource = user;
            Glavnaya customer2 = (Glavnaya)DgridHotels2.SelectedItem;
        }
        public int rel = 0;
        private void DgridHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(rel == 0)
            {
                if (MessageBox.Show($"Вы хотите забронировать этот рейс?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    List<aeroflot.reis> r = new List<aeroflot.reis>();
                    r = Entities.GetContext().reis.ToList();
                    int count11 = Entities.GetContext().reis.Count();
                    int count111 = Entities.GetContext().klients.Count();
                    IList rows = DgridHotels.SelectedItems;
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
                                if (rrr[j].klient == User)
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
           
            DgridHotels.ItemsSource = null;
            List<aeroflot.reis> reisiii = new List<aeroflot.reis>();
            reisiii = Entities.GetContext().reis.ToList();
            int counts1 = Entities.GetContext().reis.Count();
            for (int j = 0; j < counts1; j++)
            {
                if (reisiii[j].date < DateTime.Now)
                {
                    reisiii.RemoveAt(j);
                    j--;
                    counts1--;
                }
            }
            DgridHotels.ItemsSource = reisiii;
            Glavnaya customer = (Glavnaya)DgridHotels.SelectedItem;
            rel = 0;
        }
    
    }   
}
