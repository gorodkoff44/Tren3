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
    /// Логика взаимодействия для AddStroyPage.xaml
    /// </summary>
    public partial class AddStroyPage : Page
    {
        private Tren3Entities _context = new Tren3Entities();
        private StroyMaterial currentStroy = new StroyMaterial();
        public AddStroyPage()
        {
            InitializeComponent();
            ComboSklad.ItemsSource = _context.Sklad.ToList();
            DataContext = currentStroy;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Tren3Entities.GetContext().StroyMaterial.Add(currentStroy);
            Tren3Entities.GetContext().SaveChanges();
            NavigationService.GoBack();
        }
    }
}
