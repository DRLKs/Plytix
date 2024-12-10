namespace Plytix
{
    partial class ProductosListarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductosListarForm));
            this.ProductosGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProductosGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductosGridView
            // 
            this.ProductosGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductosGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductosGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ProductosGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductosGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ProductosGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductosGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.ProductosGridView.GridColor = System.Drawing.SystemColors.Control;
            this.ProductosGridView.Location = new System.Drawing.Point(97, 160);
            this.ProductosGridView.MultiSelect = false;
            this.ProductosGridView.Name = "ProductosGridView";
            this.ProductosGridView.ReadOnly = true;
            this.ProductosGridView.RowHeadersVisible = false;
            this.ProductosGridView.RowHeadersWidth = 51;
            this.ProductosGridView.RowTemplate.Height = 24;
            this.ProductosGridView.Size = new System.Drawing.Size(1225, 595);
            this.ProductosGridView.TabIndex = 8;
            this.ProductosGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductosGridView_CellContentClick);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(108, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "USER PRODUCTS";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(1251, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 49);
            this.button1.TabIndex = 14;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // Add
            // 
            this.Add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Add.AutoSize = true;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Add.Location = new System.Drawing.Point(1104, 117);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(120, 25);
            this.Add.TabIndex = 13;
            this.Add.Text = "Add Product";
            this.Add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Add.Click += new System.EventHandler(this.AddProductLabel_Click);
            // 
            // ProductosListarForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1430, 767);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.ProductosGridView);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductosListarForm";
            this.Text = "Home > Products";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProductosListarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductosGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductosGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Add;
    }
}