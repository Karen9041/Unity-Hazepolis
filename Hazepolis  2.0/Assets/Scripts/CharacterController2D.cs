using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CharacterController2D : MonoBehaviour
{
	public GameObject[] MainPlayer;
	private GameObject currentPlayer, previousPlayer;

	[SerializeField] private int iCharcaterCount = 0;
    private Component script;
	public Camera cameraMain2D;
	// Start is called before the first frame update
	void Start()
	{

	}
	void Update()
	{
		ChangeCharacter();
		MagicDetect();
	}

	void ChangeCharacter()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			iCharcaterCount++;
			if (iCharcaterCount >= MainPlayer.Length)
			{
				iCharcaterCount = 0;
			}
			previousPlayer = currentPlayer;
			currentPlayer = null;
		}

		switch (iCharcaterCount)
		{
			case 0:
				{
					if (currentPlayer == null) { currentPlayer = MainPlayer[0]; Debug.Log(currentPlayer.name); }
					currentPlayer.gameObject.SendMessage("Activate");
					if(previousPlayer != null)previousPlayer.gameObject.SendMessage("Deactivate");
                }
				break;
			case 1:
				{
					if (currentPlayer == null) { currentPlayer = MainPlayer[1]; Debug.Log(currentPlayer.name); }
                    currentPlayer.gameObject.SendMessage("Activate");
                    previousPlayer.gameObject.SendMessage("Deactivate");
				}
				break;
			default:
				break;
		}
	}

	private void MagicDetect()
	{
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -1.35f;

        Vector3 objectPos = cameraMain2D.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        RaycastHit2D objHit = Physics2D.Raycast(transform.position, transform.right, 20, 1 << LayerMask.NameToLayer("Interactive"));

		if (Input.GetKey(KeyCode.E) && Input.mouseScrollDelta.y!=0 && objHit.collider != null)
        {
			currentPlayer.gameObject.SendMessage("Magic");
			String activeObj = objHit.collider.name;
			float  mouseScr = Input.mouseScrollDelta.y;
			
			Debug.Log(activeObj);
			Debug.DrawRay(transform.position, transform.right * 20, Color.red);
            GameObject.Find(activeObj).SendMessage("ControlTime", mouseScr);

		}

		if (Input.GetKey(KeyCode.E) && Input.GetMouseButton(1) && objHit.collider != null)
		{
			currentPlayer.gameObject.SendMessage("Magic2");
			String activeObj = objHit.collider.name;

			Debug.DrawRay(transform.position, transform.right * 20, Color.red);
			GameObject.Find(activeObj).SendMessage("PauseTime");
		}

	}
}


