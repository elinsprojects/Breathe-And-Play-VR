using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script handles the flower growing when it's being hit by the waterparticle system of the waterpistol.
//also it destroys the red plane gameobject underneath the flower to mark the task done 
public class GrowFlower : MonoBehaviour
{
    public ParticleSystem waterParticleSystem;
    public Vector3 targetScale = new Vector3(2.0f, 2.0f, 2.0f);
    public GameObject targetPlane;

    public AudioSource earcon; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            if (waterParticleSystem.isPlaying)
            {

                transform.localScale = targetScale;

                if (targetPlane != null)
                {
                    earcon.Play();
                    Destroy(targetPlane); 
                    FireScoreScript.IncrementSunflowerScore(); 
                }
            }
            else
            {
                Debug.Log("Water effect is not active, Flower will not grow");
            }
        }
    }
}