using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ZombieHealth : MonoBehaviour
{
    int EnemyDeathChance = 10;
    public TMP_Text Score;//displayes players score on the UI
    string scorestring;//string of the number score
    public Text finalscore;//used to display score after defea
    public bool numberincrease = false;
    public TMP_Text EDamageupgrade;
    private Color EDamagecolor = Color.red;
    public Button EDamagebutton;
    static int w ;
    public GameObject POP;
    public Text HighScore;
    bool mustendalive;
    public void Start()
    {
        HighScore.text = PlayerPrefs.GetInt("HighScore:", 0).ToString();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.gameObject.tag == "ammo")//just like for the player health this will only respond to game objects that hat a custom tage of "ammo" which uniqley the bullets have
        {

            w = w + 1;
            scorestring = System.Convert.ToString(w);
            Score.text = "score\n" + (scorestring);
            finalscore.text = scorestring;

            int rand = Random.Range(0, EnemyDeathChance);
            if (rand < 3)//Enemy has a 11/2 chance of getting destroyed for every bullet that hits them
            {
                
                Death(); 
                POP.SetActive(true);
                
            }
        } 
    }
    public void IncrementEnemyCount()
    {
        
        
       
        
    }
    public void SkillTreeWeaponDamage()
    {
        EnemyDeathChance = 7;//this increases every enemies chances of getting destroyed on bullet collision

        EDamageupgrade.text = ("Upgrade Redeemed");
        ColorBlock cb = EDamagebutton.colors;
        cb.normalColor = EDamagecolor;
        cb.highlightedColor = EDamagecolor;
        cb.pressedColor = EDamagecolor;
        cb.selectedColor = EDamagecolor;
        EDamagebutton.colors = cb;
    }
    public void Death()
    {

        IncrementEnemyCount();

        
        

        Destroy(gameObject);//emeny is destroyed
        POP.SetActive(false);
    }
    public void DEAD()
    {
        mustendalive = true;
        Debug.Log(w);
        if (w > PlayerPrefs.GetInt("HighScore:", 0))
        {
            PlayerPrefs.SetInt("HighScore:", w);
            HighScore.text = "You have a highscore of:" + w.ToString();
        }
        
    }
    
}

        
       
       

    

    
   
    //Liam Lean you return types
          



        
       

    

