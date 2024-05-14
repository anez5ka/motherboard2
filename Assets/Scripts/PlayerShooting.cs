
using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBalls;


    private Animator anim;
    private PlayerMovement move;
    private float coolDownTimer = Mathf.Infinity;


    void Awake()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (coolDownTimer == 0)
        {
            anim.ResetTrigger("shoot");
        }
        coolDownTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.X)&&coolDownTimer>attackCooldown && move.canShoot())
            Shoot();

    }

    private void Shoot()
    {
        coolDownTimer = 0;
        anim.SetTrigger("shoot");
        //pool fireball
        fireBalls[FindFireBall()].transform.position = new Vector3((firePoint.position.x + 0.75f * move.side), firePoint.position.y);

        // fireBalls[0].transform.position = new Vector3(1,0,0);
        fireBalls[FindFireBall()].GetComponent<Projectile>().SetDirection(move.side);
        //fireBalls[0].SetActive(true);
    }

    private int FindFireBall()
    {
        for (int i = 0; i < fireBalls.Length; i++)
        {
            if (!fireBalls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
