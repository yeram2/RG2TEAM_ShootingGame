using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player ¼¼ÆÃ")]

    public float speed;
    public int hp;

    Rigidbody2D rigid;

    void Update()
    {
        Move();
    }
    void Move()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        Vector2 direction1 = new Vector2(Horizontal, 0);
        transform.position = (Vector2)transform.position + direction1 * speed * Time.deltaTime;



        float Vertical = Input.GetAxis("Vertical");
        Vector2 direction2 = new Vector2(0, Vertical);
        transform.position = (Vector2)transform.position + direction2 * speed * Time.deltaTime;



    }


    public void Init()
    {
        speed = 6f;
        hp = 3;
    }



}