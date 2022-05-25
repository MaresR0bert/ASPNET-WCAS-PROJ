namespace ISM_MaresRobertDorian_ASPNETPROJWCAS.Models
{
    public class Review
    {
        public int Id { get;  set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPositive { get; set; }

        //ManyToOne
        public int GameId { get; set; }
        public Game? Game { get; set; }
    }
}
