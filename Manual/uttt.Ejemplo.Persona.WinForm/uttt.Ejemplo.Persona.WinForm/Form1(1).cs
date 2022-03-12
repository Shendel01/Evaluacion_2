using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uttt.Ejemplo.Persona.WinForm;
using ejemplo = uttt.Ejemplo.Persona.WinForm.Ejemplo;

namespace uttt.Ejemplo.Persona.WinForm
{
    public partial class Form1 : Form
    {
        ejemplo.EjemploSoapClient example = new ejemplo.EjemploSoapClient();

        public Form1()
        {
            InitializeComponent();
            this.setTabIndex();
        }

        private void setTabIndex()
        {
            try
            {
                int c = 0;
                this.btnAgregar.TabIndex = c++;
                this.btnBuscar.TabIndex = c++;
                this.dgvPersona.TabIndex = c++;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
        private void buscar()
        {
            try
            {
                 ejemplo.Persona[] persona = example.consultarGlobalPersona();
                
                this.dgvPersona.DataSource = persona;
            
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.buscar();
             

            }
            catch (Exception _e)
            {
                MessageBox.Show(_e.Message);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PersonaManager view = new PersonaManager();
            bool resultado = view.setForm(this, null);
            if (resultado)
            {
                ejemplo.Persona[] persona = example.consultarGlobalPersona();
                this.dgvPersona.DataSource = persona;
                this.buscar();
            }

        }

        private void dgvPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    if (this.dgvPersona.Columns["btnEditar"].Index == e.ColumnIndex)
                    {
                        PersonaManager view = new PersonaManager();
                        ejemplo.Persona nuevo = (ejemplo.Persona)this.dgvPersona.SelectedRows[0].DataBoundItem;
                        bool resultado = view.setForm(this, (ejemplo.Persona)this.dgvPersona.SelectedRows[0].DataBoundItem);
                        if (resultado)
                        {
                            ejemplo.Persona[] persona = example.consultarGlobalPersona();
                            this.dgvPersona.DataSource = persona;
                        }

                    }
                    if(this.dgvPersona.Columns["btnEliminar"].Index == e.ColumnIndex)
                    {
                        ejemplo.Persona personita = new ejemplo.Persona();
                        ejemplo.Persona eliminarPersona = (ejemplo.Persona)this.dgvPersona.SelectedRows[0].DataBoundItem;
                        personita.Id = eliminarPersona.Id;

                        if (example.eliminarPersona(personita))
                        {

                            MessageBox.Show("Eliminado corectamente");
                        }
                        else
                        {
                            MessageBox.Show("EL usuario se encuentra en uso por el sistema");
                        }
                        this.buscar();
                    }
                    if (this.dgvPersona.Columns["btnDireccion"].Index == e.ColumnIndex)
                    {
                        ejemplo.Persona agregarDireccion = (ejemplo.Persona)this.dgvPersona.SelectedRows[0].DataBoundItem;
                        frmDireccionPrincipal show = new frmDireccionPrincipal();
                       bool resulatado =  show.setForm(this,agregarDireccion);
                    }

                }
                
            }
            catch (Exception _e )
            {
                
                throw _e;
            }
        }
    }
}
