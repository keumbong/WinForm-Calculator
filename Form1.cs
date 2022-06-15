using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
        }

        public double result = 0;   //결과값
        public bool operandPerformed = false;   //연산자 사용 확인 변수
        public string operand = ""; //연산자를 저장할 변수
        
        private void NumBtn_Click(object sender, System.EventArgs e) //숫자 버튼 클릭 이벤트
        {
            if(resultBox.Text == "0" || operandPerformed) //결과창이 '0'이거나 연산자 미사용시 결과값 초기화
            {
                resultBox.Clear();
            }
            Button num_btn = (Button)sender;
            resultBox.Text += num_btn.Text;
            operandPerformed = false; //숫자 클릭 메소드라 다음에 올 연산자를 위해 'false'로 고정
                   
        }

        private void CalBnt_Click(object sender, EventArgs e) //연산 버튼 클릭 이벤트
        {
            operandPerformed = true; //연산 버튼이 클릭됐음을 확인
            Button cal_btn = (Button)sender;
            string operand_s = cal_btn.Text;
           

            processBox.Text = processBox.Text + " " + resultBox.Text + " " + operand_s;
          

            switch (operand)
            {
                case "+":
                    resultBox.Text = (result + Double.Parse(resultBox.Text)).ToString();
                    break;
                case "-":
                    resultBox.Text = (result - Double.Parse(resultBox.Text)).ToString();
                    break;
                case "*":
                    resultBox.Text = (result * Double.Parse(resultBox.Text)).ToString();
                    break;
                case "/":
                    resultBox.Text = (result / Double.Parse(resultBox.Text)).ToString();
                    break;
                default:
                    break;

            }

            result = Double.Parse(resultBox.Text);
            operand = operand_s;
          
        }

        private void btn_clear_Click(object sender, EventArgs e) //C button 클릭 이벤트(초기화)
        {
            result = 0;
            operandPerformed = false;
            operand = "";
            resultBox.Text = "0";
            processBox.Text = "";
            
        
        }

        private void btn_del_Click(object sender, EventArgs e) //del 최근에 쓴 문자 제거
        {
            if (resultBox.Text != "0" && operand != "=" && resultBox.Text.Length > 0)
            {
                resultBox.Text = resultBox.Text.Substring(0, resultBox.Text.Length - 1);
                processBox.Text = processBox.Text.Substring(0, processBox.Text.Length - 1);
            }
        }

        private void btn_dot_Click(object sender, EventArgs e) // 실수 계산을 위한 이벤트
        {
            if (!resultBox.Text.Contains("."))
            {
                resultBox.Text += ".";
            }
        }

        private void btn_equal_Click(object sender, EventArgs e) // 결과 값을 보기 위한 메서드
        {
            processBox.Text = "";
            operandPerformed = true;

            switch(operand)
            {
                case "+":
                    resultBox.Text = (result + Double.Parse(resultBox.Text)).ToString();
                    break;
                case "-":
                    resultBox.Text = (result - Double.Parse(resultBox.Text)).ToString();
                    break;
                case "*":
                    resultBox.Text = (result * Double.Parse(resultBox.Text)).ToString();
                    break;
                case "/":
                    resultBox.Text = (result / Double.Parse(resultBox.Text)).ToString();
                    break;

            }

            result = Double.Parse(resultBox.Text);
            resultBox.Text = result.ToString();
            result = 0;
            operand = "";
        }

        
    }
}
