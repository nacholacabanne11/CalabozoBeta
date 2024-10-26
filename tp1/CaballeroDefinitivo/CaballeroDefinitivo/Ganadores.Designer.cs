namespace CaballeroDefinitivo
{
    partial class Ganadores
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
            this.lGanadores = new System.Windows.Forms.ListBox();
            this.Aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lGanadores
            // 
            this.lGanadores.FormattingEnabled = true;
            this.lGanadores.Location = new System.Drawing.Point(22, 39);
            this.lGanadores.Name = "lGanadores";
            this.lGanadores.Size = new System.Drawing.Size(579, 355);
            this.lGanadores.TabIndex = 0;
            // 
            // Aceptar
            // 
            this.Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Aceptar.Location = new System.Drawing.Point(241, 400);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(80, 29);
            this.Aceptar.TabIndex = 1;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            // 
            // Ganadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 455);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.lGanadores);
            this.Name = "Ganadores";
            this.Text = "Ganadores";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Aceptar;
        public System.Windows.Forms.ListBox lGanadores;
    }
}