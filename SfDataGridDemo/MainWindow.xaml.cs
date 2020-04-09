using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.ComponentModel;
using System.Data;

namespace SfDataGrid_Sample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
    }

    public class OrderInfo : INotifyPropertyChanged
    {
        int orderID;
        string customerId;
        string country;
        string customerName;
        string shippingCity;
        bool isShipped;

        public OrderInfo()
        {

        }

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; this.OnPropertyChanged("OrderID"); }
        }

        public string CustomerID
        {
            get { return customerId; }
            set { customerId = value; this.OnPropertyChanged("CustomerID"); }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; this.OnPropertyChanged("CustomerName"); }
        }

        public string Country
        {
            get { return country; }
            set { country = value; this.OnPropertyChanged("Country"); }
        }

        public string ShipCity
        {
            get { return shippingCity; }
            set { shippingCity = value; this.OnPropertyChanged("ShipCity"); }
        }

        public bool IsShipped
        {
            get { return isShipped; }
            set { isShipped = value; this.OnPropertyChanged("IsShipped"); }
        }


        public OrderInfo(int orderId, string customerName, string country, string customerId, string shipCity, bool isShipped)
        {
            this.OrderID = orderId;
            this.CustomerName = customerName;
            this.Country = country;
            this.CustomerID = customerId;
            this.ShipCity = shipCity;
            this.IsShipped = isShipped;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ViewModel
    {
        private ObservableCollection<OrderInfo> _orders;
        public ObservableCollection<OrderInfo> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public ViewModel()
        {
            _orders = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            for (int i = 0; i < 10; i++)
            {
                _orders.Add(new OrderInfo(1001, "Maria Anders", "Germany", "ALFKI", "Berlin", true));
                _orders.Add(new OrderInfo(1002, "Ana Trujilo", "Mexico", "ANATR", "Mexico D.F.", false));
                _orders.Add(new OrderInfo(1003, "Antonio Moreno", "Mexico", "ANTON", "Mexico D.F.", true));
                _orders.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London", true));
                _orders.Add(new OrderInfo(1005, "Christina Berglund", "Sweden", "BERGS", "Lula", false));
                _orders.Add(new OrderInfo(1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim", true));
                _orders.Add(new OrderInfo(1007, "Frederique Citeaux", "France", "BLONP", "Strasbourg", true));
                _orders.Add(new OrderInfo(1008, "Martin Sommer", "Spain", "BOLID", "Madrid", true));
                _orders.Add(new OrderInfo(1009, "Laurence Lebihan", "France", "BONAP", "Marseille", false));
                _orders.Add(new OrderInfo(1010, "Elizabeth Lincoln", "Canada", "BOTTM", "Tsawassen", true));
            }
        }
    }

    public class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((value as FilterElement).DisplayText == "True")
                return "Yes";
            else
                return "No";

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
