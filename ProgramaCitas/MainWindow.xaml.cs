using System;
using System.Windows;
using ProgramaCitas.UI.Registros;

namespace ProgramaCitas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void rCitasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rCitas rCitas1 = new rCitas();
            rCitas1.Show();

        }
        private void cUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
           

        }
        private void AyudaMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
