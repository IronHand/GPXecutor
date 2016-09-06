using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GPXecutor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        gpx_master gpx_tool = new gpx_master();

        List<gpx_master.gpx_trkpt> pt_list;
        string list_name;

        Point track_offset = new Point(0, 0);
        Point mouse_diff = new Point(0, 0);
        int zoom_fak = 1000;
        double last_player_lat = 0;
        double last_player_lon = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataPointView.VirtualMode = true;
        }

        private void fill_dataView(List<gpx_master.gpx_trkpt> pt_list, bool add_to_list = false)
        {
            if (add_to_list != true)
            {
                dataPointView.Rows.Clear();
            }

            DataGridViewRow[] new_row_list = new DataGridViewRow[pt_list.Count];
            DataGridViewRowCollection row_collection = new DataGridViewRowCollection(dataPointView);

            foreach (gpx_master.gpx_trkpt point in pt_list)
            {
                DataGridViewRow new_row = new DataGridViewRow();

                new_row.Cells.Add(new DataGridViewTextBoxCell { Value = point.id });
                new_row.Cells.Add(new DataGridViewTextBoxCell { Value = point.time });
                new_row.Cells.Add(new DataGridViewTextBoxCell { Value = point.speed });
                new_row.Cells.Add(new DataGridViewTextBoxCell { Value = point.ele });
                new_row.Cells.Add(new DataGridViewTextBoxCell { Value = point.lat });
                new_row.Cells.Add(new DataGridViewTextBoxCell { Value = point.lon });

                new_row_list[point.id - 1] = new_row;
            }

            dataPointView.Rows.AddRange(new_row_list);
        }

        private PointF convert_angles_to_xy(double lat, double lon)
        {
            PointF new_xy_point = new PointF(0, 0);

            float R = 6378137;

            float x = (float)(R * Math.Cos(lat) * Math.Cos(lon));
            float y = -(float)(R * Math.Cos(lat) * Math.Sin(lon));
            float z = (float)(R * Math.Sin(lat));

            int focal_length = zoom_fak;//Convert.ToInt32(numericUpDown1.Value);

            float projected_x = x * focal_length / (focal_length + z);
            float projected_y = y * focal_length / (focal_length + z);

            projected_x -= (float)Convert.ToDouble(focal_length * -0.121) - 500;
            projected_y -= (float)Convert.ToDouble(focal_length * 2.23) - 50;

            new_xy_point.X = projected_x;
            new_xy_point.Y = projected_y;

            return new_xy_point;
        }

        //Drawing Functions-------------------------------------------------------------------------
        private void draw_track(List<gpx_master.gpx_trkpt> pt_list)
        {
            if (pt_list == null)
            {
                return;
            }
            Bitmap bmp = new Bitmap(track_box.Width, track_box.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Red, 3.0f);

            PointF[] point_list = new PointF[pt_list.Count];
            PointF last_point = new PointF(0,0);
            int p_count = 0;

            foreach (gpx_master.gpx_trkpt point in pt_list)
            {
                PointF xy_point = convert_angles_to_xy(point.lat, point.lon);

                xy_point.X -= track_offset.X + mouse_diff.X;
                xy_point.Y -= track_offset.Y + mouse_diff.Y;

                point_list[p_count] = xy_point;
                p_count++;
            }

            g.Clear(Color.LightGreen);
            g.DrawLines(pen, point_list);
            
            g.Dispose();

            track_box.Image = bmp;
        }

        private void draw_single_point(double lat, double lon)
        {
            Bitmap bmp = (Bitmap)track_box.Image;

            if (bmp != null)
            {
                Graphics g = Graphics.FromImage(bmp);
                Pen pen = new Pen(Color.Black, 1.0f);

                PointF xy_point = convert_angles_to_xy(lat, lon);

                xy_point.X -= track_offset.X + mouse_diff.X;
                xy_point.Y -= track_offset.Y + mouse_diff.Y;

                g.DrawEllipse(pen, xy_point.X - 10, xy_point.Y - 10, 20, 20);
                g.Dispose();

                track_box.Image = bmp;
            }
        }

        private void draw_elevation(List<gpx_master.gpx_trkpt> pt_list)
        {
            if (pt_list == null)
            {
                return;
            }
            Bitmap bmp = new Bitmap(alt_pictureBox.Width, alt_pictureBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black, 1.0f);

            PointF[] point_list = new PointF[pt_list.Count];
            int p_count = 0;

            foreach (gpx_master.gpx_trkpt point in pt_list)
            {
                point_list[p_count] = new PointF(p_count, (float)point.ele / 10);
                p_count++;
            }

            g.Clear(Color.LightGray);
            g.DrawLines(pen, point_list);

            alt_pictureBox.Image = bmp;
        }
        //-------------------------------------------------------------------------------------------
        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                load_gpx_xml(ofd.FileName);
            }
        }

        private void load_gpx_xml(string file_path)
        {
            pt_list = gpx_tool.load_gpx_to_list(file_path);
            list_name = gpx_tool.last_loaded_gpx_name;

            this.Text = "GPXecutor" + " - " + list_name;

            fill_dataView(pt_list);
            draw_track(pt_list);

            draw_elevation(pt_list);
        }

        //Track Box Controlls
        private void track_box_SizeChanged(object sender, EventArgs e)
        {
            draw_track(pt_list);
        }

        Point last_mouse_pos;
        private void track_box_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                last_mouse_pos = MousePosition;
            }
        }

        private void track_box_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
               track_offset.X += mouse_diff.X;
               track_offset.Y += mouse_diff.Y;
            }
        }

        private void track_box_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouse_diff = new Point(last_mouse_pos.X - MousePosition.X, last_mouse_pos.Y - MousePosition.Y);
                draw_track(pt_list);
                draw_single_point(last_player_lat, last_player_lon);
            }
            else
            {
            }
        }

        private void track_box_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoom_fak += 1000;
            }
            else if (e.Delta < 0 & zoom_fak > 1000)
            {
                zoom_fak -= 1000;
            }

            mouse_diff.X = 0;
            mouse_diff.Y = 0;

            draw_track(pt_list);
            draw_single_point(last_player_lat, last_player_lon);
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            track_offset.X = 0;
            track_offset.Y = 0;

            mouse_diff.X = 0;
            mouse_diff.Y = 0;

            draw_track(pt_list);
        }

        //Bearbeiten Tool Menü---------------------------------------------------------------------------------------
        private void zeitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            time_change tc = new time_change();
            tc.ShowDialog();

            if (tc.time_span != new TimeSpan(0,0,0))
            {
                List<gpx_master.gpx_trkpt> temp_list = new List<gpx_master.gpx_trkpt>();
                foreach (gpx_master.gpx_trkpt point in pt_list)
                {
                    gpx_master.gpx_trkpt pd = pt_list.Find(x => x.id.Equals(point.id));
                    pd.time += tc.time_span;

                    temp_list.Add(pd);
                }

                pt_list = temp_list;

                fill_dataView(pt_list);
            }
        }
        //-------------------------------------------------------------------------------------------------------------

        private void track_box_MouseEnter(object sender, EventArgs e)
        {
            track_box.Focus();
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                gpx_tool.save_list_to_gpx(pt_list, sfd.FileName);
            }
        }

        //Data Grid View----------------------------------------------------------------------------------------------------------------------------------------------------
        private void dataPointView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            last_player_lat = Convert.ToDouble(dataPointView.Rows[e.RowIndex].Cells[4].Value);
            last_player_lon = Convert.ToDouble(dataPointView.Rows[e.RowIndex].Cells[5].Value);

            mouse_diff.X = 0;
            mouse_diff.Y = 0;

            draw_track(pt_list);
            draw_single_point(last_player_lat, last_player_lon);

            dataPointView.Rows[e.RowIndex].Selected = true;
        }

        private void dataPointView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                dataPointView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            gpx_master.gpx_trkpt removed_point = pt_list.Find(x => x.id.Equals(Convert.ToInt32(e.Row.Cells[0].Value)));
            pt_list.Remove(removed_point);

            after_del_timer.Enabled = true;
        }

        private void dataPointView_MouseEnter(object sender, EventArgs e)
        {
            dataPointView.Focus();
        }

        private void after_del_timer_Tick(object sender, EventArgs e)
        {
            dataPointView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataPointView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataPointView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataPointView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataPointView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataPointView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
