using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour
{
    public GameObject particleObject;
    ParticleSystem[] particles;


    // play a particle at a certain location based on tag
    public void PlayAt(Vector3 location, string tag)
    {
        particles = particleObject.GetComponentsInChildren<ParticleSystem>();
        var particle = particleObject.GetComponent<ParticleSystem>();
        
        Instantiate(particleObject, location, Quaternion.identity);

        if (particles.Length > 0)
        {
            foreach (ParticleSystem p in particles)
            {
                var pmain = p.main;
                switch (tag)
                {
                    case "Organic":
                        pmain.startColor = Color.red;
                        break;
                    default:
                        break;
                }
            }
        }
        // activate and play effect at location 
        particleObject.SetActive(true);

        particleObject.transform.position = location;
        particle.Play();
    }

}
