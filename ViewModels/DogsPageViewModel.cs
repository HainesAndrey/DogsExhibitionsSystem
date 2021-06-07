using DogsExhibitionsSystem.Managers;
using DogsExhibitionsSystem.Models;
using DogsExhibitionsSystem.Views.CollectionViews;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace DogsExhibitionsSystem.ViewModels
{
    public class DogsPageViewModel : MvxViewModel
    {
        private readonly DogManager _dogManager;
        private readonly ClubManager _clubManager;

        private ObservableCollection<Dog> _dogs;
        private ObservableCollection<DogBreed> _allBreeds;
        private ObservableCollection<DogPedigree> _allPedigrees;
        private ObservableCollection<DogHandler> _allHandlers;
        private ObservableCollection<Club> _allClubs;
        private Dog _selectedDog;

        public ObservableCollection<Dog> Dogs { get => _dogs; set => SetProperty(ref _dogs, value, nameof(Dogs)); }
        public ObservableCollection<DogBreed> AllBreeds { get => _allBreeds; private set => SetProperty(ref _allBreeds, value, nameof(AllBreeds)); }
        public ObservableCollection<DogPedigree> AllPedigrees { get => _allPedigrees; set => SetProperty(ref _allPedigrees, value, nameof(AllPedigrees)); }
        public ObservableCollection<DogHandler> AllHandlers { get => _allHandlers; set => SetProperty(ref _allHandlers, value, nameof(AllHandlers)); }
        public ObservableCollection<Club> AllClubs { get => _allClubs; private set => SetProperty(ref _allClubs, value, nameof(AllClubs)); }
        public Dog SelectedDog { get => _selectedDog; set => SetProperty(ref _selectedDog, value, nameof(SelectedDog)); }

        public ICommand RefreshGridCmd { get; set; }

        public ICommand ShowPedigreesCmd { get; set; }
        public ICommand ShowHandlersCmd { get; set; }
        public ICommand ShowClubsCmd { get; set; }

        public DogsPageViewModel(DogManager dogManager, ClubManager clubManager)
        {
            _dogManager = dogManager;
            _clubManager = clubManager;
            InitializeCmds();
        }

        private void InitializeCmds()
        {
            RefreshGridCmd = new MvxCommand(RefreshGridCmdAction);

            ShowPedigreesCmd = new MvxCommand(ShowPedigreesCmdAction);
            ShowHandlersCmd = new MvxCommand(ShowHandlersCmdAction);
            ShowClubsCmd = new MvxCommand(ShowClubsCmdAction);
        }

        private void RefreshGridCmdAction()
        {
            Dogs = new ObservableCollection<Dog>(_dogManager.GetDogs());
            AllBreeds = new ObservableCollection<DogBreed>(_dogManager.GetBreeds());
            AllPedigrees = new ObservableCollection<DogPedigree>(_dogManager.GetPedigrees());
            AllHandlers = new ObservableCollection<DogHandler>(_dogManager.GetHandlers());
            AllClubs = new ObservableCollection<Club>(_clubManager.GetClubs());

            SelectedDog = Dogs.FirstOrDefault();
        }

        private void ShowPedigreesCmdAction()
        {
            ShowCollectionWindow<DogPedigreesView, DogPedigree>("Все родословные", DogPedigreesView.PedigreesProperty, DogPedigreesView.SelectedPedigreeProperty,
                AllPedigrees, SelectedDog, nameof(SelectedDog.Pedigree));
        }

        private void ShowHandlersCmdAction()
        {
            ShowCollectionWindow<DogHandlersView, DogHandler>("Все хозяева собак", DogHandlersView.HandlersProperty, DogHandlersView.SelectedHandlerProperty,
                AllHandlers, SelectedDog, nameof(SelectedDog.Handler));
        }

        private void ShowClubsCmdAction()
        {
            ShowCollectionWindow<ClubsView, Club>("Все клубы", ClubsView.ClubsProperty, ClubsView.SelectedClubProperty,
                AllClubs, SelectedDog, nameof(SelectedDog.Club));
        }

        private void ShowCollectionWindow<TView, TModel>(string wndTitle, DependencyProperty collectionProp, DependencyProperty selItemProp,
            ICollection<TModel> collection, object selItem, string bindPath) where TView : ContentControl, new()
        {
            var view = new TView();
            view.SetBinding(collectionProp, new Binding() { Source = collection });
            view.SetBinding(selItemProp, new Binding(bindPath) { Source = selItem, Mode = BindingMode.TwoWay });
            var wnd = new Window() { Title = wndTitle, Content = view };
            wnd.ShowDialog();
        }
    }
}
