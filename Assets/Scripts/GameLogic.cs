using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    public GameObject towerPreFab;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
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
                    GameObject tower = Instantiate(towerPreFab, hit.collider.gameObject.transform.position, Quaternion.identity) as GameObject;
                    currentTile.occupiedByTower_ = true;
                }
            }
        }
    }
}
