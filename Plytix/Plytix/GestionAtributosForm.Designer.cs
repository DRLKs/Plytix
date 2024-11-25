namespace Plytix
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
            this.RemainingAtributesLabel = new System.Windows.Forms.Label();
            this.AvisoNoAtributos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddAttributesLabel = new System.Windows.Forms.Label();
            this.Volver = new System.Windows.Forms.Button();
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
            this.GridViewAtributos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewAtributos.DataSource = this.grupo11DBDataSetBindingSource;
            this.GridViewAtributos.Location = new System.Drawing.Point(52, 179);
            this.GridViewAtributos.Name = "GridViewAtributos";
            this.GridViewAtributos.ReadOnly = true;
            this.GridViewAtributos.RowHeadersWidth = 51;
            this.GridViewAtributos.RowTemplate.Height = 24;
            this.GridViewAtributos.Size = new System.Drawing.Size(942, 303);
            this.GridViewAtributos.TabIndex = 2;
            this.GridViewAtributos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AtributosGridClickar);
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
            this.textBuscarAtributo.Visible = false;
            // 
            // RemainingAtributesLabel
            // 
            this.RemainingAtributesLabel.AutoSize = true;
            this.RemainingAtributesLabel.Location = new System.Drawing.Point(619, 134);
            this.RemainingAtributesLabel.Name = "RemainingAtributesLabel";
            this.RemainingAtributesLabel.Size = new System.Drawing.Size(202, 16);
            this.RemainingAtributesLabel.TabIndex = 5;
            this.RemainingAtributesLabel.Text = "Remaining available attributes: X";
            // 
            // AvisoNoAtributos
            // 
            this.AvisoNoAtributos.AutoSize = true;
            this.AvisoNoAtributos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvisoNoAtributos.Location = new System.Drawing.Point(414, 246);
            this.AvisoNoAtributos.Name = "AvisoNoAtributos";
            this.AvisoNoAtributos.Size = new System.Drawing.Size(320, 175);
            this.AvisoNoAtributos.TabIndex = 6;
            this.AvisoNoAtributos.Text = "There are no user attributes yet.\n\n\n\n\n\n\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(334, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Buscar:";
            this.label3.Visible = false;
            // 
            // AddAttributesLabel
            // 
            this.AddAttributesLabel.AutoSize = true;
            this.AddAttributesLabel.Location = new System.Drawing.Point(869, 134);
            this.AddAttributesLabel.Name = "AddAttributesLabel";
            this.AddAttributesLabel.Size = new System.Drawing.Size(90, 16);
            this.AddAttributesLabel.TabIndex = 10;
            this.AddAttributesLabel.Text = "Add Atributtes";
            // 
            // Volver
            // 
            this.Volver.Location = new System.Drawing.Point(140, 40);
            this.Volver.Name = "Volver";
            this.Volver.Size = new System.Drawing.Size(75, 23);
            this.Volver.TabIndex = 11;
            this.Volver.Text = "Return";
            this.Volver.UseVisualStyleBackColor = true;
            this.Volver.Click += new System.EventHandler(this.Volver_Click);
            // 
            // GestionAtributosForm
            // 
            this.ClientSize = new System.Drawing.Size(1070, 653);
            this.Controls.Add(this.Volver);
            this.Controls.Add(this.AddAttributesLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RemainingAtributesLabel);
            this.Controls.Add(this.textBuscarAtributo);
            this.Controls.Add(this.AddAtributoBotton);
            this.Controls.Add(this.GridViewAtributos);
            this.Controls.Add(this.plytixLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AvisoNoAtributos);
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
        private System.Windows.Forms.Label RemainingAtributesLabel;
        private System.Windows.Forms.Label AvisoNoAtributos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AddAttributesLabel;
        private System.Windows.Forms.Button Volver;
    }
}
