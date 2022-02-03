/*Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/

using PlayerStatController.Utility;
using StatControllers;

public class CharacterHealth : BindingAlias
{
    public CharacterHealth(int value, string name) : base(value, name)
    {
    }

    public CharacterHealth(int value, string name, string alias) : base(value, name, alias)
    {
    }

    public override string GetCurrentValue(EntityPlayer player, string alias)
    {
        switch (alias)
        {
            case "max":
                return FormatUtil.FormatFloat(player.Stats.Health.Max);
            case "withmax":
                return string.Format("{0}/{1}", player.Health.ToString(), 
                    FormatUtil.FormatFloat(player.Stats.Health.Max).ToString());
            case "percentage":
                return FormatUtil.FormatFloat(player.Stats.Health.ValuePercentUI * 100);
            default: 
                return player.Health.ToString();
        }
    }
}

public class CharacterStamina : BindingAlias
{
    public CharacterStamina(int value, string name) : base(value, name)
    {
    }

    public CharacterStamina(int value, string name, string alias) : base(value, name, alias)
    {
    }

    public override string GetCurrentValue(EntityPlayer player, string alias)
    {
        switch (alias)
        {
            case "max":
                return FormatUtil.FormatFloat(player.Stats.Stamina.Max);
            case "withmax":
                return string.Format("{0}/{1}", 
                    FormatUtil.FormatFloat(player.Stamina), 
                    FormatUtil.FormatFloat(player.Stats.Stamina.Max));
            case "percentage":
                return FormatUtil.FormatFloat(player.Stats.Stamina.ValuePercentUI * 100);
            default:
                return FormatUtil.FormatFloat(player.Stamina);
        }
    }
}

public class CharacterFood : BindingAlias
{
    public CharacterFood(int value, string name) : base(value, name)
    {
    }

    public CharacterFood(int value, string name, string alias) : base(value, name, alias)
    {
    }

    public override string GetCurrentValue(EntityPlayer player, string alias)
    {
        switch (alias)
        {
            case "max":
                return FormatUtil.FormatFloat(player.Stats.Food.Max);
            case "withmax":
                return string.Format("{0}/{1}", 
                    FormatUtil.FormatRoundingFloat(player.Stats.Food.Value), 
                    FormatUtil.FormatFloat(player.Stats.Food.Max));
            case "percentage":
                return FormatUtil.FormatRoundingFloat(player.Stats.Food.ValuePercentUI * 100);
            default:
                return FormatUtil.FormatRoundingFloat(player.Stats.Food.Value);
        }
    }
}

public class CharacterWater : BindingAlias
{
    public CharacterWater(int value, string name) : base(value, name)
    {
    }

    public CharacterWater(int value, string name, string alias) : base(value, name, alias)
    {
    }

    public override string GetCurrentValue(EntityPlayer player, string alias)
    {
        switch (alias)
        {
            case "max":
                return FormatUtil.FormatFloat(player.Stats.Water.Max);
            case "withmax":
                return string.Format("{0}/{1}", 
                    FormatUtil.FormatRoundingFloat(player.Water), 
                    FormatUtil.FormatFloat(player.Stats.Water.Max));
            case "percentage":
                return FormatUtil.FormatRoundingFloat(player.Stats.Water.ValuePercentUI * 100);
            default:
                return FormatUtil.FormatRoundingFloat(player.Water);
        }
    }
}