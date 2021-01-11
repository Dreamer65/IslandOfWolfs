using System.Windows.Forms;

namespace Matimatico
{
    public partial class Form1 : Form
    {
        Game game;
        int currentCard;
        int cardCount;
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridViev(dgvHuman);
            InitializeDataGridViev(dgvComputer);
        }

        private void InitializeDataGridViev(DataGridView dataGrid)
        {
            AddColumns(dataGrid, 5);
            AddRows(dataGrid, 5);
            NormilizeCells(dataGrid);
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
        }
        private void CleareDataGridViev(DataGridView dataGrid)
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    dataGrid.Rows[i].Cells[j].Value = null;
                }
            }
        }

        private int[,] ReadDataGridViev(DataGridView dataGrid)
        {
            int[,] result = new int[dataGrid.Rows.Count, dataGrid.Columns.Count];

            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    result[i, j] = int.Parse(dataGrid.Rows[i].Cells[j].Value.ToString());
                }
            }

            return result;
        }

        private void dgvHuman_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).ClearSelection();
            if(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                MessageBox.Show("Ячейка уже занята.");
                return;
            }

            ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value = currentCard;

            currentCard = game.NextCard();
            lbCurrentCard.Text = currentCard.ToString();
            cardCount++;

            if (cardCount == 25) CalculateResults();
        }

        private void pbNewGame_Click(object sender, System.EventArgs e)
        {
            game = new Game();
            currentCard = game.NextCard();
            lbCurrentCard.Text = currentCard.ToString();
            cardCount = 0;
            CleareDataGridViev(dgvHuman);
        }

        private void CalculateResults()
        {
            int[,] mass = ReadDataGridViev(dgvHuman);
            MessageBox.Show(string.Format("Результат: {0}", Game.CountResult(mass)));
        }
    }
}
