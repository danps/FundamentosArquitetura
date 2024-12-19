namespace FundamentosEF.Domain
{
    public class Departament : IDepartament
    {
        public bool HasEmployers() => Employers?.Any() ?? false;

        public IEnumerable<IEmployer> GetEmployers() => Employers;

        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<Employer> Employers { get; set; }
    }
}