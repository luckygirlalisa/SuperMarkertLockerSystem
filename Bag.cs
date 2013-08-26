namespace SuperMarketLockerSystem
{
    public class Bag
    {
        private int bagId { get; set; }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return bagId;
        }
    }
}