using UnityEngine.UI;
using UnityEngine;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    private Image totalFill;
    private Image currentFill;
    private Health health;
    

    private void Awake()
    {
        health = GetComponent<Health>();
        totalFill = totalHealthBar.GetComponent<Image>();
        currentFill = currentHealthBar.GetComponent<Image>();
    }

    private void Update()
    {
        totalFill.fillAmount = health.startingHealth * 0.0625f;
        currentFill.fillAmount = health.currentHealth * 0.0625f;
    }

   
}
