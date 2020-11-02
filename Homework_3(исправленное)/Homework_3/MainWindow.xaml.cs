using System.Linq;
using System.Windows;

namespace HomeWork_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }       
        void function_for_cipher(bool flag)
        {
            int number = 0;
            string text = "";
            bool check = false;
            if (flag == true)
            {
                text = tb_1.Text;
            }
            else
            {
                text = tb_2.Text;
            }
            check = int.TryParse(text, out number);
            if (check == false)
            {
                bool check_reg = false;

                string lower_text = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                string high_text = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                string punc = ",.!? ";

                var mas_lower = lower_text.ToArray();
                var mas_high = high_text.ToArray();
                 var mas_punc= punc.ToArray();

                var st_text = text.ToArray();

                var fine_text = "";
                var mas_text = fine_text.ToArray();

                char[] new_text = new char[st_text.Length];

                for (char ch_reg = high_text[0]; ch_reg <= high_text[32]; ch_reg++)
                {
                    if (st_text[0] == ch_reg)
                    {
                        check_reg = true;
                    }
                }
                for (int i = 0; i < text.Length; i++)
                {

                    if (check_reg == false)
                    {
                        fine_text = lower_text;
                        mas_text = mas_lower;
                    }

                    else if (check_reg == true)
                    {
                        fine_text = high_text;
                        mas_text = mas_high;
                        check_reg = false;
                    }

                    //------------------------------------------------------------------------
                    {
                        if (flag == true)
                        {
                            for (int j = 0; j < fine_text.Length; j++)
                            {
                                if (st_text[i] == mas_text[j])
                                {
                                    int num_mas = 32 - j;
                                    new_text[i] = fine_text[num_mas];
                                }
                                else if (j <= 4)
                                {
                                    if (st_text[i] == mas_punc[j])
                                    {
                                        new_text[i] = st_text[i];
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = (fine_text.Length) - 1; j >= 0; j--)
                            {
                                if (st_text[i] == fine_text[j])
                                {
                                    int num_mas = 32 - j;
                                    new_text[i] = fine_text[num_mas];
                                }
                                else if (j <= 3)
                                {
                                    if (st_text[i] == mas_punc[j])
                                    {
                                        new_text[i] = st_text[i];
                                    }
                                }
                            }
                        }
                    }



                }
                string new_Text = "";
                for (int i = 0; i < text.Length; i++)
                {
                    new_Text += new_text[i];
                }
                if (flag == true)
                    tb_result_1.Text = new_Text;
                else
                    tb_result_2.Text = new_Text;
            }
            
            else
                MessageBox.Show("Вы ввели число");
        }

        private void bt_1_Click(object sender, RoutedEventArgs e)
        {
            if (tb_1.Text == "")
            {
                MessageBox.Show("Введите текст для шифровки!");
            }
            else
            {
                bool flag = true;
                function_for_cipher(flag);
            }
        }
        private void bt_2_Click(object sender, RoutedEventArgs e)
        {
            if (tb_2.Text == "")
            {
                MessageBox.Show("Введите текст для расшифровки!");
            }
            else
            {
                bool flag = false;
                function_for_cipher(flag);
            }
        }

    }
}