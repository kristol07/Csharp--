# Question Set about C# Language
- [Question Set about C# Language](#question-set-about-c-language)
  - [`readonly` vs `const`](#readonly-vs-const)

## `readonly` vs `const`

- `const`常量局限于数字和字符串类型，而`readonly`常量可以任何类型。
- `const`常量相当于一个数字或字符串的别名，在代码编译后`const`常量的位置被数字或字符串取代了；而`readonly`常量的引用依然存在，这样做的好处就是当当前程序集中的常量处理操作改变时，对其存在引用的其他程序集中无需重新编译，因为编译后的结果是不变的，而对于const常量来说，则需要重新编译，因为需要修改为新的值。
  - 这类似于书上对于使用属性还是公共字段的代码实践推荐 p97
- 使用`const`常量的好处就是速度，但丢失了`readonly`常量的灵活性。在代码版本更新过程中不会发生改变的变量可以使用`const`。

---

[What is the difference between const and readonly in C#?](https://stackoverflow.com/a/56024)

Consider a class defined in `AssemblyA`.

```csharp
public class Const_V_Readonly
{
  public const int I_CONST_VALUE = 2;
  public readonly int I_RO_VALUE;
  public Const_V_Readonly()
  {
     I_RO_VALUE = 3;
  }
}
```
`AssemblyB` references `AssemblyA` and uses these values in code. When this is compiled,

  in the case of the `const` value, it is like a find-replace, the value 2 is 'baked into' the `AssemblyB`'s IL. This means that if tomorrow I'll update `I_CONST_VALUE` to 20 in the future. `AssemblyB` would still have 2 till I recompile it.
  in the case of the `readonly` value, it is like a ref to a memory location. The value is not baked into `AssemblyB`'s IL. This means that if the memory location is updated, `AssemblyB` gets the new value without recompilation. So if `I_RO_VALUE` is updated to 30, you only need to build `AssemblyA`. All clients do not need to be recompiled.

So if you are confident that the value of the constant won't change use a `const`.

```csharp
public const int CM_IN_A_METER = 100;
```

But if you have a constant that may change (e.g. w.r.t. precision).. or when in doubt, use a `readonly`.


```csharp
public readonly float PI = 3.14;
```

---

\<Effective Csharp\> Item 2

Compile-time constants are limited to numbers and strings.
Runtime constants can be any type. 
You must initialize them in a constructor, or you can use an initializer. 
You can make `readonly` values of the `DateTime` structures; you cannot create `DateTime` values with `const`.

The IL generated when you reference a `readonly` constant references the `readonly` variable, not the value.
Compile-time constants generate the same IL as though you’ve used the numeric constants in your code, even across assemblies: A constant in one assembly is still replaced with the value when used in another assembly.

Updating the value of a public constant should be viewed as an interface change.
You must recompile all code that references that constant. 
Updating the value of a read-only constant is an implementation change; it is binary compatible with existing client code.

The final advantage of using `const` over `readonly` is performance: Known constant values can generate slightly more efficient code than the variable accesses necessary for `readonly` values. 
However, any gains are slight and should be weighed against the decreased flexibility. 
Be sure to profile performance differences before giving up the flexibility.

--- 

[Const vs Static vs Readonly in C#](https://exceptionnotfound.net/const-vs-static-vs-readonly-in-c-sharp-applications/)

- If you know the value will never, ever, ever change for any reason, use `const`.
- If you're unsure of whether or not the value will change, but you don't want other classes or code to be able to change it, use `readonly`.
- If you need a field to be a property of a type, and not a property of an instance of that type, use `static`.
A `const` value is also implicitly `static`.