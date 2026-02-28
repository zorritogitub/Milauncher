using System;
using System.Diagnostics;
using System.Windows;

namespace MiLauncher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Esto debe estar aquí
        }

        private void Jugar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StatusText.Text = "Iniciando juego..."; // StatusText debe existir en XAML
                
                // Aquí iría la lógica para iniciar tu juego
                Process.Start("explorer.exe"); // Ejemplo
                
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