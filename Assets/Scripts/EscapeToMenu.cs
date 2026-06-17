using UnityEngine;
using UnityEngine.InputSystem;

public class EscapeToExit : MonoBehaviour
{
  [SerializeField] private AudioSource audioSource;
  [SerializeField] private AudioClip pop04;

  private bool exiting = false;

  void Update()
  {
    if (!exiting &&
        Keyboard.current != null &&
        Keyboard.current.escapeKey.wasPressedThisFrame)
    {
      exiting = true;

      if (audioSource != null && pop04 != null)
      {
        audioSource.PlayOneShot(pop04);
        Invoke(nameof(ExitGame), pop04.length);
      }
      else
      {
        ExitGame();
      }
    }
  }

  private void ExitGame()
  {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
  }
}