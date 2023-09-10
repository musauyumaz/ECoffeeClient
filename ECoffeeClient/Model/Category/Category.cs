namespace ECoffeeClient.Model.Category
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ProductNames { get; set; }
    }
    public class CategoryResponse
    {
        public List<Category> Categories { get; set; }
        public int TotalCategoryCount { get; set; }
    }
}
