
using System;

namespace Spike.Patterns.Singleton.Generic
{
    public interface ISingleton
    {
        void Initialize();
    }

    public abstract class SingletonBase<T>
        where T : ISingleton
    {
        private static readonly object _lock = new object();

        public abstract void Initialize();

        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_lock)
                    if (_instance == null)
                    {
                        var tempInstance = Activator.CreateInstance<T>();
                        tempInstance.Initialize();
                        System.Threading.Thread.MemoryBarrier();
                        _instance = tempInstance;
                    }

                return _instance;
            }
        }
    }
}
