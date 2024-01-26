using System.Diagnostics;

namespace NetCoreWithAngular.IntegrationTests;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IList<Product> Products { get; set; }
}
public class Product
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
}


public class PerformanceTests
{
    public List<Category> categories { get; set; } = new();
    public List<Product> products { get; set; } = new();

    public PerformanceTests()
    {
        for (int i = 0; i < 1000; i++)
        {
            categories.Add(new Category
            {
                Id = Guid.NewGuid(),
                Name = $"Category_{i}"
            });
        }

        for (int i = 0; i < 1000; i++)
        {
            var category = categories[i];
            for (int j = 0; j < 10000; j++)
            {
                products.Add(new Product
                {
                    CategoryId = category.Id,
                    Name = $"Product_{i}"
                });

                if (j % 79 == 0)
                {
                    products.Add(new Product
                    {
                        CategoryId = category.Id,
                        Name = $"Product_{i}_{i}"
                    });
                }
            }
        }

    }
        
    //[Fact]
    //public void Test1()
    //{
    //    var sw = new Stopwatch();
    //    sw.Start();

    //    foreach (var category in categories)
    //    {
    //        category.Products = products.Where(p => p.CategoryId == category.Id).ToList();
    //    }

    //    sw.Stop();

    //    throw new Exception($"Elapsed={sw.Elapsed}");
    //}
        
    [Fact]
    public void Test2()
    {
        var sw = new Stopwatch();
        sw.Start();

        var dict = products
            .GroupBy(p => p.CategoryId)            
            .ToDictionary(g => g.Key, g => g.ToList());

        Parallel.ForEach(categories, category =>
        {
            category.Products = dict.TryGetValue(category.Id, out var products) ? products : Array.Empty<Product>();
        });

        sw.Stop();

        throw new Exception($"Elapsed={sw.Elapsed}");
    }
        
    
}
