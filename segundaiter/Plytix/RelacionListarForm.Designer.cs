namespace Plytix
{
    partial class RelacionListarForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.addLabel = new System.Windows.Forms.Label();
            this.buttonAddLabel = new System.Windows.Forms.Button();
            this.relacionesDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.relacionesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(95, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 29);
            this.label2.TabIndex = 28;
            this.label2.Text = "USER RELATIONS";
            // 
            // addLabel
            // 
            this.addLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addLabel.AutoSize = true;
            this.addLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addLabel.Location = new System.Drawing.Point(1020, 53);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(123, 25);
            this.addLabel.TabIndex = 27;
            this.addLabel.Text = "Add Relation";
            this.addLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAddLabel
            // 
            this.buttonAddLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonAddLabel.Location = new System.Drawing.Point(1161, 41);
            this.buttonAddLabel.Name = "buttonAddLabel";
            this.buttonAddLabel.Size = new System.Drawing.Size(54, 49);
            this.buttonAddLabel.TabIndex = 26;
            this.buttonAddLabel.Text = "+";
            this.buttonAddLabel.UseVisualStyleBackColor = true;
            this.buttonAddLabel.Click += new System.EventHandler(this.buttonAddLabel_Click);
            // 
            // relacionesDataGridView
            // 
            this.relacionesDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.relacionesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.relacionesDataGridView.ColumnHeadersHeight = 29;
            this.relacionesDataGridView.Location = new System.Drawing.Point(100, 96);
            this.relacionesDataGridView.Name = "relacionesDataGridView";
            this.relacionesDataGridView.ReadOnly = true;
            this.relacionesDataGridView.RowHeadersWidth = 51;
            this.relacionesDataGridView.RowTemplate.Height = 24;
            this.relacionesDataGridView.Size = new System.Drawing.Size(1115, 404);
            this.relacionesDataGridView.TabIndex = 25;
            this.relacionesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.relacionesDataGridView_CellContentClick);
            // 
            // RelacionListarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 541);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addLabel);
            this.Controls.Add(this.buttonAddLabel);
            this.Controls.Add(this.relacionesDataGridView);
            this.Name = "RelacionListarForm";
            this.Text = "RelacionListarForm";
            this.Load += new System.EventHandler(this.RelacionListarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.relacionesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.Button buttonAddLabel;
        private System.Windows.Forms.DataGridView relacionesDataGridView;
    }
}