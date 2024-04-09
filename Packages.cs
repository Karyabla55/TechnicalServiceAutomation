using System;
using System.IO;

namespace TechnicalServiceAutomation
{
    public class Packages
    {
        public string PackageId;
        public int[] FaultType;
        public string FixType;
        public TimeSpan FixTime;
        public TimeSpan EntranceTime;
        public TimeSpan ExitTime;

        public Packages(string packageId, int[] faultType, string fixType, TimeSpan fixTime, TimeSpan entranceTime, TimeSpan exitTime)
        {
            PackageId = packageId;
            FaultType = faultType;
            FixType = fixType;
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

                        string fixT = packageData[2];
                        TimeSpan fixTime = StringToTime(packageData[3]);
                        TimeSpan enTime = StringToTime(packageData[4]);
                        TimeSpan exTime = StringToTime(packageData[5]);

                        Packages package = new Packages(id, repT, fixT, fixTime, enTime, exTime);

                        allPackages.addToLast(package);

                    }

                    SortForTime(allPackages);
                    
                    /*
                    Node<Packages> ither = allPackages.root;
                    while (ither != null)
                    {
                        Console.Write(ither.Data.PackageId + ",");
                        for (int j = 0; j < ither.Data.FaultType.Length; j++)
                        {
                            if (j == ither.Data.FaultType.Length - 1)
                            {
                                Console.Write(ither.Data.FaultType[j] + ",");
                            }
                            else
                            {
                                Console.Write(ither.Data.FaultType[j] + "*");
                            }
                            
                        }

                        Console.Write(ither.Data.FixType + ",");
                        Console.Write(ither.Data.FixTime + ",");
                        Console.Write(ither.Data.EntranceTime + ",");
                        Console.Write(ither.Data.ExitTime + ",");
                        Console.WriteLine();
                        ither = ither.next;
                    }
                    */

                }
                Console.WriteLine("İş paketleri Eklendi...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
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
    }
}

