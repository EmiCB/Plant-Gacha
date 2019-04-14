using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // --- Variables & Objects ---
    public GC gc;
    private Rigidbody2D _rb2d;
    protected Joystick joystick;

    public GameObject deathMenu;

    [SerializeField]
    private float _speed = 10.0f;       //movement speed
    [SerializeField]
    private float _force = 20.0f;       //jump multiplier
    [SerializeField]
    private float _jumpValue = 0.5f;    //joystick input vertical

    private bool _isGrounded;           //checks to see if player is on the ground

    // --- Start ---
    private void Start() {
        //find relavent objects and components
        _rb2d = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();

        _isGrounded = true;             //player starts game on the ground
    }

    // --- Main Loop ---
    void Update() {
        if (!AutoRunButton.isAutoRunEnabled) {
            JoystickMovement();
        }
        else {
            AutoRun();
        }
        CheckIfGrounded();
    }

    // --- Movement ---
    void JoystickMovement() {
        //handles joystick input
        _rb2d.velocity = new Vector2(joystick.Horizontal * _speed, _rb2d.velocity.y);
        //handles jumping
        if (joystick.Vertical >= _jumpValue && _isGrounded) {
            _rb2d.velocity = new Vector2(joystick.Horizontal * _speed, joystick.Vertical * _force);
            _isGrounded = false;
        }
    }
    void AutoRun() {
        _rb2d.velocity = new Vector2(_speed, _rb2d.velocity.y);
        //handles jumping
        if (Input.GetMouseButtonDown(0) && _isGrounded) {
            _rb2d.velocity = new Vector2(_speed, joystick.Vertical * _force);
            _isGrounded = false;
        }
    }

    // --- Is Player On The Ground? ---
    void CheckIfGrounded() {
        if(_rb2d.velocity.y == 0) {
            _isGrounded = true;
        }
    }

    // --- Died ---
    public void Died()
    {
        if (!GC.isPaused)
        {
            GC.isPaused = true;
            Time.timeScale = 0.0f;
            deathMenu.SetActive(true);
        }
    }

    // --- Player Collisions ---
    void OnTriggerEnter2D(Collider2D other) {
        // Checks to see if object is a seed
        if (other.gameObject.CompareTag("seed")) {
            other.gameObject.SetActive(false);
            gc.totalSeeds++;
        }
        // Checks to see if object is a rare seed
        if (other.gameObject.CompareTag("rareSeed")) {
            other.gameObject.SetActive(false);
            gc.totalRareSeeds++;
        }
        // Checks to see if object is a killbox
        if (other.gameObject.CompareTag("killbox")) {
            this.gameObject.SetActive(false);
            Died();
            Debug.Log("Oof ouch I died");
        }
    }
}
