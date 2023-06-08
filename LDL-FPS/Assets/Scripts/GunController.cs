using UnityEngine;
using static UnityEngine.UI.Image;

public class GunController : MonoBehaviour
{
    public float damage = 50.0f;
    public float range = 100.0f;

    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        RaycastHit hit;

        // raycast a vector forwards, if hit something, 
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyBehaviour target = hit.transform.GetComponent<EnemyBehaviour>();

            if (target != null)
            {
                target.DecreaseHealth(damage);
            }
        }
    }

    // draw raycast line for debugging
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * 40);
    }
}
