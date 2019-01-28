namespace AspNet.Essentials.Workshop.Models
{
    public class Results
    {
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public int TotalResults { get; set; }
        public Beer[] Data { get; set; }
        public string Status { get; set; }
    }

    public class Beer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameDisplay { get; set; }
        public string Description { get; set; }
        public string Abv { get; set; }
        public string Ibu { get; set; }
        public int StyleId { get; set; }
        public string IsOrganic { get; set; }
        public string IsRetired { get; set; }
        public string Status { get; set; }
        public string StatusDisplay { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public Style Style { get; set; }
        public int GlasswareId { get; set; }
        public Glass Glass { get; set; }
        public int AvailableId { get; set; }
        public Labels Labels { get; set; }
        public string ServingTemperature { get; set; }
        public string ServingTemperatureDisplay { get; set; }
        public Available Available { get; set; }
        public int SrmId { get; set; }
        public Srm Srm { get; set; }
    }

    public class Style
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string IbuMin { get; set; }
        public string IbuMax { get; set; }
        public string AbvMin { get; set; }
        public string AbvMax { get; set; }
        public string SrmMin { get; set; }
        public string SrmMax { get; set; }
        public string OgMin { get; set; }
        public string FgMin { get; set; }
        public string FgMax { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public string OgMax { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateDate { get; set; }
    }

    public class Glass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreateDate { get; set; }
    }

    public class Labels
    {
        public string Icon { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
        public string ContentAwareIcon { get; set; }
        public string ContentAwareMedium { get; set; }
        public string ContentAwareLarge { get; set; }
    }

    public class Available
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Srm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hex { get; set; }
    }
}