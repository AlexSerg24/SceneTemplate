using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private ScriptableObject[] scriptableObjects;
    [SerializeField] private NavMeshSurface surface;
    private void Start()
    {
        int currentindex = -1;
        for (int i = 0; i < scriptableObjects.Length; i++)        
        {
            if (scriptableObjects[i].name == PlayerPrefs.GetString("currentPlayer", "fail..."))
            {
                currentindex = i;
            }
        }
        if (currentindex != -1)
        {
            AddPlayerModel((Player)scriptableObjects[currentindex]);
        }

        surface.BuildNavMesh();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            CheckRaycast(ray);
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;
            Ray ray = camera.ScreenPointToRay(touchPosition);
            CheckRaycast(ray);
        }
    }
    private void CheckRaycast(Ray _ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }
    private void AddPlayerModel(Player _player)
    {
        if (gameObject.transform.childCount > 0)
            Destroy(gameObject.transform.GetChild(0).gameObject);

        Instantiate(_player.playerModel, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.6f, gameObject.transform.position.z), gameObject.transform.rotation, gameObject.transform);
    }
}
