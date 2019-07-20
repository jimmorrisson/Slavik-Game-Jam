using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawnerScript : MonoBehaviour
{
    [SerializeField]
    public int minRange;
    [SerializeField]
    public int maxRange;
    [SerializeField]
    public GameObject trashPrefab;
    [SerializeField]
    public Vector2 maxPosition;
    [SerializeField]
    public Vector2 minPosition;

    public void SpawnTrash(Vector3 trashPosition)
    {
        var posX = Random.Range(minRange, maxRange);
        var posZ = Random.Range(minRange, maxRange);
        Vector3 spawnPosition = trashPosition + new Vector3(posX, 0, posZ);
        while(!IsValidPosition(spawnPosition))
        {
            posX = Random.Range(minRange, maxRange);
            posZ = Random.Range(minRange, maxRange);
            var plusOrMinus = Random.Range(0, 1);
            spawnPosition = (plusOrMinus > 0.5f) ? trashPosition + new Vector3(posX, 0, posZ) : trashPosition - new Vector3(posX, 0, posZ);
        }           
        Instantiate(trashPrefab, spawnPosition, Quaternion.identity);
    }

    private bool IsValidPosition(Vector3 position)
    {
        if (position == null)
            return false;

        if (position.x > maxPosition.x ||
            position.x < minPosition.x ||
            position.z > maxPosition.y ||
            position.z < minPosition.y)
            return false;

        //RaycastHit hit;
        //var ray = Camera.main.ScreenPointToRay(position);

        //if (Physics.Raycast(ray, out hit))
        //{
        //    if (hit.transform.tag == "Tree")
        //        return false;
        //}
        return true;
    }
}
