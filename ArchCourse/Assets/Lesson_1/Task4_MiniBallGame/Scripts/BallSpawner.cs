using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public GameObject[] balls; // Массив шаров
    public List<Ball> spawnedBalls;


    public int ballCount; // Количество шаров
    public bool spawnComplete = false;
    private float positionShift = 0.2f; // Смещение позиции шара
    public void SpawnBalls()
    {
        StartCoroutine(SpawnBall());        
    }

    IEnumerator SpawnBall()
    {
        int _spawnedBalls = 0;
        Ball _ball;

        while (_spawnedBalls < ballCount)
        {

            var transformWithShift = transform.position + new Vector3(Random.Range(-positionShift, positionShift), 0, Random.Range(-positionShift, positionShift));
            var b = Instantiate(balls[Random.Range(0, balls.Length)], transformWithShift, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);

            spawnedBalls.Add(b.GetComponent<Ball>());
            _spawnedBalls++;
        }
        
//        createListsOfDifferentBalls(spawnedBalls);
        spawnComplete = true;
        
    }
    public void removeBallFromList(Ball ball)
    { 
        spawnedBalls.Remove(ball);
    }
    
}
