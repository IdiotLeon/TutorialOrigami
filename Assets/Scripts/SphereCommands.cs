using UnityEngine;

public class SphereCommands : MonoBehaviour
{
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
}
