using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {
        private string input = string.Empty;    // Current input
        private string operand1 = string.Empty; // First operand
        private string operand2 = string.Empty; // Second operand
        private char operation;                // Current operator
        private double result = 0.0;           // Calculation result

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            input += button.Content.ToString();
            ResultTextBox.Text = input;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (!string.IsNullOrEmpty(input))
            {
                operand1 = input;
                operation = Convert.ToChar(button.Content);
                input = string.Empty;
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(input))
            {
                operand2 = input;

                try
                {
                    switch (operation)
                    {
                        case '+':
                            result = Convert.ToDouble(operand1) + Convert.ToDouble(operand2);
                            break;
                        case '-':
                            result = Convert.ToDouble(operand1) - Convert.ToDouble(operand2);
                            break;
                        case '*':
                            result = Convert.ToDouble(operand1) * Convert.ToDouble(operand2);
                            break;
                        case '/':
                            if (Convert.ToDouble(operand2) != 0)
                                result = Convert.ToDouble(operand1) / Convert.ToDouble(operand2);
                            else
                                MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                    ResultTextBox.Text = result.ToString();
                    input = result.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            input = string.Empty;
            operand1 = string.Empty;
            operand2 = string.Empty;
            result = 0.0;
            ResultTextBox.Text = "0";
        }
    }
}
