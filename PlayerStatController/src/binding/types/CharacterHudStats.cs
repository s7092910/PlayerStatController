/*Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/

using StatControllers;

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

public class CharacterFood : CharacterMainStat
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