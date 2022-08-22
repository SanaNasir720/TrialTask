using SPStudios.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationManager : MonoBehaviour
{
    public GameObject[] objectsToInstantiate;

    private Vector3 OffSet;

    private float ZCoordinate;

    public void CreateObject(int index) {

        GameObject createdObject = Instantiate(objectsToInstantiate[index],
               objectsToInstantiate[index].transform.position,
               objectsToInstantiate[index].transform.rotation);

        createdObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5;

    }

}
