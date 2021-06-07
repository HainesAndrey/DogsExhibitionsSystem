using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DogsExhibitionsSystem.Models;

namespace DogsExhibitionsSystem.Views.CollectionViews
{
    public partial class DogPedigreesView : UserControl
    {
        public DogPedigree SelectedPedigree
        {
            get { return (DogPedigree)GetValue(SelectedPedigreeProperty); }
            set { SetValue(SelectedPedigreeProperty, value); }
        }

        public static readonly DependencyProperty SelectedPedigreeProperty =
            DependencyProperty.Register("SelectedPedigree", typeof(DogPedigree), typeof(DogPedigreesView));

        public ICollection<DogPedigree> Pedigrees
        {
            get { return (ICollection<DogPedigree>)GetValue(PedigreesProperty); }
            set { SetValue(PedigreesProperty, value); }
        }

        public static readonly DependencyProperty PedigreesProperty =
            DependencyProperty.Register("Pedigrees", typeof(ICollection<DogPedigree>), typeof(DogPedigreesView));

        public DogPedigreesView()
        {
            InitializeComponent();
        }
    }
}
