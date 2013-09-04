namespace SuperMarketLockerSystem
{
    public class Ticket
    {
        public Bag bag { get; set; }
        public Ticket(Bag bag)
        {
            this.bag = bag;
        }
    }
}