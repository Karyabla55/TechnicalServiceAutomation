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
        public Stacks<Packages> DistributionUnit;
        public LinkList<RepairUnit> RepairUnits;

        public Automation()
        {
            allPackages = new LinkList<Packages>();
            DistributionUnit = new Stacks<Packages>(25);
            RepairUnits = new LinkList<RepairUnit>();
        }

        public void SendDistribution()
        {

            Node<Packages> ither = allPackages.root;
            while (ither.next != null) 
            {
                DistributionUnit.Push(ither.Data);
                
                ither = ither.next;
                allPackages.ExtractToHead();
                if (DistributionUnit.IsFull())
                {
                    break;
                }
            }
        }
        public void SendRepairUnits() 
        {
            if(DistributionUnit.getSize() >= 15 || ChekTotalDuratation())
            {
                //Tamir birimlerine iş paketleri gönderilecek
            }
        }

        private bool ChekTotalDuratation()
        {
            TimeSpan TotalDurates = TimeSpan.Zero;
            Node<Packages> ither = DistributionUnit.PeekNode();
            while(ither.next != null) 
            {
                TotalDurates = TotalDurates.Add(ither.Data.FixTime);
                if(TotalDurates > TimeSpan.FromMinutes(300))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
