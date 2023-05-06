namespace Lab07_ASP.NET_WEB_API.Data.Models
{
    public class Table1
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Table2> Table2s { get; } = new List<Table2>();
    }
}
