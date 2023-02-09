using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Authentication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string login = "admin";
        string pass = "admin";
        int time = 10;

        DispatcherTimer timer = new DispatcherTimer();
        
        public MainWindow(int index)
        {
            InitializeComponent();
            tbLogin.IsEnabled = false;
            tbPassword.IsEnabled = false;
            btAuto.IsEnabled = false;
            switch (index)
            {
                case 0:
                    break;
                case 1:                    
                    tbNewCode.Visibility = Visibility.Visible;
                    timer.Interval = new TimeSpan(0, 0, 1); 
                    timer.Tick += new EventHandler(Timer_tick);
                    timer.Start();
                    break;
                case 2:
                    tbNewCode.Visibility = Visibility.Collapsed;
                    borderCap.Visibility = Visibility.Visible;
                    tbCaptcha.Visibility = Visibility.Visible;
                    Captcha();
                    break;
            }

        }

        private void Timer_tick(object sender, EventArgs e) //обработчик события для истекающего таймера
        {
            time--;
            tbNewCode.Text = "Получить новый код можно через " + time.ToString() + " секунд";
            if (time == 0)
            {
                btnNewCode.Visibility = Visibility.Visible;
                tbNewCode.Visibility = Visibility.Collapsed;
                timer.Stop();
            }
        }
                
        string code = "";
        private void btnNewCode_Click(object sender, RoutedEventArgs e)
        {
            if(tbLogin.Text == login)
            {
                if(tbPassword.Password == pass)
                {
                    Random rnd = new Random();
                    code = rnd.Next(10000, 50000).ToString();
                    MessageBox.Show(code + "\nЗапомните пожалуйста код", "Код");
                    WindowCode windowCode = new WindowCode(code);
                    windowCode.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неправильный пароль!");
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин!");
            }
        }

        private void btAuto_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == login)
            {
                if (tbPassword.Password == pass)
                {
                    Random rnd = new Random();
                    code = rnd.Next(10000, 50000).ToString();
                    MessageBox.Show(code + "\nЗапомните пожалуйста код", "Код");
                    WindowCode windowCode = new WindowCode(code);
                    windowCode.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неправильный пароль!");
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин!");
            }
        }
        string str = "";
        int i;
        void Captcha()
        {
            Random random = new Random();
            int k = random.Next(7, 11); //рандомное кол-во линий
            for (int i = 0; i < k; i++)
            {
                SolidColorBrush solidColor = new SolidColorBrush(Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)));
                Line l = new Line()
                {
                    X1 = random.Next(Convert.ToInt32(CCaptcha.Width)),
                    Y1 = random.Next(Convert.ToInt32(CCaptcha.Height)),
                    X2 = random.Next(Convert.ToInt32(CCaptcha.Width)),
                    Y2 = random.Next(Convert.ToInt32(CCaptcha.Height)),
                    Stroke = solidColor
                };
                CCaptcha.Children.Add(l);
            }
            char[] symbol = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            int x1 = 0;
            int x2 = Convert.ToInt32(CCaptcha.Width / k) - 20;
            for (int i = 0; i < k; i++)
            {
                int position = random.Next(3);
                TextBlock textBlock = new TextBlock()
                {
                    Text = symbol.ToString(),
                    Padding = new Thickness(random.Next(x1, x2), random.Next(Convert.ToInt32(CCaptcha.Height)) / 2, 0, 0),
                    FontSize = random.Next(20, 28),
                    FontFamily = new FontFamily("Calibri")
                };
                switch (position)
                {
                    case 0:
                        textBlock.FontStyle = FontStyles.Italic;
                        break;
                    case 1:
                        textBlock.FontWeight = FontWeights.Bold;
                        break;
                    case 2:
                        textBlock.FontStyle = FontStyles.Italic;
                        textBlock.FontWeight = FontWeights.Bold;
                        break;
                }
                CCaptcha.Children.Add(textBlock);
            }            
        }

        private void tbCaptcha_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbCaptcha.Text.Length == str.Length)
            {
                if (tbCaptcha.Text == str)
                {
                    MessageBox.Show("Все успешно!");
                    Close();
                }
                else
                {
                    if(i == 1)
                    {
                        MessageBox.Show("Captcha введена неправильно!\nПовторите вход", "Ошибка");
                        tbCaptcha.Text = "";
                        CCaptcha.Children.Clear();
                        str = "";
                        Captcha();
                    }
                    else
                    {
                        MessageBox.Show("Лимит исчерпан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        Close();
                    }
                }
            }         
        }
    }
}
