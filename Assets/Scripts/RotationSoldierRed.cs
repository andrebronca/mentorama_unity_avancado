using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RotationSoldierRed : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook cinemachineFreeLook;
    private float _rotationX;
    private float _sensivity = 150f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        PlayerRotation();    
    }

    private void PlayerRotation() 
    {
        if (Input.GetMouseButton(1))
        {
            cinemachineFreeLook.m_XAxis.m_InputAxisName = "Mouse X";
		}
		if (Input.GetMouseButtonUp(1))
		{
			cinemachineFreeLook.m_XAxis.m_InputAxisName = "";
		}

		float mouseX = Input.GetAxis("Mouse X");
        _rotationX += mouseX * _sensivity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, _rotationX, 0);
    }
}
