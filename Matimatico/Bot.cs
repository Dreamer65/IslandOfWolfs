using System;
using System.Collections.Generic;

namespace Matimatico
{
    public class Bot
    {
        readonly List<int> diag_Comb;
        readonly List<int> foll_Fir;
        readonly List<int> keeper;
        int count;
        Random random;
        readonly int[,] Table;
        public Bot()
        {
            diag_Comb = new List<int> { 1, 10, 11, 12, 13 };
            foll_Fir = new List<int> { 2, 3, 4, 5 };
            keeper = new List<int> { };
            count = 25;

            Table = new int[5, 5];
            random = new Random();

        }

        public event EventHandler<BotTurnDoneEventArgs> TurnDone;

        public bool Check_Main(int num)
        {
            bool result = false;
            if (diag_Comb.Contains(num))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (Table[i, i] == num)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public void Step(int num)
        {
            if (keeper.Contains(num))
            {
                int k_i, k_j;
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (Table[i, j] == num)
                        {
                            k_i = i;
                            k_j = j;
                            for (int k = 1; k < 5; k++)
                            {
                                if (Table[k, k_j] == 0 && (k != k_j) && (k != 0))
                                {
                                    Table[k, k_j] = num;
                                    keeper.Add(num);
                                    count--;

                                    TurnDone?.Invoke(this, new BotTurnDoneEventArgs(k, k_j, num));
                                    return;
                                }
                            }
                            for (int l = 0; l < 5; l++)
                            {
                                if (Table[k_i, l] == 0 && (l != k_i) && (k_i != 0))
                                {
                                    Table[k_i, l] = num;
                                    keeper.Add(num);
                                    count--;

                                    TurnDone?.Invoke(this, new BotTurnDoneEventArgs(k_i, l, num));
                                    return;
                                }
                            }


                        }
                    }
                Random_Cell(num);
            }
            if (!Check_One(num) && (Check_Main(num)) && (!keeper.Contains(num)))
            {
                for (int i = 1; i < 5; i++)
                {
                    if (Table[i, i] == 0)
                    {
                        Table[i, i] = num;
                        keeper.Add(num);
                        count--;

                        TurnDone?.Invoke(this, new BotTurnDoneEventArgs(i, i, num));
                        break;
                    }
                }
            }
            if (Check_Fol(num) && (!keeper.Contains(num)))
            {
                for (int i = 1; i < 5; i++)
                {
                    if (Table[0, i] == 0)
                    {
                        Table[0, i] = num;
                        keeper.Add(num);
                        count--;

                        TurnDone?.Invoke(this, new BotTurnDoneEventArgs(0, i, num));
                        break;
                    }
                }
            }
            if (Check_One(num))
            {
                if (!keeper.Contains(num))
                {
                    Table[0, 0] = 1;
                    keeper.Add(num);
                    count--;

                    TurnDone?.Invoke(this, new BotTurnDoneEventArgs(0, 0, num));
                }

            }

            if ((!keeper.Contains(num) && (!foll_Fir.Contains(num)) && (!diag_Comb.Contains(num))))
            {
                Random_Cell(num);
                keeper.Add(num);
                count--;
            }

        }
        private bool Check_One(int num)
        {
            return (num == 1);
        }
        private bool Check_Fol(int num)
        {
            bool Res = false;
            if (foll_Fir.Contains(num))
                for (int i = 1; i < 5; i++)
                {
                    if (Table[0, i] == num)
                    {
                        Res = false;
                    }
                    else
                    {
                        Res = true;
                    }
                }
            return Res;
        }

        private void Random_Cell(int num)
        {
            int i, j;
            int[] mass = new int[2];
            if (count > 1)
            {
                do
                {
                    i = random.Next(1, 5);
                    j = random.Next(0, 5);
                }
                while ((i == 0 || i == j) || Table[i, j] != 0);
            }
            else
                do
                {
                    i = random.Next(0, 5);
                    j = random.Next(0, 5);
                }
                while (Table[i, j] != 0);
            Table[i, j] = num;
            keeper.Add(num);
            count--;

            TurnDone?.Invoke(this, new BotTurnDoneEventArgs(i, j, num));
        }
    }

    public class BotTurnDoneEventArgs : EventArgs
    {
        public BotTurnDoneEventArgs(int row, int column, int value)
        {
            Value = value;
            RowIndex = row;
            ColumnIndex = column;
        }

        public int Value { get; }

        public int RowIndex { get; }

        public int ColumnIndex { get; }
    }
}
