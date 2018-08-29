using System;
using System.Collections.Concurrent;

namespace Spike.Patterns.KeyLocking.Generic
{
    public class KeyLockGuard <T, TY>
    {
        private static readonly object LockObject = new object();
        private static readonly ConcurrentDictionary<T, LockItem> LockDictionary = new ConcurrentDictionary<T, LockItem>();

        public static TY Protect(T key, Func<T, TY> action)
        {
            LockItem item;

            lock (LockObject)
            {
                item = LockDictionary.GetOrAdd(key, new LockItem());
                item.UseCounter++;
            }

            void DecrementUseCountAndTryRemove()
            {
                lock (LockObject)
                {
                    item.UseCounter--;
                    if (item.UseCounter == 0)
                    {
                        LockDictionary.TryRemove(key, out _);
                    }
                }
            }

            TY returnVal;
            lock (item)
            {
                try
                {
                    returnVal = action(key);
                }
                catch (Exception)
                {
                    DecrementUseCountAndTryRemove();
                    throw;
                }
            }

            DecrementUseCountAndTryRemove();

            return returnVal;
        }

    }

    public class LockItem
    {
        public int UseCounter { get; set; }
    }
}
