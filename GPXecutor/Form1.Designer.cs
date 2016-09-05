namespace GPXecutor
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zeitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPointView = new System.Windows.Forms.DataGridView();
            this.point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elevation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.track_box = new System.Windows.Forms.PictureBox();
            this.track_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPointView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_box)).BeginInit();
            this.track_contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem,
            this.speichernToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.öffnenToolStripMenuItem.Text = "Öffnen";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zeitToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.editToolStripMenuItem.Text = "Bearbeiten";
            // 
            // zeitToolStripMenuItem
            // 
            this.zeitToolStripMenuItem.Name = "zeitToolStripMenuItem";
            this.zeitToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.zeitToolStripMenuItem.Text = "Zeit";
            this.zeitToolStripMenuItem.Click += new System.EventHandler(this.zeitToolStripMenuItem_Click);
            // 
            // dataPointView
            // 
            this.dataPointView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataPointView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPointView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.point,
            this.time,
            this.speed,
            this.elevation,
            this.latitute,
            this.longitude});
            this.dataPointView.Location = new System.Drawing.Point(12, 27);
            this.dataPointView.Name = "dataPointView";
            this.dataPointView.Size = new System.Drawing.Size(497, 522);
            this.dataPointView.TabIndex = 1;
            // 
            // point
            // 
            this.point.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.point.HeaderText = "Pt";
            this.point.Name = "point";
            // 
            // time
            // 
            this.time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.time.HeaderText = "Time";
            this.time.Name = "time";
            this.time.Width = 55;
            // 
            // speed
            // 
            this.speed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.speed.HeaderText = "Speed";
            this.speed.Name = "speed";
            this.speed.Width = 63;
            // 
            // elevation
            // 
            this.elevation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.elevation.HeaderText = "Elevation";
            this.elevation.Name = "elevation";
            this.elevation.Width = 76;
            // 
            // latitute
            // 
            this.latitute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.latitute.HeaderText = "Latitute";
            this.latitute.Name = "latitute";
            this.latitute.Width = 67;
            // 
            // longitude
            // 
            this.longitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.longitude.HeaderText = "Longitude";
            this.longitude.Name = "longitude";
            this.longitude.Width = 79;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.track_box);
            this.panel1.Location = new System.Drawing.Point(515, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 522);
            this.panel1.TabIndex = 2;
            // 
            // track_box
            // 
            this.track_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.track_box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.track_box.ContextMenuStrip = this.track_contextMenuStrip;
            this.track_box.Location = new System.Drawing.Point(3, 3);
            this.track_box.Name = "track_box";
            this.track_box.Size = new System.Drawing.Size(473, 378);
            this.track_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.track_box.TabIndex = 0;
            this.track_box.TabStop = false;
            this.track_box.SizeChanged += new System.EventHandler(this.track_box_SizeChanged);
            this.track_box.MouseDown += new System.Windows.Forms.MouseEventHandler(this.track_box_MouseDown);
            this.track_box.MouseEnter += new System.EventHandler(this.track_box_MouseEnter);
            this.track_box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.track_box_MouseMove);
            this.track_box.MouseUp += new System.Windows.Forms.MouseEventHandler(this.track_box_MouseUp);
            this.track_box.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.track_box_MouseWheel);
            // 
            // track_contextMenuStrip
            // 
            this.track_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.centerToolStripMenuItem});
            this.track_contextMenuStrip.Name = "track_contextMenuStrip";
            this.track_contextMenuStrip.Size = new System.Drawing.Size(110, 26);
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            this.centerToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.centerToolStripMenuItem.Text = "Center";
            this.centerToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataPointView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPointView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.track_box)).EndInit();
            this.track_contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataPointView;
        private System.Windows.Forms.DataGridViewTextBoxColumn point;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn elevation;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitute;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitude;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox track_box;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zeitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip track_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
    }
}

