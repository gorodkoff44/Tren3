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
        private StroyMaterial currentStroy = new StroyMaterial();
        public AddStroyPage()
        {
            InitializeComponent();
            
            DataContext = currentStroy;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tren3Entities1.GetContext().StroyMaterial.Add(currentStroy);
                Tren3Entities1.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено");
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка. Возможно вы указали несуществующий склад");
                //NavigationService.GoBack();
            }
        }

        private void ComboSklad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
