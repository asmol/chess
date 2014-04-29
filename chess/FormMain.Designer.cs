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
<<<<<<< HEAD
            this.TCMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PBoard = new System.Windows.Forms.Panel();
            this.TSMain = new System.Windows.Forms.ToolStrip();
            this.TSS1 = new System.Windows.Forms.ToolStripSeparator();
            this.MIPreferences = new System.Windows.Forms.MenuItem();
            this.MISeparator = new System.Windows.Forms.MenuItem();
            this.TSS2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSBComputer = new System.Windows.Forms.ToolStripButton();
            this.TSBHuman = new System.Windows.Forms.ToolStripButton();
            this.TSBOpen = new System.Windows.Forms.ToolStripButton();
            this.TSBSave = new System.Windows.Forms.ToolStripButton();
            this.TSBUndo = new System.Windows.Forms.ToolStripButton();
            this.TSBRedo = new System.Windows.Forms.ToolStripButton();
            this.TSBPreferences = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.SBPMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBPWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBPBlack)).BeginInit();
            this.TCMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.TSMain.SuspendLayout();
=======
            ((System.ComponentModel.ISupportInitialize)(this.SBPMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBPWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBPBlack)).BeginInit();
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
            this.SuspendLayout();
            // 
            // SBMain
            // 
<<<<<<< HEAD
            this.SBMain.Location = new System.Drawing.Point(0, 318);
=======
            this.SBMain.Location = new System.Drawing.Point(0, 348);
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
            this.SBMain.Name = "SBMain";
            this.SBMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.SBPMove,
            this.SBPWhite,
            this.SBPBlack});
            this.SBMain.ShowPanels = true;
<<<<<<< HEAD
            this.SBMain.Size = new System.Drawing.Size(512, 22);
=======
            this.SBMain.Size = new System.Drawing.Size(327, 22);
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
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
<<<<<<< HEAD
            this.SBPBlack.Width = 475;
=======
            this.SBPBlack.Width = 291;
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
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
<<<<<<< HEAD
            this.MIRedo,
            this.MISeparator,
            this.MIPreferences});
=======
            this.MIRedo});
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
            this.MIEdit.Text = "Edit";
            // 
            // MIAbout
            // 
            this.MIAbout.Index = 0;
<<<<<<< HEAD
            this.MIAbout.Text = "About…";
=======
            this.MIAbout.Text = "About";
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
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
<<<<<<< HEAD
            // TCMain
            // 
            this.TCMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TCMain.Controls.Add(this.tabPage1);
            this.TCMain.Location = new System.Drawing.Point(272, 32);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedIndex = 0;
            this.TCMain.Size = new System.Drawing.Size(232, 277);
            this.TCMain.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(224, 251);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "History";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(8, 8);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(208, 235);
            this.textBox1.TabIndex = 0;
            // 
            // PBoard
            // 
            this.PBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PBoard.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.PBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBoard.Location = new System.Drawing.Point(8, 32);
            this.PBoard.Name = "PBoard";
            this.PBoard.Size = new System.Drawing.Size(256, 277);
            this.PBoard.TabIndex = 2;
            this.PBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PBoard_MouseClick);
            // 
            // TSMain
            // 
            this.TSMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSBComputer,
            this.TSBHuman,
            this.TSBOpen,
            this.TSBSave,
            this.TSS1,
            this.TSBUndo,
            this.TSBRedo,
            this.TSS2,
            this.TSBPreferences});
            this.TSMain.Location = new System.Drawing.Point(0, 0);
            this.TSMain.Name = "TSMain";
            this.TSMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TSMain.Size = new System.Drawing.Size(512, 25);
            this.TSMain.TabIndex = 3;
            this.TSMain.Text = "toolStrip1";
            // 
            // TSS1
            // 
            this.TSS1.Name = "TSS1";
            this.TSS1.Size = new System.Drawing.Size(6, 25);
            // 
            // MIPreferences
            // 
            this.MIPreferences.Index = 3;
            this.MIPreferences.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.MIPreferences.Text = "Preferences…";
            this.MIPreferences.Click += new System.EventHandler(this.MIPreferences_Click);
            // 
            // MISeparator
            // 
            this.MISeparator.Index = 2;
            this.MISeparator.Text = "-";
            // 
            // TSS2
            // 
            this.TSS2.Name = "TSS2";
            this.TSS2.Size = new System.Drawing.Size(6, 25);
            // 
            // TSBComputer
            // 
            this.TSBComputer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBComputer.Image = global::chess.Properties.Resources.Computer;
            this.TSBComputer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBComputer.Name = "TSBComputer";
            this.TSBComputer.Size = new System.Drawing.Size(23, 22);
            this.TSBComputer.Text = "New game with computer";
            // 
            // TSBHuman
            // 
            this.TSBHuman.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBHuman.Image = global::chess.Properties.Resources.Human;
            this.TSBHuman.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBHuman.Name = "TSBHuman";
            this.TSBHuman.Size = new System.Drawing.Size(23, 22);
            this.TSBHuman.Text = "New game with human";
            // 
            // TSBOpen
            // 
            this.TSBOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBOpen.Image = global::chess.Properties.Resources.Open;
            this.TSBOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBOpen.Name = "TSBOpen";
            this.TSBOpen.Size = new System.Drawing.Size(23, 22);
            this.TSBOpen.Text = "Open";
            // 
            // TSBSave
            // 
            this.TSBSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBSave.Image = global::chess.Properties.Resources.Save;
            this.TSBSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBSave.Name = "TSBSave";
            this.TSBSave.Size = new System.Drawing.Size(23, 22);
            this.TSBSave.Text = "Save";
            // 
            // TSBUndo
            // 
            this.TSBUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBUndo.Image = global::chess.Properties.Resources.Undo;
            this.TSBUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBUndo.Name = "TSBUndo";
            this.TSBUndo.Size = new System.Drawing.Size(23, 22);
            this.TSBUndo.Text = "Undo";
            this.TSBUndo.Click += new System.EventHandler(this.TSBUndo_Click);
            // 
            // TSBRedo
            // 
            this.TSBRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBRedo.Image = global::chess.Properties.Resources.Redo;
            this.TSBRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBRedo.Name = "TSBRedo";
            this.TSBRedo.Size = new System.Drawing.Size(23, 22);
            this.TSBRedo.Text = "Redo";
            this.TSBRedo.Click += new System.EventHandler(this.TSBRedo_Click);
            // 
            // TSBPreferences
            // 
            this.TSBPreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBPreferences.Image = global::chess.Properties.Resources.Preferences;
            this.TSBPreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBPreferences.Name = "TSBPreferences";
            this.TSBPreferences.Size = new System.Drawing.Size(23, 22);
            this.TSBPreferences.Text = "Preferences";
            this.TSBPreferences.Click += new System.EventHandler(this.TSBPreferences_Click);
            // 
=======
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(512, 340);
            this.Controls.Add(this.TSMain);
            this.Controls.Add(this.PBoard);
            this.Controls.Add(this.TCMain);
            this.Controls.Add(this.SBMain);
            this.Menu = this.MenuMain;
            this.MinimumSize = new System.Drawing.Size(528, 378);
            this.Name = "FormMain";
            this.Text = "Chess";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
=======
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(327, 370);
            this.Controls.Add(this.SBMain);
            this.Menu = this.MenuMain;
            this.MinimumSize = new System.Drawing.Size(335, 397);
            this.Name = "FormMain";
            this.Text = "Chess";
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseClick);
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.SBPMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBPWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SBPBlack)).EndInit();
<<<<<<< HEAD
            this.TCMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.TSMain.ResumeLayout(false);
            this.TSMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
=======
            this.ResumeLayout(false);
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439

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
<<<<<<< HEAD
        private System.Windows.Forms.TabControl TCMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel PBoard;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStrip TSMain;
        private System.Windows.Forms.ToolStripButton TSBOpen;
        private System.Windows.Forms.ToolStripButton TSBSave;
        private System.Windows.Forms.ToolStripSeparator TSS1;
        private System.Windows.Forms.ToolStripButton TSBUndo;
        private System.Windows.Forms.ToolStripButton TSBRedo;
        private System.Windows.Forms.ToolStripButton TSBComputer;
        private System.Windows.Forms.ToolStripButton TSBHuman;
        private System.Windows.Forms.MenuItem MISeparator;
        private System.Windows.Forms.MenuItem MIPreferences;
        private System.Windows.Forms.ToolStripSeparator TSS2;
        private System.Windows.Forms.ToolStripButton TSBPreferences;
=======
>>>>>>> 87d586307a4356bd8125dbb16bd6b8b14a1cd439

    }
}

