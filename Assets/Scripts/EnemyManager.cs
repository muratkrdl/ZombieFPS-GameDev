using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] float health = 100f;

    public GameObject player;
    public GameManager gameManager;

    Animator animator;

    void Awake() 
    {
        animator = GetComponent<Animator>();
        
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        if(GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(damage);
            Debug.Log("hitted plater!");
        }    
    }

    public void Hit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            gameManager.enemiesAlive--;
            //Died phase
            Destroy(gameObject);
        }
    }

}
