using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] Engine engine;
    [SerializeField] string plTag;
    [SerializeField] GameObject playerDeathSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == plTag)
        {
            if(playerDeathSound != null) Instantiate(playerDeathSound, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            engine.PlayerDeath();
        }
    }
}
