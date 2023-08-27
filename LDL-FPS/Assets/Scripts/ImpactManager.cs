using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour
{
    public GameObject particlePrefab;
    ParticleSystem[] particles;
    GameObject particleObject;

    // play a particle at a certain location based on tag
    public void PlayAt(Vector3 location, string tag)
    {
        particles = particlePrefab.GetComponentsInChildren<ParticleSystem>();   

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
                        pmain.startColor = Color.white;
                        break;
                }
            }
        }

        particleObject = Instantiate(particlePrefab, location, Quaternion.identity);
        var particleEffect = particleObject.GetComponentInChildren<ParticleSystem>();

        // activate and play effect at location
        particlePrefab.SetActive(true);

        particlePrefab.transform.position = location;
        particleEffect.Play();
    }

}
