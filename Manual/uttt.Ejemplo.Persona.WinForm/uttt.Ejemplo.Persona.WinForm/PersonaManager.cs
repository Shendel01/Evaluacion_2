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
    public partial class PersonaManager : Form
    {
        bool resultado = false;
        ejemplo.Persona personaGlobal;
        ejemplo.EjemploSoapClient example = new ejemplo.EjemploSoapClient();
        public PersonaManager()
        {
            InitializeComponent();
        }

        public bool setForm(Form _parent, ejemplo.Persona _Persona)
        {
            this.personaGlobal = _Persona;
            this.setInformation();

            this.ShowDialog(_parent);

            return this.resultado;
        }

        private void setTabIndex()
        {
            try
            {
                int c = 0;
                this.txtClave.TabIndex = c++;
                this.txtNombre.TabIndex = c++;
                this.txtAParterno.TabIndex = c++;
                this.txtAMaterno.TabIndex = c++;
                this.cmbSexo.TabIndex = c++;
                this.btnAceptar.TabIndex = c++;
                this.btnSalir.TabIndex = c++;
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void setInformation()
        {
            try
            {
                this.setTabIndex();
                ejemplo.CatSexo[] listaSexo = this.example.consultaGlobalSexo();
                this.cmbSexo.DataSource = listaSexo;
                this.cmbSexo.ValueMember = "Id";
                this.cmbSexo.DisplayMember = "StrValor";
                if (this.personaGlobal == null)
                {
                    this.lblAccion.Text = "Agregar";
                }
                else
                {
                    this.lblAccion.Text = "Editar";
                    this.txtClave.Text = this.personaGlobal.StrClaveUnica;
                    this.txtNombre.Text = this.personaGlobal.StrNombre;
                    this.txtAParterno.Text = this.personaGlobal.StrAPaterno;
                    this.txtAMaterno.Text = this.personaGlobal.StrAMaterno;
                    this.cmbSexo.SelectedIndex = this.cmbSexo.FindString(this.personaGlobal.CatSexoTemp.StrValor);
                }

            }
            catch (Exception _e)
            {
                throw _e;
            }

        }

        private bool validaNombre()
        {
            try
            {
                if (this.txtNombre.Text.Trim() == String.Empty)
                {
                    this.txtNombre.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }

            catch (Exception)
            {

                throw;
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                ejemplo.Persona personaTemp = new ejemplo.Persona();
                if (this.lblAccion.Text == "Editar")
                {
                    personaTemp.Id = this.personaGlobal.Id;
                }
                personaTemp.StrClaveUnica = this.txtClave.Text.Trim();
                personaTemp.StrNombre = this.txtNombre.Text.Trim();
                personaTemp.StrAPaterno = this.txtAParterno.Text.Trim();
                personaTemp.StrAMaterno = this.txtAMaterno.Text.Trim();
                personaTemp.IdCatSexo = ((ejemplo.CatSexo)this.cmbSexo.SelectedItem).Id;
                if (this.personaGlobal == null)
                {
                    if (this.validaNombre())
                    {
                        this.resultado = this.example.insertarPersona(personaTemp);
                    }
                    if (resultado)
                    {
                        MessageBox.Show("El Registro se Inserto Correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No Se Pudo Insertar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.resultado = this.example.editarPersona(personaTemp);
                    if (resultado)
                    {
                        MessageBox.Show("El registro se Edito Correctamente","Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se puede Editar", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                this.Close();
            }
            catch (Exception _e)
            {
                throw _e;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Desea Guardar el registro antes de salir?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes)
            {
                if (this.txtNombre.Text == String.Empty)
                {
                    this.txtNombre.Focus();                 
                    MessageBox.Show("Nombre Vacío", "Sistema ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {

                        ejemplo.Persona personaTemp = new ejemplo.Persona();
                        if (this.lblAccion.Text == "Editar")
                        {
                            personaTemp.Id = this.personaGlobal.Id;
                        }
                        personaTemp.StrClaveUnica = this.txtClave.Text.Trim();
                        personaTemp.StrNombre = this.txtNombre.Text.Trim();
                        personaTemp.StrAPaterno = this.txtAParterno.Text.Trim();
                        personaTemp.StrAMaterno = this.txtAMaterno.Text.Trim();
                        personaTemp.IdCatSexo = ((ejemplo.CatSexo)this.cmbSexo.SelectedItem).Id;
                        if (this.personaGlobal == null)
                        {
                            if (this.validaNombre())
                            {
                                this.resultado = this.example.insertarPersona(personaTemp);
                            }
                            if (resultado)
                            {
                                MessageBox.Show("El registro se Inserto Correctamente");
                            }
                            else
                            {
                                MessageBox.Show("hay probelmas :(");
                            }
                        }
                        else
                        {
                            this.resultado = this.example.editarPersona(personaTemp);
                            if (resultado)
                            {
                                MessageBox.Show("El registro se edito correctamente");
                            }
                            else
                            {
                                MessageBox.Show("hay probelmas :(");
                            }

                        }
                        this.Close();
                    }
                    catch (Exception _e)
                    {
                        throw _e;
                    }
                }
            }
        }
    }
}