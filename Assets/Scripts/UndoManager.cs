using SPStudios.Tools;
using System.Collections.Generic;
using UnityEngine;

public class UndoableAction {
    public UndoableActionType Type { get; set; }
    public Object Target { get; set; }
    public object From { get; set; }
    public object To { get; set; }

    public UndoableAction(UndoableActionType Type, Object Target, object From, object To) {
        this.Type = Type;
        this.Target = Target;
        this.From = From;
        this.To = To;
    }

}

public enum UndoableActionType {
    Position,
    Scale,
    Delete
}

public class UndoManager : Singleton {

    private Stack<UndoableAction> availableUndos = new Stack<UndoableAction>();

    public void TrackChangeAction(UndoableActionType type, Object target, object from, object to) {

        // Add this action do undoable actions
        availableUndos.Push(new UndoableAction(type, target, from, to));
    }


    public void Undo() {
        if (availableUndos.Count == 0) return;

        // get latest entry added to available Undo
        UndoableAction undo = availableUndos.Pop();

        switch (undo.Type) {

            case UndoableActionType.Position:
                ((GameObject)undo.Target).transform.position = (Vector3)undo.From;
                break;

            case UndoableActionType.Scale:
                ((GameObject)undo.Target).transform.localScale = (Vector3)undo.From;
                break;

            case UndoableActionType.Delete:
                ((GameObject)undo.Target).SetActive((bool)undo.From);
                break;


        }
    }
}