using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public void StartLevel()
    {
        BroadcastMessage("CheckReset");
    }
}
