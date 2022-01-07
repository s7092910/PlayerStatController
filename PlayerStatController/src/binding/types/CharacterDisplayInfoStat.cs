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

public class CharacterDisplayInfoStat : BindingType
{
    protected DisplayInfoEntry displayInfoEntry;
    private int displayInfoIndex;

    public CharacterDisplayInfoStat(int value, string name, int displayInfoIndex) : base(value, name)
    {
        this.displayInfoIndex = displayInfoIndex;
    }

    public override string GetCurrentValue(EntityPlayer player)
    {
        if (displayInfoEntry == null)
        {
            displayInfoEntry = GetStatEntry(displayInfoIndex);

            if (displayInfoEntry == null)
            {
                var message = string.Format("{0} does not have a supported Character Display Info Entry", Name);
                Logging.Out(this.GetType().ToString(), message);
                return "";
            }

            var mess = string.Format("DisplayInfoEntry found for bindingName {0} with a title of {1}",
                Name, UIDisplayInfoManager.Current.GetLocalizedName(displayInfoEntry.StatType));
            Logging.Out(this.GetType().ToString(), mess);

            return XUiM_Player.GetStatValue(displayInfoEntry.StatType, player, displayInfoEntry);
        }
        return XUiM_Player.GetStatValue(displayInfoEntry.StatType, player, displayInfoEntry); ;
    }

    protected DisplayInfoEntry GetStatEntry(int index)
    {
        var displayInfoList = UIDisplayInfoManager.Current.GetCharacterDisplayInfo();
        if (displayInfoList.Count <= index)
        {
            return null;
        }
        return displayInfoList[index];
    }
}