using UnityEngine;
using Zenject;

namespace rav3d
{
    public class TransactionController: ITransactionController
    {
        private readonly DiContainer diContainer = null;

        public TransactionController(DiContainer container)
        {
            diContainer = container;
        }
        public void StartTransaction(BaseTransaction transaction)
        {
            BindTransaction(transaction);
            transaction.Execute();
        }
        
        private void BindTransaction(BaseTransaction transaction)
        {
            diContainer.Inject(transaction);
        }
    }
}