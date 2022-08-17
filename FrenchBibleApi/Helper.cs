using HtmlAgilityPack;
using System.Net;

namespace FrenchBibleApi;

public static class Helper
{
	public static string AelfUrl { get; set; } = "";
	public static HtmlNode Load(string? url = null) => new HtmlWeb().Load(AelfUrl + url).DocumentNode;
}