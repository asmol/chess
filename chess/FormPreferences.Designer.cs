namespace chess
{
    partial class FormPreferences
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
            this.TCMain = new System.Windows.Forms.TabControl();
            this.TPGeneral = new System.Windows.Forms.TabPage();
            this.GBTime = new System.Windows.Forms.GroupBox();
            this.MTBTimeBlack = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MTBTimeWhite = new System.Windows.Forms.MaskedTextBox();
            this.CBTimeEnabled = new System.Windows.Forms.CheckBox();
            this.GBBoard = new System.Windows.Forms.GroupBox();
            this.CBBoardSetting2 = new System.Windows.Forms.CheckBox();
            this.CBBoardSetting1 = new System.Windows.Forms.CheckBox();
            this.BOK = new System.Windows.Forms.Button();
            this.BCancel = new System.Windows.Forms.Button();
            this.TCMain.SuspendLayout();
            this.TPGeneral.SuspendLayout();
            this.GBTime.SuspendLayout();
            this.GBBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCMain
            // 
            this.TCMain.Controls.Add(this.TPGeneral);
            this.TCMain.Location = new System.Drawing.Point(8, 8);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedIndex = 0;
            this.TCMain.Size = new System.Drawing.Size(240, 185);
            this.TCMain.TabIndex = 0;
            // 
            // TPGeneral
            // 
            this.TPGeneral.Controls.Add(this.GBTime);
            this.TPGeneral.Controls.Add(this.GBBoard);
            this.TPGeneral.Location = new System.Drawing.Point(4, 22);
            this.TPGeneral.Name = "TPGeneral";
            this.TPGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TPGeneral.Size = new System.Drawing.Size(232, 159);
            this.TPGeneral.TabIndex = 0;
            this.TPGeneral.Text = "General";
            this.TPGeneral.UseVisualStyleBackColor = true;
            // 
            // GBTime
            // 
            this.GBTime.Controls.Add(this.MTBTimeBlack);
            this.GBTime.Controls.Add(this.label2);
            this.GBTime.Controls.Add(this.label1);
            this.GBTime.Controls.Add(this.MTBTimeWhite);
            this.GBTime.Controls.Add(this.CBTimeEnabled);
            this.GBTime.Location = new System.Drawing.Point(8, 82);
            this.GBTime.Name = "GBTime";
            this.GBTime.Size = new System.Drawing.Size(216, 69);
            this.GBTime.TabIndex = 1;
            this.GBTime.TabStop = false;
            this.GBTime.Text = "Time limit";
            // 
            // MTBTimeBlack
            // 
            this.MTBTimeBlack.Location = new System.Drawing.Point(155, 41);
            this.MTBTimeBlack.Mask = "00:00";
            this.MTBTimeBlack.Name = "MTBTimeBlack";
            this.MTBTimeBlack.PromptChar = ' ';
            this.MTBTimeBlack.Size = new System.Drawing.Size(53, 20);
            this.MTBTimeBlack.TabIndex = 4;
            this.MTBTimeBlack.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 41);
            this.label2.MinimumSize = new System.Drawing.Size(35, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Black";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.MinimumSize = new System.Drawing.Size(0, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "White";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MTBTimeWhite
            // 
            this.MTBTimeWhite.Location = new System.Drawing.Point(51, 41);
            this.MTBTimeWhite.Mask = "00:00";
            this.MTBTimeWhite.Name = "MTBTimeWhite";
            this.MTBTimeWhite.PromptChar = ' ';
            this.MTBTimeWhite.Size = new System.Drawing.Size(53, 20);
            this.MTBTimeWhite.TabIndex = 1;
            this.MTBTimeWhite.ValidatingType = typeof(System.DateTime);
            // 
            // CBTimeEnabled
            // 
            this.CBTimeEnabled.AutoSize = true;
            this.CBTimeEnabled.Location = new System.Drawing.Point(8, 16);
            this.CBTimeEnabled.Name = "CBTimeEnabled";
            this.CBTimeEnabled.Size = new System.Drawing.Size(65, 17);
            this.CBTimeEnabled.TabIndex = 0;
            this.CBTimeEnabled.Text = "Enabled";
            this.CBTimeEnabled.UseVisualStyleBackColor = true;
            this.CBTimeEnabled.CheckedChanged += new System.EventHandler(this.CBTimeEnabled_CheckedChanged);
            // 
            // GBBoard
            // 
            this.GBBoard.Controls.Add(this.CBBoardSetting2);
            this.GBBoard.Controls.Add(this.CBBoardSetting1);
            this.GBBoard.Location = new System.Drawing.Point(8, 8);
            this.GBBoard.Name = "GBBoard";
            this.GBBoard.Size = new System.Drawing.Size(216, 66);
            this.GBBoard.TabIndex = 0;
            this.GBBoard.TabStop = false;
            this.GBBoard.Text = "Board";
            // 
            // CBBoardSetting2
            // 
            this.CBBoardSetting2.AutoSize = true;
            this.CBBoardSetting2.Location = new System.Drawing.Point(8, 41);
            this.CBBoardSetting2.Name = "CBBoardSetting2";
            this.CBBoardSetting2.Size = new System.Drawing.Size(158, 17);
            this.CBBoardSetting2.TabIndex = 1;
            this.CBBoardSetting2.Text = "Reverse board at every turn";
            this.CBBoardSetting2.UseVisualStyleBackColor = true;
            // 
            // CBBoardSetting1
            // 
            this.CBBoardSetting1.AutoSize = true;
            this.CBBoardSetting1.Location = new System.Drawing.Point(8, 16);
            this.CBBoardSetting1.Name = "CBBoardSetting1";
            this.CBBoardSetting1.Size = new System.Drawing.Size(89, 17);
            this.CBBoardSetting1.TabIndex = 0;
            this.CBBoardSetting1.Text = "Play as black";
            this.CBBoardSetting1.UseVisualStyleBackColor = true;
            // 
            // BOK
            // 
            this.BOK.Location = new System.Drawing.Point(8, 201);
            this.BOK.Name = "BOK";
            this.BOK.Size = new System.Drawing.Size(116, 24);
            this.BOK.TabIndex = 1;
            this.BOK.Text = "OK";
            this.BOK.UseVisualStyleBackColor = true;
            this.BOK.Click += new System.EventHandler(this.BOK_Click);
            // 
            // BCancel
            // 
            this.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancel.Location = new System.Drawing.Point(132, 201);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(116, 24);
            this.BCancel.TabIndex = 2;
            this.BCancel.Text = "Cancel";
            this.BCancel.UseVisualStyleBackColor = true;
            // 
            // FormPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancel;
            this.ClientSize = new System.Drawing.Size(256, 233);
            this.Controls.Add(this.BCancel);
            this.Controls.Add(this.BOK);
            this.Controls.Add(this.TCMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPreferences";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.TCMain.ResumeLayout(false);
            this.TPGeneral.ResumeLayout(false);
            this.GBTime.ResumeLayout(false);
            this.GBTime.PerformLayout();
            this.GBBoard.ResumeLayout(false);
            this.GBBoard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TCMain;
        private System.Windows.Forms.TabPage TPGeneral;
        private System.Windows.Forms.GroupBox GBTime;
        private System.Windows.Forms.MaskedTextBox MTBTimeBlack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox MTBTimeWhite;
        private System.Windows.Forms.CheckBox CBTimeEnabled;
        private System.Windows.Forms.GroupBox GBBoard;
        private System.Windows.Forms.CheckBox CBBoardSetting2;
        private System.Windows.Forms.CheckBox CBBoardSetting1;
        private System.Windows.Forms.Button BOK;
        private System.Windows.Forms.Button BCancel;
    }
}