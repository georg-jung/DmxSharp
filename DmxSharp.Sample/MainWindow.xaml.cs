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
using DmxSharp.Filters.Scene;
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
        private ColorSceneGenerator _sceneGen;
        private ManualGenerator _trigger;
        private SceneTranslator _translator;
        private SceneBlackout _blackout;

        public MainWindow()
        {
            InitializeComponent();
            CreateDmx();
        }

        public void CreateDmx()
        {
            var uni = new Universe();
            var sgenFac = new SceneGeneratorFactory();
            var sigGen = new CompositeGenerator();
            _trigger = new ManualGenerator();
            _sink = new AvSink("192.168.0.2", 5120);
            _controller = new Controller(uni, _translator, sgenFac, sigGen, _sink);

            sigGen.Add(_trigger);
            sigGen.Add(new HertzGenerator(5000));

            _translator = new SceneTranslator();
            _blackout = new SceneBlackout();
            _translator.SceneFilters.Add(_blackout);

            uni.TryAddDevice(new RgbLight(Guid.NewGuid()), 17); // klSu
            uni.TryAddDevice(new RgbLight(Guid.NewGuid()), 25); // klSo

            _sink.TurnOn();

            _sceneGen = (ColorSceneGenerator)_controller.SceneGenerator;
        }

        private void ButtonR_Click(object sender, RoutedEventArgs e)
        {
            _sceneGen.Color = Models.Color.Red;
            _trigger.Trigger();
        }

        private void ButtonG_Click(object sender, RoutedEventArgs e)
        {
            _sceneGen.Color = Models.Color.Green;
            _trigger.Trigger();
        }

        private void ButtonB_Click(object sender, RoutedEventArgs e)
        {
            _sceneGen.Color = Models.Color.Blue;
            _trigger.Trigger();
        }

        private void ButtonW_Click(object sender, RoutedEventArgs e)
        {
            _sceneGen.Color = Models.Color.White;
            _trigger.Trigger();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _blackout.Active = Blackout.IsChecked == true;
            _trigger.Trigger();
        }
    }
}
