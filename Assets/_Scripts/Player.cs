using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int PlayerStartSpeed;
    [SerializeField] private Color StartColor = Color.green;

    [SerializeField] private Color BlueColor = Color.blue;
    [SerializeField] private Color RedColor = Color.red;
    [SerializeField] private Color YellowColor = Color.yellow;
    [SerializeField] private Color PurpleColor = Color.magenta;

    [SerializeField] private AudioSource AudSource;

    private bool _isMoving;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private BoxCollider2D boxCollider;

    public ColorType curPlayerColor { get; protected set; }

	void Start ()
    {
        _isMoving = true;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        curPlayerColor = ColorType.Green;
	}
	
	void Update()
    {
        if(_isMoving)
        {
            rb.velocity = new Vector2(-1,0);
        }
        else
        {
            // This is necessary to prevent a unity bug...
            // TODO: change colling object into a rb
            //transform.position = transform.position + Vector3.zero;
            rb.velocity = new Vector2(0.0001f, 0.0000f);
        }

        if (Input.GetKeyDown(KeyCode.B) ||
            Input.GetKeyDown(KeyCode.R) ||
            Input.GetKeyDown(KeyCode.Y) ||
            Input.GetKeyDown(KeyCode.P))
            AudSource.Play();


        // Input handling
        if(Input.GetKey(KeyCode.B))
        {
            sr.color = BlueColor;
            curPlayerColor = ColorType.Blue;
            _isMoving = false;
        }
        else if(Input.GetKey(KeyCode.R))
        {
            sr.color = RedColor;
            curPlayerColor = ColorType.Red;
            _isMoving = false;
        }
        else if(Input.GetKey(KeyCode.Y))
        {
            sr.color = YellowColor;
            curPlayerColor = ColorType.Yellow;
            _isMoving = false;
        }
        else if(Input.GetKey(KeyCode.P))
        {
            sr.color = PurpleColor;
            curPlayerColor = ColorType.Purple;
            _isMoving = false;
        }
        else
        {
            sr.color = StartColor;
            curPlayerColor = ColorType.Green;
            _isMoving = true;
        }
	}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlendInObject"))
        {
            Debug.Log("is Colliding, Color: " + curPlayerColor.ToString() + ", isLookingUp: " + Human.Instance.isLookingUp);
            //float percentageInside = BoundsContainedPercentage(
            //    collision.bounds,
            //    this.boxCollider.bounds);

            ColorType curObjColor = collision.gameObject.GetComponent<BlendInObject>().curObjColor;
            if (curObjColor != curPlayerColor
                && Human.Instance.isLookingUp)
            //&& percentageInside > 0.5)
            {
                GameManager.Instance.LoseGame();
            }
            else
            {
                Debug.Log("Is Same");
            }
        }
        else if (collision.gameObject.CompareTag("Exit"))
        {
            GameManager.Instance.WinGame();

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BlendInObject"))
        {
            Debug.Log("is Colliding, Color: " + curPlayerColor.ToString() + ", isLookingUp: " + Human.Instance.isLookingUp);
            //float percentageInside = BoundsContainedPercentage(
            //    collision.bounds,
            //    this.boxCollider.bounds);

            ColorType curObjColor = collision.gameObject.GetComponent<BlendInObject>().curObjColor;
            if (curObjColor != curPlayerColor
                && Human.Instance.isLookingUp)
            //&& percentageInside > 0.5)
            {
                GameManager.Instance.LoseGame();
            }
            else
            {
                Debug.Log("Is Same");
            }
        }
        else if (collision.gameObject.CompareTag("Exit"))
        {
            GameManager.Instance.WinGame();

        }
    }
    private float BoundsContainedPercentage(Bounds obj, Bounds region)
    {
        var total = 1f;

        for (var i = 0; i < 2; i++)
        {
            var dist = obj.min[i] > region.center[i] ?
                obj.max[i] - region.max[i] :
                region.min[i] - obj.min[i];

            total *= Mathf.Clamp01(1f - dist / obj.size[i]);
        }

        return total;
    }
        


}
