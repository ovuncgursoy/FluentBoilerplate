FluentBoilerplate
=================

All official release information / released builds will be located at https://www.nuget.org/packages/FluentBoilerplate/ as a NuGet package.

**This is still an alpha-quality work in progress. This means that things can and will break.**

That said, you're more than welcome to report any bugs you may find, contribute, etc., keeping in mind that the codebase may be changing fairly quickly.

Enjoy!

Getting Started
=================

- Build the source (or get a release from NuGet, if available)
- Reference the built assembly in your project

The Simplest Example
=================

The only namespace you should care about is FluentBoilerplate. Add that to your file's using statements.

```C#
using FluentBoilerplate;
```

Everything is driven from an IContext implementation. You should get one.

```C#
var boilerplate = Boilerplate.New();
```

Doing something within the context is very simple. If you don't want to return a result, you may do this.

```C#
boilerplate.Do(context => /* Take some action */);
```

If you'd like to get a result back, you may do this instead.

```C#
boilerplate.Get<int>(context => /* Take some action that returns an integer */);
```

After you get a result, you may want to use it.

```C#
var text = boilerplate
              .Get<string>(context => /* Take some action that returns a string */)
              .Result;
```

So why is that useful? Those actions can have a contract defined that applies to them.

For example, it might be nice to handle an ArgumentException that might be thrown when doing the action. For this, we need to create a contract.

```C#
boilerplate
    .BeginContract()
         .Handles<ArgumentException>("Top Level", ex => Console.WriteLine(ex.Message))
    .EndContract()
    .Do(context => /* Take some action */);
```

If your call to Do() throws an ArgumentException, it will now be caught and its message written to the console. Just like you would with a try/catch block, you can define any number of exception types and their handlers, and the order they're defined in matches the order in which they're handled.

Contract Examples
=================

You may be saying to yourself "Self, this sounds sort of like Code Contracts", and you wouldn't be wrong. This follows along the same lines, in that it's very often ideal to be able to express pre and post conditions for a given action.

Let's require that a parameter is not null.

```C#
public static void DoSomething(IContext boilerplate, string text)
{
    boilerplate
        .BeginContract()
             .Requires(text != null, "The parameter 'text' must not be null")
        .EndContract()
        .Do(context => /* Take some action */);
}
```

When the call to Do() is performed, the contract will be validated. If the parameter is null, a ContractViolationException will be thrown with the given message.

You're welcome to throw your own exceptions as well.

```C#
public static void DoSomething(IContext boilerplate, string text)
{
    boilerplate
        .BeginContract()
             .Requires(text != null, () => { throw new ArgumentException("text", "The parameter must not be null"); })
        .EndContract()
        .Do(context => /* Take some action */);
}
```


Additional information is forthcoming...

