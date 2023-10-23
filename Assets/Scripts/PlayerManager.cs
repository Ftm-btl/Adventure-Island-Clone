using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float  bulletSpeed;
    private bool _dead = false;

    public float health;
    public float score;
    public TextMeshProUGUI playerScoreText;
    public GameObject hammerBullet;
    public GameObject fireBullet;
    public Transform _muzzle;
    public Slider slider;
    public Transform finish;
    public Transform fall;
    private void Start()
    {
        health = 100;
        score = 0;
        slider.maxValue = health;
        slider.value = health;
    }

    private void Update()
    {
        playerScoreText.text = score.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
        FinishController();
        fallController();
    }

    public void GetDamage( float damage)
    {
        if((health-damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }

    private void AmIDead()
    {
        if(health <= 0)
        {
            _dead = true;
            SceneManager.LoadScene(2);
        }        
    }

    private void ShootBullet()
    {
        if (score < 300)
        {
            GameObject tempHammer;
            tempHammer = Instantiate(hammerBullet, _muzzle.position, Quaternion.identity);
            tempHammer.GetComponent<Rigidbody2D>().AddForce(_muzzle.forward * bulletSpeed);
        }
        else if (score >= 300)
        {
            GameObject tempFire;
            tempFire = Instantiate(fireBullet, _muzzle.position, Quaternion.identity);
            tempFire.GetComponent<Rigidbody2D>().AddForce(_muzzle.forward * bulletSpeed);
        }
        
    }

    private void FinishController()
    {
        if( finish.position.x >= 209 && finish.position.y >= 10)
        {
            SceneManager.LoadScene(0);
        }
    }
     private void fallController()
    {
        if (fall.position.y <= -5)
        {
            SceneManager.LoadScene(2);
        }
    }
}
