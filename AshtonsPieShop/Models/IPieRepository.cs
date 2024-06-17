namespace AshtonsPieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        IEnumerable<Pie> SearchPies(string searchQuery);
        Pie? GetPieById(int pieid);
    }
}
