using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Object;
    [SerializeField] private float radius =5f;
    [SerializeField] private float SpawnSpeed =3f;
    private float time = 0f;
    [SerializeField] private float circleSpeed = 1f;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    public int maxObjects = 10;
    private int currentObjects = 0;
    private int n = 5;

    GameObject newObject;

void Start()
{
    InvokeRepeating("Activate", 2f, 3f);
}

private void Spawn5()
    {
        Vector3 localPosition = Random.insideUnitCircle * radius;
        Vector3 worldPosition = transform.TransformPoint(localPosition);
        newObject = Instantiate(Object, worldPosition, Quaternion.identity);
        newObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        newObject.SetActive(false);
        currentObjects++;
        time = 0f;
    }

private void Activate()
    {
        newObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * circleSpeed);
        newObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        newObject = spawnedObjects[spawnedObjects.Count - 1];
        spawnedObjects.RemoveAt(spawnedObjects.Count - 1);
        newObject.SetActive(true);
    }

    void Update()
    {
        if(SpawnSpeed <= 0f) return;
        time += Time.deltaTime;
        if (time >= 1f/SpawnSpeed && currentObjects < maxObjects)
        {
            for (int i = 0; i < n; i++)
            {
                Spawn5();
                Activate();
            }
        }
    }
}
