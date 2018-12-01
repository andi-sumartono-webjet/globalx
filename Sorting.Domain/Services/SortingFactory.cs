using System;
using Sorting.Domain.Models;
using Sorting.Domain.Models.Interface;

namespace Sorting.Domain.Services.Interface
{
    public class SortingFactory<T> : ISortingFactory<T> 
        where T : Sorting.Domain.Models.Interface.IComparable<T>
    {
        private readonly IServiceProvider serviceProvider;

        public SortingFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ISort<T> GetSortingMethod(SortingMethodEnum method) 
        {
            ISort<T> sortingMethod = null;

            switch (method)
            {
                case SortingMethodEnum.Bubble : 
                    sortingMethod = new BubbleSort<T>();
                    break;
                case SortingMethodEnum.Quick : 
                    sortingMethod = new QuickSort<T>();
                    break;
            }

            return sortingMethod;
        }
    }
}
