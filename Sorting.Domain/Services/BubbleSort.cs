using System.Collections.Generic;
using Sorting.Domain.Services.Interface;

namespace Sorting.Domain.Services 
{
    public class BubbleSort<T> : ISort<T> where T : IComparable<T>, new()
    {
        private readonly ILogger<Services.BubbleSort> logger;

        public ClassName(ILogger<BubbleSort> logger)
        {
            this.logger = logger;
        }

        public IList<T> Sort(IList<T> source)
        {
            return new List<T>();
        }
    }
}