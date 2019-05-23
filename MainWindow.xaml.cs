/*
 * Conner Warboys
 * May 23rd, 2019
 * Math Tutor 
 * ICS3U
 */
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

namespace u5MathTutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        double x = 0;
        double y = 0;
        string sign = "";
        double counter = 0;
        public MainWindow()
        {
            InitializeComponent();

            NewQuestion();
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (counter == 0)
            {
                string Input = UserInput.Text;
                double UserAnswer = 0;
                double.TryParse(Input, out UserAnswer);

                double Answer = 0;
                if (sign == "/")
                {
                    Answer = x / y;
                }
                else if (sign == "*")
                {
                    Answer = x * y;
                }
                else if (sign == "+")
                {
                    Answer = x + y;
                }
                else if (sign == "-")
                {
                    Answer = x - y;
                }

                if (UserAnswer == Answer)
                {
                    lblRevealAnswer.Content = "You're Answer is Correct!";
                }
                else
                {
                    lblRevealAnswer.Content = "You're Answer Is Incorrect :(" + Environment.NewLine + "Correct Answer: " + Answer;
                }
                btnCheck.Content = "Next Question";
                counter++;
            }

            else
            {
                NewQuestion();
                lblRevealAnswer.Content = "";
                btnCheck.Content = "Check Answer";
                counter = 0;
            }
        }
            public void NewQuestion()
            {
                sign = Operator(sign);
                string Question = "";
                x = random.Next(1, 11);
                y = random.Next(1, 11);
                Question = x + " " + sign + " " + y;
                lblQuestion.Content = Question;
            }
            public string Operator(string sign)
            {
                int SignNumber = random.Next(1, 5);

                if (SignNumber == 1)
                {
                    sign = "+";
                    return sign;
                }

                else if (SignNumber == 2)
                {
                    sign = "-";
                    return sign;
                }

                else if (SignNumber == 3)
                {
                    sign = "*";
                    return sign;
                }
                else
                {
                    sign = "/";
                    return sign;
                }
            }

        }
    }

