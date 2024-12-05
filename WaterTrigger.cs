using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

//this script handles the water trigger of water pistol that is attached to the right XR controller.
//it plays and pauses the particle system according to user input 
public class WaterTrigger : MonoBehaviour
{
    public ParticleSystem FX_WateringCan;  
    public ActionBasedController rightHandController;  
    public AudioSource water;

    private bool isPlaying = false;


    void Start()
    {

        FX_WateringCan.Stop();
        if (water != null)
        {
            water.Stop();
        
        }
    }


    void Update()
    {
        if (rightHandController == null || FX_WateringCan == null  || water == null)
        {
            return;
        }

        if (rightHandController.activateAction.action.IsPressed())
        {
            if (!isPlaying)
            {
                FX_WateringCan.Play();
                water.Play();
                isPlaying = true;
            }
        }
        else
        {
            if (isPlaying)
            {
                FX_WateringCan.Stop();
                water.Stop(); 
                isPlaying = false;
            }
        }
    }
}
