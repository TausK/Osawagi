using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    //Set timerr to 10sec



    public GameObject TausFails;



    
    public float timer = 10.0f;
    //Place timer txt on gamescene
    public Text timerTxT;
    //Set ballcount to gamescene
    public Text ballTxT;
    //Player Win
    public Text playerWin;
    //Player Score
    public Text playerNumScore;
    //Set ballcount to 100 balls
    private int ballCount = 100;
    //Set limit between 100 - 0 ball count
    public int minSpawn = 0;
    public int maxSpawn = 100;


    public int maxBallSpawn;

    public Transform[] spawnPoints;
    public GameObject[] inkBalls;

    public float spawnTimer = 2.0f;
    public float gameTimer = 1.5f;

    public float randomSpawnForce = 3f;

    public AttackBall[] playerScores;



    // Use this for initialization
    void Start()
    {
        //Whatever player is spawned (attached to)
        playerScores = FindObjectsOfType<AttackBall>();
        maxBallSpawn = 0;
        InvokeRepeating("BallSpawn", gameTimer, spawnTimer);


    }
    void Update()
    {
        #region balldrop count && timer
        //Set Ball TxT in game to Ball : then -> + ballcount from 100....
        ballTxT.text = "Balls: " + ballCount.ToString();
        // Once ballcount has reach 0 and timer is is bigger then 0
        if (ballCount <= 0 && timer >= 0.0f)
        {
            //Start ball count from 10 - 0 seconds
            timer -= Time.deltaTime;
            //Display Time
            timerTxT.text = "" + timer.ToString("Time to Collect! 0");
        }
        //if the time has reached 0 then.....
        if (timer <= 0)
        {
            // This is where you decide who wins 
            int minScore = int.MinValue;
            AttackBall winner = null;
            for (int i = 0; i < playerScores.Length; i++)
            {
                AttackBall player = playerScores[i];
                if (player.score >= minScore)
                {
                    minScore = player.score;
                    winner = player;
                }
                //print(player.hitColor + ": " + player.count);
            }

            TausFails.SetActive(true);

            //If the algorithm found a winner
            if (winner != null)
            {
                // Enable Winner Canvas Panels
                // Set text of 'winner color' to winner.hitColor
                playerWin.text = "Player " + winner.hitColor + " wins!";
                // Set text of 'winner score' to winner.score
                playerNumScore.text = "Points: " + winner.score;
                Time.timeScale = 0.0f;
            }
          

        }
        #endregion




    }

    void BallSpawn()
    {
        //Creating multiple clones
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int objectIndex = Random.Range(0, inkBalls.Length);
        GameObject clone = Instantiate(inkBalls[objectIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        ballCount--;
        Debug.Log("Ball Spawn");

        //Setting Ball limit to 100
        minSpawn++;
        if (minSpawn >= maxSpawn)
        {
            CancelInvoke("BallSpawn");
        }

        Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>();
        Vector2 randomForce = new Vector2(Random.Range(-randomSpawnForce, randomSpawnForce), 0);
        rigid.AddForce(randomForce, ForceMode2D.Impulse);
    }

}
