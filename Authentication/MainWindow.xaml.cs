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
        DispatcherTimer timer = new DispatcherTimer();
        int time = 10;
        public MainWindow(int k)
        {
            InitializeComponent();

            switch (k)
            {
                case 0:
                    break;
                case 1:
                    btAuto.IsEnabled = false;
                    tbNewCode.Visibility = Visibility.Visible;
                    timer.Interval = new TimeSpan(0, 0, 1); //свойство, запускающее таймер на 10 сек
                    timer.Tick += new EventHandler(Timer_tick);
                    timer.Start();
                    break;
                case 2:
                    btAuto.IsEnabled = false;
                    tbNewCode.Visibility = Visibility.Collapsed;

                    break;
            }

        }

        private void Timer_tick(object sender, EventArgs e) //обработчик события для истекающего таймера
        {
            time--;
            tbNewCode.Text = "Получить код можно через " + time + " секунд";
            if (time == 0)
            {
                btnNewCode.Visibility = Visibility.Visible;
                timer.Stop();
            }
        }

        private void btnNewCode_Click(object sender, RoutedEventArgs e)
        {
            if(tbLogin.Text == login)
            {
                if(tbPassword.Password == pass)
                {
                    Random rnd = new Random();
                    int code = rnd.Next(10000, 50000);
                    MessageBox.Show(code.ToString() + "\nЗапомните пожалуйста код", "Код");
                    //WindowCode windowCode = new WindowCode(kod);
                    //windowCode.ShowDialog();
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
                    int code = rnd.Next(10000, 50000);
                    MessageBox.Show(code.ToString() + "\nЗапомните пожалуйста код", "Код");
                    //WindowCode windowCode = new WindowCode(kod);
                    //windowCode.ShowDialog();
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
