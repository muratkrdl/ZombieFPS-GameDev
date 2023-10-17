using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] float health = 100;

    void Start()
    {
        healthText.text = "Health: " + health.ToString();
    }

    public void Hit(float damage)
    {
        health -= damage;
        healthText.text = "Health: " + health.ToString();

        if(health <= 0)
        {
            healthText.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().ShowGameOver();
        }
    }

}
