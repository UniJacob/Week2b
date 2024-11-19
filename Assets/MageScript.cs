using UnityEngine;
using UnityEngine.InputSystem;

public class MageScript : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    Vector3 bottomLeftBorder, topRightBorder, spriteBounds;
    [SerializeField]
    InputAction moveUp = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveDown = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveRight = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction moveLeft = new InputAction(type: InputActionType.Button);


    void OnEnable()
    {
        moveUp.Enable();
        moveDown.Enable();
        moveRight.Enable();
        moveLeft.Enable();
    }

    private void OnDisable()
    {
        moveUp.Disable();
        moveDown.Disable();
        moveRight.Disable();
        moveLeft.Disable();
    }

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
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        //transform.Translate(moveSpeed * Time.deltaTime * movement);

        if (moveUp.IsPressed())
        {
            //transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
            Vector3 movement = Vector3.up;
            transform.Translate(moveSpeed * Time.deltaTime * movement);
        }
        else if (moveDown.IsPressed())
        {
            //transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
            Vector3 movement = Vector3.down;
            transform.Translate(moveSpeed * Time.deltaTime * movement);
        }
        if (moveRight.IsPressed())
        {
            //transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            Vector3 movement = Vector3.right;
            transform.Translate(moveSpeed * Time.deltaTime * movement);
        }
        else if (moveLeft.IsPressed())
        {
            //transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
            Vector3 movement = Vector3.left;
            transform.Translate(moveSpeed * Time.deltaTime * movement);
        }

        /* Ensures sprite is in bounds */
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, bottomLeftBorder.x, topRightBorder.x);
        position.y = Mathf.Clamp(position.y, bottomLeftBorder.y, topRightBorder.y);
        transform.position = position;
    }
}
