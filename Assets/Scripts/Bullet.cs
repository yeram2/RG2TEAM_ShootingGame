using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Vector3 targetPosition; // ���콺 Ŭ�� ��ġ�� �����ϴ� ����

    private void Start()
    {
        Destroy(gameObject, 3);
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
    }

    private void FixedUpdate()
    {
        // ���콺 ��ġ�� ���ϴ� ���� ���
        Vector3 direction = (targetPosition - transform.position).normalized;

        // ���� �������� �Ѿ��� �̵�
        transform.Translate(direction * speed * Time.deltaTime);

        // �Ѿ��� ���� ��ġ�κ��� ����� ��������� �ı�
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Bullet_Attack(collision);
        }
    }

    void Bullet_Attack(Collider2D collider)
    {
        Destroy(collider.gameObject);

        GameManager.instance.score += 1;
    }
}
