/*Copyright 2021 Christopher Beda

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public abstract class BindingType : Enumeration
{
    //All the base BindingTypes supported by the controller
    public static readonly BindingType characterLevel          = new CharacterLevel(0,             "PlayerLevel");
    public static readonly BindingType characterLootStage      = new CharacterLootStage(1,         "PlayerLootStage");
    public static readonly BindingType CharacterCoreTemp       = new CharacterCoreTemp(2,          "PlayerCoreTemp");
    public static readonly BindingType CharacterZombieKills    = new CharacterZombieKills(3,       "PlayerZombieKills");
    public static readonly BindingType CharacterPlayerKills    = new CharacterPlayerKills(4,       "PlayerPvPKills");
    public static readonly BindingType CharacterDeaths         = new CharacterDeaths(5,            "PlayerDeaths");
    public static readonly BindingType CharacterTravelled      = new CharacterTravelled(6,         "PlayerTravelled");
    public static readonly BindingType CharacterItemsCrafted   = new CharacterItemsCrafted(7,      "PlayerItemsCrafted");
    public static readonly BindingType CharacterLongestLife    = new CharacterLongestLife(8,       "PlayerLongestLife");
    public static readonly BindingType CharacterCurrentLife    = new CharacterCurrentLife(9,       "PlayerCurrentLife");
    public static readonly BindingType CharacterXPToNextLevel  = new CharacterXPToNextLevel(10,    "PlayerXPToNextLevel");

    public static readonly BindingType characterHealthCurrent = new CharacterHealth(100, "PlayerHealth",            CharacterMainStat.MainStatFormat.Current);
    public static readonly BindingType characterHealthMax     = new CharacterHealth(101, "PlayerHealthMax",         CharacterMainStat.MainStatFormat.Max);
    public static readonly BindingType characterHealthWithMax = new CharacterHealth(102, "PlayerHealthWithMax",     CharacterMainStat.MainStatFormat.WithMax);
    public static readonly BindingType characterHealthPercent = new CharacterHealth(103, "PlayerHealthPercentage",  CharacterMainStat.MainStatFormat.Percentage);

    public static readonly BindingType characterStaminaCurrent = new CharacterStamina(110, "PlayerStamina",             CharacterMainStat.MainStatFormat.Current);
    public static readonly BindingType characterStaminaMax     = new CharacterStamina(111, "PlayerStaminaMax",          CharacterMainStat.MainStatFormat.Max);
    public static readonly BindingType characterStaminaWithMax = new CharacterStamina(112, "PlayerStaminaWithMax",      CharacterMainStat.MainStatFormat.WithMax);
    public static readonly BindingType characterStaminaPercent = new CharacterStamina(113, "PlayerStaminaPercentage",   CharacterMainStat.MainStatFormat.Percentage);

    public static readonly BindingType characterFoodCurrent = new CharacterFood(120, "PlayerFood",             CharacterMainStat.MainStatFormat.Current);
    public static readonly BindingType characterFoodMax     = new CharacterFood(121, "PlayerFoodMax",          CharacterMainStat.MainStatFormat.Max);
    public static readonly BindingType characterFoodWithMax = new CharacterFood(122, "PlayerFoodWithMax",      CharacterMainStat.MainStatFormat.WithMax);
    public static readonly BindingType characterFoodPercent = new CharacterFood(123, "PlayerFoodPercentage",   CharacterMainStat.MainStatFormat.Percentage);

    public static readonly BindingType characterWaterCurrent = new CharacterWater(130, "PlayerWater",             CharacterMainStat.MainStatFormat.Current);
    public static readonly BindingType characterWaterMax     = new CharacterWater(131, "PlayerWaterMax",          CharacterMainStat.MainStatFormat.Max);
    public static readonly BindingType characterWaterWithMax = new CharacterWater(132, "PlayerWaterWithMax",      CharacterMainStat.MainStatFormat.WithMax);
    public static readonly BindingType characterWaterPercent = new CharacterWater(133, "PlayerWaterPercentage",   CharacterMainStat.MainStatFormat.Percentage);

    public static readonly BindingType characterHealthModifier         = new CharacterDisplayInfoStat(200, "PlayerHealthModifier",       0);
    public static readonly BindingType characterStaminaModifier        = new CharacterDisplayInfoStat(201, "PlayerStaminaModifier",      1);
    public static readonly BindingType characterArmor                  = new CharacterDisplayInfoStat(202, "PlayerArmor",                2);
    public static readonly BindingType characterExplosionResist        = new CharacterDisplayInfoStat(203, "PlayerExplosionResist",      3);
    public static readonly BindingType characterCritResist             = new CharacterDisplayInfoStat(204, "PlayerCritResist",           4);
    public static readonly BindingType characterStaminaRegen           = new CharacterDisplayInfoStat(205, "PlayerStaminaRegen",         5);
    public static readonly BindingType characterHealthRegen            = new CharacterDisplayInfoStat(206, "PlayerHealthRegen",          6);
    public static readonly BindingType characterMedicalHealthRegen     = new CharacterDisplayInfoStat(207, "PlayerMedicalHealthRegen",   7);
    public static readonly BindingType characterColdResist             = new CharacterDisplayInfoStat(208, "PlayerColdResist",           8);
    public static readonly BindingType characterHeatResist             = new CharacterDisplayInfoStat(209, "PlayerHeatResist",           9);
    public static readonly BindingType characterMobility               = new CharacterDisplayInfoStat(210, "PlayerMobility",             10);
    public static readonly BindingType characterJumpStrength           = new CharacterDisplayInfoStat(211, "PlayerJumpStrength",         11);
    public static readonly BindingType characterCarryingCapacity       = new CharacterDisplayInfoStat(212, "PlayerCarryingCapacity",     12);
    public static readonly BindingType characterDamage                 = new CharacterDisplayInfoStat(213, "PlayerDamage",               13);
    public static readonly BindingType characterBlockDamage            = new CharacterDisplayInfoStat(214, "PlayerBlockDamage",          14);
    public static readonly BindingType characterRPM                    = new CharacterDisplayInfoStat(215, "PlayerRPM",                  15);
    public static readonly BindingType characterAPM                    = new CharacterDisplayInfoStat(216, "PlayerAPM",                  16);

    public static readonly BindingType flashlight           = new FlashLight(300,           "InventoryIsFlashLightOn");
    public static readonly BindingType handflashlight       = new HandFlashLight(301,       "InventoryIsHandFlashLightOn");
    public static readonly BindingType gunflashlight        = new GunFlashLight(302,        "InventoryIsGunFlashLightOn");
    public static readonly BindingType helmetflashlight     = new HelmetFlashLight(303,     "InventoryIsHelmetFlashLightOn");

    public static readonly BindingType bagUsedSlots                 = new BagUsedSlots(304,         "PlayerBagUsedSlots");
    public static readonly BindingType bagSize                      = new BagSize(305,              "PlayerBagSize");
    public static readonly BindingType characterCarryCapacity       = new BagCarryCapacity(306,     "PlayerCarryCapacity");
    public static readonly BindingType characterMaxCarryCapacity    = new BagMaxCarryCapacity(307,  "PlayerMaxCarryCapacity");

    private static readonly List<BindingType> supportedBindings = new List<BindingType>();

    private static bool areDefaultSupportedStatTypesLoaded = false;

    /// <summary>
    /// The supported <see cref="BindingType"/> for the XUiC_PlayerStatController <br/>
    /// Loads the default <see cref="BindingType"/> if they haven't been loaded before
    /// </summary>
    protected static List<BindingType> SupportedBindingTypes
    { get 
        {
            if (!areDefaultSupportedStatTypesLoaded)
            {
                Logging.Out("Loading Default Supported Bindings");
                areDefaultSupportedStatTypesLoaded = true;
                supportedBindings.AddRange(GetAllBaseSupportedBindingTypes());
                Logging.Out("Loaded Default Supported Bindings");
            }
            return supportedBindings; 
        } 
    }


    /// <summary>
    /// The <see cref="BindingType"/> constructor
    /// </summary>
    /// <param name="value">The <see langword="int"/> value used for identifying the <see cref="BindingType"/></param>
    /// <param name="name">The bindingName for the <see cref="BindingType"/></param>
    protected BindingType(int value, string name) : base(value, name)
    {
    }

    /// <summary>
    /// Gets the current value of the <see cref="BindingType"/> to bind to the XML
    /// </summary>
    /// <param name="player">The <see cref="EntityPlayer">player</see> the stat value belongs to</param>
    /// <returns>The value to bind to the XML</returns>
    public abstract string GetCurrentValue(EntityPlayer player);

    /// <summary>
    /// Determines if the value for the <see cref="BindingType"/> has been updated and sets the last value in if it has been updated
    /// </summary>
    /// <param name="player">The <see cref="EntityPlayer">player</see> the stat value belongs to</param>
    /// <param name="lastValue">The value for the <see cref="BindingType"/> since it was last checked to see if it has been updated<br/>
    /// If last value has been found to be changed, the new updated value will be sent back in this <see langword="ref"/></param>
    /// <returns><see langword="true"/> if the value has changed, otherwise <see langword="false"/></returns>
    public virtual bool HasValueChanged(EntityPlayer player, ref string lastValue)
    {
        string currentValue = GetCurrentValue(player);
        bool changed = lastValue != currentValue;
        lastValue = currentValue;
        return changed;
    }

    /// <summary>
    /// Adds a new <see cref="BindingType"/> to the Supported <see cref="BindingType"/>.
    /// <para>
    /// This method must be called to add a new custom <see cref="BindingType"/> that is not already supported <br/>
    /// if a custom binding is wanted to be used. See the Custom Binding Example to see how to <br/>
    /// add a new custom <see cref="BindingType"/>
    /// </para>
    /// </summary>
    /// <param name="binding"></param>
    public static void AddNewBinding(BindingType binding)
    {
        SupportedBindingTypes.Add(binding);
    }

    /// <summary>
    /// Determines if there is a <see cref="BindingType"/> for the bindingName.<br/>
    /// An error will be logged to the 7 Days to Die console if the bindingName doesn't have a corresponding <see cref="BindingType"/>
    /// </summary>
    /// <param name="bindingName">The bindingName to check for a corresponding BindingType </param>
    /// <returns><see langword="true"/> if the bindingName has a BindingType, otherwise <see langword="false"/> </returns>
    public static bool SupportsBinding(string bindingName)
    {
        bool b = SupportedBindingTypes.Exists(item => item.Name.EqualsCaseInsensitive(bindingName));
        if (!b)
        {
            var message = string.Format("{0} is not a supported bindingName", bindingName);
            Logging.Error(typeof(BindingType).ToString(), message);
        }

        return b;
    }

    /// <summary>
    /// Finds the BindingType that contains the value.<br/>
    /// An error will be logged to the 7 Days to Die console if a B<see cref="BindingType"/> can not be found for the value
    /// </summary>
    /// <param name="value">The value to search for</param>
    /// <returns> <see cref="BindingType"/> - returns the found <see cref="BindingType"/>, otherwise <see langword="null"/></returns>
    public static BindingType FromValue(int value)
    {
        var matchingItem = parse<int>(value, item => item.Value == value);
        return matchingItem;
    }

    /// <summary>
    /// Finds the BindingType that contains the bindingName <br/>
    /// An error will be logged to the 7 Days to Die console if a <see cref="BindingType"/> can not be found for the bindingName
    /// </summary>
    /// <param name="name">The bindingName to search for</param>
    /// <returns>The found <see cref="BindingType"/>, otherwise <see langword="null"/></returns>
    public static BindingType FromBindingName(string name)
    {
        var matchingItem = parse<string>(name, item => item.Name.EqualsCaseInsensitive(name));
        return matchingItem;
    }

    /// <summary>
    /// Gets all the base supported <see cref="BindingType">BindingTypes</see>. It does this by searching the fields of <see cref="BindingType"/> for any fields declared as <br/>
    /// {public static readonly} and will cast them to <see cref="BindingType"/> . If a field that is not castable to <see cref="BindingType"/>, this will cause
    /// an error
    /// </summary>
    /// <returns>An IEnumerable containing all the found <see cref="BindingType">BindingTypes</see> that are <see cref="BindingType"/> fields</returns>
    private static IEnumerable<BindingType> GetAllBaseSupportedBindingTypes()
    {
        var type = typeof(BindingType);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

        return fields.Select(f => f.GetValue(null)).Cast<BindingType>();
    }

    /// <summary>
    /// Searches the SupportedBindingTypes list to find a <see cref="BindingType"/> based on the Predicate. <br/>
    /// An error will be logged to the 7 Days to Die console if a <see cref="BindingType"/> can not be found for the value
    /// </summary>
    /// <typeparam name="K">The type of the value to be searched</typeparam>
    /// <param name="value">The value that is being searched for</param>
    /// <param name="predicate">The prdicate to use to search the SupportedBindingTypes list</param>
    /// <returns>The found <see cref="BindingType"/>, otherwise <see langword="null"/></returns>
    private static BindingType parse<K>(K value, Predicate<BindingType> predicate)
    {
        var matchingItem = SupportedBindingTypes.Find(predicate);

        if (matchingItem == null)
        {
            var message = string.Format("{0} is not a supported bindingName", value);
            Logging.Error(typeof(BindingType).ToString(), message);
        }

        return matchingItem;
    }
}

public abstract class CharacterMainStat : BindingType
{
    protected MainStatFormat formatType;
    protected readonly CachedStringFormatter<float> floatRoundingFormatter = new CachedStringFormatter<float>((float f) => f.ToCultureInvariantString("0"));
    protected readonly CachedStringFormatter<float> floatFormatter = new CachedStringFormatter<float>((float f) => ((int)f).ToString());

    public CharacterMainStat(int value, string name, MainStatFormat formatType) : base(value, name)
    {
        this.formatType = formatType;
    }

    public override string GetCurrentValue(EntityPlayer player)
    {
        switch (formatType)
        {
            case MainStatFormat.Current:
                return GetCurrentStatValue(player);
            case MainStatFormat.Max:
                return GetMaxStatValue(player);
            case MainStatFormat.WithMax:
                return GetWithMaxStatValue(player);
            case MainStatFormat.Percentage:
                return GetPercentageStatValue(player);
        }
        return "";
    }

    public abstract string GetCurrentStatValue(EntityPlayer player);
    public abstract string GetMaxStatValue(EntityPlayer player);

    public abstract string GetWithMaxStatValue(EntityPlayer player);

    public abstract string GetPercentageStatValue(EntityPlayer player);

    public enum MainStatFormat
    {
        Current,
        Max,
        WithMax,
        Percentage
    }
}

public class CharacterLevel : BindingType
{
    public CharacterLevel(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return player.Progression.GetLevel().ToString();
    }

}

public class CharacterLootStage : BindingType
{
    public CharacterLootStage(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return player.GetHighestPartyLootStage(0f, 0f).ToString();
    }

}

public class CharacterCoreTemp : BindingType
{
    public CharacterCoreTemp(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetCoreTemp(player);
    }

}

public class CharacterZombieKills : BindingType
{
    public CharacterZombieKills(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetZombieKills(player).ToString();
    }

}

public class CharacterPlayerKills : BindingType
{
    public CharacterPlayerKills(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetPlayerKills(player).ToString();
    }

}

public class CharacterDeaths : BindingType
{
    public CharacterDeaths(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetDeaths(player).ToString();
    }

}

public class CharacterTravelled : BindingType
{
    public CharacterTravelled(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetKMTraveled(player);
    }

}


public class CharacterItemsCrafted : BindingType
{
    public CharacterItemsCrafted(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetItemsCrafted(player).ToString();
    }

}

public class CharacterLongestLife : BindingType
{
    public CharacterLongestLife(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetLongestLife(player);
    }

}


public class CharacterCurrentLife : BindingType
{
    public CharacterCurrentLife(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetCurrentLife(player);
    }

}


public class CharacterXPToNextLevel : BindingType
{
    public CharacterXPToNextLevel(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetXPToNextLevel(player).ToString();
    }

}

public class CharacterHealth : CharacterMainStat
{
    public CharacterHealth(int value, string name, MainStatFormat formatType) : base(value, name, formatType)
    {
    }

    public override string GetCurrentStatValue(EntityPlayer player)
    { 
        return player.Health.ToString();
    }

    public override string GetMaxStatValue(EntityPlayer player)
    {
        return ((int)player.Stats.Health.Max).ToString();
    }

    public override string GetWithMaxStatValue(EntityPlayer player)
    {
        return string.Format("{0}/{1}", player.Health.ToString(), floatFormatter.Format(player.Stats.Health.Max).ToString());
    }

    public override string GetPercentageStatValue(EntityPlayer player)
    {
        return floatFormatter.Format(player.Stats.Health.ValuePercentUI * 100);
    }
}

public class CharacterStamina : CharacterMainStat
{
    public CharacterStamina(int value, string name, MainStatFormat formatType) : base(value, name, formatType)
    {
    }

    public override string GetCurrentStatValue(EntityPlayer player)
    {
        return ((int)player.Stamina).ToString();
    }

    public override string GetMaxStatValue(EntityPlayer player)
    {
        return ((int)player.Stats.Stamina.Max).ToString();
    }

    public override string GetWithMaxStatValue(EntityPlayer player)
    {
        return string.Format("{0}/{1}", floatFormatter.Format(player.Stamina), floatFormatter.Format(player.Stats.Stamina.Max));
    }

    public override string GetPercentageStatValue(EntityPlayer player)
    {
        return floatFormatter.Format(player.Stats.Stamina.ValuePercentUI * 100);
    }
}

public class CharacterFood: CharacterMainStat
{
    public CharacterFood(int value, string name, MainStatFormat formatType) : base(value, name, formatType)
    {
    }

    public override string GetCurrentStatValue(EntityPlayer player)
    {
        return floatRoundingFormatter.Format(player.Stats.Food.Value);
    }

    public override string GetMaxStatValue(EntityPlayer player)
    {
        return ((int)player.Stats.Food.Max).ToString();
    }

    public override string GetWithMaxStatValue(EntityPlayer player)
    {
        return string.Format("{0}/{1}", floatRoundingFormatter.Format(player.Stats.Food.Value), floatFormatter.Format(player.Stats.Food.Max));
    }

    public override string GetPercentageStatValue(EntityPlayer player)
    {
        return floatRoundingFormatter.Format(player.Stats.Food.ValuePercentUI * 100);
    }
}

public class CharacterWater : CharacterMainStat
{
    public CharacterWater(int value, string name, MainStatFormat formatType) : base(value, name, formatType)
    {
    }

    public override string GetCurrentStatValue(EntityPlayer player)
    {
        return floatRoundingFormatter.Format(player.Water);
    }

    public override string GetMaxStatValue(EntityPlayer player)
    {
        return ((int)player.Stats.Water.Max).ToString();
    }

    public override string GetWithMaxStatValue(EntityPlayer player)
    {
        return string.Format("{0}/{1}", floatRoundingFormatter.Format(player.Water), floatFormatter.Format(player.Stats.Water.Max));
    }

    public override string GetPercentageStatValue(EntityPlayer player)
    {
        return floatRoundingFormatter.Format(player.Stats.Water.ValuePercentUI * 100);
    }
}
