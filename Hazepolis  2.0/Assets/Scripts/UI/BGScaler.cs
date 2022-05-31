using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Created by Vitens on 2020/12/11 20:48:35
/// 
/// Description : 
///      全屏背景圖片等比例拉伸自適應
/// </summary>
[ExecuteInEditMode]
public class BGScaler : MonoBehaviour
{
    //圖片原大小(壓縮前的)
    public Vector2 textureOriginSize = new Vector2(2048, 1024);
    // Start is called before the first frame update
    void Start()
    {
        Scaler();
    }

    void Scaler()
    {
        //當前畫布尺寸
        Vector2 canvasSize = gameObject.GetComponentInParent<Canvas>().GetComponent<RectTransform>().sizeDelta;
        //當前畫布尺寸長寬比
        float screenxyRate = canvasSize.x / canvasSize.y;

        //圖片尺寸 這個得到的結果是 (0,0) ?
        //Vector2 bgSize = bg.mainTexture.texelSize;
        Vector2 bgSize = textureOriginSize;
        //影片尺寸長寬比
        float texturexyRate = bgSize.x / bgSize.y;

        RectTransform rt = (RectTransform)transform;
        //影片x偏長,需要適配y（下面的判斷 '>' 改為 '<' 就是影片播放器的影片方式）
        if (texturexyRate > screenxyRate)
        {
            int newSizeY = Mathf.CeilToInt(canvasSize.y);
            int newSizeX = Mathf.CeilToInt((float)newSizeY / bgSize.y * bgSize.x);
            rt.sizeDelta = new Vector2(newSizeX, newSizeY);
        }
        else
        {
            int newVideoSizeX = Mathf.CeilToInt(canvasSize.x);
            int newVideoSizeY = Mathf.CeilToInt((float)newVideoSizeX / bgSize.x * bgSize.y);
            rt.sizeDelta = new Vector2(newVideoSizeX, newVideoSizeY);
        }
    }

    public void Update()
    {
#if UNITY_EDITOR
        //editor模式下測試用
        Scaler();
#endif
    }

}