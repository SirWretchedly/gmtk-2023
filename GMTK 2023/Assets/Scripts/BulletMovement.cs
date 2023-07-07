using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
	public static float velX;
	public static float velY;
	
	private static Rigidbody2D rb;
    public float deletionTime;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
        Invoke("DeleteObject", deletionTime);
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();

	}

	void Movement() {
		rb.velocity = new Vector2 (velX, velY);

	}

    private void DeleteObject()
    {
        Destroy(gameObject);
    }
}