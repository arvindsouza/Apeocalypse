using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//FOR HUD

public class Health : MonoBehaviour {

    public int startHeart = 2;
    private int maxHearts = 8;
    private float curHealth;
    private float maxHealth;
    private int healthPerHeart = 20;

    private ApeHealth playerHealth;

    public Image[] hearts;
    public Image[] faces;
    public Sprite[] heartSprites;

	// Use this for initialization
	void Start () {
        playerHealth = FindObjectOfType<ApeHealth>();
        maxHealth = playerHealth.MaxHealth;
        curHealth = playerHealth.curHealth;
        checkHealth();
        initFaces();
    }

    // Update is called once per frame
    void Update () {
    }

    public void checkHealth()
    {
        for(int i = 0; i < maxHearts; i++)
        {
            if(startHeart < i)
            {
                hearts[i].enabled = false;
            }
            else
            {
                hearts[i].sprite = heartSprites[0];
                hearts[i].enabled = true;
            }
        }
    }

   public void updateHearts()
    {
        bool empty = false;
        int i = 0;
        curHealth = playerHealth.curHealth;

        foreach(Image image in hearts)
        {
            if (empty)
            {
                image.sprite = heartSprites[4];
            }
            else
            {
                i++;
                if(curHealth >= i * healthPerHeart)
                {
                    image.sprite = heartSprites[0];
                }
                else
                {
                    int curHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - curHealth));
                    int healthPerSprite = healthPerHeart / (heartSprites.Length - 1);
                    int spriteIndex = (heartSprites.Length-1) - curHeartHealth / healthPerSprite;
                   // Debug.Log(spriteIndex + " "+ curHeartHealth + " " + curHealth);
                    image.sprite = heartSprites[spriteIndex];
                    empty = true;
                }
            }
        }
    }

    public void initFaces()
    {
      for(int i = 0; i < faces.Length; i++)
        {
            if (i != 0)
                faces[i].enabled = false;
        }
    }

    public IEnumerator toggleFaces(int enable)
    {
        faces[enable].enabled = true;
        faces[0].enabled = false;
        yield return new WaitForSeconds(.3f);
        faces[enable].enabled = false;
        faces[0].enabled = true;
    }

}
