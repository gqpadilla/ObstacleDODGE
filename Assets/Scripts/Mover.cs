using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private GameObject finishPanel;

    private Rigidbody body;
    private Vector3 direction;
    public bool Finished { get; private set; }

    void Start()
    {
        body = GetComponent<Rigidbody>();
        direction = Vector3.zero;
        Finished = false;
        finishPanel.SetActive(false);
        PrintInstructions();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(gameObject.scene.buildIndex);
            return;
        }

        MovePlayer();
    }

    void FixedUpdate()
    {
        body.linearVelocity = Finished ? Vector3.zero : direction * moveSpeed;
    }

    private void PrintInstructions()
    {
        Debug.Log("Welcome to Obstacle Dodge!\nMove using WASD or the arrow keys.\nTry not to bump into obstacles.");
    }

    private void MovePlayer()
    {
        direction = Vector3.ClampMagnitude(new Vector3(
            Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")), 1f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Finish"))
            return;

        Finished = true;
        finishPanel.SetActive(true);
    }
}
