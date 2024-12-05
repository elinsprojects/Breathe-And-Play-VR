using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//time 3 seconds in, pause 1 sec, 5 seconds out, pause 1 sec. 
//Repeated 3 times to guide the user to breathe for 30 seconds (1 breath cycle/10 seconds)
//attached to UI text to appear and disappear
public class Breathing : MonoBehaviour
{
    public TMP_Text breathIn;  
    public TMP_Text breathOut;  
    public GameObject panel; 

    private float timer = 0f;
    private int repetitionCount = 0;

    private void Start()
    {
        panel.gameObject.SetActive(true);
        breathIn.gameObject.SetActive(true);
        breathOut.gameObject.SetActive(false);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        float breathCycle = 10f; 

        if (repetitionCount < 3)
        {
            if (timer < 3f)
            {
                breathIn.gameObject.SetActive(true);
                breathOut.gameObject.SetActive(false);
            }
             else if (timer < 4f)
            {
                breathIn.gameObject.SetActive(false);
                breathOut.gameObject.SetActive(false);
            }
            
            else if (timer < 9)
            {
                breathIn.gameObject.SetActive(false);
                breathOut.gameObject.SetActive(true);
            }

            else if (timer < breathCycle)
            {
                breathIn.gameObject.SetActive(false);
                breathOut.gameObject.SetActive(false);
            }
            else
            {
                timer = 0f;
                repetitionCount++;
            }
        }
        else
        {
            breathIn.gameObject.SetActive(false);
            breathOut.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);

            enabled = false;
        }
    }
}