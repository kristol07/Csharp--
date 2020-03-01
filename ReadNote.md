# C# 图解教程
- [C# 图解教程](#c-%e5%9b%be%e8%a7%a3%e6%95%99%e7%a8%8b)
  - [Chapter 5: 方法](#chapter-5-%e6%96%b9%e6%b3%95)
    - [本地变量](#%e6%9c%ac%e5%9c%b0%e5%8f%98%e9%87%8f)
      - [`var`关键字](#var%e5%85%b3%e9%94%ae%e5%ad%97)
    - [本地常量](#%e6%9c%ac%e5%9c%b0%e5%b8%b8%e9%87%8f)
    - [方法参数](#%e6%96%b9%e6%b3%95%e5%8f%82%e6%95%b0)
      - [形参 vs 实参](#%e5%bd%a2%e5%8f%82-vs-%e5%ae%9e%e5%8f%82)
      - [值参数](#%e5%80%bc%e5%8f%82%e6%95%b0)
      - [引用参数](#%e5%bc%95%e7%94%a8%e5%8f%82%e6%95%b0)
      - [输出参数](#%e8%be%93%e5%87%ba%e5%8f%82%e6%95%b0)
      - [参数数组](#%e5%8f%82%e6%95%b0%e6%95%b0%e7%bb%84)
      - [命名参数](#%e5%91%bd%e5%90%8d%e5%8f%82%e6%95%b0)
      - [可选参数](#%e5%8f%af%e9%80%89%e5%8f%82%e6%95%b0)
    - [方法重载](#%e6%96%b9%e6%b3%95%e9%87%8d%e8%bd%bd)
  - [Chapter 6: 深入理解类](#chapter-6-%e6%b7%b1%e5%85%a5%e7%90%86%e8%a7%a3%e7%b1%bb)
    - [静态类成员和常量成员](#%e9%9d%99%e6%80%81%e7%b1%bb%e6%88%90%e5%91%98%e5%92%8c%e5%b8%b8%e9%87%8f%e6%88%90%e5%91%98)
    - [属性](#%e5%b1%9e%e6%80%a7)
    - [构造函数](#%e6%9e%84%e9%80%a0%e5%87%bd%e6%95%b0)
    - [析构函数](#%e6%9e%90%e6%9e%84%e5%87%bd%e6%95%b0)
    - [`readonly`修饰符](#readonly%e4%bf%ae%e9%a5%b0%e7%ac%a6)
    - [`this`关键字](#this%e5%85%b3%e9%94%ae%e5%ad%97)
    - [索引器](#%e7%b4%a2%e5%bc%95%e5%99%a8)
      - [访问器的访问修饰符限制](#%e8%ae%bf%e9%97%ae%e5%99%a8%e7%9a%84%e8%ae%bf%e9%97%ae%e4%bf%ae%e9%a5%b0%e7%ac%a6%e9%99%90%e5%88%b6)
    - [分部类和分部方法](#%e5%88%86%e9%83%a8%e7%b1%bb%e5%92%8c%e5%88%86%e9%83%a8%e6%96%b9%e6%b3%95)
  - [Chapter 7: 类和继承](#chapter-7-%e7%b1%bb%e5%92%8c%e7%bb%a7%e6%89%bf)
    - [类继承](#%e7%b1%bb%e7%bb%a7%e6%89%bf)
    - [屏蔽基类成员](#%e5%b1%8f%e8%94%bd%e5%9f%ba%e7%b1%bb%e6%88%90%e5%91%98)
      - [基类访问：关键字`base`](#%e5%9f%ba%e7%b1%bb%e8%ae%bf%e9%97%ae%e5%85%b3%e9%94%ae%e5%ad%97base)
    - [使用基类的引用](#%e4%bd%bf%e7%94%a8%e5%9f%ba%e7%b1%bb%e7%9a%84%e5%bc%95%e7%94%a8)
      - [虚方法和覆写方法：`virtual` & `override`](#%e8%99%9a%e6%96%b9%e6%b3%95%e5%92%8c%e8%a6%86%e5%86%99%e6%96%b9%e6%b3%95virtual--override)
      - [覆写标记为`override`的方法](#%e8%a6%86%e5%86%99%e6%a0%87%e8%ae%b0%e4%b8%baoverride%e7%9a%84%e6%96%b9%e6%b3%95)
    - [构造函数的执行](#%e6%9e%84%e9%80%a0%e5%87%bd%e6%95%b0%e7%9a%84%e6%89%a7%e8%a1%8c)
    - [成员访问修饰符](#%e6%88%90%e5%91%98%e8%ae%bf%e9%97%ae%e4%bf%ae%e9%a5%b0%e7%ac%a6)
      - [程序集间的继承](#%e7%a8%8b%e5%ba%8f%e9%9b%86%e9%97%b4%e7%9a%84%e7%bb%a7%e6%89%bf)
    - [抽象成员和抽象类](#%e6%8a%bd%e8%b1%a1%e6%88%90%e5%91%98%e5%92%8c%e6%8a%bd%e8%b1%a1%e7%b1%bb)
      - [密封类](#%e5%af%86%e5%b0%81%e7%b1%bb)
    - [静态类](#%e9%9d%99%e6%80%81%e7%b1%bb)
    - [扩展方法](#%e6%89%a9%e5%b1%95%e6%96%b9%e6%b3%95)
    - [命名约定](#%e5%91%bd%e5%90%8d%e7%ba%a6%e5%ae%9a)
  - [Chapter 15: 接口](#chapter-15-%e6%8e%a5%e5%8f%a3)
    - [接口的作用](#%e6%8e%a5%e5%8f%a3%e7%9a%84%e4%bd%9c%e7%94%a8)
    - [接口的声明](#%e6%8e%a5%e5%8f%a3%e7%9a%84%e5%a3%b0%e6%98%8e)
    - [接口的实现](#%e6%8e%a5%e5%8f%a3%e7%9a%84%e5%ae%9e%e7%8e%b0)
    - [接口是引用类型](#%e6%8e%a5%e5%8f%a3%e6%98%af%e5%bc%95%e7%94%a8%e7%b1%bb%e5%9e%8b)
      - [`as`运算符](#as%e8%bf%90%e7%ae%97%e7%ac%a6)
    - [接口可以继承接口](#%e6%8e%a5%e5%8f%a3%e5%8f%af%e4%bb%a5%e7%bb%a7%e6%89%bf%e6%8e%a5%e5%8f%a3)
  - [Chapter 16: 转换](#chapter-16-%e8%bd%ac%e6%8d%a2)
    - [隐式转换 vs 显式/强制转换](#%e9%9a%90%e5%bc%8f%e8%bd%ac%e6%8d%a2-vs-%e6%98%be%e5%bc%8f%e5%bc%ba%e5%88%b6%e8%bd%ac%e6%8d%a2)
    - [装箱转换 vs 拆箱转换](#%e8%a3%85%e7%ae%b1%e8%bd%ac%e6%8d%a2-vs-%e6%8b%86%e7%ae%b1%e8%bd%ac%e6%8d%a2)
    - [用户自定义转换](#%e7%94%a8%e6%88%b7%e8%87%aa%e5%ae%9a%e4%b9%89%e8%bd%ac%e6%8d%a2)
      - [多步用户自定义转换](#%e5%a4%9a%e6%ad%a5%e7%94%a8%e6%88%b7%e8%87%aa%e5%ae%9a%e4%b9%89%e8%bd%ac%e6%8d%a2)
    - [`is`和`as`运算符](#is%e5%92%8cas%e8%bf%90%e7%ae%97%e7%ac%a6)

## Chapter 5: 方法

### 本地变量

- 没有隐式初始化，在使用前须被赋值
- 值类型存储在栈；引用类型的引用存储在栈，数据存储在堆
- 不能再第一个名称的有效范围内声明另一个同名的本地变量

本地变量 vs 实例字段 表格5-1 p51

#### `var`关键字

类型推断，只是句法上的速记，不是特殊类型变量的符号。
- 用于本地变量而不能用于字段
- 在变量声明包含初始化时使用
- 编译器推断出变量类型后便不能更改

### 本地常量

与本地变量类似，只是一旦被初始化，值就不能改变。类型前添加`const`关键字。
- 在声明时必须初始化
- 声明后不能改变

成员常量 -> p90

### 方法参数

#### 形参 vs 实参

- 形参是本地变量，声明在方法的参数列表中，而不是方法体中。
  - 除了输出参数，其在方法体外定义，并在方法开始前初始化
- 实参是用于初始化形参的表达式或变量，位于方法调用的参数列表
  - 方法调用时，每个实参的值被用于初始化相应的形参，方法体随后被执行

#### 值参数

通过将实参（变量或表达式）的**值复制**给形参的方式把数据传递给方法
- 如果实参是值类型，则值被复制给形参。
- 如果实参是引用类型，则引用被复制。
  - 如果方法内形参被赋值新的引用，则和实参的内存空间失去了联系

#### 引用参数

在方法的声明和调用中都使用`ref`修饰符
- 实参必须是变量
- 形参的参数名**作为实参变量的别名**，指向相同的内存位置 => 关系还在，无论实参是什么类型。
  - 如果方法内形参被赋值新的引用，则实参对应的内存空间也跟着换了地址。

#### 输出参数

用于从方法体内把数据传出到调用代码。在声明和调用中都使用`out`修饰符
- 实参必须是变量
- 形参担当实参的别名
- 在方法内部，输出参数在能够被读取前必须被赋值
- 在方法返回之前，方法内部贯穿的任何可能路径都必须为所有输出参数进行一次赋值

#### 参数数组

允许零个或多个实参对应一个特殊的形参。
- 一个参数列表中只能有一个参数数组
- 如果有，必须是列表的最后一个
- 参数数组中的所有参数必须是相同类型

```csharp
void ListInts( params int[] inVals){
  ...
}
```

在声明中需要修饰符，在调用中不允许有修饰符。


#### 命名参数

实参无需和形参位置一一对应，只需显式指定参数的名字。

在方法调用中：
- 使用这样的格式 `形参名:实参`。
- 在位置参数和命名参数的混合使用中，位置参数须先列出。

#### 可选参数

在方法声明时为参数提供默认值，在方法调用时则可省略它。

注意：
- 只有值类型，和引用类型默认值为null时才可作为可选参数
- 方法声明中，必填参数必须在可选参数之前，而params参数必须在可选参数之后
- 方法调用中的参数省略时从最后开始的。

### 方法重载

一个类可以有一个以上的方法拥有相同名称，只需有不同的方法签名。

方法签名： **返回类型不是**方法签名的一部分
- 方法名称
- 参数数目
- 参数数据类型和顺序
- 参数修饰符




## Chapter 6: 深入理解类

类成员声明语句：[特性] [修饰符：`private`/`public`/...] 核心声明

### 静态类成员和常量成员

类成员可以关联到：
- 一个实例：实例类成员，每个实例有自己的类成员副本，互不影响
- 类的整体：`static` => 静态类成员，和类名绑定 (ex: `Math.PI`)。 （表6-2 p89）
  - 被类的所有实例共享，所有实例都访问同一内存位置

成员常量：`const` 
- 常量必须声明在类型内
- 表现地像静态值，对类的每个实例都是“可见的”，即使没有类的实例也可以使用。
- 与静态量不同，没有自己的存储位置
    - 在编译时被编译器替代。类似c和c++中的`#define`值。
    - 不能声明为`static`

### 属性

- 语法和字段类似，但为函数成员，不分配内存，而执行代码
- 带访问器 (`set`、`get`) 的方法，但不能显式调用（`.get()` => error!）
    - `set`访问器：带有一个隐式值参`value`
- 属性与公共字段在编译后的语义不同，改变属性的实现不用再重新编译访问它的其他程序集（p97）
- 自动实现属性 auto-implemented poperty
    - 编译器自动创建隐藏的后备字段，并自动挂载到get和set访问器上
    - 不能提供访问器的方法体，必须简单声明为分号，即：`set; get;` 
    - 必须同时提供读写访问器，只读或只写属性没有意义，其他方法不能访问该隐藏后备字段

```csharp
class Test
{
    public int MyValue
    {
        set; get;
    }
}
```

### 构造函数

- 实例构造函数：初始化每个新实例
    - 名称和类名相同，无返回值，可被重载(`this`访问器)
    - 隐式的默认构造函数只在无自定义的显式构造函数时才会被编译器创建。
- 静态构造函数： 初始化类级别的项，如类的静态字段
    - 只能有一个，且不能有访问修饰符
    - p104的问题？？？

### 析构函数 

p105 ？？？

### `readonly`修饰符

- 可在任意位置设置它的值，对比`const`字段只能在字段声明语句中初始化
- 可在运行时决定值，对比`const`字段值必须在编译时决定
- 内存中有自己的存储位置，既可以是实例字段，也可以是静态字段，对比`const`的行为总是静态的


`readonly` vs `const`

Ref: https://stackoverflow.com/a/56024 and \<Effective Csharp\> Item 2

- `const`常量局限于数字和字符串类型，而`readonly`常量可以任何类型。
- `const`常量相当于一个数字或字符串的别名，在代码编译后`const`常量的位置被数字或字符串取代了；而`readonly`常量的引用依然存在，这样做的好处就是当当前程序集中的常量处理操作改变时，对其存在引用的其他程序集中无需重新编译，因为编译后的结果是不变的，而对于const常量来说，则需要重新编译，因为需要修改为新的值。
  - 这类似于书上对于使用属性还是公共字段的代码实践推荐 p97
- 使用`const`常量的好处就是速度，但丢失了`readonly`常量的灵活性。在代码版本更新过程中不会发生改变的变量可以使用`const`。

---

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

### `this`关键字

对当前实例的引用 => say no to 静态成员

出现的地方
- 实例构造函数
- 实例方法
- 属性和索引器的实例访问器

### 索引器

实现像数组一样访问多个字段
- 一组`get`和`set`访问器 => 和属性的类似性
- 和属性的不同：声明中有一组参数列表，使用`this`引用而不是名称
- 索引器重载：只要参数列表不同即可

```csharp
ReturnType this [Type param1, ...]
{
    get
    {
        ...
    }
    set
    {
        ...
    }
}
```

#### 访问器的访问修饰符限制

- 同时有`get`和`set`访问器时才能加访问修饰符
- 访问器必须同时出现，但却只能给一个加访问修饰符
- 加的访问修饰符的访问级别要比成员的级别更严格（p115 访问修饰符级别）

### 分部类和分部方法

p116 ？？？


## Chapter 7: 类和继承

### 类继承

```csharp
class OtherClass : SomeClass
{
    ...
}
```

所有类都派生自`object`类。
没有基类规格说明的类隐式地直接派生自类`object`

一个类声明的基类规格说明中只能有一个单独的类。
不过继承的层次是没有限制的。

### 屏蔽基类成员

派生类不能删除继承的任何成员，但可以名称相同的成员来屏蔽基类成员。
- 数据成员：相同类型，相同名称
- 函数成员：相同签名（名称和参数列表，不包括返回类型）
- 为了让编译器知道你在故意屏蔽，可以加上`new`修饰符
- 也可以屏蔽静态成员

#### 基类访问：关键字`base`

用于访问被隐藏的继承成员。

使用过多，很可能说明程序需要更好的设计。

### 使用基类的引用

派生类的引用指向整个类对象，包括基类部分。

如果有一个派生类对象的引用，就可以获取该对象基类部分的引用，并用类型转换运算符转换成基类类型。
=> 这样基类部分的引用看到的是自身部分的实现 #label[上一个问题]

#### 虚方法和覆写方法：`virtual` & `override`

使用基类引用调用派生类的方法 => 解决#ref[上一个问题]
- 基类方法用`virtual`标注
- 派生类方法用`override`标注

注意：
- 不能覆写`static`方法或非虚方法
- 覆写和被覆写的方法必须有相同的可访问性

#### 覆写标记为`override`的方法

对对象基类部分的引用调用覆写的方法，其要追溯到最高的派生级别
=> 理解：从`virtual`开始找到距离它最远的`override`方法
Examples：p128-p129

### 构造函数的执行

默认情况下，将调用基类的无参数构造函数。
若要指定，则可以使用`base`关键字。
对于当前类的指定，可以使用`this`关键字。

如果有多个构造函数，公共代码可以提取出来作为一个构造函数，供其他构造函数使用（借助`this`）。p133


### 成员访问修饰符

表7-1 p140
- `public`
- `private`: 只能同一个类里的代码
- `protected`：同一类或者派生类
- `internal`：同一程序集
- `protected internal`：同一程序集或者派生类

#### 程序集间的继承

`internal`类访问修饰符：同程序集内(namespace?)的类才能看到

跨程序集：
- 基类必须为`public`
- 在vs中的References节点添加对包含基类程序集的引用
- 在代码中为了更方便引用，可在源文件顶部放置`using`指令

### 抽象成员和抽象类

抽象成员是指设计为被覆写的函数成员，只能在抽象类中声明
- 必须为函数成员：方法、属性、事件、索引
- `abstract`修饰符标记
- 不能有实现代码。用**分号**替换实现。
- 在派生类中必须用相应成员覆写，指定`override`修饰符

表7-3 比较虚成员和抽象成员 p141

抽象类只能被用作其他类的基类，使用`abstract`声明。
- 不能实例化
- 可包含抽象成员或普通非抽象成员
- 可派生自另外的抽象类
- 派生自抽象类的派生类必须用`override`关键字实现该抽象类所有抽象成员，除非这个派生类自己也是抽象类

#### 密封类

和抽象类相反，只能被用作独立的类，不能被用作基类。

用`sealed`修饰符标注。

### 静态类

静态类中所有成员都是静态的，用于存放不受实例数据影响的数据和函数。
常见用途如创建包含数学方法和值的数据库。

- 本身用`static`标记
- 所有成员都是静态的
- 隐式密封，不能被继承

### 扩展方法

允许编写的方法和声明它的类之外的类关联，在类的实例上调用该方法。
=> 为一个写好/不能修改源代码的类添加新的方法 `Class.NewMethod()`

- 声明扩展方法的类必须声明为`static`
- 扩展方法本身必须声明为`static`
- 扩展方法必须包含关键字`this`作为它的第一个参数类型，并在后面跟着它所扩展的类的名称

```csharp
static class ExtendMyData
{
    public static double Average(this MyData md)
    {
        ...
    }
}
```

### 命名约定

名称要用全拼并有意义。
方法一般是动词或动宾。
类、变量、参数一般是名词。

- Pascal大小写，如 ProductType
  - 命名空间
  - 类型名称
  - 方法
  - 属性
  - 公共字段
- Camel大小写，如 poductType
  - 局部变量名称
  - 方法声明的形参名称
  - 私有和受保护的字段


## Chapter 15: 接口

接口是指定一组**函数成员**（非静态成员函数）而**不实现它们**的**引用**类型。
- 方法
- 属性
- 事件
- 索引器


### 接口的作用

=> 理解：
- 不同类实现相同接口，即有了相同名称但不同实现的方法；
- 其他类通过利用接口引用，就可以用同样的代码实现不同类的方法。
  - 通常是`Method(IInterface interface)`的形式

例如：`Array.sort(ClassName)`
- 这个类必须要实现`IComparable`接口，接口中包含`CompareTo`方法。
- 实际上真正的形式是Array下的Sort方法的形参是`IComparable`接口，即`void Sort(IComparable SomeArray)`


### 接口的声明

- 接口声明可以有任何的访问修饰符
- 但**接口成员不能有任何访问修饰符**，是隐式`public`的。

```csharp
public interface IInterfaceName
{
  returnType1 Method1(...);
  returnType1 Method2(...);
  ...;
}
```

### 接口的实现

- 在基类列表后列出接口名称
   - 如果从基类继承，由于只能有一个基类，列出的其他类型必须为接口名
   - 逗号分隔
- 为接口的**每一个**成员都提供实现
  - 实现接口的类可以从它的基类继承实现的代码
  - 如果其中一些接口有相同的签名和返回类型的成员
    - 类可以实现单个成员来满足所有包含重复成员的接口
    - 要为每个接口分离实现，则可以创建显示接口成员实现（添加限定接口名称，`接口成员.成员名称`）
      - 这样的实现只能通过指向接口的引用来访问，即便同类下的其他成员也无法直接访问实现。 p283


注意，只有类和结构能实现接口。
- 接口只包含函数成员，所以只有类和结构可以；
- 枚举类型不能有函数成员，所以不可以；

### 接口是引用类型

将类对象引用强制转换为类未实现的接口的引用 => 目的？作用？ <-p283?

p285 代码： 为何在Cat和Dog中接口的实现要显式？

#### `as`运算符

- 如果类实现了接口，表达式返回指向接口的引用
- 如果类没有实现接口，表达式返回null而不是抛出异常

```csharp
ILiveBirth b = a as IliveBirth;
```

### 接口可以继承接口

...

## Chapter 16: 转换

### 隐式转换 vs 显式/强制转换

隐式转换
- 无符号类型：零扩展
- 有符号类型：符号扩展，额外的高位用源表达式符号位填充

显式转换：可能引起数据丢失
- 溢出检测 `OverflowException`： 运算符 `checked`, `unchecked` 
- `InvalidCastException`

### 装箱转换 vs 拆箱转换

装箱转换： 值类型 => 对象组件
- 隐式转换，接收值类型的值，在堆上创建一个完整的引用类型对象并返回对象引用。
- 创建副本，与原始值断开联系

拆箱转换：
- 显式转换，装箱转换的逆操作

### 用户自定义转换

`public static` + `implicit`/`explicit`

```csharp
public static implicit operator TargetType ( SourceType Identifier)
{
  ...
  return ObjectOfTargetType;
}
```

注意：
- 不能重定义标准隐式或显式转换
- 只可以为类和结构定义用户自定义转换
- 源类型S和目标类型T
  - S和T必须是不同类型
  - S和T不能通过继承关联
  - S和T都不能是接口类型或`object`类型


#### 多步用户自定义转换

用户自定义转换在完整转换链中最多出现一次。 p304

### `is`和`as`运算符

`is`运算符:
检查转换是否会成功完成，避免盲目尝试转换。=> `bool`
- 引用转换
- 装箱、拆箱转换
- 不能用于用户自定义转换

```csharp
Expr is TargetType
```

`as`运算符:
转换失败返回null而不是抛出异常。
- 引用转换
- 装箱转换
- 不能用于用户自定义转换或到值类型的转换

\<Effective Csharp\> Item3: Prefer the `is` or `as` Operators to Casts

