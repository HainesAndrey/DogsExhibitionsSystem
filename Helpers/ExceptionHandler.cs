using System;
using System.Threading.Tasks;
using DogsExhibitionsSystem.Managers;

namespace DogsExhibitionsSystem.Helpers
{
    public static class ExceptionHandler
    {
        public static void Handle(Action action, MessageBoxManager boxManager)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                boxManager.ShowException(ex);
                throw;
            }
        }

        public static async Task Handle(Func<Task> task, MessageBoxManager boxManager)
        {
            try
            {
                await task();
            }
            catch (Exception ex)
            {
                boxManager.ShowException(ex);
                throw;
            }
        }
    }
}
