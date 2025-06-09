using UnityEngine;

public class molamonobehaviour : MonoBehaviour
{
    public Transform molaTransform;
    public Rigidbody2D ballRb;
    public float maxPullDistance = 10f;
    public float launchForce = 500f;

    private Vector3 molaInitialPosition;
    private Vector2 ballInitialPosition;
    private bool isPulling = false;

    void Start()
    {
        molaInitialPosition = molaTransform.localPosition;
        ballInitialPosition = ballRb.position; // posi��o via Rigidbody2D
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isPulling = true;
            // Move visualmente a mola (sem f�sica)
            molaTransform.localPosition = Vector3.Lerp(
                molaTransform.localPosition,
                molaInitialPosition - Vector3.up * maxPullDistance,
                Time.deltaTime * 10f
            );
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && isPulling)
        {
            isPulling = false;
            // Volta mola para posi��o original
            molaTransform.localPosition = molaInitialPosition;

            // Zera a f�sica da bola antes de reposicionar
            ballRb.velocity = Vector2.zero;
            ballRb.angularVelocity = 0f;

            // Reposiciona a bola via f�sica
            ballRb.position = ballInitialPosition;

            // Aplica for�a
            ballRb.AddForce(Vector2.up * launchForce);
        }
    }
}
