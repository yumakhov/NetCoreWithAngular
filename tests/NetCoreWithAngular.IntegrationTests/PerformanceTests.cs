using System.Diagnostics;

namespace NetCoreWithAngular.IntegrationTests;

public class Category
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public IList<Product>? Products { get; set; }
}
public class Product
{
    public Guid CategoryId { get; set; }
    public required string Name { get; set; }
}


public class PerformanceTests
{
    private List<Category> _categories { get; set; } = new();
    private List<Product> _products { get; set; } = new();

    public PerformanceTests()
    {
        for (int i = 0; i < 1000; i++)
        {
            _categories.Add(new Category
            {
                Id = Guid.NewGuid(),
                Name = $"Category_{i}"
            });
        }

        for (int i = 0; i < 1000; i++)
        {
            var category = _categories[i];
            for (int j = 0; j < 10000; j++)
            {
                _products.Add(new Product
                {
                    CategoryId = category.Id,
                    Name = $"Product_{i}"
                });

                if (j % 79 == 0)
                {
                    _products.Add(new Product
                    {
                        CategoryId = category.Id,
                        Name = $"Product_{i}_{i}"
                    });
                }
            }
        }

    }
        
    [Fact]
    public void Test2()
    {
        var sw = new Stopwatch();
        sw.Start();

        var dict = _products
            .GroupBy(p => p.CategoryId)            
            .ToDictionary(g => g.Key, g => g.ToList());

        Parallel.ForEach(_categories, category =>
        {
            category.Products = dict.TryGetValue(category.Id, out var products) ? products : Array.Empty<Product>();
        });

        sw.Stop();

        throw new Exception($"Elapsed={sw.Elapsed}");
    }
}
