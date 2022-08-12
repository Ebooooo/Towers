using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public Manager towerNumb;
    public bool noMoreTowers;
    float maxDistance;
    Vector2 startingPos;
    public Transform launchPosition;
    public TowerManager towerspawn;
    Rigidbody2D rb;

    void Awake()
    {
        maxDistance = Random.Range(5,20);
        startingPos = transform.position;
        towerNumb = GameObject.Find("Manager").GetComponent<Manager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(maxDistance);
        float currentDistance = Vector2.Distance(startingPos, transform.position);
        if(currentDistance > maxDistance && towerNumb.TowerNumber <= 99 && !towerNumb.noMore)
        {
            Destroy(gameObject);
            Instantiate(towerspawn, launchPosition.position, Quaternion.identity);
            towerNumb.TowerNumber++;
        }
        else if(currentDistance > maxDistance)
        {
            Destroy(gameObject);
        }
        if(noMoreTowers && currentDistance > maxDistance)
        {
            Destroy(gameObject);
        }
        float Speed = 20f;
        rb.AddForce(transform.up * Time.deltaTime * Speed); 
    }

    public void OnCollisionEnter2D(Collision2D tower)
    {
        if(tower.gameObject.CompareTag("Tower"))
        {
            Destroy(gameObject);
            towerNumb.TowerNumber--;
        }
    }
}
