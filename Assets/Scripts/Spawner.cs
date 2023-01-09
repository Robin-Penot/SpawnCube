using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject Object;
    [SerializeField] private float radius =5f;
    [SerializeField] private float SpawnSpeed =3f;

    private float time = 0f;


    void Update()
    {
        if(SpawnSpeed <= 0f) return;

        time += Time.deltaTime;

            GameObject newObject;
            if (time >= 1f/SpawnSpeed)
            {
                Vector3 localPosition = Random.insideUnitCircle * radius;
                Vector3 worldPosition = transform.TransformPoint(localPosition);
                newObject = Instantiate(Object, worldPosition, Quaternion.identity);
                newObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
                time = 0f;
            }
    }
}
