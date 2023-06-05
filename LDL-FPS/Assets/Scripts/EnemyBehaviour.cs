using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent navAgent;

    public float speed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        // initialize components
        target = GameObject.Find("Player");
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 moveDirection = (target.transform.position - transform.position) * 1.0f;

        //enemyRb.AddForce(moveDirection.normalized * Time.fixedDeltaTime *  speed);

        // find target position and move towards target
        navAgent.destination = target.transform.position;

    }
}
