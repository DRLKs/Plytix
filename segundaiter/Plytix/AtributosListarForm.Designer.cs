namespace Plytix
{
    partial class AtributosListarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtributosListarForm));
            this.AtributosGridView = new System.Windows.Forms.DataGridView();
            this.buttonAddLabel = new System.Windows.Forms.Button();
            this.addLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AtributosGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AtributosGridView
            // 
            this.AtributosGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AtributosGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AtributosGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AtributosGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AtributosGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.AtributosGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AtributosGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.AtributosGridView.GridColor = System.Drawing.SystemColors.Control;
            this.AtributosGridView.Location = new System.Drawing.Point(2, 104);
            this.AtributosGridView.MultiSelect = false;
            this.AtributosGridView.Name = "AtributosGridView";
            this.AtributosGridView.ReadOnly = true;
            this.AtributosGridView.RowHeadersVisible = false;
            this.AtributosGridView.RowHeadersWidth = 51;
            this.AtributosGridView.RowTemplate.Height = 24;
            this.AtributosGridView.Size = new System.Drawing.Size(1301, 387);
            this.AtributosGridView.TabIndex = 17;
            this.AtributosGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AtributosGridView_CellContentClick);
            // 
            // buttonAddLabel
            // 
            this.buttonAddLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonAddLabel.Location = new System.Drawing.Point(1249, 16);
            this.buttonAddLabel.Name = "buttonAddLabel";
            this.buttonAddLabel.Size = new System.Drawing.Size(54, 49);
            this.buttonAddLabel.TabIndex = 20;
            this.buttonAddLabel.Text = "+";
            this.buttonAddLabel.UseVisualStyleBackColor = true;
            this.buttonAddLabel.Click += new System.EventHandler(this.AddAtributoClick);
            // 
            // addLabel
            // 
            this.addLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addLabel.AutoSize = true;
            this.addLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addLabel.Location = new System.Drawing.Point(1110, 28);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(125, 25);
            this.addLabel.TabIndex = 21;
            this.addLabel.Text = "Add Atributte";
            this.addLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 29);
            this.label2.TabIndex = 22;
            this.label2.Text = "USER ATTRIBUTES";
            // 
            // AtributosListarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 724);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addLabel);
            this.Controls.Add(this.buttonAddLabel);
            this.Controls.Add(this.AtributosGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AtributosListarForm";
            this.Text = "Atributte";
            ((System.ComponentModel.ISupportInitialize)(this.AtributosGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AtributosGridView;
        private System.Windows.Forms.Button buttonAddLabel;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.Label label2;
    }
}