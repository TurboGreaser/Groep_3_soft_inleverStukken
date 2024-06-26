﻿namespace Project_B;

public class Film
{
    public string Name;
    public string Genre;
    public int Duration_in_minutes;
    public double Price;
    public string Director;
    public string Description;
    public List<Showing> Showings;
    public Film(string name, string genre, int duration, double price, string director, string description, List<Showing> showings)
    {
        Name = name;
        Genre = genre;
        Duration_in_minutes = duration;
        Price = price;
        Director = director;
        Description = description;
        Showings = showings;
    }

    public string Info()
    {
        return
        $"Naam: {Name}\n" +
        $"Lengte: {Duration_in_minutes} min\n" +
        $"Genre: {Genre}\n" +
        $"Director: {Director}\n" +
        $"\nBeschrijving:\n{Description}\n" +
        $"\nFilm wordt afgespeeld op deze tijden: {Showings}\n" +
        $"Prijs: {Price} Euro\n" +
        $"Je kan hem zien op:\n" +
        $"{FormatShowings()}\n";
    }

    public string CompactInfo(int spacingName = 0, int spacingGenre = 0)
    {
        string name = $"{Name}".PadRight(spacingName);
        string genre = $"{Genre}".PadRight(spacingGenre);
        string duration = $"{Duration_in_minutes}".PadRight(4) + " min";
        string price = $"{Price:C}".PadRight(5);
        return $"{name} | {genre} | {duration} | {price} ";
    }

    private string FormatShowings()
    {
        if (Showings.Count > 0)
        {
            string formattedShowings = "";
            foreach (var showing in Showings)
            {
                formattedShowings += $"Datum: {showing.Datum}, Zaal: {showing.Zaal}\n";
            }
            return formattedShowings;
        }
        return "Geen tijden gevonden";
    }

    public static DateTime StringToDatetime(string dateString)
    {
        string format = "yyyy-MM-dd HH:mm";

        // Parse the string to DateTime using ParseExact method
        if (DateTime.TryParseExact(dateString, format, null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
        {
            return dateTime;
        }
        else
        {
            DateTime noDate = new(2000, 1, 1, 1, 1, 1);
            return noDate;
        }
    }

}
