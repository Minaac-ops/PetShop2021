using System.Dynamic;

namespace Mac.PetShop2021comp1.Core.Filter
{
    public class Filter
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public string OrderDir { get; set; }
        public string OrderBy { get; set; }
        public string Search { get; set; }
    }
}