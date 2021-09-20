namespace GamesLibrary.API.Entities;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description {  get; set; }
    public decimal Price { get; set; }
    public DateTime Premiere { get; set; }

    public int PegiId { get; set; }
    public virtual Pegi Pegi { get; set; }

    public virtual ICollection<Genre> Genres { get; set; }

    public virtual ICollection<User> Users { get; set; }

    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }


}
