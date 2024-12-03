public class Concert{
    public string name;
    public DateTime date;
    public string location;
    public int AvailableSeats;
}

public class Ticket{
    public Concert Concert { get; set; }
    public decimal Price { get; set; }
    public int SeatNumber { get; set; }

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
}





internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}