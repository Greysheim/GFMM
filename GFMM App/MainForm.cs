using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFMM_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            String modListJson = ReadModList();

            Object modListObj = Newtonsoft.Json.JsonConvert.DeserializeObject(modListJson);

            DebugLabel.Text = modListObj.ToString();
        }

        public String ReadModList()
        {
            String result = "";

            try
            {
                String appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                String modListFile = System.IO.Path.Combine(appData, @"Factorio\mods\mod-list.json");
                result = System.IO.File.ReadAllText(modListFile);
            }
            catch (Exception ex)
            {
                // File read failed
                result = "File read failed.\n" + ex.ToString();
            }
            
            return result;
        }
    }
}
