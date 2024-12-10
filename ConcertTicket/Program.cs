public class Concert{
    public string Name;
    public DateTime Date;
    public string Location;
    public int AvailableSeats;
    
    public Concert(string name, DateTime date, string location, int availableSeats)
    {
        Name = name;
        Date = date;
        Location = location;
        AvailableSeats = availableSeats;
    }
}

public class Ticket
{
    public Concert Concert;
    public decimal Price;
    public int SeatNumber;

    public Ticket(Concert concert, decimal price, int seatNumber){
        Concert = concert;
        Price = price;
        SeatNumber = seatNumber;
    }
}

public class BookingSystem{
    private List<Concert> concerts = new List<Concert>();
    private List<Ticket> tickets = new List<Ticket>();

    public void AddConcert(Concert concert){
        concerts.Add(concert);
    }

    public Ticket BookTicket(Concert concert, decimal price, int seatNumber)
    {
        if (concert.AvailableSeats > 0){
            concert.AvailableSeats--;
            Ticket ticket = new Ticket(concert, price, seatNumber);
            tickets.Add(ticket);
            return ticket;
        }
        else{
            Console.WriteLine("Brak dostępnych miejsc na koncert.");
            return null;
        }
    }
    
    public List<Concert> GetConcertsByDate(DateTime date)
    {
        return concerts.Where(c => c.Date.Date == date.Date).ToList();
    }

    public List<Concert> GetConcertsByLocation(string location)
    {
        return concerts.Where(c => c.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Concert> FilterConcerts(Func<Concert, bool> criteria)
    {
        return concerts.Where(criteria).ToList();
    }

    public void GenerateReportByDate()
    {
        foreach (var concert in concerts.OrderBy(c => c.Date))
        {
            Console.WriteLine($"{concert.Name} - {concert.Date} - {concert.Location} - {concert.AvailableSeats} available seats");
        }
    }

    public void GenerateReportByLocation()
    {
        foreach (var concert in concerts.OrderBy(c => c.Location))
        {
            Console.WriteLine($"{concert.Name} - {concert.Date} - {concert.Location} - {concert.AvailableSeats} available seats");
        }
    }
}


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
        Ticket ticket1 = bookingSystem.BookTicket(new Concert("Rock Fest", new DateTime(2024, 12, 10), "Warsaw", 100), 150, 1);
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
        Console.WriteLine($"\nConcerts {Concert.Location}:");
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