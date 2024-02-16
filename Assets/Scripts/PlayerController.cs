using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver = false;

    public Slider levelSlider;
    public TextMeshProUGUI levelNumber;
	public TextMeshProUGUI scoreNumber;

	private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem playerParticle;
    public ParticleSystem playerParticleDirtSplatter;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerSource;

    private int points = 0;
    private int currentLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
		scoreNumber.text = points.ToString();
        levelNumber.text = points.ToString();
	}

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            playerParticleDirtSplatter.Stop();
            playerSource.PlayOneShot(jumpSound);
            isOnGround = false;
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerParticleDirtSplatter.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOverCanvas.SetActive(true);
            Debug.Log("GameOver");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerParticleDirtSplatter.Stop();
            playerParticle.Play();
            playerSource.PlayOneShot(crashSound);
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            addPoint();
            Destroy(collision.gameObject);
        }
        
    }

    private void addPoint()
    {
        points++;
		
        if(levelSlider.maxValue == levelSlider.value)
        {
            levelSlider.value = 0;
            currentLevel++;
        }
        else
        {
            levelSlider.value++;
        }

		scoreNumber.text = points.ToString();
        levelNumber.text = currentLevel.ToString();
    }
}
