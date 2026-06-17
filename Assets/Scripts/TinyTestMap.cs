using UnityEngine;

public class TinyTestMap : MonoBehaviour
{
  public GameObject floorPrefab;
  public GameObject wallPrefab;
  public Transform player;

  public float cellSize = 2f;

  private string[] map =
  {
        "#######",
        "#.....#",
        "#.###.#",
        "#.#.#.#",
        "#.#.#.#",
        "#...#.#",
        "#######"
    };

  void Start()
  {
    BuildMap();
    PlacePlayer();
  }

  void BuildMap()
  {
    for (int z = 0; z < map.Length; z++)
    {
      for (int x = 0; x < map[z].Length; x++)
      {
        Vector3 pos = new Vector3(x * cellSize, 0, -z * cellSize);

        Instantiate(floorPrefab, pos, Quaternion.identity, transform);

        if (map[z][x] == '#')
        {
          Instantiate(wallPrefab, pos, Quaternion.identity, transform);
        }
      }
    }
  }

  void PlacePlayer()
  {
    if (player == null) return;

    int playerX = 1;
    int playerZ = 1;

    player.position = new Vector3(playerX * cellSize, 0, -playerZ * cellSize);
    player.rotation = Quaternion.Euler(0, 90, 0); // look east
  }
}