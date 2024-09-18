namespace WebApplication1.Models
{
    public class Node
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();

    }
}
