using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 delta = new Vector3(3, 0, 0);
    public float transitionTime = .5f;
    public float jumpForce = 5f; // Siła skoku
    private bool isGrounded = true; // Czy gracz jest na ziemi?

    int position = 1;

    public void Update()
    {
        if (position > 0)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                position--;
                StartCoroutine(moveLeft());
            }
        }
        if (position < 2)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                position++;
                StartCoroutine(moveRight());
            }
        }

        // Obsługa skoku
        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            StartCoroutine(Jump());
        }
    }

    private IEnumerator moveLeft()
    {
        transform.position = Vector3.Slerp(transform.position, transform.position + delta, transitionTime);
        yield return null;
    }

    private IEnumerator moveRight()
    {
        transform.position = Vector3.Slerp(transform.position, transform.position - delta, transitionTime);
        yield return null;
    }

    private IEnumerator Jump()
    {
        // Zastosuj siłę skoku
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Odczekaj krótki czas, aby zapobiec wielokrotnemu skakaniu
        yield return new WaitForSeconds(0.1f);
    }

    // Sprawdzenie, czy gracz dotyka ziemi
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isGrounded = false;
        }
    }
}
