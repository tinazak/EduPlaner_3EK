namespace HAK_BlazorPicoTemplate.Models
{
    public class Termin
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Titel { get; set; } = "";
        public string Beschreibung { get; set; } = "";
    }
}
