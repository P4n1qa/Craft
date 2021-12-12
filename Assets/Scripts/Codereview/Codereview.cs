using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject camerFollow ,spectatorCamera;
    [SerializeField] Text damagetext;
    [SerializeField] Slider healthSlider;
    [SerializeField] int currentHealth, damage;

    private int _maxHealth = 100;


    private void Start()
    {
        currentHealth = _maxHealth;
        healthSlider.value = _maxHealth;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakingDamage();
            if (currentHealth <= 0)
            {
                Isdead();
                spectatorCamera.SetActive(true);
                camerFollow.SetActive(false);
                healthSlider.gameObject.SetActive(false);
            }
        }
    }

    private void TakingDamage()
    {
        currentHealth -= damage;
        damagetext.text = currentHealth.ToString();
        healthSlider.value = currentHealth;
    }

    private bool Isdead()
    {
        CarDestroying();
        return true;
    }

    private void CarDestroying()
    {
        Destroy(gameObject);
    }

}