using UnityEngine;
using UnityEngine.InputSystem;

public class MovementKeys : MonoBehaviour
{
  [Header("Grid Movement")]
  public float cellSize = 6f;

  [Header("Wall Detection")]
  public LayerMask wallLayer;
  public float rayHeight = 1.5f;

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
    if (Keyboard.current == null) return;

    if (Keyboard.current.upArrowKey.wasPressedThisFrame)
      TryMove(Vector3.forward);

    if (Keyboard.current.downArrowKey.wasPressedThisFrame)
      TryMove(Vector3.back);

    if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
      TryMove(Vector3.left);

    if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
      TryMove(Vector3.right);

    if (Keyboard.current.deleteKey.wasPressedThisFrame)
      transform.Rotate(0f, -90f, 0f);

    if (Keyboard.current.pageDownKey.wasPressedThisFrame)
      transform.Rotate(0f, 90f, 0f);
  }

  private void TryMove(Vector3 direction)
  {
    Vector3 targetPosition = transform.position + direction * cellSize;

    Vector3 boxCenter = targetPosition + Vector3.up * rayHeight;
    Vector3 boxHalfSize = new Vector3(0.45f, 1.0f, 0.45f);

    bool wallAtTarget = Physics.CheckBox(
        boxCenter,
        boxHalfSize,
        Quaternion.identity,
        wallLayer
    );

    if (wallAtTarget)
    {
      Debug.Log("WALL DETECTED");
      PlayWallHitSound();
      return;
    }

    transform.position = targetPosition;
  }

  private void PlayWallHitSound()
  {
    if (audioSource != null && wallHitSound != null)
      audioSource.PlayOneShot(wallHitSound);
  }
}