using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    /// <summary>
    /// MyControl1.xaml 的互動邏輯
    /// </summary>
    public partial class MyControl1 : UserControl
    {
        // 用來給外面接的事件
        public event EventHandler<RoutedEventArgs> MatchClearButtonClicked;
        public event EventHandler<RoutedEventArgs> InputButtonClicked;
        public event EventHandler<KeyEventArgs> InputBoxDown;

        public string ServerName = "undefined";
        public ObservableCollection<MyModel> TheCollection = new ObservableCollection<MyModel>();
        private int LineCount;

        public MyControl1()
        {
            InitializeComponent();
            LogList.ItemsSource = TheCollection;
        }

        private void MatchClearButton_Click(object sender, RoutedEventArgs e)
        {
            MatchList.Items.Clear();
            MatchClearButtonClicked?.Invoke(sender, e);
        }

        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            MyInputClick();
            InputButtonClicked?.Invoke(sender, e);
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            MyInputboxKeyDown(e);
            InputBoxDown?.Invoke(sender, e);
        }

        private void MyInputClick()
        {
            if (InputBox.Text.Length < 4)
            {
                InputBox.Background = Brushes.Red;
                return;
            }
            CheckWin(InputBox.Text);
            TheCollection.Add(new MyModel(InputBox.Text));
            if (++LineCount > 5)
                TheCollection.RemoveAt(0);

            InputBox.Text = string.Empty;
        }

        private void CheckWin(string input)
        {
            MyModel winItem = TheCollection.LastOrDefault(x => x.TheText == input);
            if (winItem != null)
            {
                winItem.TextColorBrush = Brushes.Red;
                MatchList.Items.Add(ServerName + " " + input);
            }
        }

        private void MyInputboxKeyDown(KeyEventArgs e)
        {
            InputBox.Background = Brushes.White;
            if (e.Key == Key.Enter)
            {
                MyInputClick();
            }
        }
    }
}
