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
        //private Tren3Entities1 _context = new Tren3Entities1();
        private StroyMaterial _currentStroy = new StroyMaterial();
        public AddStroyPage(StroyMaterial selectstroyMaterial)
        {
            InitializeComponent();
            if (selectstroyMaterial !=null)
            {
                _currentStroy = selectstroyMaterial;
            }
            DataContext = _currentStroy;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tren3Entities1.GetContext().StroyMaterial.Add(_currentStroy);
            }
            catch
            {

                try
                {
                    Tren3Entities1.GetContext().SaveChanges();
                    MessageBox.Show("Успешно сохранено");
                    NavigationService.GoBack();
                }
                catch
                {
                    MessageBox.Show("Ошибка. Возможно вы указали несуществующий склад");
                }
            }
        }
    }
}
