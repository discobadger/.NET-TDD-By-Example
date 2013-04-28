using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
 
namespace Common
{
    public static class ServiceLocator
    {
        private static IWindsorContainer _container = new WindsorContainer(new XmlInterpreter());
 
        public static void Clear()
        {
            _container = new WindsorContainer();
        }
 
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
 
        public static void AddInstance<T>(object instance)
        {
            _container.Kernel.AddComponentInstance<T>(typeof(T), instance);
        }

        public static void Release(object instance)
        {
            _container.Release(instance);
        }
    }
}

