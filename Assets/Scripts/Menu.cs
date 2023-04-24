using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Game(int sceneId)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneId);
    }
}
