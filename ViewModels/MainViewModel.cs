using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;
using DogsExhibitionsSystem.Helpers;
using DogsExhibitionsSystem.Managers;

namespace DogsExhibitionsSystem.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public DogsPageViewModel DogsPageVm { get; set; }
        public ExpertsPageViewModel ExpertsPageVm { get; set; }
        public RingsPageViewModel RingsPageVm { get; set; }
        public RequestsPageViewModel RequestsPageVm { get; set; }

        private MessageBoxManager _messageBoxManager;
        private DbManager _dbManager;
        private RingManager _ringManager;
        private ClubManager _clubManager;
        private DogManager _dogManager;

        public ICommand CreateDataBaseCmd { get; private set; }

        public MainViewModel()
        {
            ExceptionHandler.Handle(() =>
            {
                InitializeManagers();
                InitializeVms();
                InitializeCmds();
            }, _messageBoxManager);
        }

        private void InitializeManagers()
        {
            _messageBoxManager = new MessageBoxManager();
            _dbManager = new DbManager(App.DbFilePath);
            _ringManager = new RingManager(_dbManager);
            _clubManager = new ClubManager(_dbManager);
            _dogManager = new DogManager(_dbManager);
        }

        private void InitializeVms()
        {
            DogsPageVm = new DogsPageViewModel(_dogManager);
            ExpertsPageVm = new ExpertsPageViewModel();
            RingsPageVm = new RingsPageViewModel(_ringManager);
            RequestsPageVm = new RequestsPageViewModel();
        }

        private void InitializeCmds()
        {
            CreateDataBaseCmd = new MvxAsyncCommand(CreateDataBaseCmdAction);
        }

        #region Commands actions
        private Task CreateDataBaseCmdAction()
        {
            return ExceptionHandler.Handle(async () =>
            {
                if (await _dbManager.Database.EnsureCreatedAsync())
                    await _dbManager.FillAsync();
                //return Task.CompletedTask;
            }, _messageBoxManager);
        }
        #endregion
    }
}
