namespace Plytix
{
    partial class Form1
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
            this.ProductosRelaciondosdataGridView = new System.Windows.Forms.DataGridView();
            this.plytixLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProductosRelaciondosdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductosRelaciondosdataGridView
            // 
            this.ProductosRelaciondosdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductosRelaciondosdataGridView.Location = new System.Drawing.Point(12, 235);
            this.ProductosRelaciondosdataGridView.Name = "ProductosRelaciondosdataGridView";
            this.ProductosRelaciondosdataGridView.RowHeadersWidth = 51;
            this.ProductosRelaciondosdataGridView.RowTemplate.Height = 24;
            this.ProductosRelaciondosdataGridView.Size = new System.Drawing.Size(792, 187);
            this.ProductosRelaciondosdataGridView.TabIndex = 0;
            // 
            // plytixLabel
            // 
            this.plytixLabel.AutoSize = true;
            this.plytixLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plytixLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.plytixLabel.ForeColor = System.Drawing.Color.Purple;
            this.plytixLabel.Location = new System.Drawing.Point(23, 20);
            this.plytixLabel.Name = "plytixLabel";
            this.plytixLabel.Size = new System.Drawing.Size(98, 29);
            this.plytixLabel.TabIndex = 13;
            this.plytixLabel.Text = "PLYTIX";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plytixLabel);
            this.Controls.Add(this.ProductosRelaciondosdataGridView);
            this.Name = "Form1";
            this.Text = "RelatedProducts";
            ((System.ComponentModel.ISupportInitialize)(this.ProductosRelaciondosdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductosRelaciondosdataGridView;
        private System.Windows.Forms.Label plytixLabel;
    }
}