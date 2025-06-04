using UnityEngine;

public class molamonobehaviour : MonoBehaviour
{
    public Transform molaTransform; 
    public Transform ballTransform; 
    public Rigidbody2D ballRb; 
    public float maxPullDistance = 10f;
    public float launchForce = 500f;
    private Vector3 initialPosition;
    private Vector3 ballInitialPosition;
    private bool isPulling = false;

    void Start()
    {
        initialPosition = molaTransform.localPosition;
        ballInitialPosition = ballTransform.localPosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isPulling = true;
            // Move para baixo visualmente
            molaTransform.localPosition = Vector3.Lerp(
                molaTransform.localPosition,
                initialPosition - Vector3.up * maxPullDistance,
                Time.deltaTime * 10f
            );
  
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && isPulling)
        {
            isPulling = false;
            // Volta para posição original
            molaTransform.localPosition = initialPosition;
            // Aplica força na bola
            ballTransform.localPosition = ballInitialPosition;
            ballRb.AddForce(Vector2.up * launchForce);
            
        }
    }
}
  