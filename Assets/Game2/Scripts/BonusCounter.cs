using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BonusCounter : MonoBehaviour
{
    public TextMeshProUGUI playerText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject child1 = other.transform.GetChild(0).gameObject;
        GameObject child2 = child1.transform.GetChild(0).gameObject;
        string text = child2.GetComponent<TextMeshProUGUI>().text;
        Debug.Log("On Trigger Bonus " + text);
        int value = Int32.Parse(text);
        int playerValue = Int32.Parse(playerText.text);
        int res = playerValue + value;
        playerText.text = res.ToString();
        Destroy(other.gameObject);
    }
}