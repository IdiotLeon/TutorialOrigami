using UnityEngine;

public class TapToPlaceParent : MonoBehaviour
{
    bool placing = false;

    // called by GazeGestureManager when the user performs a "Select" gesture
    void OnSelect()
    {
        // to toggle whether the user is in placing mode on each "Select" gesture
        placing = !placing;

        // to display the spatial mapping mesh, if the user is in placing mode
        if (placing)
        {
            SpatialMapping.Instance.drawVisualMeshes = true;
        }
        // to hide the spatial mapping mesh, if the user is not in placing mode
        else
        {
            SpatialMapping.Instance.drawVisualMeshes = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // to update the placement to match the user's gaze, if the user is in placing mode

        if (placing)
        {
            // to do a raycast into the world that will only hit the Spatial Mapping mesh
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 30.0f, SpatialMapping.PhysicsRaycastMask))
            {
                // to move the parent of this object to where the raycast hit the Spatial Mapping mesh
                this.transform.parent.position = hitInfo.point;

                // to rotate the parent of this object to face the user
                var toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.y = 0;
                this.transform.parent.rotation = toQuat;
            }
        }

    }
}
