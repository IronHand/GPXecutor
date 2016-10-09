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
    public partial class Geocaching : Form
    {
        gpx_master gm = new gpx_master();

        public Geocaching()
        {
            InitializeComponent();
        }

        private void Geocaching_Load(object sender, EventArgs e)
        {
            gm = new gpx_master();
            wb.Navigate("https://www.geocaching.com");

            timer1.Interval = 500;
            timer1.Enabled = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //gm.get_chach_from_groundspeak("https://www.geocaching.com/geocache/GC5E94P_big-u?guid=d840518f-f504-4265-9e2f-5f12e7ec5107", wb);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wb.Navigate("https://www.geocaching.com/account/login?returnUrl=%2fplay");
        }

        private void wb_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            wb.Navigate(wb.StatusText);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gm.site_parsed == true)
            {
                gm.site_parsed = false;

                geoID_textBox.Text = gm.last_parsed_cach.geoID;
                name_textBox.Text = gm.last_parsed_cach.name;
                lat_textBox.Text = gm.last_parsed_cach.lat.ToString("F6");
                lon_textBox.Text = gm.last_parsed_cach.lon.ToString("F6");
                hint_textBox.Text = gm.last_parsed_cach.hints;

                long_desc_TextBox.Text = gm.last_parsed_cach.short_description + "\r\n" + gm.last_parsed_cach.long_description;
            }
        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            url_textBox.Text = wb.Url.ToString();
            gm.pack_cash(wb);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wb.Navigate(url_textBox.Text);
        }

        private void hint_textBox_DoubleClick(object sender, EventArgs e)
        {
            hint_textBox.Text = gm.decrypt_hint(hint_textBox.Text);
        }
    }
}
