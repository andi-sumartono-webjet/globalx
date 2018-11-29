using System.Collections.Generic;
using System.Text.RegularExpressions;
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

            if (obj.ToString() == null) return 1;

            var originalStack = new Stack<string>(Regex.Split(this.original, @"\s+"));
            var objStack = new Stack<string>(Regex.Split(obj.ToString(), @"\s+"));

            var originalString = string.Empty;
            var objString = string.Empty;

            var result = 0;

            while (originalStack.Count > 0 && objStack.Count > 0) 
            {
                if (originalStack.Count > 0) originalString = originalStack.Pop();
                if (objStack.Count > 0) objString = objStack.Pop();

                result = originalString.CompareTo(objString);
                if (result != 0) break; 
            }

            return result;
        } 

        public override string ToString() => this.original;
    }
}