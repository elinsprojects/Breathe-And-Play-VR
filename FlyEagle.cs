using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

//this script handles flying movement, and is attached to the XR rig, as the eagle gameobject is attached to the camera(so that it's centred)
public class FlyEagle : MonoBehaviour
{
    public ActionBasedController leftHandController;
    public Transform cameraRigMovement;
    public Transform cameraMovement;
    public float upwardSpeed = 1.2f;
    public float forwardSpeed = 4f;
    public float downwardSpeed = 1.5f;

    public GameObject eagle; 

    private float timer = 0f;        
    private bool eagleStart = false;      

    private void Start()
    {
        timer = 0f;
        eagleStart = false;
        eagle.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;

        //set eagle active when 30 seconds have gone by, allowing time for breath in and breath out UI to finish
        if (timer >= 30f) {

            eagle.SetActive(true);

        }

        //allow 2 seconds for user to settle before the eagle starts falling down due to inactivity 
        if (timer >= 32f)
        {
            eagleStart = true; 
        }

        if (eagleStart)
        {   
            //same button as proxy as teleportation grab to fly upwards and forward 
            //https://docs.unity3d.com/ScriptReference/Vector3.html
            //https://docs.unity3d.com/ScriptReference/Space.World.html

            if (leftHandController.selectAction.action.IsPressed())
            {
                Vector3 forwardDirection = cameraMovement.forward;
                cameraRigMovement.Translate(forwardDirection * forwardSpeed * Time.deltaTime, Space.World);
                cameraRigMovement.Translate(Vector3.up * upwardSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                //if button not triggered, then everything falls downwards slowly 
                cameraRigMovement.Translate(Vector3.down * downwardSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
