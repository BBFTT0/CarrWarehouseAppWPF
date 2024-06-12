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
using System.Windows.Shapes;

namespace CarrWarehouseAppWPF
{
    /// <summary>
    /// Логика взаимодействия для DeleteCarWindow.xaml
    /// </summary>
    public partial class DeleteCarWindow : Window
    {
        private DatabaseManager dbManager;

        public DeleteCarWindow()
        {
            InitializeComponent();
            this.dbManager = new DatabaseManager("NOUT", "CarWarehouseAppWPF", "NAMI", "namissms");

        }
        public int GetCarId()
        {
            // Возвращает ID удаляемой машины из формы
            return int.Parse(CarIdTextBox.Text);
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем ID удаляемой машины
            int carIdToDelete = GetCarId();

            // Вызываем метод удаления машины из базы данных
            dbManager.DeleteCar(carIdToDelete);

        }
    }
}
