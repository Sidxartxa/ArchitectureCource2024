using System.Collections.Generic;

public class VictoryCondition1 : IVictoryCondition
{
    public string description { get; set; }

    public VictoryCondition1()
    {
        description = "чпокните все шарики.";
    }

    public bool VictoryCondition(List<Ball> ballsList)
    {
        if (ballsList.Count == 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
