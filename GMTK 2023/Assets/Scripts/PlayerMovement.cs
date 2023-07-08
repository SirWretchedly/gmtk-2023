using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

	public Animator animator;

    public GameObject playerBulletPrefab;
	public Transform playerTransform;
	public float fireRate;
	public float rightOrUp;
	public float leftOrDown;
	public float diagonalFire;

    public int reverseStangaDreaptaM = 1;
    public int reverseSusJosM = 1;
    public int reverseStangaDreaptaF = 1;
    public int reverseSusJosF = 1;

    public Transform playerBulletTransform;
	float pbx;
	float pby;
	float nextFire;

    private KeyCode downM = KeyCode.S;
    private KeyCode downF = KeyCode.DownArrow;
    private KeyCode upM = KeyCode.W;
    private KeyCode upF = KeyCode.UpArrow;
    private KeyCode leftM = KeyCode.A;
    private KeyCode leftF = KeyCode.LeftArrow;
    private KeyCode rightM = KeyCode.D;
    private KeyCode rightF = KeyCode.RightArrow;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        playerTransform = gameObject.transform;
		animator = GetComponent<Animator> ();
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
        int horizontal = 0;
        int vertical = 0;
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(leftM))
            horizontal = -1;    

        if (Input.GetKey(rightM)) 
            horizontal = 1;
        
        if (Input.GetKey(downM))
            vertical = -1;    

        if (Input.GetKey(upM)) 
            vertical = 1;

        moveX = horizontal * reverseStangaDreaptaM;
        moveY = vertical * reverseSusJosM;

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

	void Move()
	{
		rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

		if (rb.velocity.x == 0 && rb.velocity.y == 0)
		{
			animator.SetBool("moving", false);
		}
		else
            animator.SetBool("moving", true);


        if (rb.velocity.x  * reverseStangaDreaptaM > 0)
		{
			animator.Play("chicken-run-right");
		}
		else if (rb.velocity.x  * reverseStangaDreaptaM < 0)
		{
			animator.Play("chicken-run-left");
		}
		else if (rb.velocity.y  * reverseSusJosM > 0)
		{
			animator.Play("chicken-run-up");
		}
		else if (rb.velocity.y  * reverseSusJosM < 0)
		{
			animator.Play("chicken-run-down");
		}
	}

	void fireDownLeft()
	{
		if (Input.GetKey(downF) && Time.time > nextFire && Input.GetKey(leftF))
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = leftOrDown * diagonalFire * reverseStangaDreaptaF;
			pby = leftOrDown * diagonalFire * reverseSusJosF;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
		else if (Input.GetKey(downF) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = 0;
			pby = leftOrDown * reverseSusJosF;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
		else if (Input.GetKey(leftF) && Time.time > nextFire)
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
		if (Input.GetKey(leftF) && Time.time > nextFire && Input.GetKey(upF))
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = leftOrDown * diagonalFire * reverseStangaDreaptaF;
			pby = rightOrUp * diagonalFire * reverseSusJosF;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
	
		else if (Input.GetKey(upF) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = 0;
			pby = rightOrUp * reverseSusJosF;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
	}

	void fireDownRight()
	{
		if (Input.GetKey(rightF) && Time.time > nextFire && Input.GetKey(downF))
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = rightOrUp * diagonalFire * reverseStangaDreaptaF;
			pby = leftOrDown * diagonalFire * reverseSusJosF;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
		else if (Input.GetKey(rightF) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = rightOrUp  * reverseStangaDreaptaF;
			pby = 0;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}

	}

	void fireUpRight()
	{
		if (Input.GetKey(rightF) && Time.time > nextFire && Input.GetKey(upF))
		{
			nextFire = Time.time + fireRate;
			CreatePlayerBullet();
			pbx = rightOrUp * diagonalFire * reverseStangaDreaptaF;
			pby = rightOrUp * diagonalFire * reverseSusJosF;
			BulletMovement.velX = pbx;
			BulletMovement.velY = pby;
		}
	}

    public void swapControls() {
        KeyCode aux = leftM;
        leftM = leftF;
        leftF = aux;
        
        aux = rightM;
        rightM = rightF;
        rightF = aux;

        aux = upM;
        upM = upF;
        upF = aux;

        aux = downM;
        downM = downF;
        downF = aux;
    }
}
