using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1
{
    public class MyModel : INotifyPropertyChanged
    {
        public MyModel(string content)
        {
            TheText = content;
        }

        private SolidColorBrush textColorBrush = Brushes.Black;
        public SolidColorBrush TextColorBrush
        {
            get => textColorBrush;
            set
            {
                textColorBrush = value;
                OnPropertyChanged(nameof(TextColorBrush));
            }
        }

        private string theText;
        public string TheText
        {
            get => theText;
            set
            {
                theText = value;
                OnPropertyChanged("TheText");
            }
        }

        public override string ToString()
        {
            return theText;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
