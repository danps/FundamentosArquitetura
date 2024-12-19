namespace FundamentosEF.Domain
{
    public interface IDepartament
    {
        int Id { get; set; }
        string Description { get; set; }
        bool Active { get; set; }

        IEnumerable<IEmployer> GetEmployers();
        bool HasEmployers();
    }
}