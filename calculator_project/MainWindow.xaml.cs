﻿using System;
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

namespace calculator_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        long first;
        long second;
        long result;
        bool finished = false;
        Operations operation = Operations.none;

        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private enum Operations
        {
            none,
            divide,
            multiply,
            minus,
            plus
        }

        public void btn_number(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (finished)
            {
                history.Text = button.Content.ToString();
                finished = false;
            }
            else if (history.Text == "")
            {
                history.Text = button.Content.ToString();
            }
            else
            {
                history.Text = history.Text + button.Content.ToString();
            }
        }

        public void btn_operator(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Content.ToString())
            {
                case "CE":
                    history.Text = string.Empty;
                    break;
                case "x":
                    first = Convert.ToInt64(history.Text);
                    operation = Operations.multiply;
                    history.Text = string.Empty;
                    break;
                case "÷":
                    first = Convert.ToInt64(history.Text);
                    operation = Operations.divide;
                    history.Text = string.Empty;
                    break;
                case "+":
                    first = Convert.ToInt64(history.Text);
                    operation = Operations.plus;
                    history.Text = string.Empty;
                    break;
                case "-":
                    first = Convert.ToInt64(history.Text);
                    operation = Operations.minus;
                    history.Text = string.Empty;
                    break;
                case "=":
                    switch (operation)
                    {
                        case Operations.multiply:
                            if (finished)
                            {
                                /*
                                 * Convert.ToInt64(history.Text)
                                 * history.Text *= second
                                 */
                                // NOT WORKING
                            }
                            else
                            {
                                second = Convert.ToInt64(history.Text);
                                result = first * second;
                                history.Text = Convert.ToString(result);
                                finished = true;
                            }
                            break;
                        case Operations.divide:
                            if (finished)
                            {
                                // same thing as above / second
                            }
                            else
                            {
                                second = Convert.ToInt64(history.Text);
                                result = first / second;
                                history.Text = Convert.ToString(result);
                                finished = true;
                            }
                            break;
                        case Operations.plus:
                            {
                                if (finished)
                                {
                                    // same thing as above + second
                                }
                                else
                                {
                                    second = Convert.ToInt64(history.Text);
                                    result = first + second;
                                    history.Text = Convert.ToString(result);
                                    finished = true;
                                }
                            }
                            break;
                        case Operations.minus:
                            {
                                if (finished)
                                {
                                    // same thing as above - second
                                }
                                else
                                {
                                    second = Convert.ToInt64(history.Text);
                                    result = first - second;
                                    history.Text = Convert.ToString(result);
                                    finished = true;
                                }
                            }
                            break;
                    }
                    break;

            }
        }
    }
}
