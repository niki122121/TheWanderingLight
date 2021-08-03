using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player variables")]
    [SerializeField] private float speed;
    [SerializeField] private float speedBlue;
    [SerializeField] private float jumpForce;
    [SerializeField] private float minYSpeed;

    [SerializeField] private Vector2 floorDetectionOffset;
    [SerializeField] private Vector2 wallDetectionOffset;
    [SerializeField] private float detectionRadius;

    [SerializeField] private float wallJumpTime;
    [SerializeField] private float wallJumpForce;
    [SerializeField] private float wallFallingSpeed;
    private float wallJumpTimer;
    private int wallJumpDirection;

    private float dirX;
    private bool isGrounding;
    private bool isWallingRight;
    private bool isWallingLeft;

    private bool isAccelerating;

    private float coyoteTimeWallCounter = 0;
    [SerializeField] private float coyoteTimeWall = 0.2f;

    private bool canMove;

    [Space]

    [Header("Components references")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spr;

    [Space]

    [Header("Gameobjects references")]
    [SerializeField] private ParticleSystem trailParticles;

    private void Start()
    {
        isGrounding = false;
        isWallingRight = false;
        isWallingLeft = false;
        wallJumpTimer = 0;
        canMove = true;
        spr.flipX = SpawnController.isLeft;
    }

    private void Update()
    {
        #region Input
        dirX = canMove ? Input.GetAxisRaw("Horizontal") : 0;
        bool jumpButton = Input.GetButtonDown("Jump");
        #endregion

        #region Collider detection
        if (coyoteTimeWallCounter > 0)
        {
            coyoteTimeWallCounter -= Time.deltaTime;
        }
        else
        {
            coyoteTimeWallCounter = 0;
        }
        isGrounding = CheckCollisionWithTag(floorDetectionOffset.x, floorDetectionOffset.y, detectionRadius, "Wall") ||
            CheckCollisionWithTag(-floorDetectionOffset.x, floorDetectionOffset.y, detectionRadius, "Wall");
        bool previousWalling = isWallingLeft || isWallingRight;
        isWallingRight = CheckCollisionWithTag(wallDetectionOffset.x, wallDetectionOffset.y, detectionRadius, "Wall") ||
            CheckCollisionWithTag(wallDetectionOffset.x, -wallDetectionOffset.y, detectionRadius, "Wall") ||
            CheckCollisionWithTag(wallDetectionOffset.x, 0, detectionRadius, "Wall");
        isWallingLeft = CheckCollisionWithTag(-wallDetectionOffset.x, wallDetectionOffset.y, detectionRadius, "Wall") ||
            CheckCollisionWithTag(-wallDetectionOffset.x, -wallDetectionOffset.y, detectionRadius, "Wall") ||
            CheckCollisionWithTag(-wallDetectionOffset.x, 0, detectionRadius, "Wall");
        if (previousWalling && (isWallingLeft || isWallingRight) == false)
        {
            coyoteTimeWallCounter = coyoteTimeWall;
        }
        #endregion

        #region Jump
        if (jumpButton && canMove)
        {
            if (isGrounding)
                Jump();
            else if (isWallingRight || isWallingLeft || coyoteTimeWallCounter > 0)
            {
                wallJumpDirection = isWallingRight ? -1 : 1;
                rb.velocity = new Vector3(wallJumpDirection * wallJumpForce, jumpForce, 0);
                wallJumpTimer = wallJumpTime;
            }
        }

        if (wallJumpTimer > 0)
        {
            wallJumpTimer -= Time.deltaTime;
            if (wallJumpTimer < 0)
                wallJumpTimer = 0;
        }
        #endregion

        #region Animations
        anim.SetBool("isWalling", isWallingLeft || isWallingRight);
        anim.SetBool("isGrounding", isGrounding);
        anim.SetBool("canMove", canMove);
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY", rb.velocity.y);

        if (isWallingLeft && !isGrounding)
            spr.flipX = true;
        else if (isWallingRight && !isGrounding)
            spr.flipX = false;
        else
            spr.flipX = rb.velocity.x < 0 ? true : (rb.velocity.x > 0 ? false : spr.flipX);
        #endregion

    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        GetComponent<PlayerSoundControl>().PlayJumpSound();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(((isAccelerating ? speedBlue : speed) * dirX) * ((wallJumpTime - wallJumpTimer) / wallJumpTime) + (wallJumpDirection * wallJumpForce) * (wallJumpTimer / wallJumpTime),
            Mathf.Clamp(rb.velocity.y, (isWallingRight || isWallingLeft) ? wallFallingSpeed : minYSpeed, Mathf.Infinity), 0);

    }

    public void Accelerate(float timeAccelerating)
    {
        isAccelerating = true;
        var main = trailParticles.main;
        main.startColor = new Color(0.2117647f, 0.4823529f, 1, 1);
        var emission = trailParticles.emission;
        emission.rateOverDistance = 5;
        Invoke("StopAccelerating", timeAccelerating);
    }

    private void StopAccelerating()
    {
        ParticleSystem.MainModule main = trailParticles.main;
        main.startColor = new Color(1, 1, 1);
        ParticleSystem.EmissionModule emission = trailParticles.emission;
        emission.rateOverDistance = 3;
        isAccelerating = false;
    }

    private bool CheckCollisionWithTag(float offsetX, float offsetY, float radius, string tag)
    {
        
        Collider[] colsDetected = Physics.OverlapSphere(transform.position + new Vector3(offsetX, offsetY, -1), radius);
        foreach (Collider c in colsDetected)
        {
            if (c.tag.Substring(0, tag.Length) == tag)
                return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        // Floor colliders are drawn.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(floorDetectionOffset.x, floorDetectionOffset.y, -1), detectionRadius);
        Gizmos.DrawWireSphere(transform.position + new Vector3(-floorDetectionOffset.x, floorDetectionOffset.y, -1), detectionRadius);

        // Wall colliders are drawn.
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + new Vector3(wallDetectionOffset.x, wallDetectionOffset.y, -1), detectionRadius);
        Gizmos.DrawWireSphere(transform.position + new Vector3(-wallDetectionOffset.x, wallDetectionOffset.y, -1), detectionRadius);
        Gizmos.DrawWireSphere(transform.position + new Vector3(wallDetectionOffset.x, -wallDetectionOffset.y, -1), detectionRadius);
        Gizmos.DrawWireSphere(transform.position + new Vector3(-wallDetectionOffset.x, -wallDetectionOffset.y, -1), detectionRadius);
        Gizmos.DrawWireSphere(transform.position + new Vector3(wallDetectionOffset.x, 0, -1), detectionRadius);
        Gizmos.DrawWireSphere(transform.position + new Vector3(-wallDetectionOffset.x, 0, -1), detectionRadius);
    }

    public void SetCanMove(bool _canMove)
    {
        canMove = _canMove;
    }

}
