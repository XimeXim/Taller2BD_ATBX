namespace taller2
{
    partial class ElimProd
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
            ListadoProd = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(129, 60);
            label1.Name = "label1";
            label1.Size = new Size(228, 37);
            label1.TabIndex = 0;
            label1.Text = "Eliminar Producto";
            // 
            // ListadoProd
            // 
            ListadoProd.FormattingEnabled = true;
            ListadoProd.Location = new Point(363, 167);
            ListadoProd.Name = "ListadoProd";
            ListadoProd.Size = new Size(121, 23);
            ListadoProd.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(67, 162);
            label2.Name = "label2";
            label2.Size = new Size(290, 28);
            label2.TabIndex = 2;
            label2.Text = "Seleccione producto a eliminar: ";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(188, 258);
            button1.Name = "button1";
            button1.Size = new Size(111, 36);
            button1.TabIndex = 3;
            button1.Text = "Eliminar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // EliminarProd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 450);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(ListadoProd);
            Controls.Add(label1);
            Name = "EliminarProd";
            Text = "EliminarProd";
            Load += EliminarProd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox ListadoProd;
        private Label label2;
        private Button button1;
    }
}
