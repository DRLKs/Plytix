﻿namespace Plytix
{
    partial class GestionAtributosForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.plytixLabel = new System.Windows.Forms.Label();
            this.GridViewAtributos = new System.Windows.Forms.DataGridView();
            this.grupo11DBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grupo11DBDataSet = new Plytix.grupo11DBDataSet();
            this.AddAtributoBotton = new System.Windows.Forms.Button();
            this.textBuscarAtributo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAtributos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupo11DBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupo11DBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "USER ATRIBUTTES";
            // 
            // plytixLabel
            // 
            this.plytixLabel.AutoSize = true;
            this.plytixLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plytixLabel.ForeColor = System.Drawing.Color.DarkOrchid;
            this.plytixLabel.Location = new System.Drawing.Point(47, 41);
            this.plytixLabel.Name = "plytixLabel";
            this.plytixLabel.Size = new System.Drawing.Size(87, 25);
            this.plytixLabel.TabIndex = 1;
            this.plytixLabel.Text = "PLYTIX";
            this.plytixLabel.Click += new System.EventHandler(this.plytixLabel_Click);
            // 
            // GridViewAtributos
            // 
            this.GridViewAtributos.AutoGenerateColumns = false;
            this.GridViewAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewAtributos.DataSource = this.grupo11DBDataSetBindingSource;
            this.GridViewAtributos.Location = new System.Drawing.Point(52, 177);
            this.GridViewAtributos.Name = "GridViewAtributos";
            this.GridViewAtributos.RowHeadersWidth = 51;
            this.GridViewAtributos.RowTemplate.Height = 24;
            this.GridViewAtributos.Size = new System.Drawing.Size(942, 303);
            this.GridViewAtributos.TabIndex = 2;
            // 
            // grupo11DBDataSetBindingSource
            // 
            this.grupo11DBDataSetBindingSource.DataSource = this.grupo11DBDataSet;
            this.grupo11DBDataSetBindingSource.Position = 0;
            // 
            // grupo11DBDataSet
            // 
            this.grupo11DBDataSet.DataSetName = "grupo11DBDataSet";
            this.grupo11DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AddAtributoBotton
            // 
            this.AddAtributoBotton.Location = new System.Drawing.Point(965, 128);
            this.AddAtributoBotton.Name = "AddAtributoBotton";
            this.AddAtributoBotton.Size = new System.Drawing.Size(29, 28);
            this.AddAtributoBotton.TabIndex = 3;
            this.AddAtributoBotton.Text = "+";
            this.AddAtributoBotton.UseVisualStyleBackColor = true;
            this.AddAtributoBotton.Click += new System.EventHandler(this.AddAtributoBotton_Click);
            // 
            // textBuscarAtributo
            // 
            this.textBuscarAtributo.Location = new System.Drawing.Point(439, 41);
            this.textBuscarAtributo.Name = "textBuscarAtributo";
            this.textBuscarAtributo.Size = new System.Drawing.Size(212, 22);
            this.textBuscarAtributo.TabIndex = 4;
            // 
            // GestionAtributosForm
            // 
            this.ClientSize = new System.Drawing.Size(1070, 653);
            this.Controls.Add(this.textBuscarAtributo);
            this.Controls.Add(this.AddAtributoBotton);
            this.Controls.Add(this.GridViewAtributos);
            this.Controls.Add(this.plytixLabel);
            this.Controls.Add(this.label1);
            this.Name = "GestionAtributosForm";
            ((System.ComponentModel.ISupportInitialize)(this.GridViewAtributos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupo11DBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupo11DBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label plytixLabel;
        private System.Windows.Forms.DataGridView GridViewAtributos;
        private System.Windows.Forms.BindingSource grupo11DBDataSetBindingSource;
        private grupo11DBDataSet grupo11DBDataSet;
        private System.Windows.Forms.Button AddAtributoBotton;
        private System.Windows.Forms.TextBox textBuscarAtributo;
    }
}
