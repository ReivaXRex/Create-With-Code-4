using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    
    private GameObject player;
    private Rigidbody enemyRb;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // enemyRb.AddForce((player.transform.position - transform.position).normalized * speed); // normailzed ensures the enemy always move at a constant rate.
        EnemyMovement();
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyMovement()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }

}
