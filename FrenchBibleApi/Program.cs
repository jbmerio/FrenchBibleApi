using FrenchBibleApi;
using System.Web;

var builder = WebApplication.CreateBuilder(args);
Helper.AelfUrl = builder.Configuration["AelfUrl"];

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/books", () =>
{
	try
	{
		var booksNode = Helper.Load().SelectNodes("//*[@id=\"middle-col\"]/div[2]/div/div/ol/li/a");

		List<Book> books = new();
		foreach (var book in booksNode)
		{
			var id = book.Attributes.First(a => a.Name == "href").Value.Split('/').TakeLast(2).FirstOrDefault() ?? "";
			var name = HttpUtility.HtmlDecode(book.InnerText);
			var firstChapterId = id == "Ps" ? HttpUtility.HtmlDecode(book.InnerText) : "1";
			books.Add(new(id, id == "Ps" ? "Psaume " + name : name, firstChapterId));
		}

		return Results.Ok(books);
	}
	catch (Exception ex)
	{
		return Results.Problem(ex.ToString(), null, 500, "Une erreur est survenue", ex.GetType().FullName);
	}
})
.WithName("GetBooks");

app.MapGet("/books/{bookId}/chapters", (string bookId) =>
{
	try
	{
		var chaptersNode = Helper.Load($@"{bookId}/1")
							.SelectNodes("//*[@id=\"menu4\"]/ul/li/a");

		Dictionary<int, string> chapters = new() { { 1, Helper.AelfUrl + bookId + "/1" } };
		foreach (var item in chaptersNode)
		{
			var id = Convert.ToInt32(item.Attributes.First(a => a.Name == "href").Value.Split('/').Last());
			chapters.Add(id, Helper.AelfUrl + bookId + "/" + id);
		}

		return Results.Ok(chapters);
	}
	catch (Exception ex)
	{
		return Results.Problem(ex.ToString(), null, 500, "Une erreur est survenue", ex.GetType().FullName);
	}
})
.WithName("GetChapters");

app.MapGet("/books/{bookId}/chapters/{chapterId}/Verses", (string bookId, string chapterId) =>
{
	try
	{
		var versesNode = Helper.Load($@"{bookId}/{chapterId}")
							.SelectNodes("//*[@id=\"right-col\"]/p/text()");

		Dictionary<string, string> verses = new();
		foreach (var item in versesNode)
		{
			verses.Add(item.ParentNode.FirstChild.InnerText, item.InnerText.TrimStart());
		}

		return Results.Ok(verses);
	}
	catch (Exception ex)
	{
		return Results.Problem(ex.ToString(), null, 500, "Une erreur est survenue", ex.GetType().FullName);
	}
})
.WithName("GetVerses");

app.Run();

internal record Book(string Id, string Name, string FirstChapterId = "1")
{
	public string Url => Helper.AelfUrl + Id + "/" + FirstChapterId;
}