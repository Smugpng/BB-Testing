using Unity.Splines.Examples;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PropPlacement : MonoBehaviour
{
    [SerializeField] private int SpawnAmout;
    public float planeWidth = 10, planeHeight = 10;
    private Vector3 LastPos;
    public GameObject test;
    [SerializeField] private GameObject max, min;
    private Vector3 worldMax, worldMin;
    [SerializeField] private LayerMask placementLayerMask;

    [SerializeField] private GameObject Parent;

    private void Start()
    {
        worldMin = min.transform.position;
        worldMax = max.transform.position;

        for (int i = 0; i < SpawnAmout; ++i)
        {
            Vector3 spawnPos = SpawnProp();

            //Spawning
            GameObject newObj = Instantiate(test);
            newObj.transform.position = spawnPos;
            newObj.transform.rotation = Quaternion.Euler(newObj.transform.rotation.x, Random.Range(0, 360), newObj.transform.rotation.z);
            newObj.transform.SetParent(Parent.transform);
        }
    }
    public Vector3 SpawnProp()
    {
        float x = Random.Range(worldMin.x, worldMax.x);
        float y = 8;
        float z = Random.Range(worldMin.z, worldMax.z);
        Vector3 randomPos = new Vector3(x, y, z);
        //var spawnPos = new Vector3(Random.Range(-planeWidth, planeHeight), 2, Random.Range(-planeWidth, planeHeight));
        RaycastHit hit;
        if (Physics.Raycast(randomPos, Vector3.down, out hit, 100, placementLayerMask))
        {

            LastPos = hit.point;
            return LastPos;
        }
        return LastPos;
    }
}
