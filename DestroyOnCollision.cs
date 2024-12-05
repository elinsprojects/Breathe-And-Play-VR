using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script handles the collisions and stopping the particle systems
public class DestroyOnCollision : MonoBehaviour
{
    public ParticleSystem starParticleSystem;
    public ParticleSystem lightParticleSystem1;
    public ParticleSystem lightParticleSystem2;
    public ParticleSystem waterParticleSystem;
    public AudioSource flamesAudio; 
    public AudioSource earcon; 
    private bool fireStopped = false; 

    void Start(){

        if (flamesAudio != null){

            flamesAudio.Play();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //if the object colliding has water as tag, then check if the waterparticle system is playing AND if the fire is not stopped,
        //AND if 3 fire particlesystems are playing, then stop them, stop the audio and play earcon
        if (other.gameObject.CompareTag("Water"))
        {
            if (waterParticleSystem.isPlaying)
            {
                if (!fireStopped && (starParticleSystem.isPlaying || lightParticleSystem1.isPlaying || lightParticleSystem2.isPlaying))
                {
                    starParticleSystem.Stop();
                    lightParticleSystem1.Stop();
                    lightParticleSystem2.Stop();

                    flamesAudio.Stop();
                    earcon.Play();

                    FireScoreScript.IncrementFireScore();
                    fireStopped = true;
                }
            }
        }

        //game logic to check if all fires are put out(5), determined by the score counter script 
        //and the water hits the plane(underneath the flower), the water trigger will increment the sunflowerscore
        if (FireScoreScript.fireScoreCount >= 5 && other.gameObject.CompareTag("TargetPlane"))
        {
            FireScoreScript.IncrementSunflowerScore();
        }
    }
}
