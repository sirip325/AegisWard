using System;
using System.Collections.Generic;
using AegisWard.Scripts.Abilities.Model;
using UnityEngine;
using AegisWard.Scripts.Abilities.Model;
using AegisWard.Scripts.Player.Model;
using TMPro;
using UniRx;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using VContainer;

public class AbilityCaster : MonoBehaviour
{
    
    [SerializeField]private List<AbilityContext> abilityContexts;
    private InputSystem_Actions inputSystemActions;
    
    [Inject]
    private PlayerStats playerStats;

    public List<IAbility> Abilities = new List<IAbility>();


    private void Awake()
    {
        AddAbilitiesToList();
        
    }
    
    private void AddAbilitiesToList()
    {
        foreach (var abilityContext in abilityContexts)
        {
            var name = abilityContext.abilityName;
            Type type = Type.GetType(name);
            Debug.Log(type);
            
            if (type == null)
            {
                Debug.LogError($"Unable to find ability: {name}");
                return;
            }

            if (!typeof(Ability).IsAssignableFrom(type))
            {
                Debug.LogError($"{name} is not a Ability");
                return;
            }
            
            IAbility ability = (IAbility)Activator.CreateInstance(type);

            
            if (ability is Ability instance)
            {
                instance.Initialize(abilityContext,playerStats,gameObject.transform);
            }
            Abilities.Add(ability);
            Debug.Log(Abilities.Count);
        }
        
    }

    private void CastAbility(InputAction.CallbackContext context)
    {
        var pressedKey = context.control.name;
        
        
        
        ManaChecker manaChecker = new ManaChecker(playerStats);
        CooldownChecker cooldownChecker = new CooldownChecker();
        
        manaChecker.SetNext(cooldownChecker);

        bool result = manaChecker.Check(Abilities[pressedKey.ToIntArray()[0] - 49]);
        
        print($"Check result: {result}");
        
        if (result)
        {
            
            Abilities[pressedKey.ToIntArray()[0]-49].Execute();
        }
           
    }
    
    private void OnEnable()
    {
        inputSystemActions = new InputSystem_Actions();
        
        inputSystemActions.Player.Cast.Enable();
        inputSystemActions.Player.Cast.performed += CastAbility;
    }

    private void OnDisable()
    {
        inputSystemActions.Player.Cast.Disable();
        inputSystemActions.Player.Cast.performed -= CastAbility;
    }
}

