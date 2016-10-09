using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;

namespace GPXecutor
{
    class gpx_master
    {
        public struct gpx_trkpt{

            public int id;
            public double lat;
            public double lon;
            public double ele;
            public double speed;
            public double speed_in_kmh;
            public DateTime time;
        };

        public struct track_stats
        {
            public double max_ele;
            public double min_ele;
            public double max_speed;
            public double mead_speed;
            public TimeSpan total_time;
            public TimeSpan motion_time; 
        };

        public struct geocash
        {
            public string geoID;
            public string name;
            public DateTime time;
            public string type;
            public double lat;
            public double lon;
            public string owner;
            public string container;
            public float difficult;
            public float terrain;
            public string country;
            public string state;

            public string short_description;
            public string long_description;
            public string hints;
        };

        public string last_loaded_gpx_name = "";

        public List<gpx_trkpt> load_gpx_to_list(string file_path)
        {
            XmlReaderSettings reader_settings = new XmlReaderSettings();
            reader_settings.IgnoreWhitespace = true;
            XmlReader reader = XmlReader.Create(file_path, reader_settings);
            int track_point_count = 0;

            gpx_trkpt add_new_point = new gpx_trkpt();

            List<gpx_trkpt> pt_list = new List<gpx_trkpt>();

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                        // Anweisungen
                        break;
                    case XmlNodeType.Element:
                        if (reader.Name == "name")
                        {
                            reader.Read();
                            last_loaded_gpx_name = reader.Value;
                        }
                        else if (reader.Name == "desc")
                        {
                        }
                        else if (reader.Name == "trkseg")
                        {
                        }
                        else if (reader.Name == "trkpt") //Track Point
                        {
                            track_point_count++;
                            add_new_point = new gpx_trkpt(); //erschaffe neuen Trackpoint
                            add_new_point.id = track_point_count;

                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    string reader_v = reader.Value.Replace(".", ",");
                                    if (reader.Name == "lat")
                                    {
                                        add_new_point.lat = Convert.ToDouble(reader_v);
                                    }
                                    else if (reader.Name == "lon")
                                    {
                                        add_new_point.lon = Convert.ToDouble(reader_v);
                                    }
                                }
                            }
                        }
                        else if (reader.Name == "ele")
                        {
                            if (add_new_point.id == track_point_count)
                            {
                                reader.Read(); //Lies das Textelement ein
                                string reader_v = reader.Value.Replace(".", ",");
                                add_new_point.ele = Convert.ToDouble(reader_v);
                            }
                        }
                        else if (reader.Name == "speed")
                        {
                            if (add_new_point.id == track_point_count)
                            {
                                reader.Read();
                                string reader_v = reader.Value.Replace(".", ",");
                                add_new_point.speed = Convert.ToDouble(reader_v);
                                add_new_point.speed_in_kmh = add_new_point.speed * 3.6;
                            }
                        }
                        else if (reader.Name == "time")
                        {
                            if (add_new_point.id == track_point_count)
                            {
                                reader.Read();
                                add_new_point.time = DateTime.ParseExact(reader.Value, "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal);
                            }
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if (reader.Name == "trkpt") //Track Point wird geschlossen
                        {
                            pt_list.Add(add_new_point);
                        }
                        break;
                }
            }

            return pt_list;
        }

        public void save_list_to_gpx(List<gpx_trkpt> pt_list, string file_path)
        {
            XmlWriterSettings writer_settings = new XmlWriterSettings();
            writer_settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(file_path, writer_settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("gpx");
            writer.WriteStartElement("trk");
            writer.WriteStartElement("trkseg");

            foreach (gpx_trkpt point in pt_list)
            {
                writer.WriteStartElement("trkpt");
                writer.WriteAttributeString("lat", point.lat.ToString().Replace(",", "."));
                writer.WriteAttributeString("lon", point.lon.ToString().Replace(",", "."));
                writer.WriteElementString("ele", point.ele.ToString().Replace(",", "."));
                writer.WriteElementString("speed", point.speed.ToString().Replace(",", "."));
                writer.WriteElementString("time", point.time.ToString("yyyy-MM-ddTHH:mm:ss") + "Z");

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Close();
        }

        public track_stats get_track_statistics(List<gpx_trkpt> pt_list)
        {
            track_stats stats = new track_stats();
            stats.max_ele = 0;
            stats.min_ele = 1000000;
            stats.max_speed = 0;
            stats.total_time = new TimeSpan();
            stats.motion_time = new TimeSpan();
            stats.mead_speed = 0;

            DateTime last_time = pt_list[0].time;

            foreach (gpx_trkpt point in pt_list)
            {
                if (point.ele > stats.max_ele)
                {
                    stats.max_ele = point.ele;
                }

                if (point.ele < stats.min_ele)
                {
                    stats.min_ele = point.ele;
                }

                if (point.speed > stats.max_speed)
                {
                    stats.max_speed = point.speed;
                }

                stats.mead_speed += point.speed;

                stats.total_time += point.time - last_time;

                if (point.speed > 0)
                {
                    stats.motion_time += point.time - last_time;
                }

                last_time = point.time;
            }

            stats.mead_speed /= pt_list.Count;

            return stats;
        }

        //Geocach Funktions--------------------------------------------------------------------------------------------------------------

        System.Windows.Forms.WebBrowser wb;

        public double degree_to_decimal(int degrees, double minutes, double seconds)
        {
            double output = 0;

            output = degrees + (minutes / 60.0) + (seconds / 3600.0);

            return output;
        }

        public string decrypt_hint(string crypted_hint)
        {
            crypted_hint = crypted_hint.ToLower();
            char[] buffer = crypted_hint.ToCharArray();
            char[] ch = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (ch.Contains(letter))
                {
                    letter = (char)(letter + 13);

                    if (letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }
                    buffer[i] = letter;
                }
            }

            return new string(buffer);
        }

        public geocash last_parsed_cach = new geocash();
        public bool site_parsed = false;
        public void get_chach_from_groundspeak(string url_address, System.Windows.Forms.WebBrowser browser)
        {
            wb = browser;
            wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
            wb.Navigate(url_address);
        }

        public void pack_cash(System.Windows.Forms.WebBrowser browser)
        {
            try
            {
                wb = browser;

                System.Windows.Forms.HtmlElement element;

                element = wb.Document.GetElementById("ctl00_ContentBody_CacheName");
                last_parsed_cach.name = element.InnerText;

                element = wb.Document.GetElementById("ctl00_ContentBody_CoordInfoLinkControl1_uxCoordInfoCode");
                last_parsed_cach.geoID = element.InnerText;

                element = wb.Document.GetElementById("uxLatLon");
                string[] coord_temp = element.InnerText.Split(' ');

                int degree = Convert.ToInt32(coord_temp[1].TrimEnd(new char[] { '°' }));
                double minutes = Convert.ToDouble(coord_temp[2].Replace('.', ','));
                int seconds = 0;

                last_parsed_cach.lat = degree_to_decimal(degree, minutes, seconds);

                degree = Convert.ToInt32(coord_temp[4].TrimEnd(new char[] { '°' }));
                minutes = Convert.ToDouble(coord_temp[5].Replace('.', ','));

                last_parsed_cach.lon = degree_to_decimal(degree, minutes, seconds);

                element = wb.Document.GetElementById("ctl00_ContentBody_ShortDescription");
                last_parsed_cach.short_description = element.InnerText;

                element = wb.Document.GetElementById("ctl00_ContentBody_LongDescription");
                last_parsed_cach.long_description = element.InnerText;

                element = wb.Document.GetElementById("div_hint");
                last_parsed_cach.hints = element.InnerText;

                if (last_parsed_cach.geoID != null)
                {
                    site_parsed = true;
                }
            }
            catch
            {
            }
        }

        void wb_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            
        }
    }
}
