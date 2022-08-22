using SPStudios.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    CreationManager creationManager;

    private void Start() {
        creationManager = GameObject.Find("CreationManager").GetComponent<CreationManager>();
    }

    public void Undo() {

        Singletons.Get<UndoManager>().Undo();
    }

    public void InstantiateObject(int objNum) {
        creationManager.CreateObject(objNum);
    }
}
