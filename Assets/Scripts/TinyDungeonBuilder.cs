using UnityEngine;

public class TinyDungeonBuilder : MonoBehaviour
{
  public float cellSize = 3f;
  public float wallHeight = 3f;
  public float wallThickness = 0.2f;

  public GameObject player;

  

  private readonly string[] map =
{
    "########",
    "#P     #",
    "#      #",
    "#  ##  #",
    "#      #",
    "########"
};
  private void Start()
  {
    BuildDungeon();
  }

  private void BuildDungeon()
  {
    for (int z = 0; z < map.Length; z++)
    {
      for (int x = 0; x < map[z].Length; x++)
      {
        char tile = map[z][x];

        Vector3 position = new Vector3(
            x * cellSize,
            wallHeight / 2f,
            -z * cellSize
        );

        if (tile == '#')
        {
          GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
         
          wall.name = "Wall";

          Renderer renderer = wall.GetComponent<Renderer>();
          renderer.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
          renderer.material.color = Color.gray;



          wall.name = "Wall";
          wall.transform.position = position;
          //wall.transform.localScale = new Vector3(cellSize, wallHeight, wallThickness);
          wall.transform.localScale = new Vector3(cellSize, wallHeight, cellSize);
          wall.layer = LayerMask.NameToLayer("Wall");
          wall.transform.SetParent(transform);
        }

        if (tile == 'P' && player != null)
        {
          player.transform.position = new Vector3(
              x * cellSize,
              0f,
              -z * cellSize
          );
        }
      }
    }
  }
}