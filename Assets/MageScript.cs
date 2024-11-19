using UnityEngine;

public class MageScript : MonoBehaviour
{
    public float moveSpeed = 300;
    private Vector3 bottomLeftBorder, topRightBorder, spriteBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetBorders();
    }

    public void SetBorders()
    {
        bottomLeftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        topRightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        spriteBounds = GetComponent<SpriteRenderer>().bounds.size;

        bottomLeftBorder.x += spriteBounds.x / 2;
        bottomLeftBorder.y += spriteBounds.y / 2;
        topRightBorder.x -= spriteBounds.x / 2;
        topRightBorder.y -= spriteBounds.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.Translate(moveSpeed * Time.deltaTime * movement);

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, bottomLeftBorder.x, topRightBorder.x);
        position.y = Mathf.Clamp(position.y, bottomLeftBorder.y, topRightBorder.y);
        transform.position = position;
    }
}
