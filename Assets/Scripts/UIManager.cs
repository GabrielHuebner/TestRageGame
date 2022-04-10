using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get => _instance; set => _instance = value; }

    public RectTransform life;

    public void Start()
    {
        _instance = this;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void OnDeath()
    {
        life.position -= new Vector3(27, 0, 0);
    }
}
