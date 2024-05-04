using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float spwanDistance = 2f;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private InputActionProperty inputActionProperty;

    private void Update()
    {
        if (inputActionProperty.action.WasPressedThisFrame())
        {
            gameMenu.SetActive(!gameMenu.activeSelf);
            gameMenu.transform.position = player.position + new Vector3(player.forward.x, 1, player.forward.z).normalized * spwanDistance;
        }

        gameMenu.transform.LookAt(new Vector3(player.position.x, gameMenu.transform.position.y, player.position.z));
        gameMenu.transform.forward *= -1;
    }
}