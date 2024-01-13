using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float startHealth = 100;
    private float health;
    //public int worth = 50;
    public GameObject deathEffect;
    [Header("Unity Stuff")]
    private bool isDead = false;
    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    //public void Slow(float pct)
    //{
    //  speed = startSpeed * (1f - pct);
    // }
    void Die()
    {
        isDead = true;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

}
