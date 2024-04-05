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
        Stacks<Packages> DagitimUnitesi;
        LinkList<RepairUnit> RepairUnits;

        public Automation()
        {
            DagitimUnitesi = new Stacks<Packages>(25);
            RepairUnits = new LinkList<RepairUnit>();
        }
        public void SaveRepairUnits()
        {
            //Dosyalar TechnicalServiceAutomation\bin\Debug konumunda iken çalışıyor, Nedenini bilmiyorum. 
            string currentDirectory = Directory.GetCurrentDirectory();
            string dosyaYolu = Path.Combine(currentDirectory, "TamirBirimleri.txt");

            try
            {
                using (StreamReader sr = new StreamReader(dosyaYolu))
                {
                    string satir;
                    
                    while ((satir = sr.ReadLine()) != null)
                    {
                        string[] repairUnitData = satir.Split(',');
                        
                        string id = repairUnitData[0];
                        int capW = int.Parse(repairUnitData[1]);
                        int capE = int.Parse(repairUnitData[2]);
                        // 4 sütunlük veri için patlar vaktin olursa bak
                        
                        RepairUnit unit = new RepairUnit(id, capE, capW);
                        RepairUnits.addToLast(unit);

                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }
    }
}
