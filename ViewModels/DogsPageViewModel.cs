using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DogsExhibitionsSystem.Managers;
using DogsExhibitionsSystem.Models;

namespace DogsExhibitionsSystem.ViewModels
{
    public class DogsPageViewModel : MvxViewModel
    {
        private readonly DogManager _dogManager;
        private ObservableCollection<Dog> _dogs;

        public ObservableCollection<Dog> Dogs { get => _dogs; private set => SetProperty(ref _dogs, value, nameof(Dogs)); }

        public ICommand RefreshGridCmd { get; set; }

        public DogsPageViewModel(DogManager dogManager)
        {
            _dogManager = dogManager;
            InitializeCmds();
        }

        private void InitializeCmds()
        {
            RefreshGridCmd = new MvxCommand(RefreshGridCmdAction);
        }

        private void RefreshGridCmdAction()
        {
            Dogs = new ObservableCollection<Dog>(_dogManager.GetDogs());
        }
    }
}
