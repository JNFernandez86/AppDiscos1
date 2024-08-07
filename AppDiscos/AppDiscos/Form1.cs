using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDiscos
{
    public partial class frmDiscos : Form
    {
        private List<Discos> listaDiscos;
        public frmDiscos()
        {
            InitializeComponent();
        }

        private void dgvDiscos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDiscos_Load(object sender, EventArgs e)
        {
            DiscosNegocios dn = new DiscosNegocios();
            listaDiscos = dn.listar();
            dgvDiscos.DataSource = listaDiscos;
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
            pbxImagenDiscoUrl.Load(listaDiscos[0].UrlImagenTapa);

        

        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
