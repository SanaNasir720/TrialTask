using SPStudios.Tools;
using UnityEngine;
using UnityEngine.EventSystems;

public class PinchToZoom : MonoBehaviour
    {
    Vector2 prevMousePosition;
    private GameObject mainObject;
    public float sizingFactor = 0.0001f;
    Vector3 minimumScale;
    Vector3 objInitialPosition;
    Vector3 fromScale;
    ModeSelect modeSelect;

    private void Start() {
        // Parsing the object we want to modify to mainObject
        mainObject = transform.gameObject;
        // Setting the minimum scale of the mainObject
        minimumScale = new Vector3(.01f, .01f, .01f);

        modeSelect = GetComponent<ModeSelect>();
    }

    private void OnMouseDown() {

        if (modeSelect.mode.Equals(ModeSelect.Mode.SCALE)) {
            Camera.main.GetComponent<CameraMovement>().canMove = false;

            fromScale = transform.localScale;
        }
    }

    void OnMouseDrag() {
        Vector2 mousePosition = Input.mousePosition;

        if (Input.GetMouseButton(0) && modeSelect.mode.Equals(ModeSelect.Mode.SCALE)) {
            // Set this object's position to where the mouse is being held down by the left click.
            transform.localPosition = objInitialPosition;

            // Change the scale of mainObject by comparing previous frame mousePosition with this frame's position, modified by sizingFactor.
            Vector3 scale = mainObject.transform.localScale;
            scale.x = scale.x + (mousePosition.x - prevMousePosition.x) * sizingFactor;
            scale.y = scale.x;
            scale.z = scale.x;
            mainObject.transform.localScale = scale;

            // Checking if current scale is less than minimumScale, if yes, mainObject scales takes value from minimumScale
            if (scale.x < minimumScale.x) {
                mainObject.transform.localScale = minimumScale;
            }
        }

        prevMousePosition = mousePosition;
    }
    private void OnMouseUp() {
        if (modeSelect.mode.Equals(ModeSelect.Mode.SCALE)) {
            Camera.main.GetComponent<CameraMovement>().canMove = true;

            Singletons.Get<UndoManager>().TrackChangeAction(UndoableActionType.Scale, this.gameObject, fromScale, transform.localScale);

        }
    }

    public void SetInitialPosition() {
        objInitialPosition = transform.localPosition;
    }


}
