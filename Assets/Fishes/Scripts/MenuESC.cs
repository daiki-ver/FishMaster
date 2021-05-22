using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuESC : MonoBehaviour
{
    bool isStop = true; //判断菜单状态，是否出现
    public GameObject Menu;
    public AudioClip music;
    
    public void OnQuit(){//退出游戏
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void OnResume(){
        Time.timeScale = 1f;
        Menu.SetActive(false);
    }

    public void OnRestart(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStop == true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isStop = false;
                Menu.SetActive(true);
            }
        }else
        {
            if(Input.GetKeyDown(KeyCode.Escape)){
                Time.timeScale = 1;
                isStop = true;
                Menu.SetActive(false);
            }
        }
    }
}
