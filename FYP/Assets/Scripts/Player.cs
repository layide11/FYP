using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	public float __Speed = 15f;
	public float __MapWidth = 4.2f;
	public Text __ScoreText;
	public Text __HighScoreText;
	private const string _ApplePrefabTag = "ApplePrefab";

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

	void OnCollisionEnter2D(Collision2D collision)
	{
		GameManager _GameManager = FindObjectOfType<GameManager>();
		GameObject _CollidedObject = collision.gameObject;
		if (_CollidedObject.tag == _ApplePrefabTag)
		{
			Destroy(_CollidedObject);
			_GameManager.AddAppleScore();
		}
        else
        {
			_GameManager.EndGame(true);
        }
	}
}
