using Sorting.Domain.Models.Interface;

namespace Sorting.Domain.Models 
{
    public class FullName : IComparable<FullName>
    {
        private readonly string original;

        public FullName(string original) => this.original = original;

        public int CompareTo(FullName obj) 
        {
            if (this.original == null) 
            {
                return (obj.ToString() == null) ? 0 : -1;
            }
            
            return this.original
                            .ToString()
                            .CompareTo(obj.ToString());
        } 

        public override string ToString() => this.original;
    }
}