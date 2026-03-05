using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static Toggle leftToggle;
    public static Toggle rightToggle;

    public Toggle leftToggleInstance;   // drag the UI toggle here in inspector
    public Toggle rightToggleInstance;  // drag the UI toggle here in inspector

    private void Awake()
    {
        // Assign static variables
        leftToggle = leftToggleInstance;
        rightToggle = rightToggleInstance;
    }
}
