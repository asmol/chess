namespace chess
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.SBMain = new System.Windows.Forms.StatusBar();
            this.SBPMove = new System.Windows.Forms.StatusBarPanel();
            this.SBPWhite = new System.Windows.Forms.StatusBarPanel();
            this.SBPBlack = new System.Windows.Forms.StatusBarPanel();
            this.MIComputer = new System.Windows.Forms.MenuItem();
            this.MIHuman = new System.Windows.Forms.MenuItem();
            this.MINew = new System.Windows.Forms.MenuItem();
            this.MIOpen = new System.Windows.Forms.MenuItem();
            this.MISave = new System.Windows.Forms.MenuItem();
            this.MISaveAs = new System.Windows.Forms.MenuItem();
            this.MIGame = new System.Windows.Forms.MenuItem();
            this.MIUndo = new System.Windows.Forms.MenuItem();
            this.MIRedo = new System.Windows.Forms.MenuItem();
            this.MIEdit = new System.Windows.Forms.MenuItem();
            this.MIAbout = new System.Windows.Forms.MenuItem();
            this.MIHelp = new System.Windows.Forms.MenuItem();
            this.MenuMain = new System.Windows.Forms.MainMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SBPMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBPWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBPBlack)).BeginInit();
            this.SuspendLayout();
            // 
            // SBMain
            // 
            this.SBMain.Location = new System.Drawing.Point(0, 348);
            this.SBMain.Name = "SBMain";
            this.SBMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.SBPMove,
            this.SBPWhite,
            this.SBPBlack});
            this.SBMain.ShowPanels = true;
            this.SBMain.Size = new System.Drawing.Size(327, 22);
            this.SBMain.TabIndex = 0;
            // 
            // SBPMove
            // 
            this.SBPMove.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.SBPMove.Name = "SBPMove";
            this.SBPMove.Width = 10;
            // 
            // SBPWhite
            // 
            this.SBPWhite.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.SBPWhite.Name = "SBPWhite";
            this.SBPWhite.Width = 10;
            // 
            // SBPBlack
            // 
            this.SBPBlack.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.SBPBlack.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.SBPBlack.Name = "SBPBlack";
            this.SBPBlack.Width = 291;
            // 
            // MIComputer
            // 
            this.MIComputer.Index = 0;
            this.MIComputer.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.MIComputer.Text = "With computer";
            // 
            // MIHuman
            // 
            this.MIHuman.Index = 1;
            this.MIHuman.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftN;
            this.MIHuman.Text = "With human";
            // 
            // MINew
            // 
            this.MINew.Index = 0;
            this.MINew.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MIComputer,
            this.MIHuman});
            this.MINew.Text = "New";
            // 
            // MIOpen
            // 
            this.MIOpen.Index = 1;
            this.MIOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.MIOpen.Text = "Open…";
            // 
            // MISave
            // 
            this.MISave.Index = 2;
            this.MISave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.MISave.Text = "Save";
            // 
            // MISaveAs
            // 
            this.MISaveAs.Index = 3;
            this.MISaveAs.Text = "Save as…";
            // 
            // MIGame
            // 
            this.MIGame.Index = 0;
            this.MIGame.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MINew,
            this.MIOpen,
            this.MISave,
            this.MISaveAs});
            this.MIGame.Text = "Game";
            // 
            // MIUndo
            // 
            this.MIUndo.Index = 0;
            this.MIUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.MIUndo.Text = "Undo";
            this.MIUndo.Click += new System.EventHandler(this.MIUndo_Click);
            // 
            // MIRedo
            // 
            this.MIRedo.Index = 1;
            this.MIRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
            this.MIRedo.Text = "Redo";
            this.MIRedo.Click += new System.EventHandler(this.MIRedo_Click);
            // 
            // MIEdit
            // 
            this.MIEdit.Index = 1;
            this.MIEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MIUndo,
            this.MIRedo});
            this.MIEdit.Text = "Edit";
            // 
            // MIAbout
            // 
            this.MIAbout.Index = 0;
            this.MIAbout.Text = "About";
            // 
            // MIHelp
            // 
            this.MIHelp.Index = 2;
            this.MIHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MIAbout});
            this.MIHelp.Text = "Help";
            // 
            // MenuMain
            // 
            this.MenuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MIGame,
            this.MIEdit,
            this.MIHelp});
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(327, 370);
            this.Controls.Add(this.SBMain);
            this.Menu = this.MenuMain;
            this.MinimumSize = new System.Drawing.Size(335, 397);
            this.Name = "FormMain";
            this.Text = "Chess";
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseClick);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.SBPMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBPWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBPBlack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBar SBMain;
        private System.Windows.Forms.StatusBarPanel SBPMove;
        private System.Windows.Forms.StatusBarPanel SBPWhite;
        private System.Windows.Forms.StatusBarPanel SBPBlack;
        private System.Windows.Forms.MenuItem MIComputer;
        private System.Windows.Forms.MenuItem MIHuman;
        private System.Windows.Forms.MenuItem MINew;
        private System.Windows.Forms.MenuItem MIOpen;
        private System.Windows.Forms.MenuItem MISave;
        private System.Windows.Forms.MenuItem MISaveAs;
        private System.Windows.Forms.MenuItem MIGame;
        private System.Windows.Forms.MenuItem MIUndo;
        private System.Windows.Forms.MenuItem MIRedo;
        private System.Windows.Forms.MenuItem MIEdit;
        private System.Windows.Forms.MenuItem MIAbout;
        private System.Windows.Forms.MenuItem MIHelp;
        private System.Windows.Forms.MainMenu MenuMain;

    }
}

