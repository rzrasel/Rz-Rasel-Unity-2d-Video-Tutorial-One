using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

	// Tutorial By: Rashed - Uz - Zaman (Rz Rasel)
	// Grid property specifications and initialization
	[SerializeField]
	//[Range(1, 10)]
	private int rows = 8; // Number of rows in the grid
	[SerializeField]
	//[Range(1, 18)]
	private int cols = 8; // Number of columns in the grid
	[SerializeField]
	private Vector2 gridSize = new Vector2(8f, 8f); // Grid size in game screen
	[SerializeField]
	private Vector2 gridOffset; // Grid offset automatic calculated, No need to set this values

	// About cells property specifications
	[SerializeField]
	private Sprite cellSprite; // Grid cell sprite image
	private Vector2 cellSize;
	private Vector2 cellScale;

	private void Start () {
		onInitCells(); // Initialize grid cells, and generate grid
	}

	private void onInitCells() {
		// Creates an empty object
		GameObject cellObject = new GameObject();
		// Adds a sprite renderer component -> set the sprite to cellSprite
		cellObject.AddComponent<SpriteRenderer>().sprite = cellSprite;
		// Catch the size of the sprite
		cellSize = cellSprite.bounds.size;

		// Get the new cell size -> adjust the size of the cells to fit the size of the grid
		Vector2 newCellSize = new Vector2(gridSize.x / (float)cols, gridSize.y / (float)rows);
		// Get the scales so you can scale the cells and change their size to fit the grid
		cellScale.x = newCellSize.x / cellSize.x;
		cellScale.y = newCellSize.y / cellSize.y;

		cellSize = newCellSize; // The size will be replaced by the new computed size, we just used cellSize for computing the scale
		cellObject.transform.localScale = new Vector2(cellScale.x, cellScale.y);

		// Fix the cells to the grid by getting the half of the grid and cells add and minus
		gridOffset.x = -(gridSize.x / 2) + cellSize.x / 2;
		gridOffset.y = -(gridSize.y / 2) + cellSize.y / 2;

		// Fill the grid with cells by using instantiate
		for(int row = 0; row < rows; row++) {
			for(int col = 0; col < cols; col++) {
				// Add the cell size so that no two cells will have the same x and y position
				//Vector2 pos = new Vector2(col * cellSize.x + gridOffset.x + transform.position.x, row * cellSize.y + gridOffset.y + transform.position.y);
				Vector3 pos = new Vector3(col * cellSize.x + gridOffset.x + transform.position.x, row * cellSize.y + gridOffset.y + transform.position.y, transform.position.z);

				// Instantiate the game object, at position pos, with rotation set to identity
				GameObject gob = Instantiate(cellObject, pos, Quaternion.identity) as GameObject;
				// Set the parent of the cell to grid so you can move the cells together with the grid;
				gob.transform.parent = transform;
			}
		}

		// Destroy the object used to instantiate the cells
		Destroy(cellObject);
	}

	// So you can see the width and height of the grid on editor
	private void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, gridSize);
	}
}
