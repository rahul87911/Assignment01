using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class TreeContext :DbContext
    {

        public DbSet<Node> Nodes { get; set; }

        public TreeContext(DbContextOptions<TreeContext> options) : base(options) { }

    }
}
