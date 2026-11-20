using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingHazard : MonoBehaviour
{
    [SerializeField] private float spinSpeed;
    [SerializeField] private float dropDistance;
    [SerializeField] private float phaseOffset;

    private Rigidbody body;
    private Vector3 raisedPosition;
    private float startedAt;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        raisedPosition = body.position;
        startedAt = Time.fixedTime;
    }

    void FixedUpdate()
    {
        if (dropDistance == 0f)
        {
            body.MoveRotation(body.rotation * Quaternion.Euler(0f, spinSpeed * Time.fixedDeltaTime, 0f));
            return;
        }

        float phase = Mathf.Repeat(Time.fixedTime - startedAt + phaseOffset, 3.2f);
        float drop = Mathf.Clamp01((phase - 1.2f) / 0.5f);
        float rise = Mathf.Clamp01((phase - 2.2f) / 0.65f);
        body.MovePosition(raisedPosition - Vector3.up * (drop * drop * (1f - rise) * dropDistance));
    }
}
