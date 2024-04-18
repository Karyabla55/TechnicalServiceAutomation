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

        public RepairUnit(string ıd,int employee, int capacity) 
        {
            Id = ıd;
            EmployeeCapacity = employee;
            WorkCapacity = new Stacks<Packages>(capacity);
            RepairType = new LinkList<int>();
            SaveTypes(ıd);
        }

        private void SaveTypes(string ıd)
        {
            string repairType;
            switch (ıd)
            {
                case "T01":
                    repairType = "1*2*3";
                    break;
                case "T02":
                    repairType = "4*5";
                    break;
                case "T03":
                    repairType = "6*7*8";
                    break;
                case "T04":
                    repairType = "8*9*10";
                    break;
                default:
                    repairType = "";
                    break;
            }

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
                        int capE = int.Parse(repairUnitData[1]);
                        int capW = int.Parse(repairUnitData[2]);
                        // 4 sütunlük veri için patlar vaktin olursa bak
                        
                        RepairUnit unit = new RepairUnit(id, capE, capW);
                        RepairUnits.addToLast(unit);

                    }
                    
                    Node<RepairUnit> ither = RepairUnits.root;
                    while (ither != null)
                    {
                        Console.Write(ither.Data.Id + ",");
                        Console.Write(ither.Data.EmployeeCapacity + ",");
                        Console.Write(ither.Data.WorkCapacity.getCapacity() + ",");
                        foreach(int repairTypes in ither.Data.RepairType)
                        {
                            Console.Write(repairTypes + "*");
                        }
                        Console.WriteLine();
                        ither = ither.next;
                    }
                    

                }
                    Console.WriteLine("Tamir birimleri Eklendi...");
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }

        public static void printRepairUnits(LinkList<RepairUnit> RepairUnits)
        {
            foreach (var unit in RepairUnits)
            {
                Console.WriteLine(unit.Id);
                Console.WriteLine(unit.EmployeeCapacity);
                Node<Packages> node = unit.WorkCapacity.PeekNode();
                while (node != null) 
                {
                    Packages.PrintPackages(node);
                    node = node.next;
                }
            }
        }
    }
}
