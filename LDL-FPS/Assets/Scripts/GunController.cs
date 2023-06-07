using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage = 10.0f;
    public float range = 100.0f;

    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        RaycastHit hitInfo;

        // raycast a vector forwards, if hit something, 
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);
        }
    }
}
