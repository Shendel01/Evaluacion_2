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
    public partial class frmDireccionManager : Form
    {
        bool resultado = false;
        ejemplo.Persona personaGlobal;
        ejemplo.Direccion direccionGlobal;
        ejemplo.EjemploSoapClient example = new ejemplo.EjemploSoapClient();
        public frmDireccionManager()
        {
            InitializeComponent();
        }

        public bool setForm(Form _parent, ejemplo.Persona _Persona, ejemplo.Direccion _direccion)
        {
            this.personaGlobal = _Persona;
            this.direccionGlobal = _direccion;
            this.setInformation();
            this.ShowDialog(_parent);
            return this.resultado;
        }
        private void setTamIndex()
        {
            try
            {
                int c = 0;
                this.txtCalle.TabIndex = c++;
                this.txtNumero.TabIndex = c++;
                this.txtColonia.TabIndex = c++;
                this.btnAceptar.TabIndex = c++;
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
                this.setTamIndex();
                if (this.direccionGlobal == null)
                {
                    this.lblAccion.Text = "Agregar";
                }
                else
                {
                    this.lblAccion.Text = "Editar";
                    this.txtCalle.Text = this.direccionGlobal.StrCalle;
                    this.txtColonia.Text = this.direccionGlobal.StrColonia;
                    this.txtNumero.Text = this.direccionGlobal.StrNumero;
                    //this.txtAMaterno.Text = this.personaGlobal.StrAMaterno;
                    //this.cmbSexo.SelectedIndex = this.cmbSexo.FindString(this.personaGlobal.CatSexoTemp.StrValor);
                }

            }
            catch (Exception _e)
            {
                throw _e;
            }

        }

        //private void setInformation()
        //{
        //    try
        //    {
        //        ejemplo.CatSexo[] listaSexo = this.example.consultaGlobalSexo();
        //        this.cmbSexo.DataSource = listaSexo;
        //        this.cmbSexo.ValueMember = "Id";
        //        this.cmbSexo.DisplayMember = "StrValor";
        //        if (this.direccionGlobal == null)
        //        {
        //            this.lblAccion.Text = "Agregar";
        //        }
        //        else
        //        {
        //            this.lblAccion.Text = "Editar";
        //            this.t.Text = this.personaGlobal.StrClaveUnica;
        //            this.txtNombre.Text = this.personaGlobal.StrNombre;
        //            this.txtAParterno.Text = this.personaGlobal.StrAPaterno;
        //            this.txtAMaterno.Text = this.personaGlobal.StrAMaterno;
        //            this.cmbSexo.SelectedIndex = this.cmbSexo.FindString(this.personaGlobal.CatSexoTemp.StrValor);
        //        }

        //    }
        //    catch (Exception _e)
        //    {
        //        throw _e;
        //    }

        //}


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                ejemplo.Direccion personaTemp = new ejemplo.Direccion();
                if (this.lblAccion.Text == "Agregar")
                {
                    personaTemp.IdPersona = this.personaGlobal.Id;
                }
                if (this.lblAccion.Text == "Editar")
                {
                    personaTemp.Id = direccionGlobal.Id;
                }
                personaTemp.StrCalle = this.txtCalle.Text.Trim();
                personaTemp.StrNumero = this.txtNumero.Text.Trim();
                personaTemp.StrColonia = this.txtColonia.Text.Trim();

                if (this.direccionGlobal == null)
                {
                    if (this.validaCalle())
                    {
                        this.resultado = this.example.insertarDireccion(personaTemp);
                    }
                    if (resultado)
                    {
                        MessageBox.Show("El registro se inserto correctamente");
                    }
                    else
                    {
                        MessageBox.Show("hay probelmas :(");
                    }
                }
                else
                {
                    this.resultado = this.example.editarDireccion(personaTemp);
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

        private bool validaCalle()
        {
            try
            {
                if (this.txtCalle.Text == String.Empty)
                {
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Guardar el registro antes de salir?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes)
            {
                if (this.txtCalle.Text == String.Empty)
                {
                     MessageBox.Show("Calle Vacío", "Sistema ", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
                        else
                        {
                            try
                            {

                                ejemplo.Direccion personaTemp = new ejemplo.Direccion();
                                if (this.lblAccion.Text == "Agregar")
                                {
                                    personaTemp.IdPersona = this.personaGlobal.Id;
                                }
                                if (this.lblAccion.Text == "Editar")
                                {
                                    personaTemp.Id = direccionGlobal.Id;
                                }
                                personaTemp.StrCalle = this.txtCalle.Text.Trim();
                                personaTemp.StrNumero = this.txtNumero.Text.Trim();
                                personaTemp.StrColonia = this.txtColonia.Text.Trim();

                                if (this.direccionGlobal == null)
                                {
                                    if (this.validaCalle())
                                    {
                                        this.resultado = this.example.insertarDireccion(personaTemp);
                                    }
                                    if (resultado)
                                    {
                                        MessageBox.Show("El registro se inserto correctamente", "Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("hay probelmas :(");
                                    }
                                }
                            }
                            catch (Exception _e)
                            {
                                throw _e;
                            }
                        }
                    }
                    else
                    {
                        this.Close();
                    }

                }
            }
        }
