namespace WebApi
{
    public class Game
    {
        //our model
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Platform { get; set; }
        public string? Developer { get; set; }
        public string? Publisher { get; set; }
        public Game() { }

    }
}
