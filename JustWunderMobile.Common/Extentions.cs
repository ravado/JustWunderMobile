using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JustWunderMobile.Common
{
    public static class Extentions
    {
        private static Random _random;
        private static Random Random
        {
            get { return _random ?? (_random = new Random()); }
        }

        /// <summary>
        /// Make Observable from IEnumerable
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="col">Collection to change</param>
        /// <returns>Shiny Observable Collection</returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> col)
        {
            return new ObservableCollection<T>(col);
        }

        /// <summary>
        /// Create random boolean value
        /// </summary>
        /// <returns>Randomized boolean value</returns>
        public static bool MakeRandom()
        {
            var rand = Random.Next(0, 2);
            return  (rand != 0);
        }
    }
}
