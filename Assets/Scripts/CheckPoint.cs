using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TerrainUtils;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Engine engine;
    [SerializeField] string plTag;
    [SerializeField] TextMeshPro displaytime;
    [SerializeField] Color gotColor;
    [SerializeField] Color notColor;
    bool Checked = false;
    bool hasRenderer = false;

    SpriteRenderer sr;
    private void Start()
    {
        hasRenderer = TryGetComponent<SpriteRenderer>(out sr);
        if (hasRenderer)
        {
            sr.color = notColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Checkpoint");
        if (collision.gameObject.tag == plTag && !Checked)
        {
            engine.CheckPointHit(spawnPoint);
            Checked = true;

            if (hasRenderer)
            {
                sr.color = gotColor;
            }

            //displaytime.text = engine.GetCurrentTime().ToString();
        }
    }

    void CheckReset()
    {
        Checked = false;
        if (hasRenderer)
        {
            sr.color = notColor;
        }
        //displaytime.text = "";
    }
}
