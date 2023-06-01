using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] Engine engine;
    [SerializeField] string plTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == plTag)
        {
            Destroy(collision.gameObject);
            engine.PlayerDeath();
        }
    }
}
