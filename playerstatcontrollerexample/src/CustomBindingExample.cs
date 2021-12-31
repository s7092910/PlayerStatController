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

public class CustomBindingExample
{
    public class PlayerStatControllerExtensionInit : IModApi
    {
        public void InitMod(Mod _modInstance)
        {
            Log.Out(" Loading Patch: " + GetType());
            //Adds the CharacterName custom binding to the supported bindings of the XUiC_PlayerStats
            //{PlayerName} is the binding used in the xml to access this custom binding.
            BindingType.AddNewBinding(new CharacterName(500, "PlayerName"));

            //Adds the Vehicle Speed Custom binding to the supported bindings of the XUiC_PlayerStats
            //{VehicleSpeed} is the binding used in the xml to access this custom binding.
            BindingType.AddNewBinding(new VehicleSpeed(501, "VehicleSpeed"));

            BindingType.AddNewBinding(new InVehicle(502, "InVehicle"));

            Log.Out(" Loaded Patch: " + GetType());

            //This turns on the INF logging of the XUiC_PlayerStats to the 7 Days to Die Console.
            //By default it is disabled
            //If disabled, WRN and ERR messages logged by the XUiC_PlayerStatController library will still be logged
            //to the 7 Days to Die Console.
            Logging.enabled = true;
        }
    }

    /// <summary>
    /// <para>
    /// An example on how to make a subclass of BindingType to create a new binding.
    /// </para>
    /// Creates a new BindingType that gets the name of an EntityPlayer. It is used to get the <br/>
    /// local player's name
    /// </summary>
    public class CharacterName : BindingType
    {
        public CharacterName(int value, string name) : base(value, name) { }

        //Overrides the base BindingType GetCurrentValue. This is required by all subclasses of BindingType
        //This gives you control over what value is bound to the XML during the binding process
        public override string GetCurrentValue(EntityPlayer player)
        {
            return player.EntityName;
        }
    }

    /// <summary>
    /// <para>
    /// An example on how to make a subclass of BindingType to create a new binding that also overrides the HasValueChanged
    /// </para>
    /// Creates a new BindingType that gets the speed of Vehicle that is attached to a player. If the player is not inside <br/>
    /// a vehicle it will not get cause the bindings to refresh their value.
    /// </summary>
    public class VehicleSpeed : BindingType
    {

        private readonly CachedStringFormatter<float> formatter = new CachedStringFormatter<float>((float f) =>  f.ToCultureInvariantString("0.00"));

        public VehicleSpeed(int value, string name) : base(value, name) { }

        public override bool HasValueChanged(EntityPlayer player, ref string lastValue)
        {
            if (player.AttachedToEntity != null)
            {
                return base.HasValueChanged(player, ref lastValue);
            }
            else
            {
                return false;
            }
        }

        public override string GetCurrentValue(EntityPlayer player)
        {
            if (player.AttachedToEntity != null)
            {
                return formatter.Format(player.AttachedToEntity.GetVelocityPerSecond().magnitude);
            }
            else
            {
                return "";
            }
        }
    }

    public class InVehicle : BindingType
    {
        public InVehicle(int value, string name) : base(value, name) { }

        public override string GetCurrentValue(EntityPlayer player)
        {
            return (player.AttachedToEntity != null).ToString();
        }
    }
}
