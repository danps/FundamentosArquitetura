namespace FundamentosEF.Domain.LazyLoader
{
    public class Employer : IEmployer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string DocumentId { get; set; }
        public int DeparmentId { get; set; }
        public Department Department { get; set; }
    }
}