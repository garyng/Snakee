using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CustomPictureBox;
using System.Drawing;
using System.Xml;

namespace Snakee
{
    public partial class frmMapLoader
    {
        string m_strMapPath = "";

        List<string> m_strMapFiles = new List<string>();

        List<Button> m_btnPreview = new List<Button>();
        List<GroupBox> m_gpPreviewCon = new List<GroupBox>();

        //List<Image> m_imgPreview = new List<Image>();
        List<MapEditor> m_mePreview = new List<MapEditor>();
        MapEditor m_meSelected = new MapEditor();


        #region Properties
        /// <summary>
        /// Return "" = no Map
        /// </summary>
        public string SelectedMap
        {
            get
            {
                return m_strMapPath;
            }
            set
            {
                m_strMapPath = value;
            }
        }

        public MapEditor MapEditor 
        {
            get
            {
                return m_meSelected;
            }
        }

        #endregion


        #region LoadFiles
        void Map_SearchFiles()
        {
            List<string> str = Directory.GetFiles(Application.StartupPath, "*.smap").ToList();
            m_strMapFiles = new List<string>(str);
            if (str.Count == 0)
            {
                m_strMapPath = "";
                MessageBox.Show("No Maps Found" + Environment.NewLine  + "Generating Default Map...");
                Map_GenDefault();

                //Generate A New Map

                this.Close();
            }

        }

        void Map_GenDefault()
        {
            MapEditor me = new MapEditor();
            me.LoadDefault();
            me.Name = "Default Map";
            me.SnakeBodyPoint = PFunc.Snakee_CalPoint(me.Width, me.Height, me.SnakeLength);
            me.Save("Default.smap");
        }


        void Map_Load()
        {

            for (int i = 0; i < m_strMapFiles.Count; i++)
            {
                MapEditor me = new MapEditor();
                me.Load(m_strMapFiles[i]);
                m_mePreview.Add(me);
            }
            
        }

        //Black
        //153, 204, 255
        //194, 224, 255
        void Map_LoadButton()
        {
            for (int i = 0; i < m_strMapFiles.Count; i++)
            {
                GroupBox gp = new GroupBox();
                gp.Text = m_mePreview[i].Name;

                Button btn = new Button();
                btn.Image = m_mePreview[i].Preview;
                btn.Location = new Point(10, 15);
                btn.Size = new Size(m_mePreview[i].Preview.Width + 12, m_mePreview[i].Preview.Height + 12);

                gp.Width = btn.Width + 22;
                gp.Height = btn.Height + 27;

                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(194, 224, 255);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(153, 204, 255);

                btn.Click += (object sender, EventArgs e) =>
                    {
                        int index = m_btnPreview.IndexOf((Button)sender);
                        m_strMapPath = m_strMapFiles[index];
                        m_meSelected = m_mePreview[index];
                        this.Close();
                    };

                gp.Dock = DockStyle.Top;
                gp.Controls.Add(btn);

                m_gpPreviewCon.Add(gp);
                m_btnPreview.Add(btn);
                this.Controls.Add(gp);


                //m_btnPreview.Add(btn);
                //this.Controls.Add(btn);


                //Button btn = new Button();
                ////bb.Size = new Size(128, 128);
                //btn.Image = m_imgPreview[i];
                //btn.Size = new Size(m_imgPreview[i].Size.Width + 10, m_imgPreview[i].Size.Height + 10);
                //btn.FlatStyle = FlatStyle.Flat;

                //Console.WriteLine(btn.Size.ToString());
            }
        }
        #endregion

    }
}
