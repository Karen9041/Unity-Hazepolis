using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Created by Vitens on 2020/12/11 20:48:35
/// 
/// Description : 
///      ���̭I���Ϥ�����ҩԦ��۾A��
/// </summary>
[ExecuteInEditMode]
public class BGScaler : MonoBehaviour
{
    //�Ϥ���j�p(���Y�e��)
    public Vector2 textureOriginSize = new Vector2(2048, 1024);
    // Start is called before the first frame update
    void Start()
    {
        Scaler();
    }

    void Scaler()
    {
        //��e�e���ؤo
        Vector2 canvasSize = gameObject.GetComponentInParent<Canvas>().GetComponent<RectTransform>().sizeDelta;
        //��e�e���ؤo���e��
        float screenxyRate = canvasSize.x / canvasSize.y;

        //�Ϥ��ؤo �o�ӱo�쪺���G�O (0,0) ?
        //Vector2 bgSize = bg.mainTexture.texelSize;
        Vector2 bgSize = textureOriginSize;
        //�v���ؤo���e��
        float texturexyRate = bgSize.x / bgSize.y;

        RectTransform rt = (RectTransform)transform;
        //�v��x����,�ݭn�A�ty�]�U�����P�_ '>' �אּ '<' �N�O�v�����񾹪��v���覡�^
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
        //editor�Ҧ��U���ե�
        Scaler();
#endif
    }

}