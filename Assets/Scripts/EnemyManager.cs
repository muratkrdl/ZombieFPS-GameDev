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
    NavMeshAgent navMeshAgent;

    void Awake() 
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    void Update()
    {
        if(!navMeshAgent.enabled)
            return;
            
        navMeshAgent.destination = player.transform.position;

        if(navMeshAgent.velocity.magnitude > 1)
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
            animator.SetTrigger("Hit");
            Debug.Log("hitted plater!");
        }
    }

    public void HitAnimEvent()
    {
        
    }

    public void Hit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            gameManager.enemiesAlive--;
            animator.SetTrigger("Dead"); 
            navMeshAgent.enabled = false;
            GetComponent<Collider>().enabled = false;      
            Destroy(gameObject,5);
        }
    }

}
