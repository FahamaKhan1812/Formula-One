namespace FormulaOne.Entities.Dtos.Responses;
public class DriverAchievementResponse
{
    public Guid Id { get; set; }
    public int WorldChampionship { get; set; }
    public int FastestLap { get; set; }
    public int PolePosition { get; set; }
    public int Wins { get; set; }

}
