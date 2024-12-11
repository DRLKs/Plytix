namespace Plytix
{
    partial class CategoriasListarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.addLabel = new System.Windows.Forms.Label();
            this.CategoriasGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriasGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(1264, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 49);
            this.button1.TabIndex = 19;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addLabel
            // 
            this.addLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addLabel.AutoSize = true;
            this.addLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addLabel.Location = new System.Drawing.Point(1114, 44);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(133, 25);
            this.addLabel.TabIndex = 18;
            this.addLabel.Text = "Add Category";
            this.addLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CategoriasGridView
            // 
            this.CategoriasGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CategoriasGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CategoriasGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.CategoriasGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CategoriasGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.CategoriasGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CategoriasGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.CategoriasGridView.GridColor = System.Drawing.SystemColors.Control;
            this.CategoriasGridView.Location = new System.Drawing.Point(38, 91);
            this.CategoriasGridView.MultiSelect = false;
            this.CategoriasGridView.Name = "CategoriasGridView";
            this.CategoriasGridView.ReadOnly = true;
            this.CategoriasGridView.RowHeadersVisible = false;
            this.CategoriasGridView.RowHeadersWidth = 51;
            this.CategoriasGridView.RowTemplate.Height = 24;
            this.CategoriasGridView.Size = new System.Drawing.Size(1301, 641);
            this.CategoriasGridView.TabIndex = 16;
            this.CategoriasGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CategoriasGridView_CellContentClick);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(33, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "USER CATEGORIES";
            // 
            // CategoriasListarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 843);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addLabel);
            this.Controls.Add(this.CategoriasGridView);
            this.Controls.Add(this.label2);
            this.Name = "CategoriasListarForm";
            this.Text = "Home > Categories";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CategoriasListarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CategoriasGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.DataGridView CategoriasGridView;
        private System.Windows.Forms.Label label2;
    }
}