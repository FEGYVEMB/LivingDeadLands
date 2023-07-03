using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent navAgent;

    public float speed = 50.0f;
    public float health = 50.0f;
    public float damage = 20.0f;

    public ParticleSystem bloodSplatter;


    // Start is called before the first frame update
    void Start()
    {
        // initialize components needed
        target = GameObject.Find("Player");
        navAgent = GetComponent<NavMeshAgent>();
        bloodSplatter = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // find target position and move towards target
        navAgent.destination = target.transform.position;
    }

    public void DecreaseHealth(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            target.GetComponent<PlayerController>().DecreaseHealth(damage);
        }
    }
}
