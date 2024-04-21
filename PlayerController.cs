using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed_player;
    public int jump_player;
    public TextMeshProUGUI СountText;
    private float movementX;
    private float movementY;
    private Rigidbody rb;
    private int count;
    public GameObject CompleteText;
    public GameObject player;
    public float r_part;
    public float g_part;
    public float b_part;
    public Material myMaterial;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        CompleteText.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && !isJumping)
        {
            jump_player = DataHolder.jump;
            GetComponent<Rigidbody>().AddForce(0, jump_player, 0);
            isJumping = true;
        }

        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("menu");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        r_part = DataHolder.r;
        g_part = DataHolder.g;
        b_part = DataHolder.b;
        myMaterial.color = new Color(DataHolder.r, DataHolder.g, DataHolder.b);
        speed_player = DataHolder.speed;
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed_player);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        movementX = v.x;
        movementY = v.y;
    }

    void SetCountText()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Игрок находится на сцене: " + sceneName);

        if (sceneName == "game_ball")
        {
            СountText.text = "Собрано фруктов: " + count.ToString() + " из 6";

            if (count >= 6)
            {
                CompleteText.SetActive(true);
                СountText.text = "";
                Invoke("GoToLevel2", 2f);
            }
        }

        if (sceneName == "game_ball2")
        {
            СountText.text = "Собрано фруктов: " + count.ToString() + " из 8";

            if (count >= 8)
            {
                CompleteText.SetActive(true);
                СountText.text = "";
                Invoke("GoToMenuAfterLevel2", 2f);
            }
        }
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("game_ball2");
    }

    public void GoToMenuAfterLevel2()
    {
        SceneManager.LoadScene("menu");
    }
}