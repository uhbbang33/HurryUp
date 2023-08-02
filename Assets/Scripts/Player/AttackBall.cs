using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBall : MonoBehaviour
{
    [SerializeField] float ballSpeed;

    void Update()
    {
        transform.Translate(Vector2.left * ballSpeed * Time.deltaTime);
    }
}
