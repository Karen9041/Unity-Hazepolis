using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool isStop = true;//�лx��A�ӧP�_�C���O�_�ݭn�Q�Ȱ�  
    public GameObject option;//�o�O�ڪ��]�mUI�ɭ�  
                             // Update is called once per frame  
    void Update()
    {
        //�C���ݭn�Q�Ȱ��A���UESC�A�C���Ȱ��A��ܧڪ��]�mUI�ɭ��A�M��N�лx��]�m��false�A���ݤU���I��ESC�ҰʹC��  
        if (isStop == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isStop = false;
                option.SetActive(true);
            }
        }
        //�C�����ݭn�Q�Ȱ��A���UESC�A�C���ҰʡA���çڪ��]�mUI�ɭ��A�M��N�лx��]�m��true�A���ݤU���I��ESC�Ȱ��C��  
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