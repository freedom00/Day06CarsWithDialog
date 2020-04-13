using CsvHelper;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Day06CarsWithDialog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Car> carsList = new List<Car>();

        public MainWindow()
        {
            InitializeComponent();
            lvCars.ItemsSource = carsList;
        }

        private void miDelete_Click(object sender, RoutedEventArgs e)
        {
            Car car = (Car)lvCars.SelectedValue;
            if (null == car)
            {
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show(this, $"Are your sure you want to delete the car <{car}>", "Operation Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (MessageBoxResult.Yes == messageBoxResult)
            {
                carsList.Remove(car);
                doRefresh();
            }
        }

        private void miEdit_Click(object sender, RoutedEventArgs e)
        {
            doEdit();
        }

        private void miAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddEditDialog(this).ShowDialog();
            doRefresh();
        }

        private void miExportToCsv_Click(object sender, RoutedEventArgs e)
        {
            saveDataToFile();
        }

        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void lvCars_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            doEdit();
        }

        private void doEdit()
        {
            Car car = (Car)lvCars.SelectedValue;
            if (null != car)
            {
                new AddEditDialog(this, car).ShowDialog();
                doRefresh();
            }
        }

        private void doRefresh()
        {
            lvCars.Items.Refresh();
            tblkStatus.Text = string.Format("You have {0} car(s) currently", carsList.Count);
        }

        private void saveDataToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";
            if (true == saveFileDialog.ShowDialog())
            {
                using (CsvWriter csvWriter = new CsvWriter(new StreamWriter(saveFileDialog.FileName), CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(carsList);
                }
            }
        }

        public void setValues(Car car = null)
        {
            if (null != car)
            {
                carsList.Add(car);
            }
        }
    }
}