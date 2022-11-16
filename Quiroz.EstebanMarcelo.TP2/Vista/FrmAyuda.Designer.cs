
namespace Vista
{
    partial class FrmAyuda
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
            this.btnExportarTxt = new System.Windows.Forms.Button();
            this.rtbAyuda = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnExportarTxt
            // 
            this.btnExportarTxt.BackColor = System.Drawing.Color.PaleGreen;
            this.btnExportarTxt.Location = new System.Drawing.Point(401, 476);
            this.btnExportarTxt.Name = "btnExportarTxt";
            this.btnExportarTxt.Size = new System.Drawing.Size(96, 30);
            this.btnExportarTxt.TabIndex = 1;
            this.btnExportarTxt.Text = "Exportar";
            this.btnExportarTxt.UseVisualStyleBackColor = false;
            this.btnExportarTxt.Click += new System.EventHandler(this.btnExportarTxt_Click);
            // 
            // rtbAyuda
            // 
            this.rtbAyuda.Location = new System.Drawing.Point(85, 140);
            this.rtbAyuda.Name = "rtbAyuda";
            this.rtbAyuda.Size = new System.Drawing.Size(721, 330);
            this.rtbAyuda.TabIndex = 2;
            this.rtbAyuda.Text = "";
            // 
            // FrmAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.backgroundMenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(903, 518);
            this.Controls.Add(this.rtbAyuda);
            this.Controls.Add(this.btnExportarTxt);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAyuda";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayuda";
            this.Load += new System.EventHandler(this.FrmAyuda_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExportarTxt;
        private System.Windows.Forms.RichTextBox rtbAyuda;
    }
}