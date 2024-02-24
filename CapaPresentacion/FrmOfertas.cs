using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmOfertas : Form
    {
        public FrmOfertas()
        {
            InitializeComponent();
        }

        private void FrmOfertas_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Value";
            cmbEstado.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                if (column.Visible == true && column.Name != "btnSeleccionar")
                {
                    cmbBusqueda.Items.Add(new OpcionCombo() { Valor = column.Name, Texto = column.HeaderText });
                }
            }
            cmbBusqueda.DisplayMember = "Texto";
            cmbBusqueda.ValueMember = "Value";
            cmbBusqueda.SelectedIndex = 0;

            List<Oferta> lista = new CN_Oferta().Listar();

            foreach (Oferta item in lista)
            {
                dgvData.Rows.Add(new object[] {"",item.IdOferta,item.NombreOferta,item.Descuento,item.FechaInicio,item.FechaFin,item.Foto,item.PantallaPrincipal,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "Activo" : "Inactivo",
                });

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal descuento = 0;
            if (!decimal.TryParse(txtDescuento.Text, out descuento))
            {
                MessageBox.Show("descuento - formato incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescuento.Select();
                return;
            }
            try
            {
                byte[] byteimagen = null;
                byte[] byteimagen2 = null;

                string mensaje = string.Empty;
                Oferta objoferta = new Oferta()
                {
                    IdOferta = Convert.ToInt32(txtId.Text),
                    NombreOferta = txtNombreOferta.Text,
                    Descuento = Convert.ToDecimal(txtDescuento.Text),
                    FechaInicio = txtFechaInicio.Value,
                    FechaFin = txtFechaFin.Value,
                    Estado = Convert.ToInt32(((OpcionCombo)cmbEstado.SelectedItem).Valor) == 1
                };

                if (picFoto.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picFoto.Image.Save(ms, ImageFormat.Jpeg);
                        byteimagen = ms.ToArray();
                    }
                }
                if (picPantallaPrincipal.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picPantallaPrincipal.Image.Save(ms, ImageFormat.Jpeg);
                        byteimagen2 = ms.ToArray();
                    }
                }

                CN_Oferta cnOferta = new CN_Oferta();

                if (objoferta.IdOferta == 0)
                {
                    int idofertagenerado = cnOferta.Registrar(objoferta, byteimagen, byteimagen2, out mensaje);

                    if (idofertagenerado != 0)
                    {
                        // Agregar la nueva fila a la DataGridView
                        dgvData.Rows.Add(new object[] { "", idofertagenerado, txtNombreOferta.Text, descuento.ToString("0.00"), txtFechaInicio.Value.ToString(),txtFechaFin.Value.ToString(), byteimagen, byteimagen2,
                        ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString()});

                        // Limpiar los campos y mostrar mensaje de éxito
                        limpiar();
                        MessageBox.Show("Oferta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    bool resultado = cnOferta.Editar(objoferta, byteimagen, byteimagen2, out mensaje);

                    if (resultado)
                    {
                        // Actualizar la fila editada en la DataGridView
                        DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["Id"].Value = txtId.Text;
                        row.Cells["NombreOferta"].Value = txtNombreOferta.Text;
                        row.Cells["Descuento"].Value = Convert.ToDecimal(txtDescuento.Text);
                        row.Cells["FechaInicio"].Value = txtFechaInicio.Value.ToString();
                        row.Cells["FechaFin"].Value = txtFechaFin.Value.ToString();
                        row.Cells["Foto"].Value = byteimagen;
                        row.Cells["PantallaPrincipal"].Value = byteimagen2;
                        row.Cells["EstadoValor"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Valor.ToString();
                        row.Cells["Estado"].Value = ((OpcionCombo)cmbEstado.SelectedItem).Texto.ToString();

                        // Limpiar los campos y mostrar mensaje de éxito
                        limpiar();
                        MessageBox.Show("Oferta actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtNombreOferta.Text = string.Empty;
            txtDescuento.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            txtFechaInicio.Text = string.Empty;
            picFoto.Image = Properties.Resources.fotonodata;
            picPantallaPrincipal.Image = Properties.Resources.fotonodata;

            cmbEstado.SelectedIndex = 0;
            txtNombreOferta.Focus();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.editar.Width;
                var h = Properties.Resources.editar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Width - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.editar, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Verificar si se hizo clic en el botón "btnSeleccionar"
                if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
                {
                    int indice = e.RowIndex;

                    if (indice >= 0)
                    {
                        txtIndice.Text = indice.ToString();
                        txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                        txtNombreOferta.Text = dgvData.Rows[indice].Cells["NombreOferta"].Value.ToString();
                        txtDescuento.Text = dgvData.Rows[indice].Cells["Descuento"].Value.ToString();
                        txtFechaInicio.Value = Convert.ToDateTime(dgvData.Rows[indice].Cells["FechaInicio"].Value);
                        txtFechaFin.Value = Convert.ToDateTime(dgvData.Rows[indice].Cells["FechaFin"].Value);

                        int idOferta = Convert.ToInt32(dgvData.Rows[indice].Cells["Id"].Value);
                        bool obtenido = true;

                        byte[] bytesImagen = new CN_Oferta().ObtenerFoto(idOferta, out obtenido);

                        bool encontrado = true;

                        byte[] bytesImagen2 = new CN_Oferta().ObtenerFotoPrincipal(idOferta, out encontrado);


                        if (obtenido)
                        {
                            Image imagen = ByteAimagen(bytesImagen);
                            picFoto.Image = imagen;

                        }
                        if (encontrado)
                        {
                            Image imagen2 = ByteAimagen2(bytesImagen2);
                            picPantallaPrincipal.Image = imagen2;

                        }
                        foreach (OpcionCombo oc in cmbEstado.Items)
                        {
                            if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                            {
                                int indice_combo = cmbEstado.Items.IndexOf(oc);
                                cmbEstado.SelectedIndex = indice_combo;
                                break;

                            }
                        }
                    }
                }
            }
        }
        public Image ByteAimagen(byte[] imagenBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagenBytes, 0, imagenBytes.Length);
            Image imagen = new Bitmap(ms);

            return imagen;

        }
        public Image ByteAimagen2(byte[] imagenBytes2)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagenBytes2, 0, imagenBytes2.Length);
            Image imagen2 = new Bitmap(ms);

            return imagen2;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("¿Desea realmente eliminar la oferta?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Oferta objoferta = new Oferta()
                    {

                        IdOferta = Convert.ToInt32(txtId.Text)

                    };
                    bool respuesta = new CN_Oferta().Eliminar(objoferta, out mensaje);
                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));

                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cmbBusqueda.SelectedItem).Valor.ToString();
            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.ico;*.tif;*.tiff;*.emf;*.wmf;*.svg;*.exif;*.jfif;*.jpe;*.jif;*.webp;*.webp2;*.webp3";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Genera un nombre de archivo único basado en la fecha y la hora
                    string fileName = "temp_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

                    // Carga la imagen WebP y la guarda con el nombre único
                    using (MagickImage webpImage = new MagickImage(openFileDialog.FileName))
                    {
                        webpImage.Format = MagickFormat.Jpeg;
                        webpImage.Write(fileName);
                    }

                    picFoto.Image = Image.FromFile(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            picFoto.Image = Properties.Resources.fotonodata;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.ico;*.tif;*.tiff;*.emf;*.wmf;*.svg;*.exif;*.jfif;*.jpe;*.jif;*.webp;*.webp2;*.webp3";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Genera un nombre de archivo único basado en la fecha y la hora
                    string fileName2 = "temp_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

                    // Carga la imagen WebP y la guarda con el nombre único
                    using (MagickImage webpImage = new MagickImage(openFileDialog.FileName))
                    {
                        webpImage.Format = MagickFormat.Jpeg;
                        webpImage.Write(fileName2);
                    }

                    picPantallaPrincipal.Image = Image.FromFile(fileName2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
