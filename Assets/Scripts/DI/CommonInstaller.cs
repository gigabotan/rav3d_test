using rav3d.Model;
using UnityEngine;
using Zenject;

namespace rav3d
{
    public class CommonInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            var inventory = new Inventory();
            Container.BindInterfacesTo<Inventory>().FromInstance(inventory).AsSingle();

            var transact = new TransactionController(Container);
            Container.BindInterfacesTo<TransactionController>().FromInstance(transact).AsSingle();
            
            BindIfExist<NetworkController>(gameObject);
            
        }
        
        public void BindIfExist<T>(GameObject target)
        {
            var controller = target.GetComponent<T>();
            if (controller != null)
            {
                Container.Bind<T>().FromInstance(controller);
            }
        }
    }
}