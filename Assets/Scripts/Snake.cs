using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private Vector2 nextDirection = Vector2.right;

    public Transform bodyPrefab;
    private List<Transform> segments;

    private void Start()
    {
        segments = new List<Transform>();
        segments.Add(this.transform);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (direction != Vector2.down) nextDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (direction != Vector2.up) nextDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (direction != Vector2.right) nextDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (direction != Vector2.left) nextDirection = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        direction = nextDirection;
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i-1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
        );
    }

    private void ResetState()
    {
        for (int i=1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);
        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Food")
        {
            FindObjectOfType<Spawner>().OnEatFood();
            FindObjectOfType<GameManager>().IncreaseScore();
            Grow();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
            ResetState();
        }
    }

    private void Grow()
    {
        Transform body = Instantiate(this.bodyPrefab);
        body.position = segments[segments.Count - 1].position;
        segments.Add(body);
    }
}
