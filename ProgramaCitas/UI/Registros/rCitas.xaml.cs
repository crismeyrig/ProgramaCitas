using System.Windows;
using ProgramaCitas.BLL;
using ProgramaCitas.Entidades;
using System;

namespace ProgramaCitas.UI.Registros
{
    public partial class rCitas : Window
    {
        private Citas cita = new Citas();
        public rCitas()
        {
            InitializeComponent();
            DataContext = cita;

        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = cita;

        }
        //——————————————————————————————————————————————————————————————[ Limpiar ]——————————————————————————————————————————————————————————————
        private void Limpiar()
        {
            this.cita = new Citas();
            this.DataContext = cita;
        }
        //——————————————————————————————————————————————————————————————[ Validar ]——————————————————————————————————————————————————————————————
        private bool Validar()
        {
            bool Validado = true;
            if (CitaIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Debe ingresar la cita Id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        //——————————————————————————————————————————————————————————————[ Buscar ]———————————————————————————————————————————————————————————————
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Citas encontrado = CitasBLL.Buscar(Utilidades.ToInt(CitaIdTextBox.Text));

            if (encontrado != null)
            {
                this.cita = encontrado;
                Cargar();
            }
            else
            {
                this.cita = new Citas();
                this.DataContext = this.cita;
                MessageBox.Show($"Esta cita no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                CitaIdTextBox.SelectAll();
                CitaIdTextBox.Focus();
            }
            if (CitaIdTextBox.Text == "1")
            {
                EliminarButton.IsEnabled = false;
            }
            else
            {
                EliminarButton.IsEnabled = true;
            }
        }
        //——————————————————————————————————————————————————————————————[ Nuevo ]———————————————————————————————————————————————————————————————
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            EliminarButton.IsEnabled = true;
        }
        //——————————————————————————————————————————————————————————————[ Guardar ]———————————————————————————————————————————————————————————————
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                //———————————————————————————————————————————————————————[ VALIDAR TEXTBOX ]———————————————————————————————————————————————————————
                //—————————————————————————————————[ Usuario Id ]—————————————————————————————————
                if (CitaIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (cita Id) está vacío.\n\nAsigne un Id al Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CitaIdTextBox.Text = "0";
                    CitaIdTextBox.Focus();
                    CitaIdTextBox.SelectAll();
                    return;
                }
                //—————————————————————————————————[ Nombres ]—————————————————————————————————
                if (NombresTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombres) está vacío.\n\nEscriba sus Nombres.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombresTextBox.Clear();
                    NombresTextBox.Focus();
                    return;
                }
                //—————————————————————————————————[ Apellidos ]—————————————————————————————————
                if (ApellidosTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Apellidos) está vacío.\n\nEscriba sus Apellidos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ApellidosTextBox.Clear();
                    ApellidosTextBox.Focus();
                    return;
                }
                //—————————————————————————————————[ Fecha  ]—————————————————————————————————
                if (FechaDatePicker.Text.Trim() == string.Empty)
                {
                    MessageBox.Show($"El Campo (Fecha Reserva) está vacío.\n\nSeleccione una fecha.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    FechaDatePicker.Focus();
                    return;
                }

            }
            //——————————————————————————————————————————————————————————————[ Eliminar ]———————————————————————————————————————————————————————————————
            private void EliminarButton_Click(object sender, RoutedEventArgs e)
            {
                //—————————————————————————————————[ Evitar que se borre el Usuario Admin Id #1 ]—————————————————————————————————
                if (CitaIdTextBox.Text == "1")
                {
                    MessageBox.Show("No se pudo eliminar esta cita.\n\nNo puede eliminar este Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Limpiar();
                    CitaIdTextBox.Focus();
                    CitaIdTextBox.SelectAll();
                    return;
                }

                if (CitasBLL.Eliminar(Utilidades.ToInt(CitaIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro por que no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
