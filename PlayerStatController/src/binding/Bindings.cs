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

using System.Collections.Generic;
using System.Linq;

namespace StatControllers
{
    public static class Bindings
    {

        private const string TAG = "Bindings";
        private static readonly Dictionary<string, Binding> supportedBindings = new Dictionary<string, Binding>();

        //Adds all the base supported bindings
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

            AddNewBinding(new CharacterHealth(100, "PlayerHealth"));
            AddNewBinding(new CharacterHealth(101, "PlayerHealth+Max"));
            AddNewBinding(new CharacterHealth(102, "PlayerHealth+WithMax"));
            AddNewBinding(new CharacterHealth(103, "PlayerHealth+Percentage"));

            AddNewBinding(new CharacterHealth(104, "PlayerHealthMax", "Max"));
            AddNewBinding(new CharacterHealth(105, "PlayerHealthWithMax", "WithMax"));
            AddNewBinding(new CharacterHealth(106, "PlayerHealthPercentage", "Percentage"));

            AddNewBinding(new CharacterStamina(110, "PlayerStamina"));
            AddNewBinding(new CharacterStamina(111, "PlayerStamina+Max"));
            AddNewBinding(new CharacterStamina(112, "PlayerStamina+WithMax"));
            AddNewBinding(new CharacterStamina(113, "PlayerStamina+Percentage"));

            AddNewBinding(new CharacterStamina(114, "PlayerStaminaMax", "Max"));
            AddNewBinding(new CharacterStamina(115, "PlayerStaminaWithMax", "WithMax"));
            AddNewBinding(new CharacterStamina(116, "PlayerStaminaPercentage", "Percentage"));

            AddNewBinding(new CharacterFood(120, "PlayerFood"));
            AddNewBinding(new CharacterFood(121, "PlayerFood+Max"));
            AddNewBinding(new CharacterFood(122, "PlayerFood+WithMax"));
            AddNewBinding(new CharacterFood(123, "PlayerFood+Percentage"));

            AddNewBinding(new CharacterFood(124, "PlayerFoodMax", "Max"));
            AddNewBinding(new CharacterFood(125, "PlayerFoodWithMax", "WithMax"));
            AddNewBinding(new CharacterFood(126, "PlayerFoodPercentage", "Percentage"));

            AddNewBinding(new CharacterWater(130, "PlayerWater"));
            AddNewBinding(new CharacterWater(131, "PlayerWater+Max"));
            AddNewBinding(new CharacterWater(132, "PlayerWater+WithMax"));
            AddNewBinding(new CharacterWater(133, "PlayerWater+Percentage"));

            AddNewBinding(new CharacterWater(134, "PlayerWaterMax", "Max"));
            AddNewBinding(new CharacterWater(135, "PlayerWaterWithMax", "WithMax"));
            AddNewBinding(new CharacterWater(136, "PlayerWaterPercentage", "Percentage"));

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

    /// <summary>
    /// The base Binding Class. All bindings must extend this class.
    /// </summary>
    public abstract class Binding : Enumeration
    {

        /// <summary>
        /// The <see cref="Binding"/> constructor
        /// </summary>
        /// <param name="value">The <see langword="int"/> value used for identifying the <see cref="Binding"/></param>
        /// <param name="name">The bindingName for the <see cref="Binding"/></param>
        protected Binding(int value, string name) : base(value, name)
        {
        }

        /// <summary>
        /// Gets the current value of the <see cref="Binding"/> to bind to the XML
        /// </summary>
        /// <param name="player">The <see cref="EntityPlayer">player</see> the stat value belongs to</param>
        /// <returns>The value to bind to the XML</returns>
        public abstract string GetCurrentValue(EntityPlayer player);

        /// <summary>
        /// Determines if the value for the <see cref="Binding"/> has been updated and sets the last value in if it has been updated
        /// </summary>
        /// <param name="player">The <see cref="EntityPlayer">player</see> the stat value belongs to</param>
        /// <param name="lastValue">The value for the <see cref="Binding"/> since it was last checked to see if it has been updated<br/>
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

    /// <summary>
    /// The base binding class for bindings that might have multiple aliases for the binding.
    /// </summary>
    public abstract class BindingAlias : Binding
    {
        public const char AliasSeperator = '+';

        protected string alias;

        /// <summary>
        /// The constructor for <see cref="BindingAlias". This constructor will extract the alias for the binding<br/>
        /// by checking the name for a Alias Seperator defined as '+'/>
        /// </summary>
        /// <param name="name">The binding name that is used in</param>
        protected BindingAlias(int value, string name) : base(value, name)
        {
            if (Name.Contains(AliasSeperator))
            {
                alias = Name.Split(AliasSeperator)[1];
            }
        }

        /// <summary>
        /// The constructor for <see cref="BindingAlias". This constructor will use the passed in alias for operations<br/>
        /// using the alias/>
        /// </summary>
        /// <param name="name">The binding name</param>
        protected BindingAlias(int value, string name, string alias) : base(value, name)
        {
            this.alias = alias.ToLower();
        }

        public override sealed string GetCurrentValue(EntityPlayer player)
        {
            return GetCurrentValue(player, alias);
        }

        public override sealed bool HasValueChanged(EntityPlayer player, ref string lastValue)
        {
            return HasValueChanged(player, alias, ref lastValue);
        }

        /// <summary>
        /// Gets the current value of the <see cref="BindingAlias"/> to bind to the XML
        /// </summary>
        /// <param name="player">The <see cref="EntityPlayer">player</see> the stat value belongs to</param>
        /// <param name="alias">The alias tied to this <see cref="BindingAlias"/> to determine what value to return</param>
        /// <returns>The value to bind to the XML</returns>
        public abstract string GetCurrentValue(EntityPlayer player, string alias);


        /// <summary>
        /// Determines if the value for the <see cref="BindingAlias"/> has been updated and sets the last value in if it has been updated
        /// </summary>
        /// <param name="player">The <see cref="EntityPlayer">player</see> the stat value belongs to</param>
        /// <param name="alias">The alias tied to this <see cref="BindingAlias"/ to determine if the value tied to the alias has been updated</param>
        /// <param name="lastValue">The value for the <see cref="BindingAlias"/> since it was last checked to see if it has been updated<br/>
        /// If last value has been found to be changed, the new updated value will be sent back in this <see langword="ref"/></param>
        /// <returns><see langword="true"/> if the value has changed, otherwise <see langword="false"/></returns>
        public virtual bool HasValueChanged(EntityPlayer player, string alias, ref string lastValue)
        {
            string currentValue = GetCurrentValue(player, alias);
            bool changed = lastValue != currentValue;
            lastValue = currentValue;
            return changed;
        }
    }
}
