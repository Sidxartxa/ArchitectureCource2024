using System.Collections.Generic;

public class VictoryCondition2 : IVictoryCondition
{
    public string description { get; set; }

    private List<Ball> purpleBallsList = new List<Ball>();
    private List<Ball> yellowBallsList = new List<Ball>();
    private List<Ball> cyanBallsList = new List<Ball>();

    public VictoryCondition2()
    {
        description = "чпокните все шарики одного цвета.";
    }

    public bool VictoryCondition(List<Ball> ballsList)
    {
        createListsOfDifferentBalls(ballsList);


        if (purpleBallsList.Count == 0 ||
            yellowBallsList.Count == 0 ||
            cyanBallsList.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void createListsOfDifferentBalls(List<Ball> _spawnedBalls)
    {
    purpleBallsList = new List<Ball>();
    yellowBallsList = new List<Ball>();
    cyanBallsList = new List<Ball>();

        foreach (var ball in _spawnedBalls)
        {

            if (ball.ballType == BallType.purple)
                purpleBallsList.Add(ball);
            else if (ball.ballType == BallType.yellow)
                yellowBallsList.Add(ball);
            else cyanBallsList.Add(ball);
        }

    }

}
