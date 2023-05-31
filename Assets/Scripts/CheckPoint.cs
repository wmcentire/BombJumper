using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Engine engine;
    [SerializeField] string plTag;
    [SerializeField] TextMeshPro displaytime;
    bool Checked = false;
    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == plTag && !Checked)
        {
            engine.CheckPointHit(spawnPoint);
            Checked = true;
            displaytime.text = engine.GetCurrentTime().ToString();
        }
    }

    void CheckReset()
    {
        Checked = false;
        displaytime.text = "";
    }
}
