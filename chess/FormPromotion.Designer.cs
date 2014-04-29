namespace chess
{
    partial class FormPromotion
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
            this.GBPromotion = new System.Windows.Forms.GroupBox();
            this.RBKnight = new System.Windows.Forms.RadioButton();
            this.RBBishop = new System.Windows.Forms.RadioButton();
            this.RBRook = new System.Windows.Forms.RadioButton();
            this.RBQueen = new System.Windows.Forms.RadioButton();
            this.BOK = new System.Windows.Forms.Button();
            this.GBPromotion.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBPromotion
            // 
            this.GBPromotion.Controls.Add(this.RBKnight);
            this.GBPromotion.Controls.Add(this.RBBishop);
            this.GBPromotion.Controls.Add(this.RBRook);
            this.GBPromotion.Controls.Add(this.RBQueen);
            this.GBPromotion.Location = new System.Drawing.Point(8, 8);
            this.GBPromotion.Name = "GBPromotion";
            this.GBPromotion.Size = new System.Drawing.Size(112, 116);
            this.GBPromotion.TabIndex = 0;
            this.GBPromotion.TabStop = false;
            this.GBPromotion.Text = "Figures";
            // 
            // RBKnight
            // 
            this.RBKnight.AutoSize = true;
            this.RBKnight.Location = new System.Drawing.Point(8, 91);
            this.RBKnight.Name = "RBKnight";
            this.RBKnight.Size = new System.Drawing.Size(55, 17);
            this.RBKnight.TabIndex = 3;
            this.RBKnight.Text = "Knight";
            this.RBKnight.UseVisualStyleBackColor = true;
            // 
            // RBBishop
            // 
            this.RBBishop.AutoSize = true;
            this.RBBishop.Location = new System.Drawing.Point(8, 66);
            this.RBBishop.Name = "RBBishop";
            this.RBBishop.Size = new System.Drawing.Size(57, 17);
            this.RBBishop.TabIndex = 2;
            this.RBBishop.Text = "Bishop";
            this.RBBishop.UseVisualStyleBackColor = true;
            // 
            // RBRook
            // 
            this.RBRook.AutoSize = true;
            this.RBRook.Location = new System.Drawing.Point(8, 41);
            this.RBRook.Name = "RBRook";
            this.RBRook.Size = new System.Drawing.Size(51, 17);
            this.RBRook.TabIndex = 1;
            this.RBRook.Text = "Rook";
            this.RBRook.UseVisualStyleBackColor = true;
            // 
            // RBQueen
            // 
            this.RBQueen.AutoSize = true;
            this.RBQueen.Location = new System.Drawing.Point(8, 16);
            this.RBQueen.Name = "RBQueen";
            this.RBQueen.Size = new System.Drawing.Size(57, 17);
            this.RBQueen.TabIndex = 0;
            this.RBQueen.Text = "Queen";
            this.RBQueen.UseVisualStyleBackColor = true;
            // 
            // BOK
            // 
            this.BOK.Location = new System.Drawing.Point(8, 132);
            this.BOK.Name = "BOK";
            this.BOK.Size = new System.Drawing.Size(112, 24);
            this.BOK.TabIndex = 1;
            this.BOK.Text = "OK";
            this.BOK.UseVisualStyleBackColor = true;
            this.BOK.Click += new System.EventHandler(this.BOK_Click);
            // 
            // FormPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(128, 164);
            this.ControlBox = false;
            this.Controls.Add(this.BOK);
            this.Controls.Add(this.GBPromotion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPromotion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pawn promotion";
            this.Shown += new System.EventHandler(this.FormPromotion_Shown);
            this.GBPromotion.ResumeLayout(false);
            this.GBPromotion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBPromotion;
        private System.Windows.Forms.RadioButton RBKnight;
        private System.Windows.Forms.RadioButton RBBishop;
        private System.Windows.Forms.RadioButton RBRook;
        private System.Windows.Forms.RadioButton RBQueen;
        private System.Windows.Forms.Button BOK;
    }
}