using System;
using System.Drawing;
using System.Windows.Forms;

namespace IslandOfWolfs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeStyles();
        }

        Island island;
        DataGridViewCellStyle rabitStyle;
        DataGridViewCellStyle MWolfStyle;
        DataGridViewCellStyle FWolfStyle;
        DataGridViewCellStyle MultyStyle;
        private void InitializeStyles()
        {
            rabitStyle = new DataGridViewCellStyle();
            rabitStyle.BackColor = Color.Green;
            rabitStyle.SelectionBackColor = Color.Green;
            rabitStyle.ForeColor = Color.White;
            rabitStyle.SelectionForeColor = Color.White;

            MWolfStyle = new DataGridViewCellStyle();
            MWolfStyle.BackColor = Color.Blue;
            MWolfStyle.SelectionBackColor = Color.Blue;
            MWolfStyle.ForeColor = Color.White;
            MWolfStyle.SelectionForeColor = Color.White;

            FWolfStyle = new DataGridViewCellStyle();
            FWolfStyle.BackColor = Color.Red;
            FWolfStyle.SelectionBackColor = Color.Red;
            FWolfStyle.ForeColor = Color.White;
            FWolfStyle.SelectionForeColor = Color.White;
            
            MultyStyle = new DataGridViewCellStyle();
            MultyStyle.BackColor = Color.Brown;
            MultyStyle.SelectionBackColor = Color.Brown;
            MultyStyle.ForeColor = Color.White;
            MultyStyle.SelectionForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            island = new Island(20, 20, 5, 3, 4);
            island.RabitsWin += rabits_Win;
            island.WolfsWin += wolfs_Win;
            /* island[0, 0].AddAnimal(new Rabit(island[0, 0]));
             island[4, 5].AddAnimal(new Rabit(island[4, 5]));
             island[3, 6].AddAnimal(new Rabit(island[3, 6]));

             island[1, 1].AddAnimal(new MWolf(island[1, 1]));
             island[6, 5].AddAnimal(new FWolf(island[6, 5]));
             island[3, 6].AddAnimal(new FWolf(island[3, 6]));*/

            DrawIsland(dgvIsland, island);
        }

        private void DrawIsland(DataGridView dataGrid, Island island)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();

            int totalWidth = 0;
            int totalHeight = 0;

            for (int i = 0; i < island.Width; i++)
            {
                dataGrid.Columns.Add("", "");
                dataGrid.Columns[i].Width = (dataGrid.Width - totalWidth - 3) / (island.Width - i);
                totalWidth += dataGrid.Columns[i].Width;
            }

            for (int i = 0; i < island.Height; i++)
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Height = (dataGrid.Height - totalHeight - 3) / (island.Height - i);
                totalHeight += dataGrid.Rows[i].Height;
                for (int j = 0; j < island.Width; j++)
                {
                    dataGrid.Rows[i].Cells[j].Value = island[j, i];
                    if (island[j, i].Owner == AnimalType.Rabit)
                    {
                        dataGrid.Rows[i].Cells[j].Style = rabitStyle;
                    }
                    else if (island[j, i].Owner == AnimalType.FWolf)
                    {
                        dataGrid.Rows[i].Cells[j].Style = FWolfStyle;
                    }
                    else if (island[j, i].Owner == AnimalType.MWolf)
                    {
                        dataGrid.Rows[i].Cells[j].Style = MWolfStyle;
                    }
                    else if (island[j, i].Owner == AnimalType.Multy)
                    {
                        dataGrid.Rows[i].Cells[j].Style = MultyStyle;
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            island.Step();
            DrawIsland(dgvIsland, island);
        }

        private void rabits_Win(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            MessageBox.Show("Победили кролики");
        }

        private void wolfs_Win(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            MessageBox.Show("Победили волки");
        }
    }

}
