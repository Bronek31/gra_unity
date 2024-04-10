using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Vector3 delta = new Vector3(3, 0, 0);
    public float transitionTime = .5f;
    public float jumpForce = 100f; 
    public float jumpDuration = 0.05f; 
    public float duckDuration = 0.5f; 
    private bool isGrounded = true; 

    int position = 1;
    Vector3 defaultScale;

    void Start()
    {
        defaultScale = transform.localScale;
        // Zablokuj rotację wokół wszystkich osi
        GetComponent<Rigidbody>().freezeRotation = true;
    }

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

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Duck());
        }

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

    private IEnumerator Duck()
    {
        transform.localScale /= 2;
        yield return new WaitForSeconds(duckDuration);
        transform.localScale = defaultScale;
    }

    private IEnumerator Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        yield return new WaitForSeconds(jumpDuration);
        isGrounded = false;
    }

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
