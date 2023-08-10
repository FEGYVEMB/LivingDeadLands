using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour
{
    public GameObject particleObject;

    //Dictionary<string, GameObject> impactParticles = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // play a particle at a certain location based on tag
    public void PlayAt(Vector3 location)
    {
        var particle = particleObject.GetComponent<ParticleSystem>();


        // activate and play effect at location 
        particleObject.SetActive(true);
        particleObject.transform.position = location;
        particle.Play();

        // reset particle object
        particleObject.transform.position = Vector3.zero;
        particleObject.SetActive(false);
        
    }

}
