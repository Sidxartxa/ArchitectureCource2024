using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallGameController : MonoBehaviour
{
    [SerializeField] private BallSpawner ballSpawner;
    public IVictoryCondition vicCondition;
    public bool isGameStarted = false;
    public Canvas canvas;
    public TMPro.TMP_Dropdown dropdown;

    public void StartTheGame()
    {
        dropdown = canvas.GetComponentInChildren<TMPro.TMP_Dropdown>();

        if (dropdown.value == 0)
        vicCondition = new VictoryCondition1();
        
        else if (dropdown.value == 1)
            vicCondition = new VictoryCondition2();

        canvas.gameObject.SetActive(false);

        ballSpawner.SpawnBalls();
        
        isGameStarted = true;

        Debug.Log($"Игра началась.\n Для победы {vicCondition.description}");
    }

    public void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Ball ball = hit.collider.GetComponent<Ball>();
                if (ball != null)
                {
                    ball.KillBall();
                    
                    ballSpawner.removeBallFromList(ball);
                }
            }

        }

        if (ballSpawner.spawnComplete == true)
        {
            if (isGameStarted == true && vicCondition.VictoryCondition(ballSpawner.spawnedBalls))
            {
                Debug.Log("Победа!");
                isGameStarted = false;
            }
        }
    }
}
