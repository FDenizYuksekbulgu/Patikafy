using System;
using System.Collections.Generic;
using System.Linq;

public class Artist
{
    public string Name { get; set; }
    public int AlbumSales { get; set; }
    public int DebutYear { get; set; }
    public string MusicGenre { get; set; }

    public Artist(string name, int albumSales, int debutYear, string musicGenre)
    {
        Name = name;
        AlbumSales = albumSales;
        DebutYear = debutYear;
        MusicGenre = musicGenre;
    }
}

public class Program
{
    public static void Main()
    {
        //Sanatçı listesini tanımlıyoruz.
        List<Artist> artists = new List<Artist>
        {
            new Artist("Ajda Pekkan", 20, 1968, "Pop"),
            new Artist("Sezen Aksu", 10, 1971, "Türk Halk Müziği/Pop"),
            new Artist("Funda Arar", 3, 1999, "Pop"),
            new Artist("Sertap Erener", 5, 1994, "Pop"),
            new Artist("Sıla", 3, 2009, "Pop"),
            new Artist("Serdar Ortaç", 10, 1994, "Pop"),
            new Artist("Tarkan", 40, 1992, "Pop"),
            new Artist("Hande Yener", 7, 1999, "Pop"),
            new Artist("Hadise", 5, 2005, "Pop"),
            new Artist("Gülben Ergen", 10, 1997, "Pop/Türk Halk Müziği"),
            new Artist("Neşet Ertaş", 2, 1960, "Türk Halk Müziği/Türk Sanat Müziği")
        };

        //a) Adı 'S' ile başlayan şarkıcılar
        var artistsWithS = artists.Where(a => a.Name.StartsWith("S")).Select(a => a.Name).ToList();
        Console.WriteLine("Adı 'S' ile başlayan şarkıcılar:");
        artistsWithS.ForEach(a => Console.WriteLine(a));

        //b) Albüm satışları 10 milyon'un üzerinde olan şarkıcılar
        var artistsWithSalesAbove10Million = artists.Where(a => a.AlbumSales > 10).Select(a => a.Name).ToList();
        Console.WriteLine("Albüm satışları 10 milyon'un üzerinde olan şarkıcılar:");
        artistsWithSalesAbove10Million.ForEach(a => Console.WriteLine(a));

        //c) 2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar (çıkış yıllarına göre gruplayarak, alfabetik sıralama)
        var popArtistsBefore2000 = artists
            .Where(a => a.DebutYear < 2000 && a.MusicGenre.Contains("Pop"))
            .OrderBy(a => a.DebutYear)  // Çıkış yılına göre sıralama
            .ThenBy(a => a.Name)        // Adına göre alfabetik sıralama
            .Select(a => a.Name)
            .ToList();
        Console.WriteLine("2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar:");
        popArtistsBefore2000.ForEach(a => Console.WriteLine(a));

        //d) En çok albüm satan şarkıcı
        var mostAlbumSellingArtist = artists.OrderByDescending(a => a.AlbumSales).First();
        Console.WriteLine("En çok albüm satan şarkıcı:");
        Console.WriteLine($"{mostAlbumSellingArtist.Name} - {mostAlbumSellingArtist.AlbumSales} milyon");

        //e) En yeni çıkış yapan şarkıcı ve en eski çıkış yapan şarkıcı
        var newestArtist = artists.OrderByDescending(a => a.DebutYear).First();
        var oldestArtist = artists.OrderBy(a => a.DebutYear).First();
        Console.WriteLine("En yeni çıkış yapan şarkıcı:");
        Console.WriteLine($"{newestArtist.Name} - {newestArtist.DebutYear}");

        Console.WriteLine("En eski çıkış yapan şarkıcı:");
        Console.WriteLine($"{oldestArtist.Name} - {oldestArtist.DebutYear}");
    }
}
