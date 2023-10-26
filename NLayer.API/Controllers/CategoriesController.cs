using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // api/categories/GetSingleCategoryByIdWithProducts/2
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var category = await _categoryService.GetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(category).ToList();
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Successs(200, categoryDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Successs(200, categoryDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            var categoryDtos = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Successs(201));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Successs(201));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            await _categoryService.RemoveAsyn(category);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Successs(204));
        }
    }
}
