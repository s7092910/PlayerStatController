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