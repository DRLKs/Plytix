﻿namespace Plytix
{
    partial class GestionProductosForms
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
            this.label1 = new System.Windows.Forms.Label();
            this.Volver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductosGridView = new System.Windows.Forms.DataGridView();
            this.Add = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProductosGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "PLYTIX";
            // 
            // Volver
            // 
            this.Volver.Location = new System.Drawing.Point(149, 13);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(75, 23);
            this.Volver.TabIndex = 1;
            this.Volver.Text = "Volver";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.VolverClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(39, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "USER PRODUCTS";
            // 
            // ProductosGridView
            // 
            this.ProductosGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductosGridView.Location = new System.Drawing.Point(44, 162);
            this.ProductosGridView.Name = "ProductosGridView";
            this.ProductosGridView.RowHeadersWidth = 51;
            this.ProductosGridView.RowTemplate.Height = 24;
            this.ProductosGridView.Size = new System.Drawing.Size(690, 228);
            this.ProductosGridView.TabIndex = 3;
            // 
            // Add
            // 
            this.Add.AutoSize = true;
            this.Add.Location = new System.Drawing.Point(584, 133);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(81, 16);
            this.Add.TabIndex = 4;
            this.Add.Text = "Add Product";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(671, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddProductButton);
            // 
            // GestionProductosForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.ProductosGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.label1);
            this.Name = "GestionProductosForms";
            this.Text = "GestionProductos";
            ((System.ComponentModel.ISupportInitialize)(this.ProductosGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Volver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView ProductosGridView;
        private System.Windows.Forms.Label Add;
        private System.Windows.Forms.Button button1;
    }
}