using AspNet.Essentials.Workshop.Enums;

namespace AspNet.Essentials.Workshop.Models
{
    public class BacCalculationRequest
    {
        public int WeightInPounds { get; set; }
        public double HoursOfDrinking { get; set; }
        public Sex Sex { get; set; }
        public Beer[] Beers { get; set; }
    }
}