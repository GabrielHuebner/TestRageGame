using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get => _instance; set => _instance = value; }

    private CharacterMovement player;
    private Vector2 playerStartPosition;
    public void Start()
    {
        _instance = this;
        player = FindObjectOfType<CharacterMovement>();
        playerStartPosition = player.gameObject.transform.position;
    }

    public void OnDeath()
    {
        player.gameObject.transform.position = playerStartPosition;
    }
}
