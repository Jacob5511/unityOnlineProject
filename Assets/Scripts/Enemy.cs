using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject boomParticleSquare, boomParticleTreugolnic, boomParticleRocket; 
    GameObject boomParticleStatic;
    private int enemyLives = 2, scoreStatic;
    [SerializeField] float speed;
    GunController player;
    private Vector2 direction;
    [SerializeField] bool square, rocket, triangle;
    bool isFreeze = false;
    void Start()
    {
        if(square)
        {
            enemyLives = 3;
            scoreStatic = 3;
            boomParticleStatic = boomParticleSquare;
        }
        if(triangle)
        {
            enemyLives = 1;
            scoreStatic = 1;
            boomParticleStatic = boomParticleTreugolnic;
        }
        if(rocket)
        {
            enemyLives = 1;
            scoreStatic = 2;
            boomParticleStatic = boomParticleRocket;
        }
        player = FindObjectOfType<GunController>();
    }
    void Update()
    {
        if(player == null)
        {
            Destroy(gameObject);
        }
        if(isFreeze == true)
        {
            if(speed > 0)
            {
                speed -= 0.009f;
            }
            else
            {
                isFreeze = false;
            }
        }
        if(Vector2.Distance(transform.position, player.transform.position) > 0.8f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
        }
        // else
        // {
        //     StartCoroutine("GunLives");
        // }
        direction = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        if(enemyLives == 0)
        {
            Destroy();
        }
    }
    void Destroy()
    {
        GameManager.countEnemy++;
        GameManager.score += scoreStatic;
        Destroy(gameObject);
        Instantiate(boomParticleStatic, transform.position, Quaternion.identity);
    }
    IEnumerator GunLives()
    {
        yield return new WaitForSeconds(1);
        GameManager.lives--;
        StartCoroutine("GunLives");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Bullet"))
        {
            enemyLives--;
            Destroy(collision.gameObject);
        }
        if(collision.tag.Equals("colliderAtomBomb"))
        {
            enemyLives = 0;
            Destroy(collision.gameObject);
        }
        if(collision.tag.Equals("colliderFreeze"))
        {
            isFreeze = true;
            Destroy(collision.gameObject);
        }
        if(collision.tag.Equals("playerCollider"))
        {
            StartCoroutine("GunLives");
        }
    }
    private void OnMouseDown()
    {
        enemyLives--;
    }
}
