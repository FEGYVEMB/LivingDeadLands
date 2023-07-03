using System.Collections;
using UnityEngine;
using static UnityEngine.UI.Image;

public class GunController : MonoBehaviour
{
    public float damage = 50.0f;
    public float range = 100.0f;
    public float fireRate = 0.1f;

    public Animator animator;

    [SerializeField]private Camera cam;
    private ParticleSystem muzzleFlash;

    private void Start()
    {
        // initialize fire animation components
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
        animator = GetComponentInChildren<Animator>();
    }

    public void Shoot()
    {
        RaycastHit hit;

        StartCoroutine(FireCooldown());
        muzzleFlash.Play();

        // raycast a vector forwards, if hit something, apply damage
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // debug drawray and display impacted target name
            //Ray ray = cam.ScreenPointToRay(hit.point.normalized);
            //Debug.DrawRay(cam.transform.position, hit.point.normalized, Color.red, 3);
            //Debug.Log(hit.transform.name);

            EnemyBehaviour enemyTarget = hit.transform.GetComponent<EnemyBehaviour>();

            if (enemyTarget != null)
            {
                if (enemyTarget.bloodSplatter != null)
                {
                //enemyTarget.bloodSplatter.transform.position = hit.point;
                enemyTarget.bloodSplatter.Play();
                }

                enemyTarget.DecreaseHealth(damage);
            }
        }
    }

    // imitate time limit between shots
    IEnumerator FireCooldown()
    {
        animator.SetBool("Firing", true);

        yield return new WaitForSeconds(fireRate);

        animator.SetBool("Firing", false);
    }

    // draw raycast line for debugging
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * 40);
    }
}
