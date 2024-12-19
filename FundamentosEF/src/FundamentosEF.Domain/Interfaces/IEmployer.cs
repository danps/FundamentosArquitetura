namespace FundamentosEF.Domain
{
    public interface IEmployer
    { 
        int Id { get; set; }
        string Name { get; set; }
        string Code { get; set; }
        string DocumentId { get; set; }
        int DeparmentId { get; set; }
    }
}