using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DmxSharp.Devices;
using DmxSharp.SignalGenerators;

namespace DmxSharp.Sample
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller _controller;
        private AvSink _sink;

        public MainWindow()
        {
            InitializeComponent();
            CreateDmx();
        }

        public void CreateDmx()
        {
            var uni = new Universe();
            var sTrans = new SceneTranslator();
            var sgenFac = new SceneGeneratorFactory();
            var sigGen = new HertzGenerator();
            _sink = new AvSink("192.168.0.2", 5120);
            _controller = new Controller(uni, sTrans, sgenFac, sigGen, _sink);

            uni.TryAddDevice(new RgbLight(Guid.NewGuid()), 17); // klSu
            uni.TryAddDevice(new RgbLight(Guid.NewGuid()), 25); // klSo
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_sink.TurnedOn) _sink.TurnOff();
            else _sink.TurnOn();
        }
    }
}
