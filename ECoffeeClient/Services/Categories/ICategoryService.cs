using ECoffeeClient.Model.Category;
using ECoffeeClient.Model.Common;

namespace ECoffeeClient.Services.Categories
{
    public interface ICategoryService
    {
        Task<BaseResponse<CategoryResponse>> GetAllCategoryListAsync(int page,int size);
        Task<BaseResponse<Category>> GetCategoryByIdAsync(string id);
        Task<BaseResponse<Category>> AddCategoryAsync(AddCategory addCategory);
        Task<BaseResponse<Category>> UpdateCategoryAsync(UpdateCategory updateCategory);
        Task<BaseResponse<Category>> DeleteCategoryAsync(string id);

    }
}
