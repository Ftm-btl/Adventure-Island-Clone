using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameObject[] fruits;

    private float ranY;
    private float ranX;
    private Vector2 whereToSpawn;
    

    public float spawnRate = 1f;
    public float nextSpawn = 1f;
    public float lostTime;
    public Transform floatingText;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;

            int randomFruitIndex = Random.Range(0, fruits.Length);

            ranY = Random.Range(1,0);
            ranX = Random.Range(-11, 200);
            whereToSpawn = new Vector2(ranX, ranY);

            GameObject newFruits = Instantiate(fruits[randomFruitIndex], whereToSpawn, Quaternion.identity);

            Destroy(newFruits, lostTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();
            player.health += 5;
            player.slider.value = player.health;
            player.score += 50;
            gameObject.SetActive(false);
            ScoreText();
        }
    }

    private void ScoreText()
    {
        PlayerManager player = GetComponent<PlayerManager>(); 
        Transform scoreText;
        scoreText = Instantiate(floatingText, transform.position, Quaternion.identity);
        scoreText.GetComponent<TextMesh>().text = player.score.ToString();
    }
}
