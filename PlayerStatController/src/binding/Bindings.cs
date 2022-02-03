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

using StatControllers;
using System.Collections.Generic;
using System.Linq;

namespace StatControllers
{
    public static class Bindings
    {

        private const string TAG = "Bindings";
        private static readonly Dictionary<string, Binding> supportedBindings = new Dictionary<string, Binding>();

        static Bindings()
        {
            AddNewBinding(new CharacterLevel(0, "PlayerLevel"));
            AddNewBinding(new CharacterLootStage(1, "PlayerLootStage"));
            AddNewBinding(new CharacterCoreTemp(2, "PlayerCoreTemp"));
            AddNewBinding(new CharacterZombieKills(3, "PlayerZombieKills"));
            AddNewBinding(new CharacterPlayerKills(4, "PlayerPvPKills"));
            AddNewBinding(new CharacterDeaths(5, "PlayerDeaths"));
            AddNewBinding(new CharacterTravelled(6, "PlayerTravelled"));
            AddNewBinding(new CharacterItemsCrafted(7, "PlayerItemsCrafted"));
            AddNewBinding(new CharacterLongestLife(8, "PlayerLongestLife"));
            AddNewBinding(new CharacterCurrentLife(9, "PlayerCurrentLife"));
            AddNewBinding(new CharacterXPToNextLevel(10, "PlayerXPToNextLevel"));

            AddNewBinding(new CharacterHealth(100, "PlayerHealth", CharacterMainStat.MainStatFormat.Current));
            AddNewBinding(new CharacterHealth(101, "PlayerHealthMax", CharacterMainStat.MainStatFormat.Max));
            AddNewBinding(new CharacterHealth(102, "PlayerHealthWithMax", CharacterMainStat.MainStatFormat.WithMax));
            AddNewBinding(new CharacterHealth(103, "PlayerHealthPercentage", CharacterMainStat.MainStatFormat.Percentage));

            AddNewBinding(new CharacterStamina(110, "PlayerStamina", CharacterMainStat.MainStatFormat.Current));
            AddNewBinding(new CharacterStamina(111, "PlayerStaminaMax", CharacterMainStat.MainStatFormat.Max));
            AddNewBinding(new CharacterStamina(112, "PlayerStaminaWithMax", CharacterMainStat.MainStatFormat.WithMax));
            AddNewBinding(new CharacterStamina(113, "PlayerStaminaPercentage", CharacterMainStat.MainStatFormat.Percentage));

            AddNewBinding(new CharacterFood(120, "PlayerFood", CharacterMainStat.MainStatFormat.Current));
            AddNewBinding(new CharacterFood(121, "PlayerFoodMax", CharacterMainStat.MainStatFormat.Max));
            AddNewBinding(new CharacterFood(122, "PlayerFoodWithMax", CharacterMainStat.MainStatFormat.WithMax));
            AddNewBinding(new CharacterFood(123, "PlayerFoodPercentage", CharacterMainStat.MainStatFormat.Percentage));

            AddNewBinding(new CharacterWater(130, "PlayerWater", CharacterMainStat.MainStatFormat.Current));
            AddNewBinding(new CharacterWater(131, "PlayerWaterMax", CharacterMainStat.MainStatFormat.Max));
            AddNewBinding(new CharacterWater(132, "PlayerWaterWithMax", CharacterMainStat.MainStatFormat.WithMax));
            AddNewBinding(new CharacterWater(133, "PlayerWaterPercentage", CharacterMainStat.MainStatFormat.Percentage));

            AddNewBinding(new CharacterDisplayInfoStat(200, "PlayerHealthModifier", 0));
            AddNewBinding(new CharacterDisplayInfoStat(201, "PlayerStaminaModifier", 1));
            AddNewBinding(new CharacterDisplayInfoStat(202, "PlayerArmor", 2));
            AddNewBinding(new CharacterDisplayInfoStat(203, "PlayerExplosionResist", 3));
            AddNewBinding(new CharacterDisplayInfoStat(204, "PlayerCritResist", 4));
            AddNewBinding(new CharacterDisplayInfoStat(205, "PlayerStaminaRegen", 5));
            AddNewBinding(new CharacterDisplayInfoStat(206, "PlayerHealthRegen", 6));
            AddNewBinding(new CharacterDisplayInfoStat(207, "PlayerMedicalHealthRegen", 7));
            AddNewBinding(new CharacterDisplayInfoStat(208, "PlayerColdResist", 8));
            AddNewBinding(new CharacterDisplayInfoStat(209, "PlayerHeatResist", 9));
            AddNewBinding(new CharacterDisplayInfoStat(210, "PlayerMobility", 10));
            AddNewBinding(new CharacterDisplayInfoStat(211, "PlayerJumpStrength", 11));
            AddNewBinding(new CharacterDisplayInfoStat(212, "PlayerCarryingCapacity", 12));
            AddNewBinding(new CharacterDisplayInfoStat(213, "PlayerDamage", 13));
            AddNewBinding(new CharacterDisplayInfoStat(214, "PlayerBlockDamage", 14));
            AddNewBinding(new CharacterDisplayInfoStat(215, "PlayerRPM", 15));
            AddNewBinding(new CharacterDisplayInfoStat(216, "PlayerAPM", 16));

            AddNewBinding(new FlashLight(300, "InventoryIsFlashLightOn"));
            AddNewBinding(new HandFlashLight(301, "InventoryIsHandFlashLightOn"));
            AddNewBinding(new GunFlashLight(302, "InventoryIsGunFlashLightOn"));
            AddNewBinding(new HelmetFlashLight(303, "InventoryIsHelmetFlashLightOn"));

            AddNewBinding(new BagUsedSlots(304, "PlayerBagUsedSlots"));
            AddNewBinding(new BagSize(305, "PlayerBagSize"));
            AddNewBinding(new BagCarryCapacity(306, "PlayerCarryCapacity"));
            AddNewBinding(new BagMaxCarryCapacity(307, "PlayerMaxCarryCapacity"));
    }

        /// <summary>
        /// Finds the BindingType that contains the bindingName <br/>
        /// An error will be logged to the 7 Days to Die console if a <see cref="Binding"/> can not be found for the bindingName
        /// </summary>
        /// <param name="name">The bindingName to search for</param>
        /// <returns>The found <see cref="Binding"/>, otherwise <see langword="null"/></returns>
        public static Binding GetBinding(string bindingName)
        {
            if (supportedBindings.TryGetValue(bindingName.ToLower(), out Binding binding))
            {
                return binding;
            }

            var message = string.Format("{0} is not a supported bindingName", bindingName);
            Logging.Error(TAG, message);

            return null;
        }

        /// <summary>
        /// Determines if there is a <see cref="Binding"/> for the bindingName.<br/>
        /// An error will be logged to the 7 Days to Die console if the bindingName doesn't have a corresponding <see cref="Binding"/>
        /// </summary>
        /// <param name="bindingName">The bindingName to check for a corresponding Binding </param>
        /// <returns><see langword="true"/> if the bindingName has a Binding, otherwise <see langword="false"/> </returns>
        public static bool SupportsBinding(string bindingName)
        {
            if (!supportedBindings.ContainsKey(bindingName.ToLower()))
            {
                var message = string.Format("{0} is not a supported bindingName", bindingName);
                Logging.Error(TAG, message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds a new <see cref="Binding"/> to the Supported <see cref="Binding"/>.
        /// <para>
        /// This method must be called to add a new custom <see cref="Binding"/> that is not already supported <br/>
        /// if a custom binding is wanted to be used. See the Custom Binding Example to see how to <br/>
        /// add a new custom <see cref="Binding"/>
        /// </para>
        /// </summary>
        /// <param name="binding"></param>
        public static void AddNewBinding(Binding binding)
        {
            supportedBindings.Add(binding.Name, binding);
        }
    }

    public abstract class Binding : Enumeration
    {
        protected Binding(int value, string name) : base(value, name)
        {
        }

        /// <summary>
        /// Gets the current value of the <see cref="PlayerBinding"/> to bind to the XML
        /// </summary>
        /// <param name="player">The <see cref="EntityPlayer">player</see> the stat value belongs to</param>
        /// <returns>The value to bind to the XML</returns>
        public abstract string GetCurrentValue(EntityPlayer player);

        /// <summary>
        /// Determines if the value for the <see cref="PlayerBinding"/> has been updated and sets the last value in if it has been updated
        /// </summary>
        /// <param name="player">The <see cref="EntityPlayer">player</see> the stat value belongs to</param>
        /// <param name="lastValue">The value for the <see cref="PlayerBinding"/> since it was last checked to see if it has been updated<br/>
        /// If last value has been found to be changed, the new updated value will be sent back in this <see langword="ref"/></param>
        /// <returns><see langword="true"/> if the value has changed, otherwise <see langword="false"/></returns>
        public virtual bool HasValueChanged(EntityPlayer player, ref string lastValue)
        {
            string currentValue = GetCurrentValue(player);
            bool changed = lastValue != currentValue;
            lastValue = currentValue;
            return changed;
        }
    }

    public abstract class BindingAlias : Binding
    {
        public const char AliasSeperator = '+';

        protected string alias;

        protected BindingAlias(int value, string name) : base(value, name)
        {
            if (Name.Contains(AliasSeperator))
            {
                alias = Name.Split(AliasSeperator)[1];
            }
        }

        public override sealed string GetCurrentValue(EntityPlayer player)
        {
            return GetCurrentValue(player, alias);
        }

        public override sealed bool HasValueChanged(EntityPlayer player, ref string lastValue)
        {
            return HasValueChanged(player, alias, ref lastValue);
        }

        public abstract string GetCurrentValue(EntityPlayer player, string alias);

        public virtual bool HasValueChanged(EntityPlayer player, string alias, ref string lastValue)
        {
            string currentValue = GetCurrentValue(player, alias);
            bool changed = lastValue != currentValue;
            lastValue = currentValue;
            return changed;
        }
    }
}

public abstract class CharacterMainStat : Binding
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

public class CharacterLevel : Binding
{
    public CharacterLevel(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return player.Progression.GetLevel().ToString();
    }

}

public class CharacterLootStage : Binding
{
    public CharacterLootStage(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return player.GetHighestPartyLootStage(0f, 0f).ToString();
    }

}

public class CharacterCoreTemp : Binding
{
    public CharacterCoreTemp(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetCoreTemp(player);
    }

}

public class CharacterZombieKills : Binding
{
    public CharacterZombieKills(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetZombieKills(player).ToString();
    }

}

public class CharacterPlayerKills : Binding
{
    public CharacterPlayerKills(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetPlayerKills(player).ToString();
    }

}

public class CharacterDeaths : Binding
{
    public CharacterDeaths(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetDeaths(player).ToString();
    }

}

public class CharacterTravelled : Binding
{
    public CharacterTravelled(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetKMTraveled(player);
    }

}


public class CharacterItemsCrafted : Binding
{
    public CharacterItemsCrafted(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetItemsCrafted(player).ToString();
    }

}

public class CharacterLongestLife : Binding
{
    public CharacterLongestLife(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetLongestLife(player);
    }

}


public class CharacterCurrentLife : Binding
{
    public CharacterCurrentLife(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetCurrentLife(player);
    }

}


public class CharacterXPToNextLevel : Binding
{
    public CharacterXPToNextLevel(int value, string name) : base(value, name) { }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return XUiM_Player.GetXPToNextLevel(player).ToString();
    }

}
