﻿namespace Plytix
{
    partial class CuentaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuentaForm));
            this.numeroProductos = new System.Windows.Forms.Label();
            this.numeroAtributos = new System.Windows.Forms.Label();
            this.numeroCategorias = new System.Windows.Forms.Label();
            this.CrearCSVButton = new System.Windows.Forms.Button();
            this.CrearJSONButton = new System.Windows.Forms.Button();
            this.NombreCuentaLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // numeroProductos
            // 
            this.numeroProductos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numeroProductos.AutoSize = true;
            this.numeroProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroProductos.Location = new System.Drawing.Point(786, 169);
            this.numeroProductos.Name = "numeroProductos";
            this.numeroProductos.Size = new System.Drawing.Size(292, 32);
            this.numeroProductos.TabIndex = 0;
            this.numeroProductos.Text = "Number of products: #";
            // 
            // numeroAtributos
            // 
            this.numeroAtributos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numeroAtributos.AutoSize = true;
            this.numeroAtributos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroAtributos.Location = new System.Drawing.Point(786, 252);
            this.numeroAtributos.Name = "numeroAtributos";
            this.numeroAtributos.Size = new System.Drawing.Size(315, 32);
            this.numeroAtributos.TabIndex = 1;
            this.numeroAtributos.Text = "Number of categories: #";
            // 
            // numeroCategorias
            // 
            this.numeroCategorias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numeroCategorias.AutoSize = true;
            this.numeroCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCategorias.Location = new System.Drawing.Point(786, 341);
            this.numeroCategorias.Name = "numeroCategorias";
            this.numeroCategorias.Size = new System.Drawing.Size(301, 32);
            this.numeroCategorias.TabIndex = 2;
            this.numeroCategorias.Text = "Number of attributes: #";
            // 
            // CrearCSVButton
            // 
            this.CrearCSVButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CrearCSVButton.AutoSize = true;
            this.CrearCSVButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CrearCSVButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CrearCSVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrearCSVButton.Location = new System.Drawing.Point(700, 527);
            this.CrearCSVButton.Name = "CrearCSVButton";
            this.CrearCSVButton.Size = new System.Drawing.Size(159, 37);
            this.CrearCSVButton.TabIndex = 4;
            this.CrearCSVButton.Text = "Generate CSV";
            this.CrearCSVButton.UseVisualStyleBackColor = true;
            this.CrearCSVButton.Click += new System.EventHandler(this.CrearCSVClick);
            // 
            // CrearJSONButton
            // 
            this.CrearJSONButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CrearJSONButton.AutoSize = true;
            this.CrearJSONButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CrearJSONButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CrearJSONButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrearJSONButton.Location = new System.Drawing.Point(936, 527);
            this.CrearJSONButton.Name = "CrearJSONButton";
            this.CrearJSONButton.Size = new System.Drawing.Size(165, 37);
            this.CrearJSONButton.TabIndex = 5;
            this.CrearJSONButton.Text = "Export to JSON";
            this.CrearJSONButton.UseVisualStyleBackColor = true;
            this.CrearJSONButton.Click += new System.EventHandler(this.CrearJSONClick);
            // 
            // NombreCuentaLabel
            // 
            this.NombreCuentaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NombreCuentaLabel.AutoSize = true;
            this.NombreCuentaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreCuentaLabel.Location = new System.Drawing.Point(336, 161);
            this.NombreCuentaLabel.Name = "NombreCuentaLabel";
            this.NombreCuentaLabel.Size = new System.Drawing.Size(119, 25);
            this.NombreCuentaLabel.TabIndex = 6;
            this.NombreCuentaLabel.Text = "ACC NAME";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(328, 214);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 179);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "ACCOUNT INFO";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(139, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "USERNAME:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(139, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 78);
            this.label3.TabIndex = 10;
            this.label3.Text = "PROFILE PICTURE:";
            // 
            // CuentaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 607);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.NombreCuentaLabel);
            this.Controls.Add(this.CrearJSONButton);
            this.Controls.Add(this.CrearCSVButton);
            this.Controls.Add(this.numeroCategorias);
            this.Controls.Add(this.numeroAtributos);
            this.Controls.Add(this.numeroProductos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CuentaForm";
            this.Text = "Home > Account";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numeroProductos;
        private System.Windows.Forms.Label numeroAtributos;
        private System.Windows.Forms.Label numeroCategorias;
        private System.Windows.Forms.Label numeroAssets;
        private System.Windows.Forms.Button CrearCSVButton;
        private System.Windows.Forms.Button CrearJSONButton;
        private System.Windows.Forms.Label NombreCuentaLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}