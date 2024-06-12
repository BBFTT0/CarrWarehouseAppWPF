using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    public partial class CarStorageWindow : Window
    {
        private List<Car> cars;

        public CarStorageWindow()
        {
            InitializeComponent();
            // Создание экземпляра DatabaseManager с необходимыми параметрами
            dbManager = new DatabaseManager("NOUT", "CarStorageWindow", "NAMI", "namissms");
            // Загрузка машин из базы данных при инициализации окна
            LoadCars();
        }

        // Добавленная строка
        private DatabaseManager dbManager;

        private void LoadCars()
        {
            // Получение машин из базы данных с помощью DatabaseManager
            cars = dbManager.GetCars();
            // Привязка списка машин к ListBox или DataGrid
            carListBox.ItemsSource = cars;
        }

        private void CarListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Включение/отключение кнопок редактирования и удаления в зависимости от выбранного элемента
            editCarButton.IsEnabled = carListBox.SelectedItem != null;
            deleteCarButton.IsEnabled = carListBox.SelectedItem != null;
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна для добавления новой машины
            AddCarWindow addCarWindow = new AddCarWindow(dbManager); // Передача экземпляра dbManager в конструктор AddCarWindow
            addCarWindow.ShowDialog();
            // Перезагрузка списка машин после добавления новой
            LoadCars();
        }

        private void EditCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна для редактирования выбранной машины
            Car selectedCar = (Car)carListBox.SelectedItem;
            DatabaseManager dbManager = new DatabaseManager("NOUT", "CarStorageWindow", "NAMI", "namissms"); // Создание экземпляра DatabaseManager
            EditCarWindow editCarWindow = new EditCarWindow(dbManager, selectedCar); // Передача DatabaseManager и выбранной машины в конструктор EditCarWindow
            editCarWindow.ShowDialog();
            // Перезагрузка списка машин после редактирования
            LoadCars();
        }

        private void DeleteCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Получение идентификатора выбранной машины
            int selectedCarId = ((Car)carListBox.SelectedItem).Id;
            // Удаление выбранной машины из базы данных
            dbManager.DeleteCar(selectedCarId);
            // Перезагрузка списка машин после удаления
            LoadCars();
        }
    }
}
