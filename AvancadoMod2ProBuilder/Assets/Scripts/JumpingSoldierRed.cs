using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class JumpingSoldierRed : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator jumpAnimator;

    //detectar a layer do chão
    [SerializeField] private LayerMask layerGround;
    //detectar o chão
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float radiusChecker;   //tamanho do checador da distância com o chão

    [SerializeField] private float maxHeight;   //altura do pulo
    [SerializeField] private float timeToMaxHeight; //tempo para chegar na altura máxima do pulo

    private Vector3 _yJumpForce;    //direção do pulo e força
    //velocidade do pulo
    private float _jumpSpeed;
    //gravidade do player
    private float _gravity;


    void Start()
    {
        SetGravity();
    }

    void Update()
    {
        JumpForce();
        GravityForce();
    }

    private void SetGravity()
    {
        //equação, física cinemática, da gravidade: g = (2Hmax) / t*t
        _gravity = (2 * maxHeight) / Mathf.Pow(timeToMaxHeight, 2);
        //equação de velocidade: v = v0 + gt
        _jumpSpeed = _gravity * timeToMaxHeight;
    }

    private void GravityForce()
    {
        _yJumpForce += _gravity * Time.deltaTime * Vector3.down;
        characterController.Move(_yJumpForce);
        if (IsGrounded())
        {
            _yJumpForce = Vector3.zero;
        }
    }

    private void JumpForce()
    {
        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yJumpForce = _jumpSpeed * Vector3.up;
                characterController.Move(_yJumpForce);
                jumpAnimator.SetBool("jump", true);
            }
        }
        else
        {
                jumpAnimator.SetBool("jump", false);
        }
    }

    private bool IsGrounded() 
    { 
        //retorna se a sphere está em contato com a layer 
        return Physics.CheckSphere(groundChecker.position, radiusChecker, layerGround);
    }


	private void OnDrawGizmos()
	{
		Gizmos.DrawSphere(groundChecker.position, radiusChecker);
	}
}
