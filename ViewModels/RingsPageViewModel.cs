using MvvmCross.ViewModels;
using DogsExhibitionsSystem.Managers;

namespace DogsExhibitionsSystem.ViewModels
{
    public class RingsPageViewModel : MvxViewModel
    {
        private readonly RingManager _ringManager;

        public RingsPageViewModel(RingManager ringManager)
        {
            _ringManager = ringManager;
        }
    }
}
