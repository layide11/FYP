using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	public float __Speed = 15f;
	public float __MapWidth = 4.2f;
	public Text __ScoreText;
	public Text __HighScoreText;

	private Rigidbody2D __RigidBody;

	void Start()
	{
		__RigidBody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * __Speed;

		Vector2 newPosition = __RigidBody.position + Vector2.right * x;

		newPosition.x = Mathf.Clamp(newPosition.x, -__MapWidth, __MapWidth);

		__RigidBody.MovePosition(newPosition);

	}

	void OnCollisionEnter2D()
	{
		FindObjectOfType<GameManager>().EndGame();
	}
}
