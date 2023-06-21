using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int MazeScene;
    public void PlayMaze()
    {
        SceneManager.LoadScene(MazeScene);
    }

    public void QuitMaze()
    {
        Ogg_Helpers.Abort("Quit Game");
    }


}
