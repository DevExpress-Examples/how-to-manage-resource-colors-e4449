using System;
using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace SchedulerResourceColorsWpf {
    public partial class MainWindow : Window {
        int resourceCounter = 0;
        
        public MainWindow() {
            InitializeComponent();

            this.DataContext = new ObservableCollection<ModelResource>();
        }

        private void btnAddResource_Click(object sender, RoutedEventArgs e) {
            if (colorEdit.EditValue == null)
                return;
            
            resourceCounter++;

            ((ObservableCollection<ModelResource>)this.DataContext).Add(new ModelResource() {
                Id = resourceCounter,
                Name = "Resource" + resourceCounter.ToString(),
                Color = (int)colorEdit.EditValue
            });
        }
    }

    public class ModelResource {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Color { get; set; }

        public ModelResource() {

        }
    }

    public class CustomColorConverter : System.Windows.Markup.MarkupExtension, System.Windows.Data.IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if (value is int) {
                string hexString = "#" + ((int)value).ToString("X");
                Color color = (Color)ColorConverter.ConvertFromString(hexString);
            }
            
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            Color color = (Color)value;
            int result = BitConverter.ToInt32(new byte[] { color.B, color.G, color.R, color.A }, 0);

            return result;
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}