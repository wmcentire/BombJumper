using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Path;
using UnityEngine;

public class Engine : MonoBehaviour
{
    //[SerializeField] SceneData[] scenes;

    //SceneData currentScene;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gun;
    [SerializeField] Canvas title;
    [SerializeField] Canvas gameUI;
    [SerializeField] TextMeshPro deathScreen;
    [SerializeField] CheckPointManager chkpntManager;

    float time = 0;
    int lives = 3;

    enum State
    {
        Title,
        Start,
        Dead,
        Play
    }

    State state = State.Start;
    float deadWeight = 3.0f;

    public void CheckPointHit(Transform newSpawn)
    {
        spawnPoint = newSpawn;
    }

    private void Start()
    {
        state = State.Title;
        // 
    }

    private void Update()
    {
        switch(state)
        {
            case State.Title:

                //title.enabled = true;
                //gameUI.enabled = false;
                break;

            case State.Dead:

                deadWeight -= Time.deltaTime;
                if (deadWeight <= 0)
                {
                    state = State.Play;
                    SpawnPlayer();
                }
                break;

            case State.Play:
                // player stuff ig idk
                time += Time.deltaTime;


                break;

            case State.Start:
                time = 0;
                chkpntManager.StartLevel();
                SpawnPlayer();
                //title.enabled = false;
                //gameUI.enabled = true;
                state = State.Play;
                break;
        }
    }

    public float GetCurrentTime()
    {
        return time;
    }

    public void PlayerDeath()
    {
        lives--;
        state = State.Dead;
        deadWeight = 3.0f;
        if (lives == 0){
            state = State.Title;
        }
    }

    private void SpawnPlayer()
    {
        Instantiate(player, spawnPoint.position, Quaternion.identity);
        Instantiate(gun, spawnPoint.position, Quaternion.identity);
    }
}
