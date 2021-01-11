using System;
using System.Collections.Generic;

namespace Polynomial
{
    class Polynom
    {
        private double[] _coeficents;
        public Polynom(params double[] coeficents) : this("x", coeficents) { }

        public Polynom(string variable, params double[] coeficents)
        {
            Variable = variable;

            int length = coeficents.Length;

            for (int i = coeficents.Length - 1; i >= 0; i--)
            {
                if (coeficents[i] != 0) break;
                length--;
            }

            if (length == 0)
                _coeficents = new double[] { 0 };
            else
            {
                _coeficents = new double[coeficents.Length];
                coeficents.CopyTo(_coeficents, 0);
            }
        }

        public string Variable { get; set; }

        public int Degree { get => _coeficents.Length - 1; }

        public double Value(double variable)
        {
            double result = this[0];

            for (int i = 1; i < _coeficents.Length; i++)
            {
                result += this[i] * Math.Pow(variable, i);
            }

            return result;
        }

        public double this[int index]
        {
            get
            {
                if (index >= _coeficents.Length) return 0;
                return _coeficents[index];
            }
        }

        public static Polynom operator +(Polynom p1, Polynom p2)
        {
            int length = Math.Max(p1.Degree, p2.Degree) + 1;
            List<double> coeficents = new List<double>();

            for (int i = 0; i < length; i++)
            {
                double c1 = (p1.Degree >= i) ? p1[i] : 0;
                double c2 = (p2.Degree >= i) ? p2[i] : 0;

                coeficents.Add(c1 + c2);
            }
            return new Polynom(coeficents.ToArray());
        }

        public static Polynom operator -(Polynom p1, Polynom p2)
        {
            int length = Math.Max(p1.Degree, p2.Degree) + 1;
            List<double> coeficents = new List<double>();

            for (int i = 0; i < length; i++)
            {
                double c1 = (p1.Degree >= i) ? p1[i] : 0;
                double c2 = (p2.Degree >= i) ? p2[i] : 0;

                coeficents.Add(c1 - c2);
            }
            return new Polynom(coeficents.ToArray());
        }

        public static Polynom operator *(Polynom p1, Polynom p2)
        {
            if (p2.Degree > p1.Degree)
            {
                Polynom tmp = p1;
                p1 = p2;
                p2 = tmp;
            }

            double[] coeficents = new double[p1.Degree + p2.Degree + 2];

            for (int i = 0; i <= p1.Degree; i++)
            {
                for (int j = 0; j <= p2.Degree; j++)
                {
                    coeficents[i + j] += p1[i] * p2[j];
                }
            }
            return new Polynom(coeficents);
        }

        public override string ToString()
        {
            string str = (_coeficents[0] == 0) ? "" : Math.Abs(_coeficents[0]).ToString();

            double prev = _coeficents[0];

            string sign, variable, coef;

            for (int i = 1; i < _coeficents.Length; i++)
            {
                if (_coeficents[i] == 0) continue;
                sign = (prev < 0) ? "-" : "+";
                sign = (prev == 0) ? "" : sign;
                prev = _coeficents[i];
                variable = (i == 1) ? Variable : Variable + "^" + i;
                coef = (Math.Abs(_coeficents[i]) == 1) ? "" : Math.Abs(_coeficents[i]).ToString();
                str =  coef + variable + sign + str;
            }
            sign = (_coeficents[_coeficents.Length - 1] < 0) ? "-" : "";
            return (str == "") ? "0" : sign + str;
        }
    }
}
