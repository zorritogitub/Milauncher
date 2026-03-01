using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

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
                new GameInfo { Nombre = "World of Warcraft", Estado = "Instalado" },
                new GameInfo { Nombre = "Overwatch 2", Estado = "Actualizar disponible" },
                new GameInfo { Nombre = "Diablo IV", Estado = "No instalado" },
                new GameInfo { Nombre = "Hearthstone", Estado = "Instalado" },
                new GameInfo { Nombre = "StarCraft II", Estado = "Instalado" },
                new GameInfo { Nombre = "Call of Duty", Estado = "En descarga" }
            };
            
            DataContext = this;
            
            // Suscribirse al evento de carga para configurar la ventana
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Asegurar que la ventana se pueda redimensionar correctamente
            this.MinHeight = 500;
            this.MinWidth = 800;
        }

        // Método para permitir arrastrar la ventana desde cualquier parte de la barra de título
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                // Doble clic en la barra de título maximiza/restaura
                Maximize_Click(sender, e);
            }
            else
            {
                // Arrastrar la ventana
                this.DragMove();
            }
        }

        private void Jugar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StatusText.Text = "Iniciando juego...";
                
                // Simular inicio de juego
                System.Threading.Thread.Sleep(500);
                
                StatusText.Text = $"{((System.Windows.Controls.Button)sender).Content} iniciado correctamente";
                
                // Aquí iría la lógica real: Process.Start("tu_juego.exe");
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
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                // Opcional: Ajustar el borde cuando se restaura
                UpdateMaximizeButtonText("□");
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                UpdateMaximizeButtonText("❐");
            }
        }

        private void UpdateMaximizeButtonText(string text)
        {
            // Buscar el botón de maximizar por su nombre si lo necesitas
            // Por ahora simplemente lo dejamos así
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Navegación
        private void Juegos_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Sección: Juegos - Mostrando tu biblioteca";
        }

        private void Tienda_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Sección: Tienda - Próximamente";
        }

        private void Noticias_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Sección: Noticias - Últimas actualizaciones";
        }

        private void Configuracion_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Sección: Configuración - Ajustes del launcher";
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Manejar el cambio de estado de la ventana para ajustar la sombra
        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            
            if (this.WindowState == WindowState.Maximized)
            {
                // Cuando está maximizada, quitamos el borde redondeado y la sombra
                this.BorderThickness = new Thickness(0);
            }
            else
            {
                // Cuando está normal, restauramos el borde
                this.BorderThickness = new Thickness(1);
            }
        }
    }
}
