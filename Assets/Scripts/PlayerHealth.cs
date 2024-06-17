using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    [SerializeField] public float currentHealth;
    private SpriteRenderer render;
    private EndingMenu menu;
    private float colorTimer;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        currentHealth = startingHealth;
        menu = GetComponent<EndingMenu>();
    }
    private void Update()
    {
        if (colorTimer < 2f)
        {
            colorTimer += Time.deltaTime;
        }   
        if (colorTimer>0.7f && render.color== Color.red)
        {
            render.color = Color.white;
        }
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth >0)
        {
            render.color = Color.red;
            colorTimer = 0;
        }
        else
        {
            menu.Lose();
        }

    }

}
