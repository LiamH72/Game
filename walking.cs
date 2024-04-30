using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class walking : MonoBehaviour
{
    private Vector2 movement;//Declaring 2D vector
    public GameObject deathscreen;
    bool mustalive = true;
    public Transform projectile;
    public float BulletForce;
    public Transform Bullet;
    public Transform FireLocation;
    Animator animator; //Declares component for animation
    public float speed = 5; //Gives a fixed speed player will move at
    private Vector2 Moving;
    SpriteRenderer spriteRenderer1; //Declares a component for rendereing 2D sprite
    public GameObject skilltree;
    public GameObject pausemenu;
    private Rigidbody2D rb;
    public GameObject button;
    public bool IsDead;
    bool isskillopen = false;
    public TMP_Text Speedupgrade;
    private Color Speedcolor = Color.red;
    public Button Speedbutton;
    public GameObject weaponsound;
    public GameObject bullets;
    private bool testing = false;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();          
        spriteRenderer1 = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (testing == true)
        {
            if (mustalive == true)//stops processes regarding the player once the player has died and the game is over
            {
                float inputX = Input.GetAxisRaw("Horizontal"); //Horizontal input (-1 left 1 right)
                float inputY = Input.GetAxisRaw("Vertical"); //verticl input (-1 down 1 up)
                movement = new Vector2(inputX, inputY); //two components above are used to represent a 2D vector

                transform.Translate(movement * speed * Time.deltaTime);//gives velocity to your 2D vector
                                                                       //Time.deltaTime = 1/fps
                Moving = new Vector2(0, 0); //A 2D vector of no movement
                if (inputX < 0)//Checks if moving left
                {
                    spriteRenderer1.flipX = true; //Flips sprite
                }

                if (inputX > 0)//checks if moving right
                {
                    spriteRenderer1.flipX = false;
                }








            }

            if (testing == true)
            {
                if (Input.GetKey(KeyCode.Space) == true)//Detects if button/mouse has been pushed down
                {
                    animator.SetBool("Weapon fire", true);

                    if (bullets.activeSelf)
                    {
                        weaponsound.SetActive(true);
                    }
                    else
                    {
                        weaponsound.SetActive(false);
                    }
                }
                else
                {
                    animator.SetBool("Is moving", false);
                    animator.SetBool("Weapon fire", false);
                    weaponsound.SetActive(false);
                }

                if (Input.GetKey(KeyCode.Mouse0) || (Input.GetKey(KeyCode.Space) == true && movement != Moving))//Detects if button/mouse has been pushed down
                {                                                                                   //AND That the sprite is moving
                    animator.SetBool("Weapon fire and moving", true);

                }
                else
                {
                    animator.SetBool("Weapon fire and moving", false);
                }
                if (movement == Moving)//Compares Players 2D vector with a vector of zero 
                {
                    animator.SetBool("Is moving", false);//Activates boolean parameter
                }
                else
                {
                    animator.SetBool("Is moving", true);
                }
            }


        }
       

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0) == true)//detects if shoot key is being pressed
        {
            //StartCoroutine(Delay());
            if (spriteRenderer1.flipX == true)//makes sure weapon is always being fired in the direction the sprite is facing
            {
                Transform projectile = Instantiate(Bullet, FireLocation.position, FireLocation.rotation);//creates a new element which is the bullet using the player location and the players rotation
                projectile.GetComponent<Rigidbody2D>().AddForce(FireLocation.TransformVector(-1, 0, 0) * BulletForce);//using rigid body the bullet is sent into a direction using a transform vector3 and a variable bullet force
            }
            else
            {
                Transform projectile = Instantiate(Bullet, FireLocation.position, FireLocation.rotation);
                projectile.GetComponent<Rigidbody2D>().AddForce(FireLocation.TransformVector(1, 0, 0) * BulletForce);
            }
        }
        if (Input.GetKey(KeyCode.P))//when key is pressed pause menu comes up
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0f;//this stops all sprites from moving suspending the game whilst the pause scene is on
        }

        if (Input.GetKey(KeyCode.Escape) == true)//used to go back of the games menus
        {

            //pausegame();

        }
        if (button == true)//button to exit game in the puase menu
        {
            Application.Quit();
        }





    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);// make sure there is a gap between shots and not one continious stream of bullets

    }
    public void SkillMenu()//activated when levelup slider has reached maximum number 
    {
        if (Input.GetKey(KeyCode.I) == true)
        {
            skilltree.SetActive(true);//open the skill tree over the game
            isskillopen = true;

        }
        if (Input.GetKey(KeyCode.Escape) == true)//used to go back of the games menus
        {

            skilltree.SetActive(false);
            isskillopen = false;

        }
        if (Input.GetKey(KeyCode.Mouse1) == true)
        {
            skilltree.SetActive(false);
            isskillopen = false;
        }
    }
    public void pausegame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;//resumes all sprite movements and game elements



    }
    public void SkillTreePlayerSpeed()
    {
        speed = 9;//this increases the volocity the player sprite moves once the button is pressed in the skill tree
        Speedupgrade.text = ("Upgrade Redeemed");
        ColorBlock cb = Speedbutton.colors;
        cb.normalColor = Speedcolor;
        cb.highlightedColor = Speedcolor;
        cb.pressedColor = Speedcolor;
        cb.selectedColor = Speedcolor;
        Speedbutton.colors = cb;
    }
    public void EXIT()
    {
        Application.Quit();//exits the program after the player had died
    }
    public void RESTART()
    {
        SceneManager.LoadScene(0);//when the restart button is pressed program move scenes back to the main menu
    }
    public void DEAD()
    {
        mustalive = false;
        StartCoroutine(waitfordeath());
    }
    IEnumerator waitfordeath()
    {
        yield return new WaitForSeconds(4f);

        Deathscore();
    }
    public void Deathscore()
    {
        deathscreen.SetActive(true);
    }

}



