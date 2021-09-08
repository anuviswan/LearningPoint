using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BoilerPlate.Bootstrap
{
    public class Bootstrap
    {
        IUnityContainer _container = new UnityContainer();
        public void Initialize()
        {

        }

        protected object GetInstance(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
