using System;
using System.Collections.Generic;

namespace Matimatico
{
    class Game
    {

        public Game()
        {
            deck = new List<int>();
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    deck.Add(i);
                }
            }

            random = new Random();
        }

        private Random random;
        private List<int> deck;

        public int NextCard()
        {
            int card = deck[random.Next(deck.Count - 1)];
            deck.Remove(card);
            return card;
        }

        public static int CountResult(int[,] field)
        {
            int[] keep = new int[5];

            int result = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    keep[j] = field[j, i];
                }
                result += Analyzer(keep);

            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    keep[j] = field[i, j];
                }
                result += Analyzer(keep);
            }

            for (int i = 0; i < 5; i++)
            {
                keep[i] = field[i, i];
            }

            result += (Analyzer(keep) == 0) ? 0 : Analyzer(keep) + 10;

            return result;
        }

        private static int Analyzer(int[] Mass)
        {
            int col = 0;
            if (Two_Sim(Mass)[0] == 0)
            {
                if (Fol_Num(Mass)[0] == 0) return col;
                else
                {
                    if (Fol_Num(Mass).Length == 1) col = 50;
                    else
                    {
                        if (Combo(Mass) == true) col = 150;
                        else return col;
                    }
                }
            }
            else
            {
                if (Thr_Sim(Mass)[0] == 0)
                {
                    if (Two_Pairs(Mass)[0] == 1) col = 20;
                    else col = 10;
                }
                else
                {
                    if (Four_Sim(Mass)[0] == 0)
                    {
                        if (Two_Pairs(Mass)[0] == 1)
                        {
                            if (Check_comb(Mass) == true) col = 100;
                            else col = 80;
                        }
                        else col = 40;
                    }
                    else
                    {
                        if (Four_Fir(Mass) == true) col = 200;
                        else col = 160;
                    }
                }
            }
            return col;
        }

        private static int[] Two_Sim(int[] Mass)//2 одинаковых числа
        {
            int count = 1;
            int temp = 0;
            for (int i = 0; i < Mass.Length; i++)
            {
                temp = Mass[i];
                for (int j = i + 1; j < Mass.Length; j++)
                {
                    if (temp == Mass[j]) count++;
                    if (count == 2)
                    {
                        int[] Res = { 1, temp, i, j };
                        return Res;
                    }
                }
            }
            int[] Res1 = { 0 };
            return Res1;

        }
        private static int[] Thr_Sim(int[] Mass)//3 одинаковых числа
        {
            int[] Temp_Mass = Two_Sim(Mass);
            for (int i = 0; i < Mass.Length; i++)
            {
                if ((i != Temp_Mass[2]) && (i != Temp_Mass[3]) && (Mass[i] == Temp_Mass[1]))
                {
                    int[] Res = { 1, Two_Sim(Mass)[1], i };
                    return Res;
                }
            }
            int[] Res1 = { 0 };
            return Res1;
        }
        private static int[] Four_Sim(int[] Mass)//4 одинаковых числа
        {
            int[] Temp_Mass = Two_Sim(Mass);
            int[] Temp_Mass1 = Thr_Sim(Mass);
            for (int i = 0; i < Mass.Length; i++)
            {
                if ((i != Temp_Mass1[2]) && (i != Temp_Mass[3]) && (i != Temp_Mass[2]) && (Mass[i] == Temp_Mass1[1]))
                {
                    int[] Res = { 1, Temp_Mass1[1] };
                    return Res;
                }
            }
            int[] Res1 = { 0 };
            return Res1;
        }
        private static bool Four_Fir(int[] Mass)//4 единицы
        {
            int[] Temp_Mass = Four_Sim(Mass);
            if (Temp_Mass[1] == 1) return true;
            else return false;
        }
        private static int[] Two_Pairs(int[] Mass)//две пары одинаковых чисел
        {
            int[] Temp_Mass = Two_Sim(Mass);
            int count = 1;
            int temp = 0;
            for (int i = 0; i < Mass.Length; i++)
            {
                if ((i != Temp_Mass[2]) && (i != Temp_Mass[3]) && (Mass[i] != Temp_Mass[1]))
                {
                    temp = Mass[i];
                    for (int j = i + 1; j < Mass.Length; j++)
                    {
                        if ((j != Temp_Mass[3]) && (temp == Mass[j])) count++;
                        if (count == 2)
                        {
                            int[] Res = { 1, temp, i, j };
                            return Res;
                        }
                    }
                }
            }
            int[] Res1 = { 0 };
            return Res1;
        }
        private static bool Check_comb(int[] Mass)//3 единички и две 13
        {
            int[] Temp_Mass = Thr_Sim(Mass);
            int[] Temp_Mass1 = Two_Pairs(Mass);
            if ((Temp_Mass[1] == 1) && (Temp_Mass1[1] == 13)) return true;
            else return false;
        }
        public static int[] Fol_Num(int[] Mass)//последовательные
        {
            Array.Sort(Mass);
            int count = 0;
            for (int i = 0; i < Mass.Length - 1; i++)
            {
                if (Math.Abs(Mass[i] - Mass[i + 1]) == 1) count++;
            }
            if (count == 4)
            {
                int[] Res = { 1 };
                return Res;
            }
            if (count == 3)
            {
                int[] Res1 = Mass;
                return Res1;
            }
            else
            {
                int[] Res2 = { 0 };
                return Res2;
            }
        }

        private static bool Combo(int[] Mass)//1+13+12+11+10
        {
            int[] Temp_Mass = Fol_Num(Mass);
            if ((Temp_Mass[0] == 1) && (Temp_Mass[1] == 10)) return true;
            else return false;
        }
    }
}
