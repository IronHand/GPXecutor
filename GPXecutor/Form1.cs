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
        int last_zoom_fak = 1000;
        int zoom_fak = 1000;

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

            //point_list[0] = new PointF(0, 0);

            foreach (gpx_master.gpx_trkpt point in pt_list)
            {
                float R = 6378137;

                float x = -(float)(R * Math.Cos(point.lat) * Math.Cos(point.lon));
                float y = -(float)(R * Math.Cos(point.lat) * Math.Sin(point.lon));
                float z = (float)(R * Math.Sin(point.lat));

                int focal_length = zoom_fak;//Convert.ToInt32(numericUpDown1.Value);

                float projected_x = x * focal_length / (focal_length + z);
                float projected_y = y * focal_length / (focal_length + z);

                projected_x -= (float)Convert.ToDouble(focal_length * 0.121);
                projected_y -= (float)Convert.ToDouble(focal_length * 2.255);

                projected_x -= track_offset.X + mouse_diff.X;
                projected_y -= track_offset.Y + mouse_diff.Y;


                PointF p = new PointF(projected_x, projected_y);
                point_list[p_count] = p;
                p_count++;
            }

            g.Clear(Color.LightGreen);
            g.DrawLines(pen, point_list);
            
            g.Dispose();

            track_box.Image = bmp;

        }

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

            draw_track(pt_list);
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            track_offset.X = 0;
            track_offset.Y = 0;

            mouse_diff.X = 0;
            mouse_diff.Y = 0;

            draw_track(pt_list);
        }

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

    }
}
