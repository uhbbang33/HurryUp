using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float hitSpeed;
    [SerializeField] float originSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] GameObject attackBallPrefab;

    LastSceneNameRememberer sceneName;

    float playerSpeed;
    float horizontalInput;
    bool isCollidingGround;
    bool isJump;
    bool possibleToAttack;
    
    Rigidbody2D playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSpeed = originSpeed;
        if (SceneManager.GetActiveScene().name == "BossScene")
            possibleToAttack = true;

        sceneName = GameObject.Find("Last Scene name").GetComponent<LastSceneNameRememberer>();
        sceneName.lastSceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isCollidingGround)
            isJump = true;
        if (Input.GetKeyDown(KeyCode.J) && possibleToAttack)
            Instantiate(attackBallPrefab, transform.position, transform.rotation);
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //transform.Translate(Vector2.right * playerSpeed * Time.deltaTime * horizontalInput);
        playerRb.AddForce(Vector2.right * playerSpeed * Time.fixedDeltaTime * horizontalInput, ForceMode2D.Impulse);
        playerRb.velocity = new Vector2(horizontalInput * playerSpeed, playerRb.velocity.y);
        
        if (isJump)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isCollidingGround = true;
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "GameOver")
            SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isCollidingGround = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            playerSpeed = hitSpeed;
            StartCoroutine(speedDownCountDownRoutine());
        }
        if (collision.gameObject.tag == "Goal")
        {
            if (SceneManager.GetActiveScene().name == "Level1")
                SceneManager.LoadScene("Level2", LoadSceneMode.Single);
            if (SceneManager.GetActiveScene().name == "Level2")
                SceneManager.LoadScene("BossScene", LoadSceneMode.Single);
        }
    }

    IEnumerator speedDownCountDownRoutine()
    {
        yield return new WaitForSeconds(4);
        playerSpeed = originSpeed;
    }
}
