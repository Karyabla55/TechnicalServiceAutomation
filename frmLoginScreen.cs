using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalServiceAutomation
{
    public partial class frmLoginScreen : Form
    {
        
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Automation automation = new Automation();
            RepairUnit.SaveRepairUnits(automation.RepairUnits);
            Packages.OrganizePackages(automation.allPackages);
            automation.SendDistribution();
            Packages.PrintPackages(automation.allPackages);
        }
    }
}
