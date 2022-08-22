using SPStudios.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{
    public void DeleteObject() {
        Singletons.Get<UndoManager>().TrackChangeAction(UndoableActionType.Delete, this.gameObject, true, false);

        gameObject.SetActive(false);

    }
}
