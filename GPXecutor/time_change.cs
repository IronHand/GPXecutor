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
    public partial class time_change : Form
    {
        public time_change()
        {
            InitializeComponent();
        }

        public TimeSpan time_span = new TimeSpan(0, 0, 0);

        private void time_change_Load(object sender, EventArgs e)
        {
            time_textBox.Text = time_span.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan add_hour = new TimeSpan(1, 0, 0);
            time_span += add_hour;
            time_textBox.Text = time_span.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimeSpan add_hour = new TimeSpan(1, 0, 0);
            time_span -= add_hour;
            time_textBox.Text = time_span.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            time_span = new TimeSpan(0, 0, 0);
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimeSpan add_time = new TimeSpan(0, 1, 0);
            time_span += add_time;
            time_textBox.Text = time_span.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TimeSpan add_time = new TimeSpan(0, 1, 0);
            time_span -= add_time;
            time_textBox.Text = time_span.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TimeSpan add_time = new TimeSpan(0, 0, 1);
            time_span += add_time;
            time_textBox.Text = time_span.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TimeSpan add_time = new TimeSpan(0, 0, 1);
            time_span -= add_time;
            time_textBox.Text = time_span.ToString();
        }
    }
}
