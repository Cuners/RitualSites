namespace WebApplication1.Models
{
    public class CategoryMapping
    {
        public static Dictionary<string, (string Controller, string Action)> Mappings = new Dictionary<string, (string Controller, string Action)>
        {
            { "Монумент", ("Products", "Monuments") },
            { "Гроб", ("Products", "Coffins") },
            { "Урна", ("Products", "Urns") },
            { "Лента", ("Products", "Tapes") },
            { "Крест", ("Products", "Crosses") },
            { "Одежда", ("Products", "Clothes") }
        };
    }
}
