namespace HAK_BlazorPicoTemplate.Models
{
    public class MonatStruktur
    {
        public int MonatsNummer { get; set; }
        public string MonatsName { get; set; } = "";
        public List<List<int>> Wochen { get; set; }
    }
}
