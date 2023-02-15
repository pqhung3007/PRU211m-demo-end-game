using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameOver gameOverScreen;
    bool isGameOver = false;
	Rigidbody2D rb;
	SpriteRenderer sr;

	[SerializeField] float moveForce = 100f;
	[SerializeField] ParticleSystem bloodPS;
	[SerializeField] Image filledHeart;	
	
	float life = 5;

	void Start ()
	{
		rb = GetComponent <Rigidbody2D> ();
		sr = GetComponent <SpriteRenderer> ();
	}

	void Update ()
	{
		if (!isGameOver) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				rb.AddRelativeForce (Vector2.right * moveForce, ForceMode2D.Impulse);
				sr.flipX = false;
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				rb.AddRelativeForce (Vector2.left * moveForce, ForceMode2D.Impulse);
				sr.flipX = true;
			}
		} else
		{
            gameOverScreen.Setup();
        }
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (!isGameOver) {
			if (other.collider.tag.Equals ("ground")) {
				rb.velocity = Vector2.zero;
			}
			if (other.collider.tag.Equals ("saw")) {
				Vector2 contact = other.contacts [0].point;
				bloodPS.transform.position = contact;
				bloodPS.Play ();

				TakeDamage();
			}
		}
	}

	void TakeDamage()
	{
		if (life >0)
		{
			life -= 1;
            filledHeart.fillAmount = life / 5;
        }
		if (life <= 0)
		{
			isGameOver = true;
		}
	}

}
