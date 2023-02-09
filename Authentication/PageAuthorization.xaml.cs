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
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {

        int time = 60;
        DispatcherTimer timer = new DispatcherTimer();
        public PageAuthorization(int index)
        {
            InitializeComponent();
            switch (index)
            {
                case 0:
                    break;
                case 1:
                    btAuto.IsEnabled = false;
                    tbLogin.IsEnabled = false;
                    tbPassword.IsEnabled = false;
                    spCode.Visibility = Visibility.Visible;                    
                    timer.Interval = new TimeSpan(0, 0, 1);
                    timer.Tick += new EventHandler(Timer_tick);
                    timer.Start();
                    break;
                case 2:
                    btAuto.IsEnabled = false;                    
                    spCode.Visibility = Visibility.Collapsed;
                    WindowCaptcha captcha = new WindowCaptcha(1);
                    captcha.Show();
                    break;
                case 3:
                    btAuto.IsEnabled = false;                   
                    spCode.Visibility = Visibility.Collapsed;
                    WindowCaptcha captcha2 = new WindowCaptcha(2);
                    captcha2.Show();
                    break;
            }
        }
        private void Timer_tick(object sender, EventArgs e) //обработчик события для истекающего таймера
        {
            time--;
            tbTime.Text = "Получить новый код можно через " + time.ToString() + " секунд";
            if (time == 0)
            {
                btnNewCode.Visibility = Visibility.Visible;
                timer.Stop();

            }
        }

        string code = "";
        private void btnNewCode_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "" || tbPassword.Password == "")
            {
                MessageBox.Show("Заполните поля!");
            }
            else
            {
                if (tbLogin.Text == "admin" && tbPassword.Password == "admin")
                {
                    Random rnd = new Random();
                    code = rnd.Next(10000, 50000).ToString();
                    MessageBox.Show(code + "\nЗапомните пожалуйста код", "Код");
                    WindowCode windowCode = new WindowCode(code, 1);
                    windowCode.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
        }

        private void btAuto_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "" || tbPassword.Password == "")
            {
                MessageBox.Show("Заполните поля!");
            }
            else
            {
                if (tbLogin.Text == "admin" && tbPassword.Password == "admin")
                {
                    Random rnd = new Random();
                    code = rnd.Next(10000, 50000).ToString();
                    MessageBox.Show(code + "\nЗапомните пожалуйста код", "Код");
                    WindowCode windowCode = new WindowCode(code, 1);
                    windowCode.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
        }

    }
}
