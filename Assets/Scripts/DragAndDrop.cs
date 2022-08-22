using SPStudios.Tools;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {
    private Vector3 offSet;

    private float zCoordinate;

    private float x, y, z;

    public bool blockX, blockY, blockZ;

    ModeSelect modeSelect;
    
    private Vector3 fromPosition;


    private void Start() {
        modeSelect = GetComponent<ModeSelect>();

    }


    private void OnMouseDown() {

        if (modeSelect.mode.Equals(ModeSelect.Mode.MOVE)) {

            Camera.main.GetComponent<CameraMovement>().canMove = false;

            zCoordinate = Camera.main.WorldToScreenPoint(transform.position).z;

            offSet = transform.position - GetMouseWorldPoint();

            fromPosition = transform.position;
        }
    }

    public Vector3 GetMouseWorldPoint() {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoordinate;

        x = y = z = 0;

        if (!blockX) {
            x = mousePoint.x;

        }

        if (!blockY) {
            y = mousePoint.y;

        }

        if (!blockZ) {
            z = mousePoint.z;

        }


        return Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));
    }

    private void OnMouseUp() {

        if (modeSelect.mode.Equals(ModeSelect.Mode.MOVE)) {
            Camera.main.GetComponent<CameraMovement>().canMove = true;

            Singletons.Get<UndoManager>().TrackChangeAction(UndoableActionType.Position, this.gameObject, fromPosition, transform.position);
        }
    }

    private void OnMouseDrag() {

        if (modeSelect.mode.Equals(ModeSelect.Mode.MOVE))
            transform.position = GetMouseWorldPoint() + offSet;
    }
}

