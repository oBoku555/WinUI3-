// MainWindow.xaml.cs

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace FluentUI
{
    public sealed partial class MainWindow : Window
    {
        float firstNumber, secondNumber;
        int operators = -1;
        public MainWindow()
        {
            this.InitializeComponent();
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string number = button.Content.ToString();

            if (ResultTextBox.Text == "0")
            {
                ResultTextBox.Text = number;
            }
            else
            {
                ResultTextBox.Text += number;
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string op = button.Content.ToString(); // 獲取運算符 (+, −, ×, ÷)
            // 這裡可以加入您的邏輯來儲存當前值和運算符
            switch (op)
            {
                case "+":
                    firstNumber = Convert.ToSingle(ResultTextBox.Text); //將輸入文字框轉換成浮點數，存入第一個數字的全域變數
                    operators = 0; //選擇「加」號
                    break;
                case "−":
                    firstNumber = Convert.ToSingle(ResultTextBox.Text); //將輸入文字框轉換成浮點數，存入第一個數字的全域變數
                    operators = 1;
                    break;
                case "×":
                    firstNumber = Convert.ToSingle(ResultTextBox.Text); //將輸入文字框轉換成浮點數，存入第一個數字的全域變數
                    operators = 2;
                    break;
                case "÷":
                    firstNumber = Convert.ToSingle(ResultTextBox.Text); //將輸入文字框轉換成浮點數，存入第一個數字的全域變數                    operators = 3;
                    operators = 3;
                    break;
            }
            ResultTextBox.Text = "0"; //重新將輸入文字框重新設定為0
        }

        // 處理等號按鈕 (=) 的點擊事件
        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            float finalResults = 0f; //宣告最後計算結果變數
            secondNumber = Convert.ToSingle(ResultTextBox.Text); //將輸入文字框轉換成浮點數，存入第二個數字的全域變數

            //依照四則運算符號的選擇，進行加減乘除
            switch (operators)
            {
                case 0:
                    finalResults = firstNumber + secondNumber;
                    break;
                case 1:
                    finalResults = firstNumber - secondNumber;
                    break;
                case 2:
                    finalResults = firstNumber * secondNumber;
                    break;
                case 3:
                    finalResults = firstNumber / secondNumber;
                    break;
            }

            ResultTextBox.Text = string.Format("{0:0.##########}", finalResults); //在輸入文字框中，顯示最後計算結果，並且轉換成格式化的字串內容

            //重置所有全域變數
            firstNumber = 0f;
            secondNumber = 0f;
            operators = -1;
        }

        // 處理清除按鈕 (C) 的點擊事件
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "0"; // 重設顯示

            // 重設任何儲存的計算狀態
            firstNumber = 0f;
            secondNumber = 0f;
            operators = -1;
        }
    }
}