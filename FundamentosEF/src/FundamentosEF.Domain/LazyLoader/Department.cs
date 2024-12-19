using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FundamentosEF.Domain.LazyLoader
{
    public class Department : IDepartament
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; } 
        
        private ILazyLoader _lazyLoader {get;set;}
        public Department()
        {
            
        }
        private Department(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        private List<Employer> _employers;
        public List<Employer> Employers
        {
            get => _lazyLoader.Load(this, ref _employers);
            set => _employers = value;
        }


        public bool HasEmployers() => Employers?.Any() ?? false;
        public IEnumerable<IEmployer> GetEmployers() => Employers;

    }
}