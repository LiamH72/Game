using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//used so i can code the levelup slider
using TMPro;


public class SpawnManger : MonoBehaviour
{
    public Transform player; //object to be tracked
    public GameObject Zombie; //object to be duplicated
    public GameObject Health;
    public TMP_Text ScoreMultupgrade;
    private Color ScoreMultcolor = Color.red;
    public Button ScoreMultbutton;
    Rigidbody2D rb;
    int spawnrate = 4; //used tp control rate of which an enemy is instantiated
    int enemynumber = 0;
    bool ispause = true;// to check if the games paused
    private walking skill;//linking script with skill tree
    public Slider levelup;//slider for showing how close player gets rewards
    float constant = 0.01f;
    public GameObject skilltree;
    bool beenpressed1 = false;
    bool beenpressed2 = false;
    bool beenpressed3 = false;
    bool beenpressed4 = false; 
    bool beenpressed5 = false;
    bool beenpressed6 = false;
    private float timer = 0f;
    public GameObject skilltreeinfo;
    // Start is called before the first frame update
    void Start()
    {
        //its a corutine so i can suspend enemy spawning if need be throughout future development
        StartCoroutine(Healthpoint());
        StartCoroutine(Spawnpoint());
        skill = GameObject.FindObjectOfType<walking>();
    }


    IEnumerator Spawnpoint()
    {

        while (ispause == true)// to stop any code looping when the player has died
        {

            int rand1 = Random.Range(0, spawnrate);//randomises the time between spawns making the spawing randomised and this is the same for all spawning locations
            Vector3 enemyspawn1 = new Vector3(-2.31f, 5.24f, 0); // location the enemy will spawn
            Instantiate(Zombie, enemyspawn1, Quaternion.identity);//spawns the zombie sprite in the correct rotation
            enemynumber++;//records for every enemy has spawned into the program
            yield return new WaitForSeconds(rand1);
            rb = player.GetComponent<Rigidbody2D>();
            int rand2 = Random.Range(0, spawnrate);
            Vector3 enemyspawn2 = new Vector3(35.2f, -4.66f, 0); //these make all the different enemy spawning locations in the game
            Instantiate(Zombie, enemyspawn2, Quaternion.identity);
            enemynumber++;
            yield return new WaitForSeconds(rand2);
            rb = player.GetComponent<Rigidbody2D>();
            int rand3 = Random.Range(0, spawnrate);
            Vector3 enemyspawn3 = new Vector3(16.8f, -18.35f, 0);
            Instantiate(Zombie, enemyspawn3, Quaternion.identity);
            enemynumber++;
            yield return new WaitForSeconds(rand3);
            rb = player.GetComponent<Rigidbody2D>();
            int rand4 = Random.Range(0, spawnrate);
            Vector3 enemyspawn4 = new Vector3(41.20f, -30.38f, 0);
            Instantiate(Zombie, enemyspawn4, Quaternion.identity);
            enemynumber++;
            yield return new WaitForSeconds(rand4);
            rb = player.GetComponent<Rigidbody2D>();
            int rand5 = Random.Range(0, spawnrate);
            Vector3 enemyspawn5 = new Vector3(-6.4f, -30.0f, 0);
            Instantiate(Zombie, enemyspawn5, Quaternion.identity);
            enemynumber++;
            yield return new WaitForSeconds(rand5);
            rb = player.GetComponent<Rigidbody2D>();
        }
    }
    IEnumerator Healthpoint()
    {
        while (ispause == true)
        {
            //Health spawns----------------------------

            int Hrand1 = Random.Range(20, 60);//randomises the time between spawns making the spawing randomised and this is the same for all spawning locations
            Debug.Log( Hrand1);
            Vector3 Healthspawn1 = new Vector3(2.31f, -5.24f, -7); // location the enemy will spawn
            Instantiate(Health, Healthspawn1, Quaternion.identity);//spawns the zombie sprite in the correct rotation
            yield return new WaitForSeconds(Hrand1);
            Debug.Log(Hrand1);
            int Hrand2 = Random.Range(20, 60);//randomises the time between spawns making the spawing randomised and this is the same for all spawning locations
            Vector3 Healthspawn2 = new Vector3(41.3f, -24f, -7); // location the enemy will spawn
            Instantiate(Health, Healthspawn2, Quaternion.identity);//spawns the zombie sprite in the correct rotation
            yield return new WaitForSeconds(Hrand1);
            int Hrand3 = Random.Range(20, 60);//randomises the time between spawns making the spawing randomised and this is the same for all spawning locations
            Vector3 Healthspawn3 = new Vector3(2.3f, -29f, -7); // location the enemy will spawn
            Instantiate(Health, Healthspawn3, Quaternion.identity);//spawns the zombie sprite in the correct rotatio
            yield return new WaitForSeconds(Hrand1);
            int Hrand4 = Random.Range(20, 60);//randomises the time between spawns making the spawing randomised and this is the same for all spawning locations
            Vector3 Healthspawn4 = new Vector3(18.5f, 3.3f, -7); // location the enemy will spawn
            Instantiate(Health, Healthspawn4, Quaternion.identity);//spawns the zombie sprite in the correct rotation
            yield return new WaitForSeconds(Hrand1);
            int Hrand5 = Random.Range(20, 60);//randomises the time between spawns making the spawing randomised and this is the same for all spawning locations
            Vector3 Healthspawn5 = new Vector3(-16.3f, -11.3f, -7); // location the enemy will spawn
            Instantiate(Health, Healthspawn5, Quaternion.identity);//spawns the zombie sprite in the correct rotation
            yield return new WaitForSeconds(Hrand1);
        }
    }
       
        
    
    void FixedUpdate()
    {

        timer += Time.deltaTime;

        // Check if the timer has reached the target time
        if (timer >= 30f)
        {
            // Do something when 30 seconds are reached


            spawnrate = 4;

        }
        if (timer >= 90f)
        {
            // Do something when 30 seconds are reached

            
            spawnrate = 3;

        }
        if (timer >= 210f)
        {
            // Do something when 30 seconds are reached


            spawnrate = 3;

        }
        if (timer >= 260f)
        {
            // Do something when 30 seconds are reached


            spawnrate = 3;

        }
        if (timer >= 300f)
        {
            // Do something when 30 seconds are reached


            spawnrate = 2;

        }
        if (timer >= 330f)
        {
            // Do something when 30 seconds are reached


            spawnrate = 2;
        }
        if(timer >= 440f)
        {
            spawnrate = 1;
        }
        levelup.value = constant * enemynumber;//this increases the value of the visible slider
        
        if(levelup.value >= 1)//SET THIS TO 1
        {
            skill.SkillMenu();
            skilltreeinfo.SetActive(true); 

        }
        else
        {
            skilltreeinfo.SetActive(false);
        }

        

    }
    public void SkillTreeScoreMultiplier()//the score multiplier button come here where when pressed doubles the value of enemynumber essentially 
    {                                      //doubling the score
        ScoreMultupgrade.text = ("Upgrade Redeemed");
        ColorBlock cb = ScoreMultbutton.colors;
        cb.normalColor = ScoreMultcolor;
        cb.highlightedColor = ScoreMultcolor;
        cb.pressedColor = ScoreMultcolor;
        cb.selectedColor = ScoreMultcolor;
        ScoreMultbutton.colors = cb;
    }
    public void usedhealth()
    {
        if(beenpressed1 == false)
        {
            enemynumber = 0;
            beenpressed1 = true;
        }

    }
    public void usedwepdam()
    {
        if (beenpressed2 == false)
        {
            enemynumber = 0;
            skilltree.SetActive(false);
            beenpressed2 = true;
        }

    }
    public void usedlargermag()
    {
        if (beenpressed3 == false)
        {
            enemynumber = 0;
            skilltree.SetActive(false);
            beenpressed3 = true;
        }

    }
    public void usedspeed()
    {
        if (beenpressed4 == false)
        {
            enemynumber = 0;
            skilltree.SetActive(false);
            beenpressed4 = true;
        }

    }
    public void usedview()
    {
        if (beenpressed5 == false)
        {
            enemynumber = 0;
            skilltree.SetActive(false);
            beenpressed5 = true;
        }

    }
    public void usedscoremult()
    {
        if (beenpressed6 == false)
        {
            enemynumber = 0;
            skilltree.SetActive(false);
            beenpressed6 = true;
        }

    }
}
