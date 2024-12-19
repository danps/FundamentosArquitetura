namespace FundamentosEF.Domain.LazyLoaderAction
{
    public class Employer : IEmployer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string DocumentId { get; set; }
        public int DeparmentId { get; set; }
        public Departament Departament { get; set; }
    }
}