using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandler;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly GetCategoryByIdCommandHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandle;

        public CategorysController(CreateCategoryCommandHandler createCategoryCommandHandler,
            GetCategoryByIdCommandHandler getCategoryByIdQueryHandler,
            GetCategoryQueryHandler getCategoryQueryHandler, 
            RemoveCategoryCommandHandler removeCategoryCommandHandler, 
            UpdateCategoryCommandHandler updateCategoryCommandHandle)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _updateCategoryCommandHandle = updateCategoryCommandHandle;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var result = await _getCategoryQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Kategori Bilgisi Eklendi");


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Kategori Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandle.Handle(command);
            return Ok("Kategori Bilgisi Güncellendi");
        }
    }
}
