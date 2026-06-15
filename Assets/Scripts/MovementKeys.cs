using UnityEngine;
using UnityEngine.InputSystem;

public class MovementKeys : MonoBehaviour
{
  [Header("Grid Movement")]
  public float cellSize = 6f;

  [Header("Wall Detection")]
  public LayerMask wallLayer;
  public float rayHeight = 0.5f;
  public float rayDistanceMultiplier = 0.6f;

  [Header("Wall Hit Sound")]
  public AudioSource audioSource;
  public AudioClip wallHitSound;

  private void Awake()
  {
    if (audioSource == null)
      audioSource = GetComponent<AudioSource>();
  }

  private void Update()
  {
    Keyboard keyboard = Keyboard.current;
    if (keyboard == null)
      return;

    Vector3 moveDirection = Vector3.zero;

    if (keyboard.upArrowKey.wasPressedThisFrame)
      moveDirection = Vector3.forward;

    if (keyboard.downArrowKey.wasPressedThisFrame)
      moveDirection = Vector3.back;

    if (keyboard.leftArrowKey.wasPressedThisFrame)
      moveDirection = Vector3.left;

    if (keyboard.rightArrowKey.wasPressedThisFrame)
      moveDirection = Vector3.right;

    if (moveDirection != Vector3.zero)
      TryMove(moveDirection);
  }

  private void TryMove(Vector3 direction)
  {
    Vector3 rayStart = transform.position + Vector3.up * rayHeight;
    float checkDistance = cellSize * rayDistanceMultiplier;

    bool wallAhead = Physics.Raycast(
        rayStart,
        direction,
        checkDistance,
        wallLayer
    );

    if (wallAhead)
    {
      PlayWallHitSound();
      return;
    }

    transform.position += direction * cellSize;
  }

  private void PlayWallHitSound()
  {
    if (audioSource != null && wallHitSound != null)
      audioSource.PlayOneShot(wallHitSound);
  }
}