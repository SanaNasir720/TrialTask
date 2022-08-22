using Gamelogic.Extensions;
using SPStudios.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationManager : MonoBehaviour
{
    public GameObject[] objectsToInstantiate;

    GameObject createdObject = null;

    private void Start() {
        Singletons.Get<PrefsManager>().LoadGame(this);
    }

    public void CreateObject(int index) {

        createdObject = Instantiate(objectsToInstantiate[index],
               objectsToInstantiate[index].transform.position,
               objectsToInstantiate[index].transform.rotation);
        createdObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5;
    }

    public void CreateObjectWithAttributes(Vector3 position, Quaternion rotation, Vector3 scale) {

        GameObject createdObject = Instantiate(objectsToInstantiate[0],
               position,
               rotation);

        createdObject.transform.localScale = scale;

    }

    public void RemoveAssets() {
        GameObject[] arrayToRemove = GameObject.FindGameObjectsWithTag("asset");

        foreach (GameObject obj in arrayToRemove) {

            Singletons.Get<UndoManager>().TrackChangeAction(UndoableActionType.Delete, obj, true, false);

            obj.SetActive(false);
        }
    }
    void OnApplicationQuit() {

        Singletons.Get<PrefsManager>().SaveGame();
    }


}
