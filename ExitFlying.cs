using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script handles the exiting to main menu from the flying game. 
//it's using collision detection with the Eagle and plays an earcon when it hits
//then it waits for 2 seconds before it changes the scene to main menu
public class ExitFlying : MonoBehaviour
{
    public string sceneName = "Main Menu";
    public float delay = 2.0f;

    private bool isColliding = false;
    private float timer = 0.0f;

    public AudioSource earcon; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Eagle"))
        {
            isColliding = true;
            earcon.Play();


        }
    }

    private void Update(){
        if (isColliding){


            timer += Time.deltaTime;

            if(timer >= delay)
            {
                SceneManager.LoadScene(sceneName);
            }
        }

    }
}