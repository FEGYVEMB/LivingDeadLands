using System.Collections;
using UnityEngine;
using static UnityEngine.UI.Image;

public class GunController : MonoBehaviour
{
    public float damage = 50.0f;
    public float range = 100.0f;
    public float fireRate = 0.3f;

    public Animator animator;

    [SerializeField]private Camera cam;
    private ParticleSystem muzzleFlash;
    private ImpactManager impactManager;
    private FireModeController fireController;

    private void Start()
    {
        // initialize fire animation components
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
        animator = GetComponentInChildren<Animator>();
        impactManager = GameObject.Find("ImpactManager").GetComponent<ImpactManager>();
        fireController = GetComponentInParent<FireModeController>();
    }

    private void Update()
    {
        
    }

    // shooting mechanics
    public void Shoot()
    {
        RaycastHit hit;

        StartCoroutine(fireController.FireCooldown(fireRate));
        muzzleFlash.Play();

        // raycast a vector forwards, if hit something, apply damage
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // debug drawray and display impacted target name
            //Ray ray = cam.ScreenPointToRay(hit.point.normalized);
            //Debug.DrawRay(cam.transform.position, hit.point.normalized, Color.red, 3);
            ////Debug.Log(hit.point);
            impactManager.PlayAt(hit.point, hit.collider.tag);
            
            EnemyBehaviour enemyTarget = hit.transform.GetComponent<EnemyBehaviour>();

            if (enemyTarget != null)
            {
                enemyTarget.DecreaseHealth(damage);
            }
        }
    }

    // draw raycast line for debugging
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * 40);
    }
}
