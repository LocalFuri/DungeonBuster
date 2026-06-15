using UnityEngine;
using UnityEngine.InputSystem;

public class MovementKeys : MonoBehaviour
{
  public float cellSize = 6f;

  void Update()
  {
    Keyboard keyboard = Keyboard.current;

    if (keyboard == null)
      return;

    if (keyboard.upArrowKey.wasPressedThisFrame)
      transform.position += transform.forward * cellSize;

    if (keyboard.downArrowKey.wasPressedThisFrame)
      transform.position -= transform.forward * cellSize;

    if (keyboard.deleteKey.wasPressedThisFrame)
      transform.Rotate(0f, -90f, 0f);

    if (keyboard.pageDownKey.wasPressedThisFrame)
      transform.Rotate(0f, 90f, 0f);
  }
}