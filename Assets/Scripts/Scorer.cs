using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Mover))]
public class Scorer : MonoBehaviour
{
    [SerializeField] private Text bumpLabel;

    private Mover mover;
    private int hits;

    void Start()
    {
        mover = GetComponent<Mover>();
        hits = 0;
        bumpLabel.text = "Bumps  0";
    }

    void OnCollisionEnter(Collision collision)
    {
        if (mover.Finished || !collision.collider.CompareTag("Obstacle"))
            return;

        hits++;
        bumpLabel.text = $"Bumps  {hits}";
        Debug.Log($"You bumped into an obstacle. Total bumps: {hits}", this);
    }
}
