using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    PlayerController player_scr;//�÷��̾� ��ũ��Ʈ ������
    public static GameManager instance;
    public PoolManager poolManager;

    public int score = 0;

    private void Awake()
    {
        instance = this;
        player_scr = player.GetComponent<PlayerController>();//�÷��̾� ��ũ��Ʈ ������
    }

    private void Start()
    {
        player_scr.Init();
    }

    private void Update()
    {
        if (player_scr.hp <= 0)
        {
            Debug.LogError("��������");
        }
    }
}
