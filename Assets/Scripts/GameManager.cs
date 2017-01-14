using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject levelManager;
    public GameObject towerPrefab;

	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "tile")
            {
                Tile currentTile = hit.collider.gameObject.GetComponent<Tile>();
                if (currentTile.type_ == Tile.tileType.GROUND && !currentTile.occupiedByTower_)
                {
                    GameObject tower = Instantiate(towerPrefab, hit.collider.gameObject.transform.position, Quaternion.identity) as GameObject;
					tower.GetComponent<SpriteRenderer>().sortingOrder = levelManager.GetComponent<LevelManager>().levelHeight - (int)currentTile.transform.position.y;
                    currentTile.occupiedByTower_ = true;
                }
            }
        }
    }
}
