using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatform : MonoBehaviour
{
    BoxCollider2D boxcol;

    void Start()
    {
        boxcol = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(disappearCollider());
        }    
    }

    IEnumerator disappearCollider()
    {
        yield return new WaitForSeconds(1);
        boxcol.isTrigger = true;
    }
}
