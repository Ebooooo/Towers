using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject tower;
    public int rotated;
    public int afterrotated;
    public Manager towerNumb;
    SpriteRenderer t_SpriteRenderer;
    Color t_NewColor;
    public Transform launchPosition;
    public Bullets bulletspawn;
    float timer = 0.5f;

    public void Start()
    {
        towerNumb = GameObject.Find("Manager").GetComponent<Manager>();
        t_SpriteRenderer = GetComponent<SpriteRenderer>();
        t_SpriteRenderer.color = Color.red;
        rotated = 0;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if(!towerNumb.noMore)
        {
        RotateTower();
        }
        if(towerNumb.noMore)
        {
        AllRotate();
        }
    }

    public void RotateTower()
    {
        if(rotated < 12 && towerNumb.TowerNumber < 100 && timer <= 0.0f)
        {
        t_SpriteRenderer.color = Color.red;
        timer += 0.5f;
        rotated++;
        float randomZ = Random.Range(15,45);
        tower.transform.Rotate(0,0,randomZ);
        Instantiate(bulletspawn, launchPosition.position, launchPosition.transform.rotation);
        }
        else if(towerNumb.TowerNumber == 100 || rotated == 12)
        {
            t_SpriteRenderer.color = Color.white;
        }
    }

    public void OnCollisionEnter2D(Collision2D bullet)
    {
        if(bullet.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    public void AllRotate()
    {
        if(afterrotated < 12 && timer <= 0.0f)
        {
        t_SpriteRenderer.color = Color.red;
        timer += 0.5f;
        afterrotated++;
        float randomZ = Random.Range(15,45);
        tower.transform.Rotate(0,0,randomZ);
        Instantiate(bulletspawn, launchPosition.position, launchPosition.transform.rotation);
        }
        else if(afterrotated == 12)
        {
            t_SpriteRenderer.color = Color.white;
        }
    }
}
