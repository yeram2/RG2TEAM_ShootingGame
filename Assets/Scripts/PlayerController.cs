using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    [Header("Player ����")]
    public int hp;
    public HPManager hpManager; // HPManager ��ũ��Ʈ ����

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Init();
    }

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
        hp = hpManager.maxHP; // HPManager�� maxHP�� �����ͼ� �ʱ�ȭ
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            hpManager.TakeDamage(1); // HPManager�� TakeDamage �޼��� ȣ��
            hp = hpManager.currentHP; // HPManager�� currentHP ���� �����ͼ� ������Ʈ

            if (hp <= 0)
            {
                Debug.LogError("��������");
                
            }
        }
    }
}
