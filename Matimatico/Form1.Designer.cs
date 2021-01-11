
namespace Matimatico
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
            this.dgvHuman = new System.Windows.Forms.DataGridView();
            this.dgvComputer = new System.Windows.Forms.DataGridView();
            this.pbNewGame = new System.Windows.Forms.Button();
            this.lbCurrentCard = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHuman
            // 
            this.dgvHuman.AllowUserToAddRows = false;
            this.dgvHuman.AllowUserToDeleteRows = false;
            this.dgvHuman.AllowUserToResizeColumns = false;
            this.dgvHuman.AllowUserToResizeRows = false;
            this.dgvHuman.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHuman.ColumnHeadersVisible = false;
            this.dgvHuman.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHuman.Location = new System.Drawing.Point(12, 12);
            this.dgvHuman.MultiSelect = false;
            this.dgvHuman.Name = "dgvHuman";
            this.dgvHuman.RowHeadersVisible = false;
            this.dgvHuman.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvHuman.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvHuman.Size = new System.Drawing.Size(486, 486);
            this.dgvHuman.TabIndex = 0;
            this.dgvHuman.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHuman_CellClick);
            // 
            // dgvComputer
            // 
            this.dgvComputer.AllowUserToAddRows = false;
            this.dgvComputer.AllowUserToDeleteRows = false;
            this.dgvComputer.AllowUserToResizeColumns = false;
            this.dgvComputer.AllowUserToResizeRows = false;
            this.dgvComputer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComputer.ColumnHeadersVisible = false;
            this.dgvComputer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvComputer.Location = new System.Drawing.Point(620, 12);
            this.dgvComputer.MultiSelect = false;
            this.dgvComputer.Name = "dgvComputer";
            this.dgvComputer.RowHeadersVisible = false;
            this.dgvComputer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvComputer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvComputer.Size = new System.Drawing.Size(486, 486);
            this.dgvComputer.TabIndex = 0;
            // 
            // pbNewGame
            // 
            this.pbNewGame.Location = new System.Drawing.Point(520, 12);
            this.pbNewGame.Name = "pbNewGame";
            this.pbNewGame.Size = new System.Drawing.Size(75, 23);
            this.pbNewGame.TabIndex = 1;
            this.pbNewGame.Text = "Новая игра";
            this.pbNewGame.UseVisualStyleBackColor = true;
            this.pbNewGame.Click += new System.EventHandler(this.pbNewGame_Click);
            // 
            // lbCurrentCard
            // 
            this.lbCurrentCard.AutoSize = true;
            this.lbCurrentCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCurrentCard.Location = new System.Drawing.Point(543, 224);
            this.lbCurrentCard.Name = "lbCurrentCard";
            this.lbCurrentCard.Size = new System.Drawing.Size(36, 25);
            this.lbCurrentCard.TabIndex = 2;
            this.lbCurrentCard.Text = "42";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 511);
            this.Controls.Add(this.lbCurrentCard);
            this.Controls.Add(this.pbNewGame);
            this.Controls.Add(this.dgvComputer);
            this.Controls.Add(this.dgvHuman);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComputer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHuman;
        private System.Windows.Forms.DataGridView dgvComputer;
        private System.Windows.Forms.Button pbNewGame;
        private System.Windows.Forms.Label lbCurrentCard;
    }
}

