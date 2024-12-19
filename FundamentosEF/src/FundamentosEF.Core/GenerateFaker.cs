using Bogus;
using Bogus.Extensions.Brazil;
using FundamentosEF.Domain;

namespace FundamentosEF.Core
{
    public class GenerateFaker
    {
        public static List<Departament> Departments(int qtd)
        {
            var faker = new Faker<Departament>()
                .RuleFor(c => c.Description, f => f.Commerce.Department())
                .RuleFor(c => c.Employers, f => Employers(f.Random.Int(1, 10)));
            return faker.Generate(qtd);
        }

        public static List<Departament> OnlyDepartments(int qtd)
        {
            var faker = new Faker<Departament>()
                .RuleFor(c => c.Description, f => f.Commerce.Department());
            var lista = faker.Generate(qtd - 1);
            lista.Add(new Departament { Description = "Department 01" });
            return lista;
        }

        public static List<Employer> Employers(int qtd)
        {
            var faker = new Faker<Employer>("pt_BR")
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Code, f => f.Person.Cpf())
                .RuleFor(c => c.DocumentId, f => f.Random.Number(1000000, 9999999).ToString());

            var lista = faker.Generate(qtd);
            return lista;
        }
    }
}