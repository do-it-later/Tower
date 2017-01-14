using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public Sprite tile_ground, tile_path;
    public enum tileType
    {
        GROUND,
        PATH
    };

    public void setTile(tileType type)
    {
        switch (type)
        {
            case tileType.GROUND:
                gameObject.GetComponent<SpriteRenderer>().sprite = tile_ground;
            break;
            case tileType.PATH:
                gameObject.GetComponent<SpriteRenderer>().sprite = tile_path;
            break;
        }
    }
}
