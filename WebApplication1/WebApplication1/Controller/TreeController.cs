using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreeController:ControllerBase
    {
        private readonly TreeService _treeService;

        public TreeController(TreeService treeService)
        {
            _treeService = treeService;
        }

        
        [HttpPost("create")]
        public IActionResult CreateNode([FromBody] Node node)
        {
            var createdNode = _treeService.CreateNode(node);
            return Ok(createdNode);
        }


       
        [HttpGet("get")]
        public IActionResult GetNodes()
        {
            var nodes = _treeService.GetNodes(); 
            return Ok(nodes);
        }

        [HttpPost("add-child")]
        public IActionResult AddChildToParent(int parentId, [FromBody] Node childNode)
        {
            try
            {
                var updatedParentNode = _treeService.AddChildToParent(parentId, childNode);
                return Ok(updatedParentNode);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }





    }
}
