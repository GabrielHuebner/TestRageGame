using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get => _instance; set => _instance = value; }

    private CharacterMovement player;
    private Vector2 playerStartPosition;
    public void Start()
    {
        _instance = this;
        if(SceneManager.GetActiveScene().name.Contains("Level")) { 
            player = FindObjectOfType<CharacterMovement>();
            playerStartPosition = player.gameObject.transform.position;
        }
    }

    public void OnDeath()
    {
        player.gameObject.transform.position = playerStartPosition;
        UIManager.Instance.OnDeath();
    }

    public void nextRoom()
    {

    }
}
