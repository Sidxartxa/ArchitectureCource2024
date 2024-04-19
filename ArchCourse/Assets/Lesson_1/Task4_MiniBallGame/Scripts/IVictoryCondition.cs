using System.Collections.Generic;

public interface IVictoryCondition
{
    public string description { get; set; }
    public bool VictoryCondition(List<Ball> ballsList);
}