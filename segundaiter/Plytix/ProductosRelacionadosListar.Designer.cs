namespace Plytix
{
    partial class ProductosRelacionadosListar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductosRelacionadosListar));
            this.ProductosRelaciondosdataGridView = new System.Windows.Forms.DataGridView();
            this.buttonAddLabel = new System.Windows.Forms.Button();
            this.addLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProductosRelaciondosdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductosRelaciondosdataGridView
            // 
            this.ProductosRelaciondosdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductosRelaciondosdataGridView.Location = new System.Drawing.Point(174, 138);
            this.ProductosRelaciondosdataGridView.Name = "ProductosRelaciondosdataGridView";
            this.ProductosRelaciondosdataGridView.RowHeadersWidth = 51;
            this.ProductosRelaciondosdataGridView.RowTemplate.Height = 24;
            this.ProductosRelaciondosdataGridView.Size = new System.Drawing.Size(1115, 404);
            this.ProductosRelaciondosdataGridView.TabIndex = 0;
            // 
            // buttonAddLabel
            // 
            this.buttonAddLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonAddLabel.Location = new System.Drawing.Point(1235, 83);
            this.buttonAddLabel.Name = "buttonAddLabel";
            this.buttonAddLabel.Size = new System.Drawing.Size(54, 49);
            this.buttonAddLabel.TabIndex = 22;
            this.buttonAddLabel.Text = "+";
            this.buttonAddLabel.UseVisualStyleBackColor = true;
            this.buttonAddLabel.Click += new System.EventHandler(this.AddRelatedProduct_Click);
            // 
            // addLabel
            // 
            this.addLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addLabel.AutoSize = true;
            this.addLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addLabel.Location = new System.Drawing.Point(1094, 95);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(123, 25);
            this.addLabel.TabIndex = 23;
            this.addLabel.Text = "Add Relation";
            this.addLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductosRelacionadosListar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 657);
            this.Controls.Add(this.addLabel);
            this.Controls.Add(this.buttonAddLabel);
            this.Controls.Add(this.ProductosRelaciondosdataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductosRelacionadosListar";
            this.Text = "RelatedProducts";
            ((System.ComponentModel.ISupportInitialize)(this.ProductosRelaciondosdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductosRelaciondosdataGridView;
        private System.Windows.Forms.Button buttonAddLabel;
        private System.Windows.Forms.Label addLabel;
    }
}