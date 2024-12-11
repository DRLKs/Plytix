namespace Plytix
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
            this.numeroAssets = new System.Windows.Forms.Label();
            this.CrearCSVButton = new System.Windows.Forms.Button();
            this.CrearJSONButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numeroProductos
            // 
            this.numeroProductos.AutoSize = true;
            this.numeroProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroProductos.Location = new System.Drawing.Point(112, 55);
            this.numeroProductos.Name = "numeroProductos";
            this.numeroProductos.Size = new System.Drawing.Size(98, 32);
            this.numeroProductos.TabIndex = 0;
            this.numeroProductos.Text = "label1";
            // 
            // numeroAtributos
            // 
            this.numeroAtributos.AutoSize = true;
            this.numeroAtributos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroAtributos.Location = new System.Drawing.Point(112, 103);
            this.numeroAtributos.Name = "numeroAtributos";
            this.numeroAtributos.Size = new System.Drawing.Size(98, 32);
            this.numeroAtributos.TabIndex = 1;
            this.numeroAtributos.Text = "label1";
            // 
            // numeroCategorias
            // 
            this.numeroCategorias.AutoSize = true;
            this.numeroCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCategorias.Location = new System.Drawing.Point(112, 157);
            this.numeroCategorias.Name = "numeroCategorias";
            this.numeroCategorias.Size = new System.Drawing.Size(98, 32);
            this.numeroCategorias.TabIndex = 2;
            this.numeroCategorias.Text = "label1";
            // 
            // numeroAssets
            // 
            this.numeroAssets.AutoSize = true;
            this.numeroAssets.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroAssets.Location = new System.Drawing.Point(112, 209);
            this.numeroAssets.Name = "numeroAssets";
            this.numeroAssets.Size = new System.Drawing.Size(98, 32);
            this.numeroAssets.TabIndex = 3;
            this.numeroAssets.Text = "label1";
            // 
            // CrearCSVButton
            // 
            this.CrearCSVButton.Location = new System.Drawing.Point(690, 103);
            this.CrearCSVButton.Name = "CrearCSVButton";
            this.CrearCSVButton.Size = new System.Drawing.Size(75, 23);
            this.CrearCSVButton.TabIndex = 4;
            this.CrearCSVButton.Text = "CSV";
            this.CrearCSVButton.UseVisualStyleBackColor = true;
            this.CrearCSVButton.Click += new System.EventHandler(this.CrearCSVClick);
            // 
            // CrearJSONButton
            // 
            this.CrearJSONButton.Location = new System.Drawing.Point(690, 209);
            this.CrearJSONButton.Name = "CrearJSONButton";
            this.CrearJSONButton.Size = new System.Drawing.Size(75, 23);
            this.CrearJSONButton.TabIndex = 5;
            this.CrearJSONButton.Text = "JSON";
            this.CrearJSONButton.UseVisualStyleBackColor = true;
            this.CrearJSONButton.Click += new System.EventHandler(this.CrearJSONClick);
            // 
            // CuentaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CrearJSONButton);
            this.Controls.Add(this.CrearCSVButton);
            this.Controls.Add(this.numeroAssets);
            this.Controls.Add(this.numeroCategorias);
            this.Controls.Add(this.numeroAtributos);
            this.Controls.Add(this.numeroProductos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CuentaForm";
            this.Text = "Account";
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
    }
}