#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
#else
using System;
using System.Windows.Controls;
#endif

namespace TTest
{
    /// <summary>
    /// Interaction logic for TTestMainView.xaml
    /// </summary>
    public partial class TTestMainView : UserControl
    {
        public TTestMainView()
        {
            InitializeComponent();
        }

#if NOESIS
        private void InitializeComponent()
        {
            NoesisUnity.LoadComponent(this);
        }
#endif
    }
}
