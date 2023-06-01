using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathSound : MonoBehaviour
{
    [SerializeField] AudioSource source;

    // Update is called once per frame
    void Update()
    {
        if (source != null)
        {
            if (!source.isPlaying) Destroy(gameObject);
        }
    }
}
