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
        private bool ChekTotalDuratation()
        {
            TimeSpan TotalDurates = TimeSpan.Zero;
            Node<Packages> ither = DistributionUnit.PeekNode();
            while (ither.next != null)
            {
                TotalDurates = TotalDurates.Add(ither.Data.FixTime);
                if (TotalDurates > TimeSpan.FromMinutes(300))
                {
                    return true;
                }
            }
            return false;
        }
        public void SendRepairUnits()
        {
            if (DistributionUnit.getSize() >= 15 || ChekTotalDuratation())
            {
                bool IsUnitsFull = false;
                bool[] unitFull = new bool[4];
                while(!IsUnitsFull) 
                {
                    Packages package = DistributionUnit.Peek();
                    foreach (var ft in package.FaultType)
                    {
                        foreach (var unit in RepairUnits)
                        {
                            if ((ft == 1 || ft == 2 || ft == 3) && unit.Id == "T01")
                            {
                                if (unit.WorkCapacity.IsFull())
                                {
                                    unitFull[0] = true;
                                    break;
                                }
                                unit.WorkCapacity.Push(package);
                                Console.WriteLine("T01 tamir birimine:" + package.PackageId + " ıd li paket eklendi");
                                DistributionUnit.Pop();
                                
                                
                            }
                            else if ((ft == 4 || ft == 5) && unit.Id == "T02")
                            {
                                if (unit.WorkCapacity.IsFull())
                                {
                                    unitFull[1] = true;
                                    break;
                                }
                                unit.WorkCapacity.Push(package);
                                Console.WriteLine("T2 tamir birimine:" + package.PackageId + " ıd li paket eklendi");
                                DistributionUnit.Pop();
                                
                            }
                            else if ((ft == 6 || ft == 7 || ft == 8) && unit.Id == "T03")
                            {
                                if (unit.WorkCapacity.IsFull())
                                {
                                    unitFull[2] = true;
                                    break;
                                }
                                unit.WorkCapacity.Push(package);
                                Console.WriteLine("T03 tamir birimine:" + package.PackageId + " ıd li paket eklendi");
                                DistributionUnit.Pop();
                                
                            }
                            else if ((ft == 9 || ft == 10) && unit.Id == "T04")
                            {
                                if (unit.WorkCapacity.IsFull())
                                {
                                    unitFull[3] = true;
                                    break;
                                }
                                unit.WorkCapacity.Push(package);
                                Console.WriteLine("T04 tamir birimine:" + package.PackageId + " ıd li paket eklendi");
                                DistributionUnit.Pop();
                            }
                            else
                            {
                                Console.WriteLine("Uyumsuz birim");
                            }
                        }
                        if (unitFull[0] == true && unitFull[1] == true && unitFull[2] == true && unitFull[3] == true)
                        {
                            IsUnitsFull = true;
                        }

                    }
                }
                
            }
            RepairUnit.printRepairUnits(RepairUnits);
        }


    }
}
