using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalServiceAutomation
{
    public class Automation
    {
        public LinkList<Packages> allPackages;
        public Stacks<Packages> DagitimUnitesi;
        public LinkList<RepairUnit> RepairUnits;

        public Automation()
        {
            allPackages = new LinkList<Packages>();
            DagitimUnitesi = new Stacks<Packages>(25);
            RepairUnits = new LinkList<RepairUnit>();
        }

    }
}
