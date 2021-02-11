using Zenject;

namespace rav3d
{
    public abstract class BaseTransaction
    {
        [Inject] protected readonly NetworkController NetworkController = null;
        protected abstract void ClassSpecificExecute();
        
        public void Execute()
        {
            ClassSpecificExecute();
        }
    }
}