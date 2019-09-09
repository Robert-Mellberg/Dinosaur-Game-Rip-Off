using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameObjectCreator
{
    public static GameObject createSprite(Vector2 position, Sprite sprite, bool movable)
    {
        GameObject gObject = new GameObject();
        gObject.transform.position = position;

        SpriteRenderer render = gObject.AddComponent<SpriteRenderer>();
        render.sprite = sprite;
        render.sortingOrder = -15;

        if (movable)
        {
            gObject.AddComponent<Movable>();
        }
        return gObject;
    }

    public static GameObject createText(Vector2 position, String text)
    {
        GameObject gObject = new GameObject();
        gObject.transform.position = position;

        TextMesh textComp = gObject.AddComponent<TextMesh>();
        textComp.characterSize = 0.2f;
        textComp.fontSize = 24;
        textComp.text = text;

        return gObject;
    }
}
