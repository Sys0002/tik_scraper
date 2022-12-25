using HtmlAgilityPack;
using System.Net;
using System;

namespace Tik_Shit {
  class Program {
    static void Main(string[] args) {
      try {
        var client = new WebClient();
        var html = client.DownloadString("https://www.tiktok.com/@username");

        var document = new HtmlDocument();
        document.LoadHtml(html);

        var name_el = document.DocumentNode.SelectSingleNode("//h1[contains(@class, 'username')]");
        var name = name_el.InnerText;

        var bio_el = document.DocumentNode.SelectSingleNode("//h2[contains(@class, 'bio')]");
        var bio = bio_el.InnerText;

        var followers_el = document.DocumentNode.SelectSingleNode("//span[contains(@class, 'followers')]");
        var followers = followers_el.InnerText;

        Console.WriteLine("Name: " + name);
        Console.WriteLine("Bio: " + bio);
        Console.WriteLine("Followers: " + followers);
      } catch (WebException ex) {
        Console.WriteLine("Error accessing TikTok website: " + ex.Message);
      } catch (NullReferenceException ex) {
        Console.WriteLine("Error parsing TikTok profile info: " + ex.Message);
      }
    }
  }
}
