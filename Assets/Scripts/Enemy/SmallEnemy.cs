using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    [SerializeField] float maxVelocity;

    Rigidbody2D enemyRb;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (enemyRb.velocity.x < maxVelocity)
            enemyRb.AddForce(Vector2.left * enemySpeed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
