using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneData : MonoBehaviour
{
    Scene scene;
    TextMeshPro sceneTitle;
    TextMeshPro subTitle;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject gunPrefab;

    [SerializeField]string sceneName;
    [SerializeField]string subName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
