using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalServiceAutomation
{
    public class RepairUnit
    {
        public string Id;
        public int EmployeeCapacity;
        public Stacks<Packages> WorkCapacity;
        public LinkList<int> RepairType;

        public RepairUnit(string ıd,int employee, int capacity, string repairType) 
        {
            Id = ıd;
            EmployeeCapacity = employee;
            WorkCapacity = new Stacks<Packages>(capacity);
            SaveTypes(repairType);
        }

        private void SaveTypes(string repairType)
        {
            string[] chars = repairType.Split('*');
            foreach(string rT in chars) {
                RepairType.addToLast(int.Parse(rT));
            }

        }

        public static void SaveRepairUnits(LinkList<RepairUnit> RepairUnits)
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
                Console.WriteLine("Tamir birimleri Eklendi...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }
    }
}
