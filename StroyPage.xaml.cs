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
    /// Логика взаимодействия для StroyPage.xaml
    /// </summary>
    public partial class StroyPage : Page
    {
        private DbEntities _context = new DbEntities();
        public StroyPage()
        {
            InitializeComponent();
            LVStroy.ItemsSource = _context.StroyMaterial.ToList();
        }
        private void UpdateStroy()
        {
            var currentStroy = _context.StroyMaterial.ToList();
            {
                currentStroy = currentStroy.FindAll(x => x.Name.Contains(SearchBox.Text));
                LVStroy.ItemsSource = currentStroy;
            }
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateStroy();
            if (SearchBox.Text == "")
            {
                rezsearchtb.Visibility = Visibility.Collapsed;
            }
            else
                rezsearchtb.Visibility = Visibility.Visible;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            _context.StroyMaterial.Remove((StroyMaterial)LVStroy.SelectedItem);
            _context.SaveChanges();
            UpdateStroy();
        }
    }
}
