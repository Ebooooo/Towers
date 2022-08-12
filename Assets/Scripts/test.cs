using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestCoroutine());
        StopCoroutine(TestCoroutine());
    }

    IEnumerator TestCoroutine()
    {
        yield return null;
        Destroy(gameObject);
    }
}
