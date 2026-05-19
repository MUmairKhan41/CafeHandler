namespace CafeHandler.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        // This makes the Category object display its name
        // when used in a ComboBox dropdown
        public override string ToString()
        {
            return CategoryName;
        }
    }
}