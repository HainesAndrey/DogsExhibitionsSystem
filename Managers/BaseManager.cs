using DogsExhibitionsSystem.Managers;

namespace DogsExhibitionsSystem.Bases
{
    public abstract class BaseManager
    {
        protected readonly DbManager _dbManager;

        protected BaseManager(DbManager dbManager)
        {
            _dbManager = dbManager;
        }

        protected void AddAndSave<T>(params T[] entities)
        {
            _dbManager.AddRange(entities);
            _dbManager.SaveChanges();
        }

        protected void RemoveAndSave<T>(params T[] entities)
        {
            _dbManager.RemoveRange(entities);
            _dbManager.SaveChanges();
        }

        protected void UpdateAndSave<T>(params T[] entities)
        {
            _dbManager.UpdateRange(entities);
            _dbManager.SaveChanges();
        }
    }
}
