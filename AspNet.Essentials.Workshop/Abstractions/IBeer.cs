namespace AspNet.Essentials.Workshop.Abstractions
{
    public interface IBeer
    {
        string Id { get; set; }
        string Name { get; set; }
        string NameDisplay { get; set; }
        double Abv { get; set; }
    }
}