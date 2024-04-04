using System;
using System.Collections.Generic;
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
    }
}
