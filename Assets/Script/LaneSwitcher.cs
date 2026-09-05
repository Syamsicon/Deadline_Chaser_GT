using UnityEngine;
using UnityEngine.UI;

public class LaneSwitcher : MonoBehaviour
{
    public static Lane CurrentActiveLane = Lane.Center; // set default

    [SerializeField] private Image HighlightLeft;
    [SerializeField] private Image HighlightRight;
    [SerializeField] private Image HighlightCenter;

    [SerializeField] private float activeAlpha = 0.20f;
    [SerializeField] private float inactiveAlpha = 0.45f;

    void Start()
    {
        UpdateHighlights(); // set tampilan awal sesuai default lane (Center)
    }

    void Update()
    {
        bool ctrlHeld = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        if (ctrlHeld)
        {
            if (Input.GetKeyDown(KeyCode.L)) CurrentActiveLane = Lane.Left;
            else if (Input.GetKeyDown(KeyCode.E)) CurrentActiveLane = Lane.Center;
            else if (Input.GetKeyDown(KeyCode.R)) CurrentActiveLane = Lane.Right;
        }

        UpdateHighlights();
    }

    void UpdateHighlights()
    {
        SetAlpha(HighlightLeft, CurrentActiveLane == Lane.Left ? activeAlpha : inactiveAlpha);
        SetAlpha(HighlightCenter, CurrentActiveLane == Lane.Center ? activeAlpha : inactiveAlpha);
        SetAlpha(HighlightRight, CurrentActiveLane == Lane.Right ? activeAlpha : inactiveAlpha);
    }

    void SetAlpha(Image img, float alpha)
    {
        if (img == null) return;
        Color c = img.color;
        c.a = alpha;
        img.color = c;
    }
}
