using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TreeService
    {
        private readonly TreeContext _context;

        public TreeService(TreeContext context)
        {
            _context = context;
        }

        public Node CreateNode(Node node)
        {
            _context.Nodes.Add(node);
            _context.SaveChanges();  
            return node;
        }

        public List<Node> GetNodes()
        {
            return _context.Nodes.Include(n => n.Children).ToList(); 
        }


        public Node AddChildToParent(int parentId, Node childNode)
        {
            
            var parentNode = _context.Nodes.Include(n => n.Children).FirstOrDefault(n => n.Id == parentId);

            if (parentNode == null)
            {
                throw new Exception("Parent node not found");
            }

           
            parentNode.Children.Add(childNode);

            
            _context.SaveChanges();

           
            return parentNode;
        }

    }
}
