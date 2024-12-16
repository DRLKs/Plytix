namespace Plytix
{
    partial class ProductosAñadirForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductosAñadirForm));
            this.label7 = new System.Windows.Forms.Label();
            this.atributosListBox = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBoxSKU = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGTIN = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.categoriaListBox = new System.Windows.Forms.CheckedListBox();
            this.TextBoxAtributtesRellenar = new System.Windows.Forms.TextBox();
            this.LabelNombreAtributo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(540, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 29);
            this.label7.TabIndex = 60;
            this.label7.Text = "Attributes";
            // 
            // atributosListBox
            // 
            this.atributosListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.atributosListBox.CheckOnClick = true;
            this.atributosListBox.FormattingEnabled = true;
            this.atributosListBox.Location = new System.Drawing.Point(474, 229);
            this.atributosListBox.Name = "atributosListBox";
            this.atributosListBox.Size = new System.Drawing.Size(253, 72);
            this.atributosListBox.TabIndex = 59;
            this.atributosListBox.TabStop = false;
            this.atributosListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.AtributoSeleccionado);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(540, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 29);
            this.label6.TabIndex = 57;
            this.label6.Text = "Categories";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(132, 317);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(200, 200);
            this.pictureBox.TabIndex = 56;
            this.pictureBox.TabStop = false;
            // 
            // textBoxSKU
            // 
            this.textBoxSKU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSKU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSKU.Location = new System.Drawing.Point(108, 107);
            this.textBoxSKU.Name = "textBoxSKU";
            this.textBoxSKU.Size = new System.Drawing.Size(253, 30);
            this.textBoxSKU.TabIndex = 55;
            this.textBoxSKU.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(199, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 29);
            this.label4.TabIndex = 54;
            this.label4.Text = "SKU";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(108, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 41);
            this.button1.TabIndex = 53;
            this.button1.TabStop = false;
            this.button1.Text = "Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveImage);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 29);
            this.label3.TabIndex = 52;
            this.label3.Text = "Thumbnail (200*200px)";
            // 
            // textBoxGTIN
            // 
            this.textBoxGTIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGTIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGTIN.Location = new System.Drawing.Point(108, 186);
            this.textBoxGTIN.Name = "textBoxGTIN";
            this.textBoxGTIN.Size = new System.Drawing.Size(253, 30);
            this.textBoxGTIN.TabIndex = 51;
            this.textBoxGTIN.TabStop = false;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNombre.Location = new System.Drawing.Point(108, 42);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(253, 30);
            this.textBoxNombre.TabIndex = 50;
            this.textBoxNombre.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 29);
            this.label2.TabIndex = 49;
            this.label2.Text = "GTIN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(154, -38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 29);
            this.label5.TabIndex = 48;
            this.label5.Text = "Product Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(157, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 29);
            this.label9.TabIndex = 63;
            this.label9.Text = "Product Name";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(367, 506);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 64;
            this.button2.Text = "SAVE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(367, 186);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 24);
            this.button3.TabIndex = 65;
            this.button3.Text = "Generate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.GenerateGTINClick);
            // 
            // categoriaListBox
            // 
            this.categoriaListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.categoriaListBox.CheckOnClick = true;
            this.categoriaListBox.FormattingEnabled = true;
            this.categoriaListBox.Location = new System.Drawing.Point(474, 84);
            this.categoriaListBox.Name = "categoriaListBox";
            this.categoriaListBox.Size = new System.Drawing.Size(253, 72);
            this.categoriaListBox.TabIndex = 58;
            this.categoriaListBox.TabStop = false;
            // 
            // TextBoxAtributtesRellenar
            // 
            this.TextBoxAtributtesRellenar.Location = new System.Drawing.Point(594, 317);
            this.TextBoxAtributtesRellenar.Name = "TextBoxAtributtesRellenar";
            this.TextBoxAtributtesRellenar.Size = new System.Drawing.Size(133, 22);
            this.TextBoxAtributtesRellenar.TabIndex = 66;
            this.TextBoxAtributtesRellenar.Visible = false;
            this.TextBoxAtributtesRellenar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PresionaTecla);
            // 
            // LabelNombreAtributo
            // 
            this.LabelNombreAtributo.AutoSize = true;
            this.LabelNombreAtributo.Location = new System.Drawing.Point(501, 322);
            this.LabelNombreAtributo.Name = "LabelNombreAtributo";
            this.LabelNombreAtributo.Size = new System.Drawing.Size(0, 16);
            this.LabelNombreAtributo.TabIndex = 67;
            // 
            // ProductosAñadirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 535);
            this.Controls.Add(this.LabelNombreAtributo);
            this.Controls.Add(this.TextBoxAtributtesRellenar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.atributosListBox);
            this.Controls.Add(this.categoriaListBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.textBoxSKU);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxGTIN);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductosAñadirForm";
            this.Text = "Add Product";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox atributosListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textBoxSKU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGTIN;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox categoriaListBox;
        private System.Windows.Forms.TextBox TextBoxAtributtesRellenar;
        private System.Windows.Forms.Label LabelNombreAtributo;
    }
}