using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelByIndex : MonoBehaviour
{
    public void LoadScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }

    public void LoadMap()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentScene", 0));
    }
    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                LoadMap();
            }
        }
            
    }
}
