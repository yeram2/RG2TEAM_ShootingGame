using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private Vector3 targetPosition; // 마우스 클릭 위치를 저장하는 변수

    private void Start()
    {
        Destroy(gameObject, 3);
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
    }

    private void FixedUpdate()
    {
        // 마우스 위치로 향하는 방향 계산
        Vector3 direction = (targetPosition - transform.position).normalized;

        // 계산된 방향으로 총알을 이동
        transform.Translate(direction * speed * Time.deltaTime);

        // 총알이 시작 위치로부터 충분히 가까워지면 파괴
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
