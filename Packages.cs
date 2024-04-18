using System;
using System.IO;

namespace TechnicalServiceAutomation
{
    public class Packages
    {
        public string PackageId;
        public int[] FaultType;
        public int[] FixType;
        public TimeSpan FixTime;
        public TimeSpan EntranceTime;
        public TimeSpan ExitTime;

        public Packages(string packageId, int[] faultType, TimeSpan fixTime, TimeSpan entranceTime, TimeSpan exitTime)
        {
            PackageId = packageId;
            FaultType = faultType;
            FixType = null;
            FixTime = fixTime;
            EntranceTime = entranceTime;
            ExitTime = exitTime;
        }

        public static void OrganizePackages(LinkList<Packages> allPackages)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dosyaYolu = Path.Combine(currentDirectory, "IsPaketi.txt");

            try
            {
                
                
                using (StreamReader sr = new StreamReader(dosyaYolu))
                {
                    string satir;

                    while ((satir = sr.ReadLine()) != null)
                    {
                        string[] packageData = satir.Split(',');
                        string id = packageData[0];

                        string[] repairT = packageData[1].Split('*');
                        int[] repT = new int[repairT.Length];
                        
                        for (int j = 0; j < repairT.Length; j++)
                        {
                            repT[j] = int.Parse(repairT[j]);
                        }
                        TimeSpan fixTime = StringToTime(packageData[3]);
                        TimeSpan enTime = StringToTime(packageData[4]);
                        TimeSpan exTime = StringToTime(packageData[5]);

                        Packages package = new Packages(id, repT, fixTime, enTime, exTime);
                        SetRepairTypes(package);
                        CalculateFixDurates(package);
                        allPackages.addToLast(package);

                    }

                    SortForTime(allPackages);
                    PrintPackages(allPackages);
                }
                Console.WriteLine("İş paketleri Eklendi...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }

        private static bool IsThereIn(string s,char a) 
        {
            foreach (char c in s)
            {
                if (c == a) return true;
            }
            return false;
        }

        private static void SetRepairTypes(Packages package)
        {
            string fixT = "";

            foreach (var fault in package.FaultType)
            {
                if (fault == 1 || fault == 2 ||  fault == 3 && !IsThereIn(fixT, '1'))
                {
                    fixT += "1*";
                }
                if (fault == 4 || fault == 5 && !IsThereIn(fixT, '2'))
                {
                    fixT += "2*";
                }
                if (fault == 5 || fault == 6 || fault == 7 && !IsThereIn(fixT, '3'))
                {
                    fixT += "3*";
                }
                if (fault == 8 || fault == 9 && !IsThereIn(fixT, '4'))
                {
                    fixT += "4*";
                }
            }
            string[] types = fixT.Split('*');
            package.FixType = new int[types.Length-1];
            int i = 0;
            foreach(var s in types)
            {
                if (i == types.Length - 1) break;
                package.FixType[i] = int.Parse(s);
                i++;
            }
            

        }

        private static void CalculateFixDurates(Packages packages)
        {
            int[] faultMinutes = { 10, 15, 20, 12, 14, 30, 26, 24, 22, 12 };
            TimeSpan[] FaultDurtations = new TimeSpan[faultMinutes.Length];
            for(int i = 0; i < faultMinutes.Length; i++)
            {
                FaultDurtations[i] = TimeSpan.FromMinutes(faultMinutes[i]);
            }
            foreach(var fault in packages.FaultType)
            {
                packages.FixTime = packages.FixTime.Add(FaultDurtations[fault-1]);
            }
        }

        private static TimeSpan StringToTime(string str)
        {
            if (str == "-")
            {
                return TimeSpan.Zero; 
            }
            string[] time = str.Split('.');
            TimeSpan organizedTime = TimeSpan.Parse(time[0] + ":" + time[1]);
            return organizedTime;
        }

        private static void SortForTime(LinkList<Packages> allPackages)
        {
            bool swapped;
            do
            {
                swapped = false;
                Node<Packages> current = allPackages.root;
                while (current != null && current.next != null)
                {
                    if (current.Data.EntranceTime > current.next.Data.EntranceTime)
                    {
                        Packages temp = current.Data;
                        current.Data = current.next.Data;
                        current.next.Data = temp;
                        swapped = true;
                    }
                    current = current.next;
                }
            } while (swapped);
            int i = 1;
            foreach (var package in allPackages)
            {
                if (i >= 10)
                {
                    package.PackageId = "P" + i;
                }
                else { package.PackageId = "P0" + i; }
                i++;
            }
        }

        public static void PrintPackages(LinkList<Packages> allPackages)
        {
            Node<Packages> ither = allPackages.root;
            while (ither != null)
            {
                Console.Write(ither.Data.PackageId + ",");
                for (int i = 0; i < ither.Data.FaultType.Length; i++)
                {
                    if (i == ither.Data.FaultType.Length - 1)
                    {
                        Console.Write(ither.Data.FaultType[i] + ",");
                    }
                    else
                    {
                        Console.Write(ither.Data.FaultType[i] + "*");
                    }

                }
                if (ither.Data.FixTime != null)
                {
                    for (int i = 0; i < ither.Data.FixType.Length; i++)
                    {
                        if (i == ither.Data.FixType.Length - 1)
                        {
                            Console.Write(ither.Data.FixType[i] + ",");
                        }
                        else
                        {
                            Console.Write(ither.Data.FixType[i] + "*");
                        }

                    }
                }
                else
                {
                    Console.Write(",");
                }
                
                Console.Write(ither.Data.FixTime.Hours + ":" + ither.Data.FixTime.Minutes + ",");
                Console.Write(ither.Data.EntranceTime.Hours + ":" + ither.Data.EntranceTime.Minutes + ",");
                Console.Write(ither.Data.ExitTime.Hours + ":" + ither.Data.ExitTime.Minutes + ",");
                Console.WriteLine();
                ither = ither.next;
            }
        }
    }
}

