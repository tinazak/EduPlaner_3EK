using HAK_BlazorPicoTemplate.Database;
using HAK_BlazorPicoTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace HAK_BlazorPicoTemplate.Services
{
    public class TerminService
    {
        // Die Kontext Factory welche die Datenbankverbindung aufbaut
        private readonly IDbContextFactory<TerminDbContext> _dbContextFactory;

        // Im Konstruktor wird die ContextFactory übergeben die wir in Program.cs erstellt haben
        // Das passiert automatisch

        public TerminService(IDbContextFactory<TerminDbContext>dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        private readonly TerminDbContext _context;

        // Der DbContext wird hier automatisch injiziert
        public TerminService(TerminDbContext context)
        {
            _context = context;
        }

        // Alle Termine aus der DB laden
        public List<Termin> HoleAlleTermine()
        {
            return _context.Termin.ToList();
        }

        // Einen bestimmten Termin suchen
        public Termin? HoleTerminNachDatum(int jahr, int monat, int tag)
        {
            return _context.Termin.FirstOrDefault(t =>
                t.Datum.Year == jahr && t.Datum.Month == monat && t.Datum.Day == tag);
        }

        // Prüfen, ob an dem Tag ein Termin existiert
        public bool HatTermin(int jahr, int monat, int tag)
        {
            return _context.Termin.Any(t =>
                t.Datum.Year == jahr && t.Datum.Month == monat && t.Datum.Day == tag);
        }

        // Termin speichern (Neu oder Update)
        public void SpeichereTermin(Termin neuerTermin, Termin? bestehenderTermin)
        {
            if (bestehenderTermin != null)
            {
                // Wenn es ihn schon gab, updaten wir den bestehenden Eintrag
                var eintrag = _context.Termin.Find(bestehenderTermin.Id);
                if (eintrag != null)
                {
                    eintrag.Titel = neuerTermin.Titel;
                    eintrag.Beschreibung = neuerTermin.Beschreibung;
                }
            }
            else
            {
                // Wenn er neu ist, hinzufügen
                _context.Termin.Add(neuerTermin);
            }

            // Daten werden an Heidisql gesendet
            _context.SaveChanges();
        }
    }
}