using DG.Tweening;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private int health = 3; // Initial health of the tree
    private float m_duration = 1f;
    private float m_amp = 0.2f;
    private bool isCutting = false; // Indicates if the tree is currently being cut

    public float cuttableRange = 3f; // The range within which the tree can be cut

    private Transform player; // Reference to the player's transform

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Tag your player GameObject as "Player"
    }

    protected virtual void Update()
    {
        // Check if the player is within the cuttable range
        if (!isCutting && Vector3.Distance(transform.position, player.position) <= cuttableRange)
        {
            StartCutting(); // Start cutting when the player is in range
        }

        if (isCutting)
        {
            // Implement the logic to progressively disable tree meshes
            // For example, disable a child GameObject representing a branch.
            // You can decrease health based on player interactions.
            // When health reaches zero, stop cutting and trigger animation.
            if (health <= 0)
            {
                StopCutting();
            }
        }
    }

    // Method to start cutting the tree
    public void StartCutting()
    {
        isCutting = true;
        GenerateAnimation(); // Start the cutting animation
    }

    // Method to stop cutting the tree
    public void StopCutting()
    {
        isCutting = false;
        // Implement logic to disable tree meshes here
        // For example, set active state to false for tree branches.
    }

    protected virtual Sequence GenerateAnimation()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOScaleX(1f - m_amp, m_duration));
        sequence.Join(transform.DOScaleY(1f + m_amp, m_duration).SetDelay(m_duration / 5));
        sequence.OnComplete(() =>
        {
            StopCutting(); // Stop cutting when the animation is complete
        });

        return sequence;
    }
}
