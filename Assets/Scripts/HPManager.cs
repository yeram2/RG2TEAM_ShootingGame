using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public int maxHP = 3; // �ִ� ü��
    public int currentHP; // ���� ü��

    public Text hpText; // ȭ�鿡 ǥ���� �ؽ�Ʈ
    public GameObject[] hearts; // Heart ������Ʈ �迭

    public void Start()
    {
        currentHP = maxHP;
        UpdateHPText();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
        UpdateHPText();

        // HP�� ������ ������ Heart ������Ʈ�� ����
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i >= currentHP)
            {
                hearts[i].SetActive(false);
            }
        }
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    private void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + GetCurrentHP().ToString();
        }
    }
}
