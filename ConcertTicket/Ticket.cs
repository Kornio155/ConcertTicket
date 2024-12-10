namespace ConcertTicket;

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