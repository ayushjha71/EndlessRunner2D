using UnityEngine;

namespace EndlessRunner.Controller
{
    public enum ObstacleState
    {
        Cloud,
        Obstacle
    }

    public class ObstacleMoverController : MonoBehaviour
    {
        [Header("Speed Settings")]
        public float baseSpeed = 5f;
        [SerializeField] private float maxSpeed = 15f;
        [SerializeField] private float speedIncreaseRate = 1f; // Reduced to make progression more gradual

        [Header("Boundary Settings")]
        [SerializeField] private float leftBoundary = -15f;
        [SerializeField] private float rightBoundary = 15f;

        [Header("State")]
        [SerializeField] private ObstacleState state = ObstacleState.Obstacle;

        private float currentSpeed;

        private void Start()
        {
            currentSpeed = baseSpeed;
        }

        private void Update()
        {
            // Update speed with a cap
            if (state == ObstacleState.Obstacle)
            {
                currentSpeed = Mathf.Min(currentSpeed + speedIncreaseRate * Time.deltaTime, maxSpeed);
            }

            // Move based on state
            switch (state)
            {
                case ObstacleState.Obstacle:
                    transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
                    // Destroy if past left boundary
                    if (transform.position.x < leftBoundary)
                    {
                        Destroy(gameObject);
                    }
                    break;

                case ObstacleState.Cloud:
                    transform.Translate(Vector3.right * baseSpeed * Time.deltaTime);
                    // Destroy if past right boundary
                    if (transform.position.x > rightBoundary)
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }

        // Public method to get current speed (useful for debugging or UI)
        public float GetCurrentSpeed()
        {
            return currentSpeed;
        }

        // Optional: Method to reset speed to base speed
        public void ResetSpeed()
        {
            currentSpeed = baseSpeed;
        }
    }
} 