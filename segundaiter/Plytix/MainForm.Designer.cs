namespace Plytix
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.productosButton = new System.Windows.Forms.Button();
            this.categoriasButton = new System.Windows.Forms.Button();
            this.atributosButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // productosButton
            // 
            this.productosButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productosButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.productosButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productosButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productosButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productosButton.Location = new System.Drawing.Point(122, 243);
            this.productosButton.Name = "productosButton";
            this.productosButton.Size = new System.Drawing.Size(211, 95);
            this.productosButton.TabIndex = 0;
            this.productosButton.Text = "Products";
            this.productosButton.UseVisualStyleBackColor = false;
            this.productosButton.Click += new System.EventHandler(this.productosButton_Click);
            // 
            // categoriasButton
            // 
            this.categoriasButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.categoriasButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.categoriasButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.categoriasButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categoriasButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriasButton.Location = new System.Drawing.Point(570, 243);
            this.categoriasButton.Name = "categoriasButton";
            this.categoriasButton.Size = new System.Drawing.Size(211, 95);
            this.categoriasButton.TabIndex = 1;
            this.categoriasButton.Text = "Categories";
            this.categoriasButton.UseVisualStyleBackColor = false;
            this.categoriasButton.Click += new System.EventHandler(this.categoriasButton_Click);
            // 
            // atributosButton
            // 
            this.atributosButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.atributosButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.atributosButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.atributosButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.atributosButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atributosButton.Location = new System.Drawing.Point(1025, 243);
            this.atributosButton.Name = "atributosButton";
            this.atributosButton.Size = new System.Drawing.Size(211, 95);
            this.atributosButton.TabIndex = 2;
            this.atributosButton.Text = "Attributes";
            this.atributosButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(36, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "PLYTIX";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.atributosButton);
            this.Controls.Add(this.categoriasButton);
            this.Controls.Add(this.productosButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button productosButton;
        private System.Windows.Forms.Button categoriasButton;
        private System.Windows.Forms.Button atributosButton;
        private System.Windows.Forms.Label label1;
    }
}