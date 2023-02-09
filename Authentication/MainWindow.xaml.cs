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

        void Captcha()
        {
            //Random random = new Random();
            //Line l = new Line()
            //{
            //    X1 = random.Next(Convert.ToInt32(CCaptcha.Width),
            //    Y1 = random.Next(Convert.ToInt32(CCaptcha.Width)),
            //    X2 = random.Next(Convert.ToInt32(CCaptcha.Height)),
            //    Y2 = random.Next(Convert.ToInt32(CCaptcha.Height)),
            //    Stroke = Brushes.Black,
            //};
            //CCaptcha.Children.Add(l);
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
    }
}
