using UnityEngine;
using UnityEngine.UI;

public class EulerAngleController : MonoBehaviour
{
    // Sliders for Euler angles
    public Slider pitchSlider; // X-axis rotation
    public Slider yawSlider;   // Y-axis rotation
    public Slider rollSlider;  // Z-axis rotation

    // The triangle object to rotate
    public Transform triangleObject;

    void Update()
    {
        // Get Euler angle values from sliders
        float pitch = pitchSlider.value; // Rotation around X-axis
        float yaw = yawSlider.value;     // Rotation around Y-axis
        float roll = rollSlider.value;   // Rotation around Z-axis

        // Calculate rotation from Euler angles
        Quaternion rotation = CalculateRotation(pitch, yaw, roll);

        // Apply the rotation to the triangle object
        triangleObject.rotation = rotation;
    }

    // Hard-coded function to calculate rotation based on Euler angles (in degrees)
    private Quaternion CalculateRotation(float pitch, float yaw, float roll)
    {
        // Convert degrees to radians
        float pitchRad = Mathf.Deg2Rad * pitch;
        float yawRad = Mathf.Deg2Rad * yaw;
        float rollRad = Mathf.Deg2Rad * roll;

        // Compute individual axis rotations using quaternions
        Quaternion qX = new Quaternion(Mathf.Sin(pitchRad / 2), 0, 0, Mathf.Cos(pitchRad / 2));
        Quaternion qY = new Quaternion(0, Mathf.Sin(yawRad / 2), 0, Mathf.Cos(yawRad / 2));
        Quaternion qZ = new Quaternion(0, 0, Mathf.Sin(rollRad / 2), Mathf.Cos(rollRad / 2));

        // Combine rotations in ZYX order (intrinsic Tait-Bryan angles)
        return qY * qX * qZ;
    }
}
