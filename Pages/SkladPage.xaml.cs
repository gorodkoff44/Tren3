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

namespace Tren3
{
    /// <summary>
    /// Логика взаимодействия для SkladPage.xaml
    /// </summary>
    public partial class SkladPage : Page
    {
        private TrenEntities _context = new TrenEntities();
        public SkladPage()
        {
            
            InitializeComponent();
            //Login login = new Login();
            //if (login.tlogin == 0)
            //{
            //    add.Visibility = Visibility.Collapsed;
            //    del.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //        add.Visibility = Visibility.Visible;
            //        del.Visibility = Visibility.Visible;
            //}
            LVSklad.ItemsSource = _context.Sklad.ToList();
            TrenEntities.GetContext().SaveChanges();
            UpdateSklad();
        }
        private void UpdateSklad()
        {
            var currentSklad = _context.Sklad.ToList(); //Поиск
            {
                currentSklad = currentSklad.FindAll(x => x.TypeMaterialiv.Contains(SearchBox.Text));
                LVSklad.ItemsSource = currentSklad;
            }
        }
        public void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSklad();
            if (SearchBox.Text == "") //спрятать текстблок "результаты поиска"
            {
                rezsearchtb.Visibility = Visibility.Collapsed;
            }
            else
                rezsearchtb.Visibility = Visibility.Visible;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Pages/AddSkladPage.xaml", UriKind.RelativeOrAbsolute));
            NavigationService.Navigate(new AddSkladPage(null));
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            if (LVSklad.SelectedItem == null)
            {
                MessageBox.Show("Не выбран склад для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                _context.Sklad.Remove((Sklad)LVSklad.SelectedItem);
                _context.SaveChanges();
                UpdateSklad();
            }
            catch
            {
                MessageBox.Show("Похоже в этом складе остались стройматериалы, удалите их и повторите попытку","Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSkladPage((sender as Button).DataContext as Sklad));
            
            
           
        }

        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {
            LVSklad.ItemsSource = _context.Sklad.ToList();
        }
    }
}
