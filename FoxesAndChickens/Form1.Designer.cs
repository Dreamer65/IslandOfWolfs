
namespace FoxesAndChickens
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMap = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMap
            // 
            this.dgvMap.AllowUserToAddRows = false;
            this.dgvMap.AllowUserToDeleteRows = false;
            this.dgvMap.AllowUserToResizeColumns = false;
            this.dgvMap.AllowUserToResizeRows = false;
            this.dgvMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMap.ColumnHeadersVisible = false;
            this.dgvMap.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMap.GridColor = System.Drawing.Color.Black;
            this.dgvMap.Location = new System.Drawing.Point(12, 12);
            this.dgvMap.MultiSelect = false;
            this.dgvMap.Name = "dgvMap";
            this.dgvMap.RowHeadersVisible = false;
            this.dgvMap.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvMap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMap.Size = new System.Drawing.Size(469, 469);
            this.dgvMap.TabIndex = 0;
            this.dgvMap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMap_CellClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 492);
            this.Controls.Add(this.dgvMap);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMap;
    }
}

