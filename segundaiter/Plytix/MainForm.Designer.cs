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
            this.panelMain = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // productosButton
            // 
            this.productosButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productosButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.productosButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productosButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productosButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productosButton.Location = new System.Drawing.Point(121, 60);
            this.productosButton.Name = "productosButton";
            this.productosButton.Size = new System.Drawing.Size(211, 45);
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
            this.categoriasButton.Location = new System.Drawing.Point(330, 60);
            this.categoriasButton.Name = "categoriasButton";
            this.categoriasButton.Size = new System.Drawing.Size(219, 45);
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
            this.atributosButton.Location = new System.Drawing.Point(547, 60);
            this.atributosButton.Name = "atributosButton";
            this.atributosButton.Size = new System.Drawing.Size(219, 45);
            this.atributosButton.TabIndex = 2;
            this.atributosButton.Text = "Attributes";
            this.atributosButton.UseVisualStyleBackColor = false;
            this.atributosButton.Click += new System.EventHandler(this.Atributos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "PLYTIX";
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(-3, 111);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1805, 922);
            this.panelMain.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(765, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(218, 45);
            this.button3.TabIndex = 7;
            this.button3.Text = "Related Products";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.RelatedProducts_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(980, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 45);
            this.button1.TabIndex = 8;
            this.button1.Text = "Account";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Account_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1802, 1034);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.atributosButton);
            this.Controls.Add(this.categoriasButton);
            this.Controls.Add(this.productosButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelMain);
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
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}