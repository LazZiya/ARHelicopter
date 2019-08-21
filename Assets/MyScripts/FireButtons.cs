using UnityEngine;
using System.Collections;

public class FireButtons : MonoBehaviour
{

    public Texture fireBomb;
    public Texture fireBullet1;

    Vector2 posFireBomb;
    Vector2 sizeFireBomb;

    Vector2 posFireBullet1;
    Vector2 sizeFireBullet1;

    // Use this for initialization
    void Start()
    {
        posFireBomb = new Vector2(250, 250);
        sizeFireBomb = new Vector2(50, 50);

        posFireBullet1 = new Vector2(350, 350);
        sizeFireBullet1 = new Vector2(50, 50);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(
            new Rect(posFireBomb.x, posFireBomb.y, sizeFireBomb.x, sizeFireBomb.y), fireBomb, new GUIStyle()))
            //todo FireBomb code...
            Debug.Log("Fire Bomb");

        if (GUI.RepeatButton(
            new Rect(posFireBullet1.x, posFireBullet1.y, sizeFireBullet1.x, sizeFireBullet1.y), fireBullet1, new GUIStyle()))
            //todo FireBullet1 code...
            Debug.Log("Fire Bullet1");
    }
}
