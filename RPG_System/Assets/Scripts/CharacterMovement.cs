using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Control parameter Movement System")]
    public Rigidbody rigidbody_char;
    public float speedMovement;
    public float speedMovement_multiply;
    public float speedRotation;
    public float jumpforce;
    [HideInInspector] public bool isRun;
    public float time_delayJump;
    [SerializeField] private float currentspeed;

    [Header("Control Animation Movement System")]
    public CharacterAnimator characterAnimator;
    [Header("Control Sensor System")]
    public CharacterSensor characterSensor;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            JumpCharacter();
        }
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftShift) && characterSensor.isGround())
        {
            isRun = true;
            MoveCharacter(Input.GetAxis("Vertical") * speedMovement_multiply);
        }
        else
        {
            isRun = false;
            MoveCharacter(Input.GetAxis("Vertical"));
        }
        RotationCharacter(Input.GetAxis("Horizontal"));

    }

    void MoveCharacter(float _speed)
    {
        float speed_temp = _speed * speedMovement * Time.deltaTime;
        if (_speed < 0)
        {
            speed_temp = speed_temp / (speedMovement_multiply * 2f);
            isRun = false;
        }
        transform.Translate(0, 0, speed_temp);
        currentspeed = speed_temp;
        if (characterSensor.isGround())
        {
            characterAnimator.MovementAnim(speed_temp, isRun);
        }

    }
    void RotationCharacter(float _speed)
    {
        float speed_temp = _speed * speedRotation * Time.deltaTime;
        transform.Rotate(0, speed_temp, 0);
    }
    void JumpCharacter()
    {
        if (characterSensor.isGround())
        {
            characterAnimator.JumpAnim();
            //StartCoroutine(JumpDelay(time_delayJump));
        }

    }
    IEnumerator JumpDelay(float _time)
    {
        yield return new WaitForSeconds(_time);
        rigidbody_char.AddForce(Vector3.up * jumpforce);
    }

}
