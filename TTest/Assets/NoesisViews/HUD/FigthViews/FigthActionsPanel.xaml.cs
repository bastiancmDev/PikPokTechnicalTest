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
    public partial class FigthActionsPanel: UserControl
    {
        public FigthActionsPanel()
        {
#if NOESIS
            Initialized += OnInitialized;
#endif
            InitializeComponent();
        }

#if NOESIS
        private void OnInitialized(object sender, Noesis.EventArgs args)
        {
            this.Visibility = Visibility.Collapsed;
            ManagerCentralizer.Instance.UiMenuControllerInstance.ShowFightUIEvent += ActiveThisPanel;
        }
#endif

        public int Counter
        {
            get { return (int)GetValue(CounterProperty); }
            set { SetValue(CounterProperty, value); }
        }

        public static readonly DependencyProperty CounterProperty =  DependencyProperty.Register(
            "Counter", typeof(int), typeof(FigthActionsPanel), new PropertyMetadata(0));

#if NOESIS
        protected override bool ConnectEvent(object source, string eventName, string handlerName)
        {
            if (eventName == "MouseUp" && handlerName == "AttackEnemy")
            {
                ((Border)source).MouseUp += this.AttackEnemy;
                return true;
            }

            return false;
        }

        private void InitializeComponent()
        {
            NoesisUnity.LoadComponent(this);
        }
#endif

        private void AttackEnemy(object sender, RoutedEventArgs args)
        {
#if NOESIS
            ManagerCentralizer.Instance.GamePlayContollerInstance.CurrentFigthModality.ActionFromPlayer(ACTION_PLAYER_TYPE.ATACK);
#endif
        }


        public void ActiveThisPanel(bool show)
        {
            if (show)
            {
                this.Visibility = Visibility.Visible;
            }
            else
            {
                this.Visibility = Visibility.Collapsed;
            }            
        }

      
    }
}