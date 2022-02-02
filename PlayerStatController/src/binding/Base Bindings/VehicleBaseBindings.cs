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

namespace StatControllers
{
    public abstract class VehicleBinding : Binding
    {
        protected VehicleBinding(int value, string name) : base(value, name)
        {
        }

        public override sealed string GetCurrentValue(EntityPlayer player)
        {
            EntityVehicle vehicle = player.AttachedToEntity as EntityVehicle;
            if (vehicle != null)
            {
                return GetCurrentValue(vehicle);
            }
            else
            {
                return "";
            }
        }

        public override sealed bool HasValueChanged(EntityPlayer player, ref string lastValue)
        {
            EntityVehicle vehicle = player.AttachedToEntity as EntityVehicle;
            if (vehicle != null)
            {
                return HasValueChanged(vehicle, ref lastValue);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the current value of the <see cref="VehicleBinding"/> to bind to the XML
        /// </summary>
        /// <param name="vehicle">The <see cref="EntityVehicle">player</see> the stat value belongs to</param>
        /// <returns>The value to bind to the XML</returns>
        public abstract string GetCurrentValue(EntityVehicle vehicle);

        /// <summary>
        /// Determines if the value for the <see cref="VehicleBinding"/> has been updated and sets the last value in if it has been updated
        /// </summary>
        /// <param name="player">The <see cref="EntityVehicle">player</see> the stat value belongs to</param>
        /// <param name="lastValue">The value for the <see cref="VehicleBinding"/> since it was last checked to see if it has been updated<br/>
        /// If last value has been found to be changed, the new updated value will be sent back in this <see langword="ref"/></param>
        /// <returns><see langword="true"/> if the value has changed, otherwise <see langword="false"/></returns>
        public virtual bool HasValueChanged(EntityVehicle vehicle, ref string lastValue)
        {
            string currentValue = GetCurrentValue(vehicle);
            bool changed = lastValue != currentValue;
            lastValue = currentValue;
            return changed;
        }
    }

    public abstract class VehicleBindingAlias : BindingAlias
    {
        protected VehicleBindingAlias(int value, string name) : base(value, name)
        {
        }

        public override sealed string GetCurrentValue(EntityPlayer player, string alias)
        {
            EntityVehicle vehicle = player.AttachedToEntity as EntityVehicle;
            if (vehicle != null)
            {
                return GetCurrentValue(vehicle, alias);
            }
            else
            {
                return "";
            }
        }

        public override sealed bool HasValueChanged(EntityPlayer player, string alias, ref string lastValue)
        {
            EntityVehicle vehicle = player.AttachedToEntity as EntityVehicle;
            if (vehicle != null)
            {
                return HasValueChanged(vehicle, alias, ref lastValue);
            }
            else
            {
                return false;
            }
        }

        public abstract string GetCurrentValue(EntityVehicle vehicle, string alias);

        public virtual bool HasValueChanged(EntityVehicle vehicle, string alias, ref string lastValue)
        {
            string currentValue = GetCurrentValue(vehicle, alias);
            bool changed = lastValue != currentValue;
            lastValue = currentValue;
            return changed;
        }
    }
}
