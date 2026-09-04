using UnityEngine;

public class LaneSwitcher : MonoBehaviour
{
    public static Lane CurrentActiveLane = Lane.Center; // set default

    void Update()
    {
        bool ctrlHeld = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        if (!ctrlHeld) return;

        if (Input.GetKeyDown(KeyCode.L)) CurrentActiveLane = Lane.Left;
        else if (Input.GetKeyDown(KeyCode.E)) CurrentActiveLane = Lane.Center;
        else if (Input.GetKeyDown(KeyCode.R)) CurrentActiveLane = Lane.Right;
    }
}
