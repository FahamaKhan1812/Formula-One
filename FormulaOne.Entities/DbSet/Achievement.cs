﻿namespace FormulaOne.Entities.DbSet;
public class Achievement : BaseEntity
{
    public int RaceWins { get; set; }
    public int PolePosition { get; set; }
    public int FatestLap { get; set; }
    public int WorldChampionship { get; set; }
    public Guid DriverId { get; set; }

    public virtual Driver? Driver { get; set; }
}
