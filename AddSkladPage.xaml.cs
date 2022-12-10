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
    /// Логика взаимодействия для AddSkladPage.xaml
    /// </summary>
    public partial class AddSkladPage : Page
    {
        private Sklad _context = new Sklad();
        public AddSkladPage()
        {
            InitializeComponent();
            DataContext = _context;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tren3Entities1.GetContext().Sklad.Add(_context);
                Tren3Entities1.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено");
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }
    }
}
