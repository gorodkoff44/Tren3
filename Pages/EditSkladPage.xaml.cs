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
    /// Логика взаимодействия для EditSkladPage.xaml
    /// </summary>
    public partial class EditSkladPage : Page
    {
        private Sklad _currentSklad = new Sklad();
        public EditSkladPage(Sklad selectedSklad)
        {
            InitializeComponent();
            _currentSklad = selectedSklad;
            DataContext = _currentSklad;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TrenEntities.GetContext().Sklad.Add(_currentSklad);
                TrenEntities.GetContext().SaveChanges();
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
