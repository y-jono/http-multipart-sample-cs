using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //送信するファイルのパス
            string filePath = @"C:\Users\pek9d\Desktop\IMG_5498.JPG";
            //送信先のURL
            string url = "http://127.0.0.1:8080/ListenerTest/";

            WebClient wc = new WebClient();
            try
            {
                //データを送信し、また受信する
                byte[] resData = wc.UploadFile(url, filePath);
                //受信したデータを表示する
                string resText = Encoding.UTF8.GetString(resData);
                Console.WriteLine(resText);
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
