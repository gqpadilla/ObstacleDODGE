using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private float interval = 2.5f;
    [SerializeField] private float initialDelay;

    private float nextShot;

    void Start()
    {
        nextShot = Time.fixedTime + initialDelay;
    }

    void FixedUpdate()
    {
        if (Time.fixedTime < nextShot)
            return;

        nextShot += interval;
        Rigidbody shot = Instantiate(projectile, transform.position, transform.rotation);
        shot.linearVelocity = transform.forward * 9f;
        Destroy(shot.gameObject, 3f);
    }
}
