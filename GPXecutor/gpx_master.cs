using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

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
            public DateTime time;
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
    }
}
