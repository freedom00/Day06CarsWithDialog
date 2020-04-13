using System;
using System.Windows;

namespace Day06CarsWithDialog
{
    /// <summary>
    /// Interaction logic for AddEditDialog.xaml
    /// </summary>
    public partial class AddEditDialog : Window
    {
        private MainWindow mainWindow;
        private Car car;

        public AddEditDialog()
        {
            InitializeComponent();
        }

        public AddEditDialog(MainWindow mainWindow, Car car = null)
        {
            this.mainWindow = mainWindow;
            this.car = car;
            InitializeComponent();
            cmbFuelType.ItemsSource = Enum.GetValues(typeof(Car.FuelTypeEnum));
            if (null == car)
            {
                btSave.Content = "Create";
            }
            else
            {
                btSave.Content = "Update";
                lblId.Content = car.Id;
                tbMakeModel.Text = car.MakeModel;
                sldEngineSizeL.Value = car.EngineSizeL;
                cmbFuelType.Text = car.FuelType.ToString();
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (null == car)
                {
                    car = new Car();
                    car.MakeModel = tbMakeModel.Text;
                    car.EngineSizeL = sldEngineSizeL.Value;
                    if (-1 == cmbFuelType.SelectedIndex)
                    {
                        showMessageBox("You must select fuel type.");
                        return;
                    }
                    car.FuelType = (Car.FuelTypeEnum)cmbFuelType.SelectedItem;
                    mainWindow.setValues(car);
                }
                else
                {
                    car.MakeModel = tbMakeModel.Text;
                    car.EngineSizeL = sldEngineSizeL.Value;
                    if (-1 == cmbFuelType.SelectedIndex)
                    {
                        showMessageBox("You must select fuel type.");
                        return;
                    }
                    car.FuelType = (Car.FuelTypeEnum)cmbFuelType.SelectedItem;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                showMessageBox(ex.Message);
                return;
            }

            DialogResult = true;
        }

        private void showMessageBox(string message)
        {
            MessageBox.Show(this, message, "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}