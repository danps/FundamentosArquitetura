namespace FundamentosEF.Domain.LazyLoaderAction
{
    public class Departament: IDepartament
    {
        public bool HasEmployers() => Employers?.Any() ?? false;
        public IEnumerable<IEmployer> GetEmployers() => Employers;

        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public Departament()
        {
        }

        private Action<object, string> _lazyLoader { get; set; }

        private Departament(Action<object, string> lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        private List<Employer> _employers;

        public List<Employer> Employers
        {
            get
            {
                _lazyLoader?.Invoke(this, nameof(Employers));

                return _employers;
            }
            set => _employers = value;
        }
    }
}