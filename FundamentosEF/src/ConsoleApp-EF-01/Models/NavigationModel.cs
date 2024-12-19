namespace ConsoleApp_EF_01.Models
{
    public class NavigationModel
    {
        private static int IdNext = 1;

        public NavigationModel(int id, string description, Action action)
        {
            Id = IdNext++;
            VisualId = id;
            Action = action;
            Description = description;
            Itens = new List<NavigationModel>();
        }

        public int Id { get; set; }
        public int VisualId { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
        public List<NavigationModel> Itens { get; set; }

        public override string ToString() => $"{VisualId} - {Description}";

        public void Add(NavigationModel menuModel)
        {
            Itens.Add(menuModel);
        }
    }
}