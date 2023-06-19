using System.Collections;
using UnityEngine;
using static UnityEngine.UI.Image;

public class GunController : MonoBehaviour
{
    public float damage = 50.0f;
    public float range = 100.0f;
    public float fireRate = 0.1f;

    public Camera cam;
    public Animator animator;

    private bool isFiring;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        RaycastHit hit;

        StartCoroutine(FireCooldown());
        // raycast a vector forwards, if hit something, apply damage
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

    // imitate the time elapsed between two shots and enable fire animation
    IEnumerator FireCooldown()
    {
        isFiring = true;
        animator.SetBool("Firing", true);

        yield return new WaitForSeconds(fireRate);
        
        animator.SetBool("Firing", false);
        isFiring = false;
    }

    // draw raycast line for debugging
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * 40);
    }
}
