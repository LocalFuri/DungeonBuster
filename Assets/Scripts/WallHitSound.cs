using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WallHitSound : MonoBehaviour
{
  [Header("Wall Hit Sound")]
  public AudioClip wallHitClip;

  private AudioSource audioSource;
  private float lastPlayTime;
  public float cooldown = 0.25f;

  private void Awake()
  {
    audioSource = GetComponent<AudioSource>();
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Wall"))
    {
      PlayWallHitSound();
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Wall"))
    {
      PlayWallHitSound();
    }
  }

  private void PlayWallHitSound()
  {
    if (wallHitClip == null) return;

    if (Time.time - lastPlayTime < cooldown) return;

    audioSource.PlayOneShot(wallHitClip);
    lastPlayTime = Time.time;
  }
}