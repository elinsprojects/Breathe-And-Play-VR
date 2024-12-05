using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script handles the flower transformation
public class AppearFlowerGL : MonoBehaviour

{
    public GameObject flowersParent; 
    private GameObject[] sunflowers; 
    public bool sunflowersVisible = false; 

    void Start()
    {
        //first find all the flowers and count them and setting them not active from the start
        //https://stackoverflow.com/questions/40993722/get-number-of-children-a-game-object-has-via-script
        int childCount = flowersParent.transform.childCount;
        sunflowers = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            sunflowers[i] = flowersParent.transform.GetChild(i).gameObject;
            sunflowers[i].SetActive(false);  
        }
    }

    void Update()
    {
        //checking if sunflowers are not visible and if all fire particle systems are stopped. 
        if (!sunflowersVisible && AllParticleSystemsStopped())
        {
            MakeSunflowersVisible();
        }
    }

    private bool AllParticleSystemsStopped()
    {
        //getting the particle systems within game object that has the tag FireStop 
        foreach (GameObject flame in GameObject.FindGameObjectsWithTag("FireStop"))
        {
            ParticleSystem firesystem = flame.GetComponent<ParticleSystem>();
            if (firesystem != null && firesystem.isPlaying)
            {
                return false;
            }
        }
        return true;
    }

    private void MakeSunflowersVisible()
    {
        //list of sunflowers and making 10 active/visible randomly from sunflowers index
        //https://docs.unity3d.com/ScriptReference/Random.Range.html

        List<int> selectedIndices = new List<int>();

        //loop to find 1 index at a time for 10 times
        while (selectedIndices.Count < 10)
        {
            int randomIndex = Random.Range(0, sunflowers.Length);

            //checking that the same index isn't selected again.
            if (!selectedIndices.Contains(randomIndex))
            {
                selectedIndices.Add(randomIndex);
                sunflowers[randomIndex].SetActive(true);
            }
        }

        sunflowersVisible = true;
    }
}