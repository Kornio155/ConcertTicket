using ConcertTicket;
internal class Program
{
    public static void Main(string[] args)
    {
        BookingSystem bookingSystem = new BookingSystem();

        bookingSystem.AddConcert(new Concert("Rock Fest", new DateTime(2024, 12, 10), "Warsaw", 100));
        bookingSystem.AddConcert(new Concert("Pop Concert", new DateTime(2024, 12, 15), "Krakow", 50));
        bookingSystem.AddConcert(new Concert("Classical Night", new DateTime(2024, 12, 10), "Warsaw", 0));
        bookingSystem.AddConcert(new Concert("Hip Hop Monday", new DateTime(2025, 1, 6), "Warsaw", 10));

        // Rezerwacja biletów
        Ticket ticket1 = bookingSystem.BookTicket(new Concert("Classical Night", new DateTime(2024, 12, 10), "Warsaw", 100), 150, 1);
        Ticket ticket2 = bookingSystem.BookTicket(new Concert("Pop Concert", new DateTime(2024, 12, 15), "Krakow", 50), 120, 2);
        Ticket ticket3 = bookingSystem.BookTicket(new Concert("Hip Hop Monday", new DateTime(2025, 1, 6), "Warsow", 50), 120, 2);

        // Wyświetlanie koncertów po dacie
        var concertsByDate = bookingSystem.GetConcertsByDate(new DateTime(2024, 12, 15));
        Console.WriteLine($"Concerts on this date:");
        foreach (var concert in concertsByDate)
        {
            Console.WriteLine($"{concert.Name} at {concert.Location}");
        }

        // Wyświetlanie koncertów po lokalizacji
        var concertsByLocation = bookingSystem.GetConcertsByLocation("Krakow");
        concertsByLocation.ForEach();
        foreach (var concert in concertsByLocation)
        {
            Console.WriteLine($"{concert.Name} on {concert.Date}");
        }

        // Filtrowanie koncertów (delegat i anonimowa funkcja)
        Console.WriteLine("\nConcerts available in Warsaw after 2024-12-10:");
        var filteredConcerts = bookingSystem.FilterConcerts(c => c.Location == "Warsaw" && c.Date > new DateTime(2024, 12, 10));
        foreach (var concert in filteredConcerts)
        {
            Console.WriteLine($"{concert.Name} on {concert.Date}");
        }

        // Generowanie raportu
        Console.WriteLine("\nReport by Date:");
        bookingSystem.GenerateReportByDate();

        Console.WriteLine("\nReport by Location:");
        bookingSystem.GenerateReportByLocation();
    }
}