using System.ComponentModel.DataAnnotations;

namespace ISM_MaresRobertDorian_ASPNETPROJWCAS.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int GameSize { get; set; }
        public string ImgString { get; set; }
        public DateTime ReleaseDate { get; set; }

        //OneToMany
        public List<Review>? Reviews { get; set; }

        public override string? ToString()
        {
            return
                this.Id + "/" +
                this.Name + "/" +
                this.Publisher + "/" +
                this.GameSize + "/" +
                this.ImgString + "/" +
                this.ReleaseDate.ToString() + "/";
        }
    }
}
