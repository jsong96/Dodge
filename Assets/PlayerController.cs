using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Rigidbody playerRigidbody;
  public float speed = 8f;
  // Start is called before the first frame update
  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody>();
  }
  // Update is called once per frame
  void Update()
  {
    float xInput = Input.GetAxis("Horizontal");
    float yInput = Input.GetAxis("Vertical");

    float xspeed = xInput * speed;
    float zspeed = yInput * speed;

    Vector3 newVelocity = new Vector3(xspeed, 0f, zspeed);
    playerRigidbody.velocity = newVelocity;
  }

  public void Die()
  {
    gameObject.SetActive(false);
    GameManager gameManager = FindObjectOfType<GameManager>();
    if (gameManager == null)
    {
      print("game manager is missing!");
    }
    gameManager.EndGame();
  }
}
