using DogsExhibitionsSystem.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DogsExhibitionsSystem.Views.CollectionViews
{
    public partial class ClubsView : UserControl
    {
        public ICollection<Club> Clubs
        {
            get { return (ICollection<Club>)GetValue(ClubsProperty); }
            set { SetValue(ClubsProperty, value); }
        }

        public static readonly DependencyProperty ClubsProperty =
            DependencyProperty.Register("Clubs", typeof(ICollection<Club>), typeof(ClubsView));

        public Club SelectedClub
        {
            get { return (Club)GetValue(SelectedClubProperty); }
            set { SetValue(SelectedClubProperty, value); }
        }

        public static readonly DependencyProperty SelectedClubProperty =
            DependencyProperty.Register("SelectedClub", typeof(Club), typeof(ClubsView));

        public ClubsView()
        {
            InitializeComponent();
        }
    }
}
