using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class CnvLVLSgtMan : MonoBehaviour
{

    public static CnvLVLSgtMan instance;

    public void Awake()
    {
        MakeInstance();
    }

    void Update()
    {

        //Always show mouse on Menu

    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void LoadLevel(string Name)
    {
        Debug.Log("Level Load requeted for : " + Name);
        SceneManager.LoadScene(Name);

    }

    public void RestartLevel()
    {
        Debug.Log("Level Load requeted for : " + "Restart Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


    public void RequestQuit()
    {
        Debug.Log("I want to quit");
        Application.Quit();

    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelByIndex(int index)
    {
        Debug.Log("Level Load requeted for index : " + index);
        SceneManager.LoadScene(index);

        // show mouse on menu


    }

    public void ShowMouse()
    {

        Cursor.visible = true;


    }

    public void PauseLevel()
    {
        Time.timeScale = 0;
        CnvAltGameplayMan.instance.gameplayState = CnvAltGameplayMan.GameplayState.GAME_PAUSE;
    }

    public void unPauseLevel()
    {
        Time.timeScale = 1;
        CnvAltGameplayMan.instance.gameplayState = CnvAltGameplayMan.GameplayState.GAME_RUNNING;
    }


}
