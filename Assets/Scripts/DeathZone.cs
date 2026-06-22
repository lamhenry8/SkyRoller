using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public Transform player;
    public float distanceBelowPlayer = 10f;

    private void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}