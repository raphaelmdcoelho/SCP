using SCP.Repository.Context;

namespace SCP.Repository.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly BaseContext context;
        public UnitOfWork(BaseContext context)
        {
            this.context = context;
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
