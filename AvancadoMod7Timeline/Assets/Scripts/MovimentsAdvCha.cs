using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentsAdvCha : MonoBehaviour
{
    public float girar = 7f;

    private CharacterController character;
    private Animator animator;
    private Vector3 input;
    private float velocidade = 2f;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.Move(input * Time.deltaTime * velocidade);
        character.Move(Vector3.down * Time.deltaTime);  //aplica gravidade ao character

        if (input != Vector3.zero)
        {
            animator.SetBool("andando", true);
            transform.forward = Vector3.Slerp(transform.forward, input, Time.deltaTime * girar); //suaviza a rotação de uma direção para outra
        } 
        else
        {
            animator.SetBool("andando", false);
        }
    }
}
