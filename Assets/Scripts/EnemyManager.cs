using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private float health;
    private bool _colliderBusy = false;

    public float damage;

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !_colliderBusy)
        {
            _colliderBusy = true;
            collision.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if (collision.tag=="Bullet")
        {
            GetDamage(collision.GetComponent<BulletManager>().bulletDamage);
            Destroy(collision.gameObject);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _colliderBusy = false;
        }
    }

    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }

        AmIDead();
    }

    private void AmIDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
