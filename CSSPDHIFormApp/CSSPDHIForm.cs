using CSSPDHI;
using CSSPModelsDLL.Models;
using DHI.Generic.MikeZero.DFS.dfsu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSSPDHIFormApp
{
    public partial class CSSPDHIForm : Form
    {
        #region Variables
        #endregion Variables

        #region Properties
        private FileInfo fi { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDHIForm()
        {
            InitializeComponent();
        }
        #endregion Constructors

        #region Events
        private void butDfs0_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting Dfs0..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            Dfs0();
            richTextBoxStatus.AppendText("\r\nFinished Dfs0..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");
        }
        private void butDfs1_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting Dfs1..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            Dfs1();
            richTextBoxStatus.AppendText("\r\nFinished Dfs1..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");
        }
        private void butDfs2_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting Dfs2..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            Dfs2();
            richTextBoxStatus.AppendText("\r\nFinished Dfs2..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");

        }
        private void butDfsuHydroMike21_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting DfsuHydroMike21..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            DfsuHydroMike21();
            richTextBoxStatus.AppendText("\r\nFinished DfsuHydroMike21..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");
        }
        private void butDfsuHydroMike3_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting DfsuHydroMike3..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            DfsuHydroMike3();
            richTextBoxStatus.AppendText("\r\nFinished DfsuHydroMike3..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");
        }
        private void butDfsuTransMike21_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting DfsuTransMike21..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            DfsuTransMike21();
            richTextBoxStatus.AppendText("\r\nFinished DfsuTransMike21..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");
        }
        private void butDfsuTransMike3_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting DfsuTransMike3..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            DfsuTransMike3();
            richTextBoxStatus.AppendText("\r\nFinished DfsuTransMike3..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");
        }
        private void butLOG_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting LOG..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            LOG();
            richTextBoxStatus.AppendText("\r\nFinished LOG..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");
        }
        private void butMDF_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting MDF..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            MDF();
            richTextBoxStatus.AppendText("\r\nFinished MDF..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");
        }
        private void butMESH_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting MESH..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            MESH();
            richTextBoxStatus.AppendText("\r\nFinished MESH..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");
        }
        private void butM21FM_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting M21FM..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            M21FM();
            richTextBoxStatus.AppendText("\r\nFinished M21FM..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");
        }
        private void butM3FM_Click(object sender, EventArgs e)
        {
            richTextBoxStatus.Text = "Starting M3FM..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n";
            M3FM();
            richTextBoxStatus.AppendText("\r\nFinished M3FM..." + DateTime.Now.ToString("yyyy MMMM dd   HH:mm:ss") + "\r\n\r\n");
        }
        private void CSSPDHIChanged(object sender, DHIBase.CSSPDHIEventArgs e)
        {
            richTextBoxStatus.AppendText("Status: [" + e.CSSPDHIMessage.Status + "]\t");
            richTextBoxStatus.AppendText("Progress: [" + e.CSSPDHIMessage.Progress + "]\t");
            richTextBoxStatus.AppendText("Completed: [" + e.CSSPDHIMessage.Completed + "]\t");
            richTextBoxStatus.AppendText("ErrorMessage: [" + e.CSSPDHIMessage.ErrorMessage + "]\r\n");
        }
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
        private void Dfs0()
        {
            FileInfo fi = new FileInfo(textBoxFile10.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (DFS0 dfs0 = new DFS0(fi))
            {
                dfs0.CSSPDHIChanged += CSSPDHIChanged;
                dfs0.ReadFile();
                dfs0.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }
        private void Dfs1()
        {
            FileInfo fi = new FileInfo(textBoxFile11.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (DFS1 dfs1 = new DFS1(fi))
            {
                dfs1.CSSPDHIChanged += CSSPDHIChanged;
                dfs1.ReadFile();
                dfs1.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }
        private void Dfs2()
        {
            FileInfo fi = new FileInfo(textBoxFile12.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (DFS2 dfs2 = new DFS2(fi))
            {
                dfs2.CSSPDHIChanged += CSSPDHIChanged;
                dfs2.ReadFile();
                dfs2.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }
        private void DfsuHydroMike21()
        {
            FileInfo fi = new FileInfo(textBoxFile1.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (DFSU dfsu = new DFSU(fi))
            {
                dfsu.CSSPDHIChanged += CSSPDHIChanged;
                dfsu.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }
        private void DfsuHydroMike3()
        {
            FileInfo fi = new FileInfo(textBoxFile3.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (DFSU dfsu = new DFSU(fi))
            {
                dfsu.CSSPDHIChanged += CSSPDHIChanged;
                dfsu.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }
        private void DfsuTransMike21()
        {
            FileInfo fi = new FileInfo(textBoxFile2.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (DFSU dfsu = new DFSU(fi))
            {
                dfsu.CSSPDHIChanged += CSSPDHIChanged;
                dfsu.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }
        private void DfsuTransMike3()
        {
            FileInfo fi = new FileInfo(textBoxFile4.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (DFSU dfsu = new DFSU(fi))
            {
                dfsu.CSSPDHIChanged += CSSPDHIChanged;
                dfsu.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }
        private void LOG()
        {
            FileInfo fi = new FileInfo(textBoxFile9.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (LOG log = new LOG(fi))
            {
                log.CSSPDHIChanged += CSSPDHIChanged;
                log.ReadFile();
                log.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }
        private void M21FM()
        {
            FileInfo fi = new FileInfo(textBoxFile7.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (M21FM m21fm = new M21FM(fi))
            {
                m21fm.CSSPDHIChanged += CSSPDHIChanged;
                m21fm.ReadFile();
                m21fm.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }
        private void M3FM()
        {
            FileInfo fi = new FileInfo(textBoxFile8.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (M3FM m3fm = new M3FM(fi))
            {
                m3fm.CSSPDHIChanged += CSSPDHIChanged;
                m3fm.ReadFile();
                m3fm.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }
        private void MDF()
        {
            FileInfo fi = new FileInfo(textBoxFile6.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (MDF mdf = new MDF(fi))
            {
                mdf.CSSPDHIChanged += CSSPDHIChanged;
                mdf.ReadFile();
                mdf.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }
        private void MESH()
        {
            FileInfo fi = new FileInfo(textBoxFile5.Text);

            if (!fi.Exists)
            {
                richTextBoxStatus.Text = "File [" + fi.FullName + "] does not exist.\r\n";
                return;
            }

            using (MESH mesh = new MESH(fi))
            {
                mesh.CSSPDHIChanged += CSSPDHIChanged;
                mesh.ReadFile();
                mesh.CSSPDHIChanged -= CSSPDHIChanged;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoGetStudyArea();
        }

        private void DoGetStudyArea()
        {
            FileInfo fi = new FileInfo(textBoxFile1.Text);

            using (DFSU dfsu = new DFSU(fi))
            {
                List<ContourPolygon> contourPolygonList = new List<ContourPolygon>();

                dfsu.GetStudyAreaContourPolygonList(contourPolygonList);
                richTextBoxStatus.AppendText("contourPolygonList.Count() = " + contourPolygonList.Count + "\r\n");

                foreach (ContourPolygon cp in contourPolygonList)
                {
                    richTextBoxStatus.AppendText("Number of nodes " + cp.ContourNodeList.Count() + "\r\n");
                }
            }
        }
        #endregion Functions private


        //private void Do2KML(List<ContourPolygon> contourPolygonList)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
        //    sb.AppendLine(@"<kml xmlns=""http://www.opengis.net/kml/2.2"" xmlns:gx=""http://www.google.com/kml/ext/2.2"" xmlns:kml=""http://www.opengis.net/kml/2.2"" xmlns:atom=""http://www.w3.org/2005/Atom"">");
        //    sb.AppendLine(@"<Document>");
        //    sb.AppendLine(@"	<name>KmlFile</name>");

        //    foreach (ContourPolygon cp in contourPolygonList)
        //    {
        //        sb.AppendLine(@"	<Placemark>");
        //        sb.AppendLine(@"	    <name>Study Area</name>");
        //        sb.AppendLine(@"	    <LineString>");

        //        sb.AppendLine(@"				    <coordinates>");
        //        foreach (Node node in cp.ContourNodeList)
        //        {
        //            sb.Append(node.X + "," + node.Y + ",0 ");
        //        }
        //        sb.AppendLine("");
        //        sb.AppendLine(@"				    </coordinates>");
        //        sb.AppendLine(@"	    </LineString>");
        //        sb.AppendLine(@" </Placemark>");
        //    }

        //    sb.AppendLine(@"</Document>");
        //    sb.AppendLine(@"</kml>");

        //    using (StreamWriter sw = new StreamWriter(@"C:\Users\leblancc\Desktop\testing.kml"))
        //    {
        //        sw.Write(sb.ToString());
        //        sw.Close();
        //    }

        //}


        //public void DoKML(List<Element> ElementList, List<Node> NodeList)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
        //    sb.AppendLine(@"<kml xmlns=""http://www.opengis.net/kml/2.2"" xmlns:gx=""http://www.google.com/kml/ext/2.2"" xmlns:kml=""http://www.opengis.net/kml/2.2"" xmlns:atom=""http://www.w3.org/2005/Atom"">");
        //    sb.AppendLine(@"<Document>");
        //    sb.AppendLine(@"	<name>KmlFile</name>");

        //    int count = 0;
        //    foreach (Node node in NodeList)
        //    {
        //        count += 1;
        //        sb.AppendLine(@"	<Placemark>");
        //        sb.AppendLine(@"		<name>index (" + node.ID + ") count(" + count + ")</name>");
        //        sb.AppendLine(@"		<Point>");
        //        sb.AppendLine(@"			<coordinates>" + node.X + "," + node.Y + ",0</coordinates>");
        //        sb.AppendLine(@"		</Point>");
        //        sb.AppendLine(@"	</Placemark>");
        //    }

        //    count = 0;
        //    foreach (Element element in ElementList)
        //    {
        //        count += 1;

        //        sb.AppendLine(@"	<Placemark>");
        //        sb.AppendLine(@"	    <name>index (" + element.ID + ") count(" + count + ")</name>");
        //        sb.AppendLine(@"	    <Polygon>");
        //        sb.AppendLine(@"		    <outerBoundaryIs>");
        //        sb.AppendLine(@"			    <LinearRing>");
        //        sb.AppendLine(@"				    <coordinates>");
        //        if (element.Type == 21 || element.Type == 32)
        //        {
        //            for (int i = 0; i < 3; i++)
        //            {
        //                sb.Append(element.NodeList[i].X + "," + element.NodeList[i].Y + ",0 ");
        //            }
        //            sb.Append(element.NodeList[0].X + "," + element.NodeList[0].Y + ",0 ");
        //        }
        //        else if (element.Type == 25 || element.Type == 33)
        //        {
        //            for (int i = 0; i < 4; i++)
        //            {
        //                sb.Append(element.NodeList[i].X + "," + element.NodeList[i].Y + ",0 ");
        //            }
        //            sb.Append(element.NodeList[0].X + "," + element.NodeList[0].Y + ",0 ");
        //        }
        //        else
        //        {
        //        }
        //        sb.AppendLine("");
        //        sb.AppendLine(@"				    </coordinates>");
        //        sb.AppendLine(@"			    </LinearRing>");
        //        sb.AppendLine(@"		    </outerBoundaryIs>");
        //        sb.AppendLine(@"	    </Polygon>");
        //        sb.AppendLine(@" </Placemark>");
        //    }

        //    sb.AppendLine(@"</Document>");
        //    sb.AppendLine(@"</kml>");

        //    using (StreamWriter sw = new StreamWriter(@"C:\Users\leblancc\Desktop\testing.kml"))
        //    {
        //        sw.Write(sb.ToString());
        //        sw.Close();
        //    }

        //}

    }
}
