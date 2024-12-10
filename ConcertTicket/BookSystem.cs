namespace ConcertTicket;

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