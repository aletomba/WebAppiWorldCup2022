namespace WebAppiWorldCup2022.Models.ViewModels.IncidentsviewModels
{
    public class CreateIncidentsViewmodel
    {
        public string? Soccerteam { get; set; }
        public string? NamePlayer { get; set; }
        public string? NameCoach { get; set; }
        public int? idMatch { get; set; }
        public int? Goal { get; set; }
        public int? Yellowcard  { get; set; }
        public int? Redcard { get; set; }
        public int? Minute { get; set; }
    }
}
