using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject target;
    private Rigidbody enemyRb;

    public float speed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        // initialize components
        target = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // find target position and move towards target
        Vector3 moveDirection = (target.transform.position - transform.position).normalized;

        enemyRb.AddForce(speed * Time.deltaTime * moveDirection);
    }
}
