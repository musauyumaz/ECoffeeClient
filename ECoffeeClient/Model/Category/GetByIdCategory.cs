namespace ECoffeeClient.Model.Category
{
    public class GetByIdCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ProductNames { get; set; }
        public bool IsActive { get; set; }
    }
}
