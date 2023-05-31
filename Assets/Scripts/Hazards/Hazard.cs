using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] Engine engine;
    [SerializeField] string plTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == plTag)
        {
            Destroy(collision.gameObject);
            engine.PlayerDeath();
        }
    }
}
