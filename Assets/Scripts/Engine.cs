using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
    //[SerializeField] SceneData[] scenes;

    //SceneData currentScene;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gun;
    [SerializeField] Canvas title;
    [SerializeField] Canvas gameUI;
    [SerializeField] Canvas deathScreen;
    [SerializeField] Canvas winScreen;
    [SerializeField] TextMeshProUGUI deathCD;
    [SerializeField] TextMeshProUGUI levelTime;
    [SerializeField] TextMeshProUGUI liveCount;
    [SerializeField] CheckPointManager chkpntManager;
    [SerializeField] private LerpCam cam;


    Transform originalSpawn;
    float time = 0;
    int lives = 2;
    bool startedGame = false;

    enum State
    {
        Title,
        Start,
        Dead,
        Play,
        Win
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
        originalSpawn = spawnPoint;
    }

    private void Update()
    {
        switch(state)
        {
            case State.Title:
                startedGame = false;
                title.enabled = true;
                gameUI.enabled = false;
                deathScreen.enabled = false;
                winScreen.enabled = false;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    state = State.Start;
                }
                break;

            case State.Dead:
                title.enabled = false;
                gameUI.enabled = false;
                deathScreen.enabled = true;
                winScreen.enabled = false;

                deadWeight -= Time.deltaTime;
                deathCD.text = Mathf.Floor(deadWeight).ToString();
                if (deadWeight <= 0)
                {
                    lives--; // re instate once titlescreen and end screen are done
                    liveCount.text = "Lives: " + (lives + 1).ToString();

                    state = State.Play;
                    SpawnPlayer();
                }
                break;

            case State.Play:
                // player stuff ig idk
                time += Time.deltaTime;
                levelTime.text = Mathf.Floor(time).ToString();
                deathScreen.enabled = false;
                gameUI.enabled = true;
                winScreen.enabled = false;

                break;

            case State.Start:
                spawnPoint = originalSpawn;
                time = 0;
                lives = 2;
                chkpntManager.StartLevel();
                SpawnPlayer();
                title.enabled = false;
                gameUI.enabled = true;
                deathScreen.enabled = false;
                winScreen.enabled = false;

                startedGame = true;
                state = State.Play;
                break;

            case State.Win:
                title.enabled = false;
                gameUI.enabled = false;
                deathScreen.enabled = false;
                winScreen.enabled = true;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    state = State.Title;
                }
                break;
        }
    }

    public float GetCurrentTime()
    {
        return time;
    }

    public void PlayerDeath()
    {
        state = State.Dead;
        deadWeight = 3.0f;
        if (lives <= 0){
            state = State.Title;
        }

    }

    public void WinGame()
    {
        state = State.Win;
    }
    private void SpawnPlayer()
    {
        liveCount.text = "Lives: " + (lives + 1).ToString();

        GameObject plInstance = Instantiate(player, spawnPoint.position, Quaternion.identity);
        GameObject gunInstance = Instantiate(gun, spawnPoint.position, Quaternion.identity);
        gunInstance.GetComponent<PlayerGun>().parent = plInstance;
        cam.target = plInstance;
    }
}
