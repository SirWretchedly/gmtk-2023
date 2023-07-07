using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;


    public GameObject playerBulletPrefab;
	public Transform playerTransform;
	public float fireRate;
	public float rightOrUp;
	public float leftOrDown;
	public float diagonalFire;

    public Transform playerBulletTransform;
	float pbx;
	float pby;
	float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        playerTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
        fireUpRight();
		fireUpLeft();
		fireDownRight();
		fireDownLeft();
    }

    void CreatePlayerBullet()
	{
		Instantiate(playerBulletPrefab, playerTransform.position, Quaternion.identity);
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void fireDownLeft()
	{
		if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextFire && Input.GetKey(KeyCode.LeftArrow))
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = leftOrDown * diagonalFire;
			pby = leftOrDown * diagonalFire;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
		else if (Input.GetKey(KeyCode.DownArrow) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = 0;
			pby = leftOrDown;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
		else if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = leftOrDown;
			pby = 0;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
	}



	void fireUpLeft()
	{
		if (Input.GetKey(KeyCode.LeftArrow) && Time.time > nextFire && Input.GetKey(KeyCode.UpArrow))
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = leftOrDown * diagonalFire;
			pby = rightOrUp * diagonalFire;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
	
		else if (Input.GetKey(KeyCode.UpArrow) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = 0;
			pby = rightOrUp;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
	}

	void fireDownRight()
	{
		if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire && Input.GetKey(KeyCode.DownArrow))
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = rightOrUp * diagonalFire;
			pby = leftOrDown * diagonalFire;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
		else if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = rightOrUp;
			pby = 0;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}

	}

	void fireUpRight()
	{
		if (Input.GetKey(KeyCode.RightArrow) && Time.time > nextFire && Input.GetKey(KeyCode.UpArrow))
		{

			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = rightOrUp * diagonalFire;
			pby = rightOrUp * diagonalFire;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}

	}
}
