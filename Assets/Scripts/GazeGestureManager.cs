using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public static GazeGestureManager Instance { get; set; }

    // to represent the hologram that is currently being gazed at
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    // to initialize
    void Awake()
    {
        Instance = this;

        // to set up a GestureRecognizer to detect "Select" gestures
        recognizer = new GestureRecognizer();
        recognizer.Tapped += (args) =>
        {
            // to send an "OnSelect" message to the focused objet and its ancestor
            if (FocusedObject != null)
            {
                FocusedObject.SendMessageUpwards("OnSelect", SendMessageOptions.DontRequireReceiver);
            }
        };
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        // to figure out which hologram is focused this frame
        GameObject oldFocusedObject = FocusedObject;

        // to do a raycast into the world based on the user's head position and orientation
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // to use that as the focused object, if the raycast hit a hologram
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            FocusedObject = null;
        }

        // to start detecting fresh gestures again, if the focused object changed this frame
        if (FocusedObject != oldFocusedObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}
