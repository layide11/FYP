using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	private const string _ApplePrefabTag = "ApplePrefab";

	public Text __HighScoreText;
	public float __MapWidth = 4.2f;
	private Rigidbody2D __RigidBody;
	public Text __ScoreText;
	public float __Speed = 15f;

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
			_GameManager.UpdateHighScores();
        }
	}

	void Start()
	{
		__RigidBody = GetComponent<Rigidbody2D>();
	}
}
