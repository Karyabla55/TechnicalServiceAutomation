using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalServiceAutomation
{
    public class Automation
    {
        public LinkList<Packages> AllPackages;
        public LinkList<RepairUnit> RepairUnits;
        public Stacks<Packages> DistributionUnit;
        public LinkList<Packages> FinishedPackages;
        public VirtualClock VirtualClock;
        
        public VirtualClock WaitClock = new VirtualClock(TimeSpan.Zero);
        public TimeSpan WaitTime = new TimeSpan(2, 0, 0);
        public Automation()
        {
            AllPackages = new LinkList<Packages>();
            DistributionUnit = new Stacks<Packages>(25);
            RepairUnits = new LinkList<RepairUnit>();
        }
        public void RunSystem()
        {
            TimeSpan StartTime = new TimeSpan(7, 50, 0);
            TimeSpan EndTime = new TimeSpan(19, 0, 0);
            VirtualClock = new VirtualClock(StartTime);
            while (VirtualClock.time < EndTime)
            {
                Console.WriteLine(VirtualClock.time);
                Console.WriteLine("Paketin beklediği süre:" + WaitClock.time);
                Thread.Sleep(1000);
                SendDistribution(VirtualClock.time);
                VirtualClock.Tick();
            }
        }
        public void SendDistribution(TimeSpan time)
        {
            Node<Packages> ither = AllPackages.root;
            while (ither.next != null)
            {
                if (ither.Data.EntranceTime <= time)
                {
                    DistributionUnit.Push(ither.Data);
                    Console.WriteLine(ither.Data.PackageId + " No'lu paket Dağıtım ünitesine gönderildi");
                    Packages.PrintPackage(ither.Data);
                    Thread.Sleep(1000);
                    AllPackages.ExtractToHead();
                    ither = ither.next;
                    SendRepairUnits();
                    if (DistributionUnit.IsFull())
                    {
                        break;
                    }
                }
                else if (DistributionUnit.getSize() != 0)
                {
                    WaitClock.Tick();
                    if (WaitClock.time >= WaitTime)
                    {
                        SendRepairUnits();
                        WaitClock.time = TimeSpan.Zero;
                    }
                    break;
                }
                else
                {
                    break;
                }

            }
        }
        private bool ChekTotalDuratation()
        {
            TimeSpan TotalDurates = TimeSpan.Zero;
            Node<Packages> ither = DistributionUnit.PeekNode();
            while (ither != null)
            {
                TotalDurates = TotalDurates.Add(ither.Data.FixTime);
                if (TotalDurates > TimeSpan.FromMinutes(300))
                {
                    return true;
                }
                ither = ither.next;
            }
            return false;
        }
        public void SendRepairUnits()
        {
            bool IsUnitsFull = false;
            if (DistributionUnit.getSize() >= 15 || ChekTotalDuratation() || WaitClock.time >= WaitTime)
            {
                Packages package = DistributionUnit.Peek();
                while (!IsUnitsFull)
                {
                    foreach (var ft in package.FaultType)
                    {
                        if (package.IsAddedToUnit)
                            continue;
                        foreach (var unit in RepairUnits)
                        {
                            Thread.Sleep(1000);
                            if ((ft == 1 || ft == 2 || ft == 3) && unit.Id == "T01")
                            {
                                if (unit.WorkCapacity.IsFull())
                                {
                                    IsUnitsFull = true;
                                    break;
                                }
                                unit.WorkCapacity.Push(package);
                                package.IsAddedToUnit = true;
                                Console.WriteLine("T01 tamir birimine:" + package.PackageId + " ıd li paket eklendi");
                                DistributionUnit.Pop();


                            }
                            else if ((ft == 4 || ft == 5) && unit.Id == "T02")
                            {
                                if (unit.WorkCapacity.IsFull())
                                {
                                    IsUnitsFull = true;
                                    break;
                                }
                                unit.WorkCapacity.Push(package);
                                package.IsAddedToUnit = true;
                                Console.WriteLine("T2 tamir birimine:" + package.PackageId + " ıd li paket eklendi");
                                DistributionUnit.Pop();

                            }
                            else if ((ft == 6 || ft == 7 || ft == 8) && unit.Id == "T03")
                            {
                                if (unit.WorkCapacity.IsFull())
                                {
                                    IsUnitsFull = true;
                                    break;
                                }
                                unit.WorkCapacity.Push(package);
                                package.IsAddedToUnit = true;
                                Console.WriteLine("T03 tamir birimine:" + package.PackageId + " ıd li paket eklendi");
                                DistributionUnit.Pop();

                            }
                            else if ((ft == 9 || ft == 10) && unit.Id == "T04")
                            {
                                if (unit.WorkCapacity.IsFull())
                                {
                                    IsUnitsFull = true;
                                    break;
                                }
                                unit.WorkCapacity.Push(package);
                                package.IsAddedToUnit = true;
                                Console.WriteLine("T04 tamir birimine:" + package.PackageId + " ıd li paket eklendi");
                                DistributionUnit.Pop();
                            }
                            //if (package.IsAddedToUnit) 
                            //    break;
                        }

                    }
                    package = DistributionUnit.Peek();
                }
                if (!package.IsAddedToUnit)
                {

                    IsUnitsFull = true;
                }
            }

            Thread.Sleep(1000);
            RepairUnit.printRepairUnits(RepairUnits);

        }
    }
}
