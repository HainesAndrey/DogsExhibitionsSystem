using System.Windows.Controls;
using DogsExhibitionsSystem.Models;
using System.Collections.Generic;
using System.Windows;

namespace DogsExhibitionsSystem.Views.CollectionViews
{
    public partial class DogHandlersView : UserControl
    {
        public ICollection<DogHandler> Handlers
        {
            get { return (ICollection<DogHandler>)GetValue(HandlersProperty); }
            set { SetValue(HandlersProperty, value); }
        }

        public static readonly DependencyProperty HandlersProperty =
            DependencyProperty.Register("Handlers", typeof(ICollection<DogHandler>), typeof(DogHandlersView));

        public DogHandler SelectedHandler
        {
            get { return (DogHandler)GetValue(SelectedHandlerProperty); }
            set { SetValue(SelectedHandlerProperty, value); }
        }

        public static readonly DependencyProperty SelectedHandlerProperty =
            DependencyProperty.Register("SelectedHandler", typeof(DogHandler), typeof(DogHandlersView));

        public DogHandlersView()
        {
            InitializeComponent();
        }
    }
}
