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

public class BagUsedSlots : Binding
{
    public BagUsedSlots(int value, string name) : base(value, name)
    {
    }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return player.bag.GetUsedSlotCount().ToString();
    }
}

public class BagCarryCapacity : Binding
{
    public BagCarryCapacity(int value, string name) : base(value, name)
    {
    }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return MathUtils.Min(player.bag.MaxItemCount, player.bag.SlotCount).ToString();
    }
}

public class BagMaxCarryCapacity : Binding
{
    public BagMaxCarryCapacity(int value, string name) : base(value, name)
    {
    }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return player.bag.MaxItemCount.ToString();
    }
}

public class BagSize: Binding
{
    public BagSize(int value, string name) : base(value, name)
    {
    }

    public override string GetCurrentValue(EntityPlayer player)
    {
        return player.bag.SlotCount.ToString();
    }
}
