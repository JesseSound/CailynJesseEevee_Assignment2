using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    

    public TextMeshProUGUI timerDisplay;
    public float totalTime= 120.0f; // total time expected to finish the maze thing
    public Collections Counters; // call the collections script so we can track keys and other things maybe
    //track the game doors so we can remove them later
    public GameObject door1;
    public GameObject door2;
    //game over handling
    public bool gameOver;
    public GameObject GameOverScreen;
    public TextMeshProUGUI timeRemaining;
    public TextMeshProUGUI itemsCollected;


    void Start()
    {
        timerDisplay.text = totalTime.ToString();

        Counters = Counters.GetComponent<Collections>();

        gameOver = false;
        GameOverScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) // Check if the game is not over
        {
            //ez pz timer
            totalTime -= Time.deltaTime;
            timerDisplay.text = Mathf.Round(totalTime).ToString();

            if (Counters.keys.Length == 2)
            {
                Debug.Log("KEYS GATHERED");

                door1.SetActive(false);
                door2.SetActive(false);
            }
        }

        if (gameOver)
        {
            // Stop the timer when the game is over
            Debug.Log(totalTime);
            timeRemaining.text = Mathf.Round(totalTime).ToString();
            itemsCollected.text = Counters.collectibles.Length.ToString();
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }


}



