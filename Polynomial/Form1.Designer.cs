
namespace Polynomial
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
            this.lbPolynom1 = new System.Windows.Forms.Label();
            this.pbNewPolynom1 = new System.Windows.Forms.Button();
            this.tbVarVal = new System.Windows.Forms.TextBox();
            this.lbVariableName = new System.Windows.Forms.Label();
            this.lbValue = new System.Windows.Forms.Label();
            this.lbPolynom2 = new System.Windows.Forms.Label();
            this.pbNewPolynom2 = new System.Windows.Forms.Button();
            this.lbResultPolynom = new System.Windows.Forms.Label();
            this.pbSum = new System.Windows.Forms.Button();
            this.pbDiv = new System.Windows.Forms.Button();
            this.pbMul = new System.Windows.Forms.Button();
            this.tbA = new System.Windows.Forms.TextBox();
            this.lbA = new System.Windows.Forms.Label();
            this.lbAVal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPolynom1
            // 
            this.lbPolynom1.AutoSize = true;
            this.lbPolynom1.Location = new System.Drawing.Point(12, 38);
            this.lbPolynom1.Name = "lbPolynom1";
            this.lbPolynom1.Size = new System.Drawing.Size(35, 13);
            this.lbPolynom1.TabIndex = 0;
            this.lbPolynom1.Text = "label1";
            // 
            // pbNewPolynom1
            // 
            this.pbNewPolynom1.Location = new System.Drawing.Point(12, 12);
            this.pbNewPolynom1.Name = "pbNewPolynom1";
            this.pbNewPolynom1.Size = new System.Drawing.Size(116, 23);
            this.pbNewPolynom1.TabIndex = 1;
            this.pbNewPolynom1.Text = "Новый многочлен";
            this.pbNewPolynom1.UseVisualStyleBackColor = true;
            this.pbNewPolynom1.Click += new System.EventHandler(this.pbNewPolynom_Click);
            // 
            // tbVarVal
            // 
            this.tbVarVal.Location = new System.Drawing.Point(61, 61);
            this.tbVarVal.Name = "tbVarVal";
            this.tbVarVal.Size = new System.Drawing.Size(42, 20);
            this.tbVarVal.TabIndex = 2;
            this.tbVarVal.TextChanged += new System.EventHandler(this.tbVarVal_TextChanged);
            // 
            // lbVariableName
            // 
            this.lbVariableName.AutoSize = true;
            this.lbVariableName.Location = new System.Drawing.Point(9, 64);
            this.lbVariableName.Name = "lbVariableName";
            this.lbVariableName.Size = new System.Drawing.Size(46, 13);
            this.lbVariableName.TabIndex = 3;
            this.lbVariableName.Text = "При X =";
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.Location = new System.Drawing.Point(109, 64);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(54, 13);
            this.lbValue.TabIndex = 3;
            this.lbValue.Text = "значение";
            // 
            // lbPolynom2
            // 
            this.lbPolynom2.AutoSize = true;
            this.lbPolynom2.Location = new System.Drawing.Point(426, 38);
            this.lbPolynom2.Name = "lbPolynom2";
            this.lbPolynom2.Size = new System.Drawing.Size(35, 13);
            this.lbPolynom2.TabIndex = 0;
            this.lbPolynom2.Text = "label1";
            // 
            // pbNewPolynom2
            // 
            this.pbNewPolynom2.Location = new System.Drawing.Point(426, 12);
            this.pbNewPolynom2.Name = "pbNewPolynom2";
            this.pbNewPolynom2.Size = new System.Drawing.Size(116, 23);
            this.pbNewPolynom2.TabIndex = 1;
            this.pbNewPolynom2.Text = "Новый многочлен";
            this.pbNewPolynom2.UseVisualStyleBackColor = true;
            this.pbNewPolynom2.Click += new System.EventHandler(this.pbNewPolynom_Click);
            // 
            // lbResultPolynom
            // 
            this.lbResultPolynom.AutoSize = true;
            this.lbResultPolynom.Location = new System.Drawing.Point(355, 243);
            this.lbResultPolynom.Name = "lbResultPolynom";
            this.lbResultPolynom.Size = new System.Drawing.Size(35, 13);
            this.lbResultPolynom.TabIndex = 0;
            this.lbResultPolynom.Text = "label1";
            // 
            // pbSum
            // 
            this.pbSum.Location = new System.Drawing.Point(319, 130);
            this.pbSum.Name = "pbSum";
            this.pbSum.Size = new System.Drawing.Size(116, 23);
            this.pbSum.TabIndex = 1;
            this.pbSum.Text = "Сумма";
            this.pbSum.UseVisualStyleBackColor = true;
            this.pbSum.Click += new System.EventHandler(this.pbSum_Click);
            // 
            // pbDiv
            // 
            this.pbDiv.Location = new System.Drawing.Point(319, 159);
            this.pbDiv.Name = "pbDiv";
            this.pbDiv.Size = new System.Drawing.Size(116, 23);
            this.pbDiv.TabIndex = 1;
            this.pbDiv.Text = "Разность";
            this.pbDiv.UseVisualStyleBackColor = true;
            this.pbDiv.Click += new System.EventHandler(this.pbDiv_Click);
            // 
            // pbMul
            // 
            this.pbMul.Location = new System.Drawing.Point(319, 188);
            this.pbMul.Name = "pbMul";
            this.pbMul.Size = new System.Drawing.Size(116, 23);
            this.pbMul.TabIndex = 1;
            this.pbMul.Text = "Произведение";
            this.pbMul.UseVisualStyleBackColor = true;
            this.pbMul.Click += new System.EventHandler(this.pbMul_Click);
            // 
            // tbA
            // 
            this.tbA.Location = new System.Drawing.Point(28, 87);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(42, 20);
            this.tbA.TabIndex = 2;
            this.tbA.TextChanged += new System.EventHandler(this.tbA_TextChanged);
            // 
            // lbA
            // 
            this.lbA.AutoSize = true;
            this.lbA.Location = new System.Drawing.Point(9, 90);
            this.lbA.Name = "lbA";
            this.lbA.Size = new System.Drawing.Size(13, 13);
            this.lbA.TabIndex = 3;
            this.lbA.Text = "a";
            // 
            // lbAVal
            // 
            this.lbAVal.AutoSize = true;
            this.lbAVal.Location = new System.Drawing.Point(76, 90);
            this.lbAVal.Name = "lbAVal";
            this.lbAVal.Size = new System.Drawing.Size(13, 13);
            this.lbAVal.TabIndex = 3;
            this.lbAVal.Text = "=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbAVal);
            this.Controls.Add(this.lbValue);
            this.Controls.Add(this.lbA);
            this.Controls.Add(this.tbA);
            this.Controls.Add(this.lbVariableName);
            this.Controls.Add(this.tbVarVal);
            this.Controls.Add(this.pbNewPolynom2);
            this.Controls.Add(this.lbResultPolynom);
            this.Controls.Add(this.pbMul);
            this.Controls.Add(this.pbDiv);
            this.Controls.Add(this.pbSum);
            this.Controls.Add(this.lbPolynom2);
            this.Controls.Add(this.pbNewPolynom1);
            this.Controls.Add(this.lbPolynom1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPolynom1;
        private System.Windows.Forms.Button pbNewPolynom1;
        private System.Windows.Forms.TextBox tbVarVal;
        private System.Windows.Forms.Label lbVariableName;
        private System.Windows.Forms.Label lbValue;
        private System.Windows.Forms.Label lbPolynom2;
        private System.Windows.Forms.Button pbNewPolynom2;
        private System.Windows.Forms.Label lbResultPolynom;
        private System.Windows.Forms.Button pbSum;
        private System.Windows.Forms.Button pbDiv;
        private System.Windows.Forms.Button pbMul;
        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.Label lbA;
        private System.Windows.Forms.Label lbAVal;
    }
}

