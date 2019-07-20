using UnityEngine;

public class SphereCommands : MonoBehaviour
{
    Vector3 originalPosition;

    private void Start()
    {
        // to grab the original local position of the sphere when the app starts
        originalPosition = this.transform.localPosition;
    }

    // called by GazeGestureManager when the user performs a "Select" gesture
    void OnSelect()
    {
        // to add one to enable physics, if the sphere has no "Rigidbody" component
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

    // called by SpeechManager when the user says "Reset world" command
    void OnReset()
    {
        // to remove it to disable physics, if the sphere has a Rigidbody component
        var rigidbody = this.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
            Destroy(rigidbody);
        }

        // to put the sphere back into its original local position
        this.transform.localPosition = originalPosition;
    }

    // called by SpeechManager when the user says the "Drop sphere" command
    void OnDrop()
    {
        // to do the same logic as a "Select" gesture
        OnSelect();
    }
}
