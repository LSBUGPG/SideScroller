using UnityEngine;

[ExecuteInEditMode]
public class Cam : MonoBehaviour
{
    Camera cam;
    Matrix4x4 originalProjection;
    public Transform target;
    public float shear = 0.5f;

    private void Start()
    {
        cam = GetComponent<Camera>();
        originalProjection = cam.projectionMatrix;
    }

    void Update()
    {
        Matrix4x4 shearMatrix = Matrix4x4.identity;
        shearMatrix.m12 = shear;
        cam.projectionMatrix = originalProjection * shearMatrix;

        Vector3 position = transform.position;
        position.x = target.position.x;
        transform.position = position;
    }
}
