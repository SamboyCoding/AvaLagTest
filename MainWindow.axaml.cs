using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaLagTest
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;
        private int numChars;
        private int numLines;
        
        public MainWindow()
        {
            DataContext = _vm = new();

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void UpdateSummary()
        {
            _vm.Summary = $"{numChars} characters, {numLines} lines";
        }

        private void StartLogging(object? sender, RoutedEventArgs e)
        {
            var toAdd = "Log entry goes here and is really long to cause the text to wrap over multiple lines or at least cause a horizontal scrollbar to appear at the bottom of the log console." +
                        "========================================================================================================================================================================\n";
            var chars = toAdd.Length;
            
            new Thread(() =>
            {
                while (true)
                {
                    _vm.LogText += toAdd;
                    numChars += chars;
                    numLines += 1;
                    UpdateSummary();
                    
                    Thread.Sleep(50);
                }
            })
            {
                IsBackground = true,
            }.Start();
        }
    }
}