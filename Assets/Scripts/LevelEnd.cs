using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] string tag;
    [SerializeField] Engine engine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tag)
        {
            engine.WinGame();
            Destroy(collision.gameObject);
        }
    }
}
