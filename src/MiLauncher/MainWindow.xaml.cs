using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace MiLauncher
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<GameInfo> MisJuegos { get; set; }

        public class GameInfo
        {
            public string Nombre { get; set; }
            public string Estado { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            // Inicializar datos de ejemplo
            MisJuegos = new ObservableCollection<GameInfo>
            {
                new GameInfo { Nombre = "Mi Juego 1", Estado = "Instalado" },
                new GameInfo { Nombre = "Mi Juego 2", Estado = "Actualizar" },
                new GameInfo { Nombre = "Mi Juego 3", Estado = "No instalado" }
            };
            
            DataContext = this;
        }

        private void Jugar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StatusText.Text = "Iniciando juego...";
                
                // Aquí iría la lógica para iniciar tu juego
                // Process.Start("tu_juego.exe");
                
                // Simulación
                System.Threading.Thread.Sleep(1000);
                
                StatusText.Text = "Juego iniciado correctamente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar: {ex.Message}", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                StatusText.Text = "Error al iniciar";
            }
        }

        // Controles de ventana
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized 
                ? WindowState.Normal 
                : WindowState.Maximized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Navegación
        private void Juegos_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Sección: Juegos";
            // Aquí navegarías a la vista de juegos
        }

        private void Tienda_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Sección: Tienda";
        }

        private void Noticias_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Sección: Noticias";
        }

        private void Configuracion_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Sección: Configuración";
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
