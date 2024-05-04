using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetTurnType : MonoBehaviour
{
    [SerializeField] private ActionBasedSnapTurnProvider snapTurnProvider;
    [SerializeField] private ActionBasedContinuousTurnProvider turnType;

    public static class TurnTypeSettings
    {
        public static bool IsSnapTurnEnabled { get; set; }
        public static bool IsTurnTypeEnabled { get; set; }
    }

    public static SetTurnType Instance { get; private set; }

    private void Awake()
    {
        turnType.enabled = TurnTypeSettings.IsTurnTypeEnabled;
        snapTurnProvider.enabled = TurnTypeSettings.IsSnapTurnEnabled;
    }

    public void SetTypeFromIndex(int index)
    {
        if (index == 0)
        {
            TurnTypeSettings.IsTurnTypeEnabled = true;
            TurnTypeSettings.IsSnapTurnEnabled = false;
        }
        else
        {
            TurnTypeSettings.IsTurnTypeEnabled = false;
            TurnTypeSettings.IsSnapTurnEnabled = true;
        }

        turnType.enabled = TurnTypeSettings.IsTurnTypeEnabled;
        snapTurnProvider.enabled = TurnTypeSettings.IsSnapTurnEnabled;
    }
}