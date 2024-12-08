using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float turnSpeed = 360f;
    private Vector3 playerInput;

    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 1f;
    [SerializeField] private float dashCooldown = 1f;
    [SerializeField] private float maxVelocity = 10f;
    public int MaxDashes = 1;
    private int Dashes;
    bool isDashing;
    bool canDash;
    bool isMoveing;

    public ParticleSystem DustTrail;

    private void Start()
    {
        canDash = true;
        Dashes = MaxDashes;
    }

    private void Update()
    {
        MaxDashes = GetComponent<PlayerStats>().dashes;
        Look();

        if (isDashing) return;
        GatherInput();


        if (Input.GetKeyDown(KeyCode.Space) && canDash && isMoveing)
        {
            StartCoroutine(Dash());
        }

    }

    private void FixedUpdate()
    {
        Move();

        // Limit speed
        if (rb.linearVelocity.magnitude > maxVelocity)
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxVelocity);
    }

    private void GatherInput()
    {
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (playerInput == Vector3.zero)
        {
            animator.SetBool("IsRunning", false);
            isMoveing = false;
            return;
        }

        var rotation = Quaternion.LookRotation(playerInput.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        isMoveing = true;
        animator.SetBool("IsRunning", true);
        CreateDustTrail();
    }

    private void Move()
    {
        if (isDashing) return;
        rb.MovePosition(transform.position + transform.forward * playerInput.normalized.magnitude * GetComponent<PlayerStats>().moveSpeed * Time.deltaTime);
    }

    private IEnumerator Dash()
    {
        Debug.Log ("Dashing");
        Dashes--;
        canDash = false;
        isDashing = true;
        animator.SetBool("IsDashing", true);
        rb.linearVelocity = new Vector3(playerInput.ToIso().x * dashSpeed, 0, playerInput.ToIso().z * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        animator.SetBool("IsDashing", false);
        rb.linearVelocity = Vector3.zero;

        if (Dashes > 0)
            canDash = true;
        else
        {
            yield return new WaitForSeconds(dashCooldown);
            Dashes = MaxDashes;
            canDash = true;
        }
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