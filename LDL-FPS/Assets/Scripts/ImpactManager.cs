using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour
{
    public GameObject particlePrefab;
    ParticleSystem[] particles;
    GameObject particleObject;

    // colors
    Color brown = new Color(0.4823f, 0.3019f, 0.1372f);

    // play a particle at a certain location based on tag
    public void PlayAt(Vector3 location, string tag)
    {
        particles = particlePrefab.GetComponentsInChildren<ParticleSystem>();   

        // set color of particles
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
                    case "Ground":
                        pmain.startColor = brown;
                        break;
                    case "Metal":
                        pmain.startColor = Color.gray;
                        break;
                    default:
                        pmain.startColor = Color.white;
                        break;
                }
            }
        }


        // activate and play effect at location
        particleObject = Instantiate(particlePrefab, location, Quaternion.identity);
        var particleEffect = particleObject.GetComponentInChildren<ParticleSystem>();

        particlePrefab.SetActive(true);

        particlePrefab.transform.position = location;
        particleEffect.Play();
    }

}
