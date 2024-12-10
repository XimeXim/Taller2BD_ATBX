namespace taller_2_2024
{
    partial class ModificarProd
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
            label1 = new Label();
            dataProd = new DataGridView();
            button1 = new Button();
            nuevoPrecio = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataProd).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(274, 56);
            label1.Name = "label1";
            label1.Size = new Size(245, 37);
            label1.TabIndex = 4;
            label1.Text = "Modificar Producto";
            // 
            // dataProd
            // 
            dataProd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataProd.Location = new Point(180, 162);
            dataProd.Name = "dataProd";
            dataProd.Size = new Size(240, 150);
            dataProd.TabIndex = 5;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(507, 251);
            button1.Name = "button1";
            button1.Size = new Size(94, 45);
            button1.TabIndex = 6;
            button1.Text = "Modificar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // nuevoPrecio
            // 
            nuevoPrecio.Location = new Point(504, 212);
            nuevoPrecio.Name = "nuevoPrecio";
            nuevoPrecio.Size = new Size(100, 23);
            nuevoPrecio.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(490, 169);
            label2.Name = "label2";
            label2.Size = new Size(129, 28);
            label2.TabIndex = 8;
            label2.Text = "Nuevo Precio";
            // 
            // ModificarProd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(nuevoPrecio);
            Controls.Add(button1);
            Controls.Add(dataProd);
            Controls.Add(label1);
            Name = "ModificarProd";
            Text = "ModificarProd";
            Load += ModificarProd_Load;
            ((System.ComponentModel.ISupportInitialize)dataProd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataProd;
        private Button button1;
        private TextBox nuevoPrecio;
        private Label label2;
    }
}
