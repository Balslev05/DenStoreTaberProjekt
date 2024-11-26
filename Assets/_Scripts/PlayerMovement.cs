using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float turnSpeed = 360f;
    private Vector3 input;

    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing;
    bool canDash;

    public ParticleSystem DustTrail;

    private void Start()
    {
        canDash = true;
    }

    private void Update()
    {
        if (isDashing) return;

        GatherInput();
        Look();

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (isDashing) return;

        Move();
    }

    private void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (input == Vector3.zero)
        {
            animator.SetBool("IsRunning", false);
            return;
        }

        var rotation = Quaternion.LookRotation(input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        //animator.SetBool("IsRunning", true);
        CreateDustTrail();
    }

    private void Move()
    {
        rb.MovePosition(transform.position + transform.forward * input.normalized.magnitude * speed * Time.deltaTime);
        animator.SetBool("IsRunning", true);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.MovePosition(transform.position + transform.forward * input.normalized.magnitude * dashSpeed * Time.deltaTime);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    void CreateDustTrail()
    {
        DustTrail.Play();
    }
}

public static class Helper
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}