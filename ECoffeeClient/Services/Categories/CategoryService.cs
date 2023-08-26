using ECoffeeClient.Model.Category;
using ECoffeeClient.Model.Common;

namespace ECoffeeClient.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientService _httpClientService;

        public CategoryService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<BaseResponse<Category>> AddCategoryAsync(AddCategory addCategory)
            => await _httpClientService.PostAsync<AddCategory, BaseResponse<Category>>(new RequestParameter() { Controller = "Categories", Action = "Add" }, addCategory);


        public async Task<BaseResponse<Category>> DeleteCategoryAsync(string id)
            => await _httpClientService.DeleteAsync<BaseResponse<Category>>(new() { Controller = "Categories", Action = "Delete" }, id);

        public async Task<BaseResponse<Category>> GetCategoryByIdAsync(string id)
            => await _httpClientService.GetAsync<BaseResponse<Category>>(new() { Controller = "Categories", Action = "GetById" }, id);

        public async Task<BaseResponse<CategoryResponse>> GetAllCategoryListAsync(int page, int size)
            => await _httpClientService.GetAsync<BaseResponse<CategoryResponse>>(new() { Controller = "Categories", Action = "GetAll", QueryString = $"page={page}&size={size}" });

        public async Task<BaseResponse<Category>> UpdateCategoryAsync(UpdateCategory updateCategory)
            => await _httpClientService.PutAsync<UpdateCategory, BaseResponse<Category>>(new RequestParameter() { Controller = "Categories", Action = "Update" }, updateCategory);
    }

}


