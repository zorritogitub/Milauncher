using System;
using System.Diagnostics;
using System.Windows;

namespace MiLauncher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Jugar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Aquí puedes poner la lógica para iniciar tu juego
                StatusText.Text = "Iniciando juego...";
                
                // Ejemplo: abrir el explorador de archivos
                Process.Start("explorer.exe");
                
                // O si tienes un juego: Process.Start("juego.exe");
                
                StatusText.Text = "Juego iniciado correctamente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar: {ex.Message}", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                StatusText.Text = "Error al iniciar";
            }
        }
    }
}