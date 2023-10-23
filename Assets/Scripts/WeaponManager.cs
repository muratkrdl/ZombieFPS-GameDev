using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] Animator playerAnimator;
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        playerAnimator.SetTrigger("Shoot");

        RaycastHit hit;

        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();

            if(enemyManager != null)
            {
                enemyManager.Hit(damage);
            }
        }
    }

}
