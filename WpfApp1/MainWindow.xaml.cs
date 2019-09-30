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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public class clientPack
        {
            public ListView MatchList;
            public Button MatchClearButton;
            public ListView LogList;
            public Button InputButton;
            public TextBox InputBox;
            public int LineCount;
            public string ServerName;
            public clientPack(ListView MatchList_input, Button MatchClearButton_input, ListView LogList_input, Button InputButton_input, TextBox InputBox_input, String Server)
            {
                MatchList = MatchList_input;
                MatchClearButton = MatchClearButton_input;
                LogList = LogList_input;
                InputButton = InputButton_input;
                InputBox = InputBox_input;
                LineCount = 0;
                ServerName = Server;
            }
        }

        public const int MatchListLines = 100;
        public const int LogListLines = 3000;
        public clientPack[] clientPacks;

        public MainWindow()
        {
            InitializeComponent();
            clientPacks = new clientPack[4];
            clientPacks[0] = new clientPack(MatchList0, MatchClearButton0, LogList0, InputButton0, InputBox0, "A");
            clientPacks[1] = new clientPack(MatchList1, MatchClearButton1, LogList1, InputButton1, InputBox1, "B");
            clientPacks[2] = new clientPack(MatchList2, MatchClearButton2, LogList2, InputButton2, InputBox2, "C");
            clientPacks[3] = new clientPack(MatchList3, MatchClearButton3, LogList3, InputButton3, InputBox3, "D");
        }

        private void MatchClearButton0_Click(object sender, RoutedEventArgs e)
        {
            clientPack thisPack = clientPacks[0];
            clientPacks[0].MatchList.Items.Clear();
        }

        private void MatchClearButton1_Click(object sender, RoutedEventArgs e)
        {
            clientPack thisPack = clientPacks[1];
            thisPack.MatchList.Items.Clear();
        }

        private void MatchClearButton2_Click(object sender, RoutedEventArgs e)
        {
            clientPack thisPack = clientPacks[2];
            thisPack.MatchList.Items.Clear();
        }

        private void MatchClearButton3_Click(object sender, RoutedEventArgs e)
        {
            clientPack thisPack = clientPacks[3];
            thisPack.MatchList.Items.Clear();
        }

        private void MyInputClick(clientPack thisPack)
        {
            if (thisPack.InputBox.Text.Length < 4)
            {
                thisPack.InputBox.Background = Brushes.Red;
                return;
            }
            CheckWin(thisPack, clientPacks[0], thisPack.InputBox.Text);
            CheckWin(thisPack, clientPacks[1], thisPack.InputBox.Text);
            CheckWin(thisPack, clientPacks[2], thisPack.InputBox.Text);
            CheckWin(thisPack, clientPacks[3], thisPack.InputBox.Text);
            thisPack.LogList.Items.Add(thisPack.InputBox.Text);
            if (++thisPack.LineCount > 5)
                thisPack.LogList.Items.RemoveAt(0);

            thisPack.InputBox.Text = "";
        }

        private void CheckWin(clientPack thisPack, clientPack comparePack, string input)
        {
            for (int i = comparePack.LogList.Items.Count - 1; i >= 0; i--)
                if (comparePack.LogList.Items[i].ToString() == input)
                {
                    comparePack.MatchList.Items.Add(thisPack.ServerName+" "+input);
                    break;
                }
        }

        private void InputButton0_Click(object sender, RoutedEventArgs e)
        {
            clientPack thisPack = clientPacks[0];
            MyInputClick(thisPack);
        }

        private void InputButton1_Click(object sender, RoutedEventArgs e)
        {
            clientPack thisPack = clientPacks[1];
            MyInputClick(thisPack);
        }

        private void InputButton2_Click(object sender, RoutedEventArgs e)
        {
            clientPack thisPack = clientPacks[2];
            MyInputClick(thisPack);
        }

        private void InputButton3_Click(object sender, RoutedEventArgs e)
        {
            clientPack thisPack = clientPacks[3];
            MyInputClick(thisPack);
        }

        private void MyInputboxKeyDown(clientPack thisPack, KeyEventArgs e)
        {
            thisPack.InputBox.Background = Brushes.White;
            if (e.Key == Key.Enter)
            {
                MyInputClick(thisPack);
            }
        }

        private void InputBox0_KeyDown(object sender, KeyEventArgs e)
        {
            clientPack thisPack = clientPacks[0];
            MyInputboxKeyDown(thisPack, e);
        }

        private void InputBox1_KeyDown(object sender, KeyEventArgs e)
        {
            clientPack thisPack = clientPacks[1];
            MyInputboxKeyDown(thisPack, e);
        }

        private void InputBox2_KeyDown(object sender, KeyEventArgs e)
        {
            clientPack thisPack = clientPacks[2];
            MyInputboxKeyDown(thisPack, e);
        }

        private void InputBox3_KeyDown(object sender, KeyEventArgs e)
        {
            clientPack thisPack = clientPacks[3];
            MyInputboxKeyDown(thisPack, e);
        }
    }
}
