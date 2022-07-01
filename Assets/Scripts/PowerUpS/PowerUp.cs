using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField, Tooltip ("Tick true for power ups that are instant use, eg a health addition that has no delay before expiring")] 
    private bool expiresImmediately;
    
    /// It is handy to keep a reference to the player that collected us

    
    protected IUnit _unit;

    protected enum PowerUpState
    {
        InAttractMode,
        IsCollected,
        IsExpiring
    }

    protected PowerUpState powerUpState;

    protected virtual void Start ()
    {
        powerUpState = PowerUpState.InAttractMode;
    }

    protected virtual void OnTriggerEnter (Collider other)
    {
        PowerUpCollected (other.gameObject);
    }

    protected void PowerUpCollected (GameObject gameObjectCollectingPowerUp)
    {
        _unit = gameObjectCollectingPowerUp.GetComponent<IUnit>();

        if (_unit == null)
        {
            return;
        }

        // We only care if we've not been collected before
        if (powerUpState == PowerUpState.IsCollected || powerUpState == PowerUpState.IsExpiring)
        {
            return;
        }
        powerUpState = PowerUpState.IsCollected;

        // We must have been collected by a player, store handle to player for later use      
        // Payload      
        PowerUpPayload ();
        
        // Now the power up visuals can go away
        Destroy(gameObject);
    }
    
    protected virtual void PowerUpPayload ()
    {
        Debug.Log ("Power Up collected, issuing payload for: " + gameObject.name);

        // If we're instant use we also expire self immediately
        if (expiresImmediately)
        {
            PowerUpHasExpired ();
        }
    }

    protected  void PowerUpHasExpired ()
    {
        if (powerUpState == PowerUpState.IsExpiring)
        {
            return;
        }
        powerUpState = PowerUpState.IsExpiring;
        
        Debug.Log ("Power Up has expired, removing after a delay for: " + gameObject.name);
        DestroySelfAfterDelay ();
    }

    protected  void DestroySelfAfterDelay ()
    {
        // Arbitrary delay of some seconds to allow particle, audio is all done
        // TODO could tighten this and inspect the sfx? Hard to know how many, as subclasses could have spawned their own
        Destroy (gameObject, 10f);
    }
}
