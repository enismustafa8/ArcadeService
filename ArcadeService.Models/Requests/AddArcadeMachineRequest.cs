namespace ArcadeService.Models.Requests
{
    public class AddArcadeMachineRequest
    {
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal BasePrice { get; set; }
    }
}
