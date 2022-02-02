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

/// <summary>
/// Base clase for BindingType so BindingType has enum like characteristics
/// </summary>
public abstract class Enumeration : IComparable
{
    private readonly int value;
    private readonly string name;

    protected Enumeration(int value, string name)
    {
        this.value = value;
        this.name = name.ToLower();
    }

    public int Value
    {
        get { return value; }
    }

    public string Name
    {
        get { return name; }
    }

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object obj)
    {
        var otherValue = obj as Enumeration;

        if (otherValue == null)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = value.Equals(otherValue.Value);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode()
    {
        return value.GetHashCode();
    }

    protected static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
    {
        var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
        return absoluteDifference;
    }

    public int CompareTo(object other)
    {
        return Value.CompareTo(((Enumeration)other).Value);
    }
}
