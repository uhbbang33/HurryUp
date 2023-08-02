using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    [SerializeField] float maxVelocity;
    [SerializeField] int enemyHP;
    [SerializeField] Vector3 cameraOffset;

    Camera mainCamera;
    Rigidbody2D enemyRb;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        mainCamera.transform.position = transform.position + cameraOffset;
    }

    private void FixedUpdate()
    {
        if (enemyRb.velocity.x < maxVelocity)
            enemyRb.AddForce(Vector2.right * enemySpeed * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        --enemyHP;
        if (enemyHP <= 0)
        {
            SceneManager.LoadScene("ClearScene", LoadSceneMode.Single);
        }
    }
}
