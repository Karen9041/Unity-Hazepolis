using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool isStop = true;//標誌位，來判斷遊戲是否需要被暫停  
    public GameObject option;//這是我的設置UI界面  
                             // Update is called once per frame  
    void Update()
    {
        //遊戲需要被暫停，按下ESC，遊戲暫停，顯示我的設置UI界面，然後將標誌位設置成false，等待下次點擊ESC啟動遊戲  
        if (isStop == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isStop = false;
                option.SetActive(true);
            }
        }
        //遊戲不需要被暫停，按下ESC，遊戲啟動，隱藏我的設置UI界面，然後將標誌位設置成true，等待下次點擊ESC暫停遊戲  
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                isStop = true;
                option.SetActive(false);
            }
        }
    }
}