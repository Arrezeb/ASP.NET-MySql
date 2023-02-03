using DesafioPedro2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioPedro2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly DesafioDbContext dbContext;
        public ProdutoController(DesafioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet("{Url}")]
        public async Task<IActionResult> GetProdutoByUrl(string url)
        {
            var produto = await dbContext.Produtos.FirstOrDefaultAsync(x => x.Url.Equals(url));
            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }
            if (!produto.Ativo)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(produto);
        }
    }
}
