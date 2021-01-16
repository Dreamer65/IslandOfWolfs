using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxesAndChickens
{
    public partial class Form1 : Form
    {
        Map map;
        Bot bot;


        public Form1()
        {
            InitializeComponent();
            InitializeStyles();
            AddColumns(dgvMap, 7);
            AddRows(dgvMap, 7);
            NormilizeCells(dgvMap);

            map = new Map();
            map.MapChenged += Map_Chenged;
            PaintDataGrid(dgvMap, map);

            bot = new Bot(map);

        }

        DataGridViewCellStyle chickenStyle;
        DataGridViewCellStyle foxStyle;
        DataGridViewCellStyle noneStyle;
        DataGridViewCellStyle outOfMapStyle;
        private void InitializeStyles()
        {
            chickenStyle = new DataGridViewCellStyle();
            chickenStyle.BackColor = Color.Pink;
            chickenStyle.SelectionBackColor = Color.DeepPink;
            chickenStyle.ForeColor = Color.Pink;
            chickenStyle.SelectionForeColor = Color.DeepPink;

            foxStyle = new DataGridViewCellStyle();
            foxStyle.BackColor = Color.Orange;
            foxStyle.SelectionBackColor = Color.Orange;
            foxStyle.ForeColor = Color.Orange;
            foxStyle.SelectionForeColor = Color.Orange;

            noneStyle = new DataGridViewCellStyle();
            noneStyle.BackColor = Color.White;
            noneStyle.SelectionBackColor = Color.White;
            noneStyle.ForeColor = Color.White;
            noneStyle.SelectionForeColor = Color.White;

            outOfMapStyle = new DataGridViewCellStyle();
            outOfMapStyle.BackColor = SystemColors.AppWorkspace;
            outOfMapStyle.SelectionBackColor = SystemColors.AppWorkspace;
            outOfMapStyle.ForeColor = SystemColors.AppWorkspace;
            outOfMapStyle.SelectionForeColor = SystemColors.AppWorkspace;
        }

        void AddColumns(DataGridView dataGrid, int count)
        {
            while (count-- > 0)
            {
                dataGrid.Columns.Add("", "");
            }
        }

        void AddRows(DataGridView dataGrid, int count)
        {
            while (count-- > 0)
            {
                dataGrid.Rows.Add();
            }
        }

        void DelColumn(DataGridView dataGrid)
        {
            if (dataGrid.Columns.Count == 0) return;
            DataGridViewColumn column = dataGrid.Columns[dataGrid.Columns.Count - 1];
            dataGrid.Columns.Remove(column);
        }

        void DelRow(DataGridView dataGrid)
        {
            if (dataGrid.Rows.Count == 0) return;
            DataGridViewRow row = dataGrid.Rows[dataGrid.Rows.Count - 1];
            dataGrid.Rows.Remove(row);
        }

        void NormilizeCells(DataGridView dataGrid)
        {
            foreach (DataGridViewRow item in dataGrid.Rows)
            {
                item.Height = (dataGrid.Height) / dataGrid.Rows.Count;
            }

            foreach (DataGridViewColumn item in dataGrid.Columns)
            {
                item.Width = (dataGrid.Width) / dataGrid.Columns.Count;
            }
/*
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    if ((i < 2 && j < 2) || (i < 2 && j >= dataGrid.Columns.Count - 2) || (i >= dataGrid.Rows.Count - 2 && j < 2) ||
                        (i >= dataGrid.Rows.Count - 2 && j >= dataGrid.Columns.Count - 2))
                    {
                        dataGrid.Rows[i].Cells[j].Style = outOfMapStyle;
                    }

                }
            }*/
        }

        void Map_Chenged(object sender, EventArgs e)
        {
            PaintDataGrid(dgvMap, (Map)sender);
            //bot.Step();
        }

        void BotStep()
        {
            Task.Run(() => bot.Step());
            
        }

        void PaintDataGrid(DataGridView dataGrid, Map map)
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    if (map[i, j] == null)
                    {
                        dataGrid.Rows[i].Cells[j].Style = outOfMapStyle;
                        continue;
                    }
                    else if (map[i, j].Visitor == CellVisitor.Chicken)
                    {
                        dataGrid.Rows[i].Cells[j].Style = chickenStyle;
                        continue;
                    }
                    else if (map[i, j].Visitor == CellVisitor.Fox)
                    {
                        dataGrid.Rows[i].Cells[j].Style = foxStyle;
                        continue;
                    }
                    else if (map[i, j].Visitor == CellVisitor.None)
                    {
                        dataGrid.Rows[i].Cells[j].Style = noneStyle;
                        continue;
                    }
                }
            }
        }

        Cell current = null;
        DataGridViewCell selectedCell;

        private void dgvMap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(map[e.RowIndex, e.ColumnIndex]?.Visitor == CellVisitor.Fox)
            {
                current = null;
                dgvMap.ClearSelection();
                selectedCell = null;
                return;
            }

            if(current == null)
            {
                current = map[e.RowIndex, e.ColumnIndex];
                selectedCell = dgvMap.CurrentCell;
                return;
            }


            if (current == map[e.RowIndex, e.ColumnIndex])
            {
                current = null;
                dgvMap.ClearSelection();
                selectedCell = null;
                return;
            }

            if (map[e.RowIndex, e.ColumnIndex] == current.Top)
            {
                if (map.MoveUp(current))
                {
                    dgvMap.ClearSelection();
                    selectedCell = null;
                    current = null;
                    BotStep();
                    return;
                }
                dgvMap.CurrentCell = selectedCell;
                return;
            }
            else if (map[e.RowIndex, e.ColumnIndex] == current.Bottom)
            {
                if (map.MoveDown(current))
                {
                    dgvMap.ClearSelection();
                    selectedCell = null;
                    current = null;
                    BotStep();
                    return;
                }
                dgvMap.CurrentCell = selectedCell;
                return;
            }
            else if (map[e.RowIndex, e.ColumnIndex] == current.Left)
            {
                if (map.MoveLeft(current))
                {
                    dgvMap.ClearSelection();
                    selectedCell = null;
                    current = null;
                    BotStep();
                    return;
                }
                dgvMap.CurrentCell = selectedCell;
                return;
            }
            else if (map[e.RowIndex, e.ColumnIndex] == current.Right)
            {
                if (map.MoveRight(current))
                {
                    dgvMap.ClearSelection();
                    selectedCell = null;
                    current = null;
                    BotStep();
                    return;
                }
                dgvMap.CurrentCell = selectedCell;
                return;
            }

            dgvMap.ClearSelection();
            selectedCell = null;
            current = null;
        }
    }
}
