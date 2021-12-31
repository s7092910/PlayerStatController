# Using the Controller in your mod

Once the PlayerStatController is added to your mod as shown in the [README.md](../README.md),
you can start using the `XUiC_PlayerStats` in your mod.

## Using the controller

The controller is added to the xml by including the attribute

```XML
    controller="PlayerStats, PlayerStatController"
```

This attribute can be used either in the element that has an attribute for the value binding
or in a parent element.

The inside the XML, the binding syntax is as followed:

```XML
    "{x}"
```

With x being the binding name to be used. You can find supported bindings lower down in this tutorial.

An example of using the controller in the same element as the XML binding:

```XML
<label
    ...
    text="{PlayerFoodWithMax}" 
    controller="PlayerStats, PlayerStatController"/>
```
This XML creates a label that displays the Player's current Food levels with their maximum amount of food.
The controller is added to the element as an attribute in the last line. While the XML binding is `{PlayerFoodWithMax}`.

The format of the output will be `(currentFood)/(maxfood)`

An example of using the controller in the parent element of the XML binding:

```XML
<rect
    ...
    controller="PlayerStats, PlayerStatController">
    <label
        ...
        text="{PlayerName}"/>
</rect>
```

This XML will create a label with the Player's name being displayed. The controller is added to the
parent element. While the binding is `{PlayerName}`. This binding is not supported in the controller
but added as a new custom XML binding. You can find out how to add custom XML bindings [here](CustomXMLBindings.md).

## Supported Bindings

XML Binding | Description
---------|----------
`{PlayerLevel}`                 | The player's level
`{PlayerLootStage}`             | The player's loot stage
`{PlayerCoreTemp}`              | The player's current core temperature
`{PlayerZombieKills}`           | The amount of zombies the player has killed
`{PlayerPvPKills}`              | The amount of other players the player has killed
`{PlayerDeaths}`                | The amount of deaths the player has
`{PlayerTravelled}`             | The total distance the player has travelled in kilometers
`{PlayerItemsCrafted}`          | The amount of items the player has crafted
`{PlayerLongestLife}`           | The player's longest life in hours and minutes
`{PlayerCurrentLife}`           | The time since the player last respawned
`{PlayerXPToNextLevel}`         | The amount of XP the player needs to reach the next level
`{PlayerHealthCurrent}`         | The player's current health
`{PlayerHealthMax}`             | The player's maximum amount of health
`{PlayerHealthWithMax}`         | The player's current health with their maximum amount of health
`{PlayerHealthPercentage}`      | The player's current health as a percentage of their maximum health
`{PlayerStaminaCurrent}`        | The player's current stamina
`{PlayerStaminaMax}`            | The player's maximum amount of stamina
`{PlayerStaminaWithMax}`        | The player's current stamina with their maximum amount of stamina
`{PlayerStaminaPercentage}`     | The player's current stamina as a percentage of their maximum stamina
`{PlayerFoodCurrent}`           | The player's current food levels
`{PlayerFoodMax}`               | The player's maximum amount of food
`{PlayerFoodWithMax}`           | The player's current health with their maximum amount of food
`{PlayerFoodPercentage}`        | The player's current food as a percentage of their maximum food
`{PlayerWaterCurrent}`          | The player's current water levels
`{PlayerWaterMax}`              | The player's maximum amount of water
`{PlayerWaterWithMax}`          | The player's current water with their maximum amount of water
`{PlayerWaterPercentage}`       | The player's current water as a percentage of their maximum water
`{PlayerHealthModifier}`        | The amount the player's max health is decreased by
`{PlayerStaminaModifier}`       | The amount the player's max stamnia is decreased by
`{PlayerArmor}`                 | The player's physical armor rating
`{PlayerExplosionResist}`       | The player's explosion resistance
`{PlayerCritResist}`            | The player's crit resistance
`{PlayerStaminaRegen}`          | The player's stamina regeneration
`{PlayerHealthRegen}`           | The player's normal health regeneration
`{PlayerMedicalHealthRegen}`    | The player's health regeneration from medical supplies - currently will only display 0
`{PlayerColdResist}`            | The player's total cold resistance from equipment, skills and other modifiers
`{PlayerHeatResist}`            | The player's total heat resistance from equipment, skills and other modifiers
`{PlayerMobility}`              | The player's mobility
`{PlayerJumpStrength}`          | The player's jump strength
`{PlayerCarryingCapacity}`      | The player's carrying capacity
`{PlayerDamage}`                | The damage of the player's currently equipped item
`{PlayerBlockDamage}`           | The block damage of the player's currently equipped item
`{PlayerRPM}`                   | The rounds per minute of the player's currently equipped item
`{PlayerAPM}`                   | The attacks per minute of the player's currently equipped item

## Debugging

If a binding is misspelled or a binding that isn't supported by the Controller is used the following error message
will be displayed on the 7 Days to Die command console that is opened by pressing F1

```text
ERR [PlayerStatController] [Bindings] x is not a supported bindingName
```

This error message will be helpful in debugging the xml.

## Additional Information

[Adding a new XML binding](CustomXMLBindings.md)

[Examples of the Controller in Action and custom XML bindings](PlayerStatController/)
