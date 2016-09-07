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
            this.alt_pictureBox = new System.Windows.Forms.PictureBox();
            this.track_box = new System.Windows.Forms.PictureBox();
            this.track_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.after_del_timer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.total_time_lable = new System.Windows.Forms.Label();
            this.motion_time_lable = new System.Windows.Forms.Label();
            this.max_ele_lable = new System.Windows.Forms.Label();
            this.min_ele_lable = new System.Windows.Forms.Label();
            this.max_speed_lable = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPointView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alt_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_box)).BeginInit();
            this.track_contextMenuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
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
            this.dataPointView.Size = new System.Drawing.Size(497, 382);
            this.dataPointView.TabIndex = 1;
            this.dataPointView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataPointView_RowEnter);
            this.dataPointView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataPointView_UserDeletingRow);
            this.dataPointView.MouseEnter += new System.EventHandler(this.dataPointView_MouseEnter);
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
            this.panel1.Controls.Add(this.alt_pictureBox);
            this.panel1.Controls.Add(this.track_box);
            this.panel1.Location = new System.Drawing.Point(515, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 522);
            this.panel1.TabIndex = 2;
            // 
            // alt_pictureBox
            // 
            this.alt_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alt_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.alt_pictureBox.Location = new System.Drawing.Point(3, 387);
            this.alt_pictureBox.Name = "alt_pictureBox";
            this.alt_pictureBox.Size = new System.Drawing.Size(473, 130);
            this.alt_pictureBox.TabIndex = 1;
            this.alt_pictureBox.TabStop = false;
            this.alt_pictureBox.SizeChanged += new System.EventHandler(this.alt_pictureBox_SizeChanged);
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
            // after_del_timer
            // 
            this.after_del_timer.Tick += new System.EventHandler(this.after_del_timer_Tick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.max_speed_lable);
            this.panel2.Controls.Add(this.min_ele_lable);
            this.panel2.Controls.Add(this.max_ele_lable);
            this.panel2.Controls.Add(this.motion_time_lable);
            this.panel2.Controls.Add(this.total_time_lable);
            this.panel2.Location = new System.Drawing.Point(12, 415);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 134);
            this.panel2.TabIndex = 3;
            // 
            // total_time_lable
            // 
            this.total_time_lable.AutoSize = true;
            this.total_time_lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_time_lable.Location = new System.Drawing.Point(3, 4);
            this.total_time_lable.Name = "total_time_lable";
            this.total_time_lable.Size = new System.Drawing.Size(79, 13);
            this.total_time_lable.TabIndex = 0;
            this.total_time_lable.Text = "Gesamt Zeit:";
            // 
            // motion_time_lable
            // 
            this.motion_time_lable.AutoSize = true;
            this.motion_time_lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motion_time_lable.Location = new System.Drawing.Point(3, 21);
            this.motion_time_lable.Name = "motion_time_lable";
            this.motion_time_lable.Size = new System.Drawing.Size(110, 13);
            this.motion_time_lable.TabIndex = 1;
            this.motion_time_lable.Text = "Zeit in Bewegung:";
            // 
            // max_ele_lable
            // 
            this.max_ele_lable.AutoSize = true;
            this.max_ele_lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max_ele_lable.Location = new System.Drawing.Point(3, 40);
            this.max_ele_lable.Name = "max_ele_lable";
            this.max_ele_lable.Size = new System.Drawing.Size(97, 13);
            this.max_ele_lable.TabIndex = 2;
            this.max_ele_lable.Text = "Maximale Höhe:";
            // 
            // min_ele_lable
            // 
            this.min_ele_lable.AutoSize = true;
            this.min_ele_lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.min_ele_lable.Location = new System.Drawing.Point(3, 59);
            this.min_ele_lable.Name = "min_ele_lable";
            this.min_ele_lable.Size = new System.Drawing.Size(94, 13);
            this.min_ele_lable.TabIndex = 3;
            this.min_ele_lable.Text = "Minimale Höhe:";
            // 
            // max_speed_lable
            // 
            this.max_speed_lable.AutoSize = true;
            this.max_speed_lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max_speed_lable.Location = new System.Drawing.Point(3, 77);
            this.max_speed_lable.Name = "max_speed_lable";
            this.max_speed_lable.Size = new System.Drawing.Size(160, 13);
            this.max_speed_lable.TabIndex = 4;
            this.max_speed_lable.Text = "Maximale Geschwindigkeit:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataPointView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "GPXecutor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPointView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alt_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_box)).EndInit();
            this.track_contextMenuStrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Timer after_del_timer;
        private System.Windows.Forms.PictureBox alt_pictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label total_time_lable;
        private System.Windows.Forms.Label motion_time_lable;
        private System.Windows.Forms.Label max_ele_lable;
        private System.Windows.Forms.Label max_speed_lable;
        private System.Windows.Forms.Label min_ele_lable;
    }
}

