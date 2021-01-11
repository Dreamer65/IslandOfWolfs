using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Polynomial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Polynom p1, p2;

        readonly string variableNamePatern = @"При {0} =";
        readonly string coefPatern = @"= {0}";

        private void tbVarVal_TextChanged(object sender, EventArgs e)
        {
            if (p1 == null) return;
            if (!double.TryParse(tbVarVal.Text, out double variable))
            {
                lbValue.Text = "";
            }
            else
            {
                lbValue.Text = p1.Value(variable).ToString();
            }

        }

        private void pbSum_Click(object sender, EventArgs e)
        {
            if (p1 == null || p2 == null) return;

            Polynom result = p1 + p2;

            lbResultPolynom.Text = result.ToString();
        }

        private void pbDiv_Click(object sender, EventArgs e)
        {
            if (p1 == null || p2 == null) return;

            Polynom result = p1 - p2;

            lbResultPolynom.Text = result.ToString();
        }

        private void pbMul_Click(object sender, EventArgs e)
        {
            if (p1 == null || p2 == null) return;

            Polynom result = p1 * p2;

            lbResultPolynom.Text = result.ToString();
        }

        private void tbA_TextChanged(object sender, EventArgs e)
        {
            if (p1 == null) return;
            if (!int.TryParse(tbA.Text, out int coef) || coef < 0)
            {
                lbAVal.Text = "=";
            }
            else
            {
                lbAVal.Text = string.Format(coefPatern, p1[coef]);
            }
        }

        private void pbNewPolynom_Click(object sender, EventArgs e)
        {
            Label destination = null;

            if (sender.Equals(pbNewPolynom1))
                destination = lbPolynom1;
            if (sender.Equals(pbNewPolynom2))
                destination = lbPolynom2;

            if (destination == null) return;

            List<double> coeficents = new List<double>();
            int count = 0;
            string str;
            do
            {
                str = Interaction.InputBox(string.Format("Введите коэфицент a{0}", count++), "Коефицент");
                if (str != "") coeficents.Add(double.Parse(str));

            } while (str != "");

            Polynom polynom = new Polynom(coeficents.ToArray());
            if (sender.Equals(pbNewPolynom1))
            {
                lbVariableName.Text = string.Format(variableNamePatern, polynom.Variable);
                p1 = polynom;
            }
            if (sender.Equals(pbNewPolynom2))
            {
                p2 = polynom;
            }

            destination.Text = polynom.ToString();

        }
    }
}
