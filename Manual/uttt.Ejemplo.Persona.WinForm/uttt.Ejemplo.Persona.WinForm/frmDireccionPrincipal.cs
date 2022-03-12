using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ejemplo = uttt.Ejemplo.Persona.WinForm.Ejemplo;

namespace uttt.Ejemplo.Persona.WinForm
{
    public partial class frmDireccionPrincipal : Form
    {
        private bool resultado = false;
        ejemplo.Persona persona= null;
        ejemplo.EjemploSoapClient example = new ejemplo.EjemploSoapClient();
        public frmDireccionPrincipal()
        {
            InitializeComponent();
        }


        public bool setForm(Form _paren, ejemplo.Persona _Persona )
        {
            try
            {
                this.persona = _Persona;
                this.loadInformation();
                this.ShowDialog(_paren);
                 
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
        }

        private void setTabIndex()
        {
            try
            {
                int c = 0;
                this.btnAgregar.TabIndex = c++;
                this.btnBuscar.TabIndex = c++;
                this.dgvDireccion.TabIndex = c++;
                this.btnSalir.TabIndex = c++;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void loadInformation()
        {
            try
            {
                this.lblNombre.Text = persona.StrNombre + " " + persona.StrAPaterno + " "+  persona.StrAPaterno;

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private void frmDireccionPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void metodoBuscar()
        {
            int id = this.persona.Id;
            ejemplo.Direccion[] persona = example.consultarGlobalDireccion(id);
            this.dgvDireccion.DataSource = persona;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.metodoBuscar();
            }
            catch (Exception _e)
            {
                MessageBox.Show(_e.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
               frmDireccionManager fmDir = new frmDireccionManager();
               bool resultado = fmDir.setForm(this, this.persona,null);
               this.metodoBuscar();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            try
            {

                this.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void dgvDireccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    if (this.dgvDireccion.Columns["btnEditar"].Index == e.ColumnIndex)
                    {
                        frmDireccionManager view = new frmDireccionManager();
                        ejemplo.Direccion nuevo = (ejemplo.Direccion)this.dgvDireccion.SelectedRows[0].DataBoundItem;
                        bool resultado = view.setForm(this,null ,(ejemplo.Direccion)this.dgvDireccion.SelectedRows[0].DataBoundItem);
                        if (resultado)
                        {
                            ejemplo.Persona[] persona = example.consultarGlobalPersona();
                            this.dgvDireccion.DataSource = persona;
                            this.metodoBuscar();
                        }

                    }
                    if (this.dgvDireccion.Columns["btnEliminar"].Index == e.ColumnIndex)
                    {
                        ejemplo.Direccion direccion = new ejemplo.Direccion();
                        ejemplo.Direccion eliminarDireccion = (ejemplo.Direccion)this.dgvDireccion.SelectedRows[0].DataBoundItem;
                        direccion.Id = eliminarDireccion.Id;
                       // example.eliminarDireccion(direccion);
                        if (example.eliminarDireccion(direccion))
                        {
                            MessageBox.Show("Se Elimino el Registro Correctamente", "Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            this.metodoBuscar();
                        }
                        else
                        {
                            MessageBox.Show("Error al Eliminar","Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
