using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalServiceAutomation
{
    public partial class LoginScreen : Form
    {
        Stacks<Packages> DagitimUnitesi = new Stacks<Packages>(25);
        public LoginScreen()
        {
            InitializeComponent();
        }
    }
}
