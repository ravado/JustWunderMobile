using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JustWunderMobile.Common
{
    public static class Extentions
    {
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
    }
}
