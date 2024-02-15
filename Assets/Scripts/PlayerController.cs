using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Component")]
	[SerializeField] Rigidbody2D rigid;
	[SerializeField] SpriteRenderer render;
	[SerializeField] Animator animator;

	[Header("Property")]
	[SerializeField] float movePower;
	[SerializeField] float brakePower;
	// [SerializeField] float maxSpeed;
	[SerializeField] float maxXSpeed;
	[SerializeField] float maxYSpeed;

	[SerializeField] float jumpSpeed;

	[SerializeField] LayerMask groundCheckLayer;

	private Vector2 moveDir; // �Է� ���� �ޱ�
	private bool isGround;

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		if (moveDir.x < 0 && rigid.velocity.x > -maxXSpeed)
		{
			rigid.AddForce(Vector2.right * moveDir.x * movePower);
		}
		else if(moveDir.x > 0 && rigid.velocity.x < maxXSpeed)
		{
			rigid.AddForce(Vector2.right * moveDir.x * movePower);
		}
		else if(moveDir.x == 0 && rigid.velocity.x > 0.1f)
		{
			rigid.AddForce(Vector2.left * brakePower);
		}
		else if(moveDir.x == 0 && rigid.velocity.x < -0.1f)
		{
			rigid.AddForce(Vector2.right * brakePower);
		}

		if(moveDir.y < -maxYSpeed) // �������� �ӵ� �������ֱ�
		{
			// rigid.velocity.y = -maxSpeed; // �ٷ� ���� �Ұ���!
			Vector3 velocity = rigid.velocity;
			velocity.y = -maxYSpeed;
			rigid.velocity = velocity;
		}

		animator.SetFloat("YSpeed", rigid.velocity.y);
	}
	private void Jump()
	{
		// rigid.velocity.y = jumpSpeed; // �ٷ� ���� �Ұ���
		Vector2 velocity = rigid.velocity;
		velocity.y = jumpSpeed;
		rigid.velocity = velocity;
	}

	private void OnMove(InputValue value)
	{
		moveDir = value.Get<Vector2>(); // �Է� ���� �״��, �¿� x, �յ� y
		// Debug.Log(moveDir);

		if(moveDir.x < 0)
		{
			render.flipX = true;
			animator.SetBool("Run", true);
		}
		else if(moveDir.x > 0)
		{
			render.flipX = false;
			animator.SetBool("Run", true);
		}
		else
		{
			animator.SetBool("Run", false);
		}


	}
	private void OnJump(InputValue value)
	{
		if (value.isPressed && isGround)
		{
			Jump();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		isGround = true;
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		isGround = false;
	}


	public LayerMask layerMask;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		// Debug.Log(LayerMask.NameToLayer("Ground")); // ��� : 6
		// Debug.Log(LayerMask.LayerToName(6)); // ��� : Ground
		// Debug.Log(LayerMask.GetMask("Ground")); // ��� : 64
		// if(collision.gameObject.layer == 6)
		// if(collision.gameObject.layer == LayerMask.GetMask("Ground"))

		// if(collision.gameObject.layer == LayerMask.NameToLayer("Ground")) // Layer Mask ������ ��
		// if(((1 << collision.gameObject.layer) & LayerMask.GetMask("Ground", "Default")) != 0)
		/*if (collision.gameObject.layer == LayerMask.NameToLayer("Ground") ||
			collision.gameObject.layer == LayerMask.NameToLayer("Obsticle"))
		{
			Debug.Log("�� ��Ҵ�!");
		}*/

		// ���̾�(0�� ~ 6�� ���̾�) == ���̾��ũ(���� ������ 0�� 1�� ǥ��)
		// if(collision.gameObject.layer == groundCheckLayer)
		// if(((1 << collision.gameObject.layer) & groundCheckLayer) != 0)

		if(groundCheckLayer.Contain(collision.gameObject.layer))
		{
			Debug.Log("�� ��Ҵ�!");
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		// if (collision.gameObject.layer == 6)
		// if (collision.gameObject.layer == LayerMask.GetMask("Ground"))
		if (groundCheckLayer.Contain(collision.gameObject.layer))
		{
			Debug.Log("������ ��������!");
		}
	}
}
