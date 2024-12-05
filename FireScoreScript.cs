using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This script handles UI elements of scores, both fires put out and sunflowers grown. 
//It also handles changes of image for icon in scorecounter UIand completion of game 
public class FireScoreScript : MonoBehaviour
{
    public Text scoreText;                    
    public Image scoreImage;                  
    public Sprite sunflowerSprite;            
    public static int fireScoreCount;        
    public static int sunflowerScoreCount;    

    public GameObject gameCompleted;          
    public GameObject scoreCounterUI;         
    private bool isGameCompleted = false;     
    private bool firesCompleted = false;      

    void Start()
    {
        fireScoreCount = 0;
        sunflowerScoreCount = 0;
        gameCompleted.SetActive(false);       
    }

    void Update()
    {
        if (!firesCompleted)
        {
            scoreText.text = fireScoreCount + "/5";

            if (fireScoreCount >= 5)
            {
                firesCompleted = true;
                scoreImage.sprite = sunflowerSprite; 
                scoreText.text = sunflowerScoreCount + "/10";
            }
        }
        else
        {
            scoreText.text = sunflowerScoreCount + "/10";

            if (sunflowerScoreCount >= 10 && !isGameCompleted)
            {
                GameCompleted();

            }

            }

            
        }
    

    private void GameCompleted()
    {
        isGameCompleted = true;
        gameCompleted.SetActive(true);   
        scoreCounterUI.SetActive(false);
    }

    public static void IncrementFireScore()
    {
        fireScoreCount++;
    }

    public static void IncrementSunflowerScore()
    {
        sunflowerScoreCount++;
    }
}
