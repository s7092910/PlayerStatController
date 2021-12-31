# Adding a new XML binding

One of the features of the **PlayerStatController** is that it is possible to add a new
XML binding if the controller doesn't have a XML binding that gets a value you want
for your mod.

Follow the steps in the in the [README.md](../README.md) on how to include the Controller
in your mod.

## Setting up the development environment

You can follow the [tutorial videos](https://www.youtube.com/playlist?list=PLJeCuPbkcF5RhAOkX7ghThq7hIfZ5Ypgj) that shows up to use Visual Studios to set up your environment to start creation of your own DLL.

Once you have your development environment setup, add the **PlayerStatController.dll** as a reference to your mod's project like you did with the other DLLs from 7 Days to Die game files.

## Creating the binding class

To start with adding a new binding, a new class is required that extends `BindingType`.

```C#
public class YourClass : BindingType
```

With extending `BindingType`, you will be required to add a base constructor. The constructor will
pass a `int` value and a `string`.

```C#
public YourClass(int value, string name) : base(value, name) { }
```

The `int` is the binding's id number. This can any number so long as it is unique. It is recommended to use a number that
is 300 or higher as the **PlayerStatController** reserves use of 1-299 for the base supported XML bindings. If a non
unique number is used, it might cause issues with XML binding can be updated if the value is changed.

The `string` is the binding name. It is the value inbetween the `{}` in the XML that the controller uses to determine it
should use this class to fetch the value to bind. For example, the XML binding `{PlayerLevel}`, its binding name is
PlayerLevel`. The binding name also has to be unique.

### Creating the `GetCurrentValue` method

Next we have to fetch the value to bind to the XML. This is done by overriding the `GetCurrentValue(EntityPlayer player)`
method.

```C#
public override string GetCurrentValue(EntityPlayer player)
{
    return (The current value);
}
```

`GetCurrentValue` is called to retrieve the current value that is to be bound to the XML.
The `EntityPlayer player` is the player's character, it isn't required to be used in the method to get the
binding value, but it is there if you need access to the player's EntityPlayer instance.

The return value is a `string` and is used to return the value that will be bound to the XML. Any formatting is required
it is suggested to be done inside this method and the formatted `string` be returned.


### Creating the `HasValueChanged` method - Optional

This is optional if you want to control how it is determined if the binding value has been changed. This is done by overriding
`HasValueChanged(EntityPlayer player, ref string lastValue)` method.

```C#
public override bool HasValueChanged(EntityPlayer player, ref string lastValue)
{
    return true | false;
}
```

`HasValueChanged` is called to check to see if the binding value has changed. As with `GetCurrentValue`, the
`EntityPlayer player` is the player's character. The `ref string lastValue` is the last bound value to check against
if the binding value has changed. `HasValueChanged` returns true if the binding value has changed and the binding needs to be
updated. Return false if the binding value hasn't changed. If the binding value has changed. `lastValue` needs to be set to
the new value.


## Adding the new Binding

Once you have created the class that handles getting the new value, you need to add that class to the supported bindings, so
it can be discovered by the controller. This is done creating a new class that will extend `IModApi` and implementing the
`InitMod` method.

```C#
public class YourClassInit : IModApi
{
    public void InitMod(Mod _modInstance)
    {
        BindingType.AddNewBinding(new YourClass(300, "YourBindingName"));
     }
}
```

`BindingType` has a method,`AddNewBinding`, that allows you to add your new binding class that exposes that instance to the controller. Create an instance of your binding class and pass it in to the `AddNewBinding` method.

Once that is done, build your project and add the DLL produced to your mod folder. You now have access to that binding in the
XML with the controller.


## Debugging

The controller does some logging to the 7 Days to Die command console, it is turned off by default. Some of the logging is can
be useful to help debug your new binding. To turn on the the logging to the console, in your `InitMod` method, add the following line to the start of the method

```C#
Logging.enabled = true;
```

## Additonal Information

[Using the Controller in your mod](ControllerUsage.md)

[Examples of the Controller in Action and custom XML bindings](PlayerStatControllerExample/)