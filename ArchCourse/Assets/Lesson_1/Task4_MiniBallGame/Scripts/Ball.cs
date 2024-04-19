using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public BallType ballType; // устанавливаем в префабе

    public BallType KillBall() // при смерти возвращаем тип шара.
    {
        Destroy(gameObject);
        return ballType;
    }

}



public enum BallType
{ 
    purple,
    yellow,
    cyan
}