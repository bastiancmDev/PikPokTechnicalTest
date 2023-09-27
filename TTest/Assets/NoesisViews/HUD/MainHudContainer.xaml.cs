#if UNITY_5_3_OR_NEWER
    #define NOESIS
    using Noesis;
using System;
#else
    using System.Windows;
    using System.Windows.Controls;
#endif

namespace Testing
{
    public partial class MainHudContainer: UserControl
    {
        public MainHudContainer()
        {
#if NOESIS
            Initialized += OnInitialized;
#endif
            InitializeComponent();
        }
#if NOESIS
        private void OnInitialized(object sender, Noesis.EventArgs args)
        {
            
        }
#endif

        public int Counter
        {
            get { return (int)GetValue(CounterProperty); }
            set { SetValue(CounterProperty, value); }
        }

        public static readonly DependencyProperty CounterProperty =  DependencyProperty.Register(
            "Counter", typeof(int), typeof(MainHudContainer), new PropertyMetadata(0));

#if NOESIS
        protected override bool ConnectEvent(object source, string eventName, string handlerName)
        {
            if (eventName == "Click" && handlerName == "Button_Click")
            {
                ((Button)source).Click += this.Button_Click;
                return true;
            }

            return false;
        }

        private void InitializeComponent()
        {
            NoesisUnity.LoadComponent(this);
        }
#endif

        private void Button_Click(object sender, RoutedEventArgs args)
        {
            Counter++;
        }
    }}