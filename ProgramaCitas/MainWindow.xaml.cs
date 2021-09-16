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
            cCitas cUsuarios1 = new cCitas();
            cCitas1.Show();

        }
        private void AyudaMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
