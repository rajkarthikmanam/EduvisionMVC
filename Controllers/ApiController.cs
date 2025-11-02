using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace EduvisionMvc.Controllers;

public class ApiController : Controller
{
    private readonly IHttpClientFactory _http;
    public ApiController(IHttpClientFactory http) => _http = http;

    // Choose one of several stable public APIs via ?source=
    // /Api?source=products or posts or publicapis
    public async Task<IActionResult> Index(string source = "products")
    {
        var client = _http.CreateClient();
        client.Timeout = TimeSpan.FromSeconds(8);

        try
        {
            return source.ToLower() switch
            {
                "posts" => await Posts(client),
                "publicapis" => await PublicApis(client),
                _ => await Products(client) // default
            };
        }
        catch (Exception ex)
        {
            // Graceful UI message
            ViewBag.Error = $"API call failed: {ex.Message}";
            return View(Enumerable.Empty<ApiRow>());
        }
    }

    private async Task<IActionResult> Products(HttpClient c)
    {
        // https://dummyjson.com/products
        var data = await c.GetFromJsonAsync<ProductsRoot>("https://dummyjson.com/products") 
                   ?? new ProductsRoot();
        var rows = data.products.Select(p => new ApiRow(p.title, $"${p.price}", "Products"));
        return View(rows);
    }

    private async Task<IActionResult> Posts(HttpClient c)
    {
        // https://jsonplaceholder.typicode.com/posts
        var posts = await c.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts") 
                    ?? new();
        var rows = posts.Take(50).Select(p => new ApiRow(p.title, $"#{p.id}", "Posts"));
        return View(rows);
    }

    private async Task<IActionResult> PublicApis(HttpClient c)
    {
        // https://api.publicapis.org/entries
        var root = await c.GetFromJsonAsync<PublicApisRoot>("https://api.publicapis.org/entries") ?? new();
        var rows = root.entries.Take(50).Select(e => new ApiRow(e.API, e.Category, "Public APIs"));
        return View(rows);
    }

    // view models / DTOs
    public record ApiRow(string Col1, string Col2, string Source);
    public record ProductsRoot(List<Product> products = null);
    public record Product(int id, string title, decimal price);
    public record Post(int userId, int id, string title, string body);
    public record PublicApisRoot(List<Entry> entries = null);
    public record Entry(string API, string Description, string Category);
}
