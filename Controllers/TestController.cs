using Microsoft.AspNetCore.Mvc;

namespace aps_hub_kt3.Controllers;

public class TestController : Controller
{
    public async Task Text()
    {
        Response.ContentType = "text/plain";
        await Response.WriteAsync("Hello, world!");
    }

    public async Task Html()
    {
        Response.ContentType = "text/html";

        const string html = """
            <h1>Test HTML Response</h1>
            <p>This is an HTML response from TestController.</p>
            """;

        await Response.WriteAsync(html);
    }

    public async Task Json()
    {
        Response.ContentType = "application/json";
        await Response.WriteAsJsonAsync(new
        {
            Name = "Answer",
            Age = 42
        });
    }

    public async Task File()
    {
        Response.ContentType = "text/plain";

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
        await Response.SendFileAsync(filePath);
    }

    public async Task Status()
    {
        Response.StatusCode = StatusCodes.Status404NotFound;
        Response.ContentType = "text/plain";
        await Response.WriteAsync("404 Not Found");
    }

    public async Task Cookie()
    {
        Response.Cookies.Append("user", "Answer");
        Response.ContentType = "text/plain";
        await Response.WriteAsync("Cookie 'user=Answer' has been set.");
    }
}
