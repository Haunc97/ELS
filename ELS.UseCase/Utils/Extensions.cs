using System.Collections.Generic;
using System.Drawing;
using System;
using System.Reflection;

namespace ELS.UseCase.Utils
{
    public static class Extensions
    {
        /// <summary>
        ///     A generic extension method that aids in reflecting 
        ///     and retrieving any attribute that is applied to an `Enum`.
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }

        public static List<string> GetRandomList(this List<string> dataList, int quantity)
        {
            if (dataList.Count <= quantity)
                return dataList;

            var res = new List<string>();
            var rnd = new Random();
            while (quantity > 0)
            {
                var rndMember = dataList[rnd.Next(dataList.Count)];
                if (!res.Contains(rndMember))
                {
                    res.Add(rndMember);
                    quantity--;
                }
            }
            return res;
        }

        public static List<T> GetRandomSublist<T>(this List<T> list, int size)
        {
           Random random = new();

            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (size < 0 || size > list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            return list.OrderBy(x => random.Next()).Take(size).ToList();
        }

        /// <summary>
        /// Shuffle the list using a random number generator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
