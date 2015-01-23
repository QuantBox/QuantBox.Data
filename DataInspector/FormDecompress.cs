using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataInspector
{
    public partial class FormDecompress : Form
    {
        public string FileName;
        private List<string> list = new List<string>();

        public FormDecompress()
        {
            InitializeComponent();
        }

        public FormDecompress(List<string> list)
        {
            InitializeComponent();
            cmbFileName.DataSource = list;
            this.list = list;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FileName = cmbFileName.SelectedItem.ToString();
            this.Close();
        }
    }
}
