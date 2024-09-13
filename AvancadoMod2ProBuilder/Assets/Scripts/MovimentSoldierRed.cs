using UnityEngine;

public class MovimentSoldierRed : MonoBehaviour
{
    [SerializeField] private CharacterController characterPlayer;
    [SerializeField] private Animator animatorPlayer;
    [SerializeField] private float speedPlayer;

    private Vector3 _movementPlayer;

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movementPlayer = (transform.right * horizontal) + (transform.forward * vertical);

        //Movimentação em 8 direções
        characterPlayer.Move(_movementPlayer.normalized * speedPlayer * Time.deltaTime); //permite equilibrar a movimentação na diagonal

        PlayerAnimations(horizontal, vertical);
    }


    private void PlayerAnimations(float x, float z)
    {
        animatorPlayer.SetFloat("inputX", x);
        animatorPlayer.SetFloat("inputZ", z);
    }

	//fonte video 1: https://youtu.be/O2SxPG3TqNc?si=RjyLwQ5FOmBQiCi3
	//fonte video 2: https://youtu.be/Z0Z3cW_4HfA?si=ysW6nl04ojmKG31U
    //fonte video 3:
}
