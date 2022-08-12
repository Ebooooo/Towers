using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int TowerNumber;
    public bool noMore;
    private TMPro.TextMeshProUGUI towerUI;

    public void Start()
    {
        noMore = false;
        GameObject[] towersnumb = GameObject.FindGameObjectsWithTag("Tower");
        TowerNumber = towersnumb.Length;
        towerUI = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void Update()
    {
        if(TowerNumber >= 100)
        {
            noMore = true;
        }
        towerUI.text = $"Towers: {Mathf.Ceil(TowerNumber)}";
    }
}
