namespace Plytix
{
    partial class GestionCategoriasForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionCategoriasForms));
            this.Volver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CategoriasGridView = new System.Windows.Forms.DataGridView();
            this.NoProductsLabel = new System.Windows.Forms.Label();
            this.textFiltroProductos = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriasGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Volver
            // 
            this.Volver.Location = new System.Drawing.Point(138, 31);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(75, 23);
            this.Volver.TabIndex = 2;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "PLYTIX";
            // 
            // CategoriasGridView
            // 
            this.CategoriasGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CategoriasGridView.Location = new System.Drawing.Point(27, 176);
            this.CategoriasGridView.Name = "CategoriasGridView";
            this.CategoriasGridView.RowHeadersWidth = 51;
            this.CategoriasGridView.RowTemplate.Height = 24;
            this.CategoriasGridView.Size = new System.Drawing.Size(746, 252);
            this.CategoriasGridView.TabIndex = 4;
            // 
            // NoProductsLabel
            // 
            this.NoProductsLabel.AutoSize = true;
            this.NoProductsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoProductsLabel.ForeColor = System.Drawing.Color.Black;
            this.NoProductsLabel.Location = new System.Drawing.Point(294, 288);
            this.NoProductsLabel.Name = "NoProductsLabel";
            this.NoProductsLabel.Size = new System.Drawing.Size(197, 29);
            this.NoProductsLabel.TabIndex = 7;
            this.NoProductsLabel.Text = "NO PRODUCTS";
            // 
            // textFiltroProductos
            // 
            this.textFiltroProductos.Location = new System.Drawing.Point(336, 33);
            this.textFiltroProductos.Name = "textFiltroProductos";
            this.textFiltroProductos.Size = new System.Drawing.Size(127, 22);
            this.textFiltroProductos.TabIndex = 8;
            // 
            // GestionCategoriasForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textFiltroProductos);
            this.Controls.Add(this.NoProductsLabel);
            this.Controls.Add(this.CategoriasGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Volver);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GestionCategoriasForms";
            this.Text = "GestionCategorias";
            ((System.ComponentModel.ISupportInitialize)(this.CategoriasGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView CategoriasGridView;
        private System.Windows.Forms.Label NoProductsLabel;
        private System.Windows.Forms.TextBox textFiltroProductos;
    }
}