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

        public void SaveRepairUnits()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("Şuan ki dosya"+currentDirectory);

            // Mevcut çalışma dizini ile dosya adını birleştir
            string dosyaYolu = Path.Combine(currentDirectory, "TamirBirimleri.txt");

            try
            {
                // Dosyayı aç
                using (StreamReader sr = new StreamReader(dosyaYolu))
                {
                    string satir;

                    // Dosyanın sonuna kadar her satırı oku
                    while ((satir = sr.ReadLine()) != null)
                    {
                        // Okunan satırı ekrana yazdır
                        Console.WriteLine(satir);
                    }
                }
            }
            catch (Exception e)
            {
                // Hata durumunda hata mesajını yazdır
                Console.WriteLine("Hata: " + e.Message);
            }
        }
    }
}
