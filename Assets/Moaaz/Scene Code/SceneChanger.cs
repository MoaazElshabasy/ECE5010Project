using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int level;
    public void goHome()
    {
        SceneManager.LoadScene(0);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoTo(int level)
    {
        SceneManager.LoadScene(level);
    }

}
