using System;
using System.Numerics;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject[] fireBalls;

    private float coolDownTimer = Mathf.Infinity;


    void Update()
    {
        if (coolDownTimer != 0)
        
    coolDownTimer += Time.deltaTime;
    if (coolDownTimer > attackCooldown)
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        coolDownTimer = 0;
        //pool fireball
        fireBalls[FindBullet()].transform.position = new UnityEngine.Vector3((transform.position.x + 0.75f * -1f), transform.position.y);

        // fireBalls[0].transform.position = new Vector3(1,0,0);
        fireBalls[FindBullet()].GetComponent<Projectile>().SetDirection(-1);
        //fireBalls[0].SetActive(true);
    }

    private int FindBullet()
    {
        for (int i = 0; i < fireBalls.Length; i++)
        {
            if (!fireBalls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}