using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject bullet, spawnBulletPoint, enemy, colliderAtomBomb, colliderFreeze, finishPanel, Game, countWaveText;
    private Vector3 direction;
    GameObject[] en;
    GameObject closest;
    private bool automatic = false, canShot = false;
    [SerializeField] float reloadTime, rotationSpeed;
    private float shotTime = Mathf.Infinity;
    void Start()
    {
    }
    void FixedUpdate()
    {
        en = GameObject.FindGameObjectsWithTag("Enemy");
        FindClosestEnemy();
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, direction), rotationSpeed * Time.deltaTime);
        CanShot();
        // enemy = GameObject.FindGameObjectWithTag("Enemy");
        direction = closest.transform.position - transform.position;
        // direction = enemy.transform.position - transform.position;
        if(automatic == true)
        {
            if(canShot && Vector2.Distance(transform.position, closest.transform.position) < 8 /*&& transform.rotation == Quaternion.LookRotation(Vector3.forward, direction)*/)
            {
                Instantiate(bullet, spawnBulletPoint.transform.position, transform.rotation);
                canShot = false;
            }
        }
        if(GameManager.lives <= 0)
        {
            Destroy(gameObject);
            Destroy(countWaveText);
            finishPanel.SetActive(true);
            Game.SetActive(false);
            GameManager.isGame = false;
            Time.timeScale = 0;
        }
    }
    GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in en)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    public void AtomBomb()
    {
        if(GameManager.score >= 150)
        {
            GameManager.score -= 150;
            Instantiate(colliderAtomBomb); 
        }
    }
    public void Freeze()
    {
        if(GameManager.score >= 100)
        {
            GameManager.score -= 100;
            Instantiate(colliderFreeze);
        }
    }
    public void AutomaticShot()
    {
        if(automatic == false)
        {
            automatic = true;
        }
        else
        {
            automatic = false;
        }
    }
    public void Shot()
    {
        if(automatic == false)
        {
            Instantiate(bullet, spawnBulletPoint.transform.position, transform.rotation);
        }
    }
    void CanShot()
    {
        if(canShot) return;
        shotTime += Time.deltaTime;
        if(shotTime > reloadTime)
        {
            shotTime = 0;
            canShot = true;
        }
    }
}
