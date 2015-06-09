using SysClinic.Bll;
using SysClinic.Bll.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SsysClinic.View.Mdi
{
    public partial class frmValidacao : Form
    {
        public frmValidacao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MacBll mac = new MacBll();
            CifraBll cf = new CifraBll();

            label1.Text = cf.GetCriptografiaMD5(mac.PegarEnderecoMAc());
        }
    }
}
