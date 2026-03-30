using System;
using UnityEngine;

//namespace Fortnite.Core
//namespace Fortnite.VFX
//namespace Fortnite.Database
//namespace Fortnite.Weapons

namespace B3NNY.Utils
{
    public class GameUtils
    {
        public static void Process<T>(T element , Action<T> action)
        {
            action(element); 
        }

        public static TResult Transform<T,TResult>(T element, Func<T, TResult> func)
        {
            return func(element);
        }

        public static bool Validate<T>(T element, Func<T, bool> func)
        {
            if (element == null || func == null)
                return false;
            else
            {
                return func(element);
            }
            

        }

        public static bool TryFind<T>(T[] array, Func<T, bool> condition, out T result)
        {
            foreach (var item in array)
            {
                if (condition(item))
                {
                    result = item;
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}
