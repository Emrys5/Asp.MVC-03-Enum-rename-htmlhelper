<div id="cnblogs_post_body">

## 一、需求

我们在开发中经常会遇到一些枚举，而且这些枚举类型可能会在表单中的下拉中，或者单选按钮中会用到等。

![](http://images2015.cnblogs.com/blog/83333/201705/83333-20170527123101669-1427973548.png)

这样用是没问题的，但是用过的人都知道一个问题，就是枚举的**命名问题**，当然有很多人枚举直接中文命名，我是不推荐这种命名规则，因为实在不够友好。

那有没有**可以不用中文命名，而且可以显示中文的方法**呢。答案是肯定的。

## 二、特性解决枚举命名问题

那就是用特性解决命名问题，这样的话既可以枚举用英文命名，显示又可以是中文的，岂不两全其美。

<div class="cnblogs_code">

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

<pre><span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
    <span style="color: #808080;">///</span> <span style="color: #008000;">性别</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
    <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">enum</span> <span style="color: #000000;">Gender
    {</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
        <span style="color: #808080;">///</span> <span style="color: #008000;">女性</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
        [Description(<span style="color: #800000;">"</span><span style="color: #800000;">女性</span><span style="color: #800000;">"</span><span style="color: #000000;">)]
        Female</span> = <span style="color: #800080;">1</span><span style="color: #000000;">,</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
        <span style="color: #808080;">///</span> <span style="color: #008000;">男性</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
        [Description(<span style="color: #800000;">"</span><span style="color: #800000;">男性</span><span style="color: #800000;">"</span><span style="color: #000000;">)]
        Male</span> = <span style="color: #800080;">2</span><span style="color: #000000;">,</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
        <span style="color: #808080;">///</span> <span style="color: #008000;">未知</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
        [Description(<span style="color: #800000;">"</span><span style="color: #800000;">未知</span><span style="color: #800000;">"</span><span style="color: #000000;">)]
        Unknown</span> = <span style="color: #800080;">3</span><span style="color: #000000;">,</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
        <span style="color: #808080;">///</span> <span style="color: #008000;">人妖</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
        [Description(<span style="color: #800000;">"</span><span style="color: #800000;">人妖</span><span style="color: #800000;">"</span><span style="color: #000000;">)]
        Demon</span> = <span style="color: #800080;">4</span> <span style="color: #000000;">}</span></pre>

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

</div>

### 1、新建枚举的特性类

首先我们需要新建枚举的特性，用来描述枚举，这样既可以解决枚举的命名问题，又可以解决枚举的显示问题。

我们在下拉框或者单选按钮上显示各个枚举项，**可能会出现一些排序问题**，所以在枚举的特性上不仅有显示的名称还有排序。

<div class="cnblogs_code">

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

<pre>  <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
    <span style="color: #808080;">///</span> <span style="color: #008000;">枚举特性</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = <span style="color: #0000ff;">false</span>, Inherited = <span style="color: #0000ff;">false</span><span style="color: #000000;">)]</span> <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">class</span> <span style="color: #000000;">DescriptionAttribute : Attribute
    {</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
        <span style="color: #808080;">///</span> <span style="color: #008000;">排序</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
        <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">int</span> Order { <span style="color: #0000ff;">get</span>; <span style="color: #0000ff;">set</span><span style="color: #000000;">; }</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
        <span style="color: #808080;">///</span> <span style="color: #008000;">名称</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
        <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">string</span> Name { <span style="color: #0000ff;">get</span>; <span style="color: #0000ff;">set</span><span style="color: #000000;">; }</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
        <span style="color: #808080;">///</span> <span style="color: #008000;">显示自定义描述名称</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
        <span style="color: #808080;">///</span> <span style="color: #808080;"><param name="name"></span><span style="color: #008000;">名称</span><span style="color: #808080;"></param></span>
        <span style="color: #0000ff;">public</span> DescriptionAttribute(<span style="color: #0000ff;">string</span> <span style="color: #000000;">name)
        {
            Name</span> = <span style="color: #000000;">name;
        }</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
        <span style="color: #808080;">///</span> <span style="color: #008000;">显示自定义名称</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
        <span style="color: #808080;">///</span> <span style="color: #808080;"><param name="name"></span><span style="color: #008000;">名称</span><span style="color: #808080;"></param></span>
        <span style="color: #808080;">///</span> <span style="color: #808080;"><param name="order"></span><span style="color: #008000;">排序</span><span style="color: #808080;"></param></span>
        <span style="color: #0000ff;">public</span> DescriptionAttribute(<span style="color: #0000ff;">string</span> name, <span style="color: #0000ff;">int</span> <span style="color: #000000;">order)
        {
            Name</span> = <span style="color: #000000;">name;
            Order</span> = <span style="color: #000000;">order;
        }

    }</span></pre>

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

</div>

 新建好枚举的特性类以后，我们就可以在枚举的字段上添加自定义的特性Description

<div class="cnblogs_code">

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

<pre><span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
<span style="color: #808080;">///</span> <span style="color: #008000;">性别</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span> 
<span style="color: #0000ff;">public</span> <span style="color: #0000ff;">enum</span> <span style="color: #000000;">Gender
{</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
    <span style="color: #808080;">///</span> <span style="color: #008000;">女性</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
    [Description(<span style="color: #800000;">"</span><span style="color: #800000;">女性</span><span style="color: #800000;">"</span>, <span style="color: #800080;">2</span><span style="color: #000000;">)]
    Female</span> = <span style="color: #800080;">1</span><span style="color: #000000;">,</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
    <span style="color: #808080;">///</span> <span style="color: #008000;">男性</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
    [Description(<span style="color: #800000;">"</span><span style="color: #800000;">男性</span><span style="color: #800000;">"</span>, <span style="color: #800080;">1</span><span style="color: #000000;">)]
    Male</span> = <span style="color: #800080;">2</span><span style="color: #000000;">,</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
    <span style="color: #808080;">///</span> <span style="color: #008000;">未知</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
    [Description(<span style="color: #800000;">"</span><span style="color: #800000;">未知</span><span style="color: #800000;">"</span>, <span style="color: #800080;">3</span><span style="color: #000000;">)]
    Unknown</span> = <span style="color: #800080;">3</span><span style="color: #000000;">,</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
    <span style="color: #808080;">///</span> <span style="color: #008000;">人妖</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
    [Description(<span style="color: #800000;">"</span><span style="color: #800000;">人妖</span><span style="color: #800000;">"</span>, <span style="color: #800080;">4</span><span style="color: #000000;">)]
    Demon</span> = <span style="color: #800080;">4</span> <span style="color: #000000;">}</span></pre>

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

</div>

特性第一个参数为名称，第二个为排序(int 类型，正序)，这就是就是我们新建枚举时在需要显示和枚举名称不一样的枚举字段上添加即可。这个Gender枚举，在**后面文章中**会一直用到(<span style="color: #ff0000;">**Gender**</span>)。

### 2、新建枚举扩展方法获取枚举特性的描述

我们前面的工作已经把**特性**和在**枚举上添加特性**已经完成了，后面我们需要的就是要**获取**我们添加的描述和排序。

<div class="cnblogs_code">

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

<pre><span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
<span style="color: #808080;">///</span> <span style="color: #008000;">枚举帮助类</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
<span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">class</span> <span style="color: #000000;">EnumTools
{</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
    <span style="color: #808080;">///</span> <span style="color: #008000;">获取当前枚举值的描述</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
    <span style="color: #808080;">///</span> <span style="color: #808080;"><param name="value"></param></span>
    <span style="color: #808080;">///</span> <span style="color: #808080;"><returns></returns></span>
    <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">string</span> GetDescription(<span style="color: #0000ff;">this</span> <span style="color: #000000;">Enum value)
    {</span> <span style="color: #0000ff;">int</span> <span style="color: #000000;">order;</span> <span style="color: #0000ff;">return</span> GetDescription(value, <span style="color: #0000ff;">out</span> <span style="color: #000000;">order);
    }</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
    <span style="color: #808080;">///</span> <span style="color: #008000;">获取当前枚举值的描述和排序</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
    <span style="color: #808080;">///</span> <span style="color: #808080;"><param name="value"></param></span>
    <span style="color: #808080;">///</span> <span style="color: #808080;"><param name="order"></param></span>
    <span style="color: #808080;">///</span> <span style="color: #808080;"><returns></returns></span>
    <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">string</span> GetDescription(<span style="color: #0000ff;">this</span> Enum value, <span style="color: #0000ff;">out</span> <span style="color: #0000ff;">int</span> <span style="color: #000000;">order)
    {</span> <span style="color: #0000ff;">string</span> description = <span style="color: #0000ff;">string</span><span style="color: #000000;">.Empty;

        Type type</span> = <span style="color: #000000;">value.GetType();</span> <span style="color: #008000;">//</span> <span style="color: #008000;">获取枚举</span>
        FieldInfo fieldInfo = <span style="color: #000000;">type.GetField(value.ToString());</span> <span style="color: #008000;">//</span> <span style="color: #008000;">获取枚举自定义的特性DescriptionAttribute</span>
        <span style="color: #0000ff;">object</span>[] attrs = fieldInfo.GetCustomAttributes(<span style="color: #0000ff;">typeof</span>(DescriptionAttribute), <span style="color: #0000ff;">false</span><span style="color: #000000;">);
        DescriptionAttribute attr</span> = (DescriptionAttribute)attrs.FirstOrDefault(a => a <span style="color: #0000ff;">is</span> <span style="color: #000000;">DescriptionAttribute);

        order</span> = <span style="color: #800080;">0</span><span style="color: #000000;">;
        description</span> = <span style="color: #000000;">fieldInfo.Name;</span> <span style="color: #0000ff;">if</span> (attr != <span style="color: #0000ff;">null</span><span style="color: #000000;">)
        {
            order</span> = <span style="color: #000000;">attr.Order;
            description</span> = <span style="color: #000000;">attr.Name;
        }</span> <span style="color: #0000ff;">return</span> <span style="color: #000000;">description;

    }

}</span></pre>

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

</div>

### 3、获取枚举描述和排序

至此：我们可以很容易获取到枚举添加的特性描述和排序。

<div class="cnblogs_code">

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

<pre><span style="color: #0000ff;">var</span> des =** <span style="color: #000000;">Gender.Male.GetDescription();</span> **<span style="color: #008000;">//</span> <span style="color: #008000;">des = “男性”</span>

<span style="color: #0000ff;">var</span> name = <span style="color: #000000;">Gender.Male.ToString();</span> <span style="color: #008000;">//</span> <span style="color: #008000;">name= "Male"</span>

<span style="color: #0000ff;">var</span> key = (<span style="color: #0000ff;">int</span><span style="color: #000000;">)Gender.Male;</span> <span style="color: #008000;">//</span> <span style="color: #008000;">key = 2</span>

<span style="color: #0000ff;">int</span> <span style="color: #000000;">order;</span> <span style="color: #0000ff;">var</span> des1 = Gender.Female.GetDescription(<span style="color: #0000ff;">out</span> <span style="color: #000000;">order);</span> <span style="color: #008000;">//</span> <span style="color: #008000;">des1 = “女性”, order= 2</span></pre>

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

</div>

这样我们就很好的解决了枚举命名问题， 可以很容易的获取到枚举的描述信息，也就是要显示的信息。但是我们需要的是一次性可以查询全部的枚举信息，以便我们进行显示。

## 三、获取所有枚举的描述和值，以便循环使用

我们已经可以很容易的获取到枚举的值，名称和描述了，所以后面的就很简单了。

<div class="cnblogs_code">

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

<pre><span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
<span style="color: #808080;">///</span> <span style="color: #008000;">枚举帮助类</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
<span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> <span style="color: #0000ff;">class</span> <span style="color: #000000;">EnumTools
{</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
    <span style="color: #808080;">///</span> <span style="color: #008000;">获取当前枚举的所有描述</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
    <span style="color: #808080;">///</span> <span style="color: #808080;"><param name="value"></param></span>
    <span style="color: #808080;">///</span> <span style="color: #808080;"><returns></returns></span>
    <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> List<KeyValuePair<<span style="color: #0000ff;">int</span>, <span style="color: #0000ff;">string</span>>> GetAll<T><span style="color: #000000;">()
    {</span> <span style="color: #0000ff;">return</span> GetAll(<span style="color: #0000ff;">typeof</span><span style="color: #000000;">(T));
    }</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
    <span style="color: #808080;">///</span> <span style="color: #008000;">获取所有的枚举描述和值</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
    <span style="color: #808080;">///</span> <span style="color: #808080;"><param name="type"></param></span>
    <span style="color: #808080;">///</span> <span style="color: #808080;"><returns></returns></span>
    <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> List<KeyValuePair<<span style="color: #0000ff;">int</span>, <span style="color: #0000ff;">string</span>>> <span style="color: #000000;">GetAll(Type type)
    {

        List</span><EnumToolsModel> list = <span style="color: #0000ff;">new</span> List<EnumToolsModel><span style="color: #000000;">();</span> <span style="color: #008000;">//</span> <span style="color: #008000;">循环枚举获取所有的Fields</span>
        <span style="color: #0000ff;">foreach</span> (<span style="color: #0000ff;">var</span> field <span style="color: #0000ff;">in</span> <span style="color: #000000;">type.GetFields())
        {</span> <span style="color: #008000;">//</span> <span style="color: #008000;">如果是枚举类型</span>
            <span style="color: #0000ff;">if</span> <span style="color: #000000;">(field.FieldType.IsEnum)
            {</span> <span style="color: #0000ff;">object</span> tmp = field.GetValue(<span style="color: #0000ff;">null</span><span style="color: #000000;">);
                Enum enumValue</span> = <span style="color: #000000;">(Enum)tmp;</span> <span style="color: #0000ff;">int</span> intValue = <span style="color: #000000;">Convert.ToInt32(enumValue);</span> <span style="color: #0000ff;">int</span> <span style="color: #000000;">order;</span> <span style="color: #0000ff;">string</span> showName = enumValue.GetDescription(<span style="color: #0000ff;">out</span> order); <span style="color: #008000;">//</span> <span style="color: #008000;">获取描述和排序</span>
                list.Add(<span style="color: #0000ff;">new</span> EnumToolsModel { Key = intValue, Name = showName, Order = <span style="color: #000000;">order });
            }
        }</span> <span style="color: #008000;">//</span> <span style="color: #008000;">排序并转成KeyValue返回</span>
        <span style="color: #0000ff;">return</span> list.OrderBy(i => i.Order).Select(i => <span style="color: #0000ff;">new</span> KeyValuePair<<span style="color: #0000ff;">int</span>, <span style="color: #0000ff;">string</span>><span style="color: #000000;">(i.Key, i.Name)).ToList();

    }
}</span></pre>

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

</div>

调用：这样我们就很容易的获取枚举所有字段的描述，如我们需要在cshtml中调用

<div class="cnblogs_code">

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

<pre><span style="color: #0000ff;"><</span><span style="color: #800000;">select</span> <span style="color: #ff0000;">class</span><span style="color: #0000ff;">="form-control"</span><span style="color: #0000ff;">></span> <span style="color: #000000;">@{ var genders = EnumTools.GetAll</span><span style="color: #0000ff;"><</span><span style="color: #800000;">Gender</span><span style="color: #0000ff;">></span><span style="color: #000000;">();}   // 或者EnumTools.GetAll<>(Typeof(Gender))
    @foreach (var item in genders)
    {</span> <span style="color: #0000ff;"><</span><span style="color: #800000;">option</span> <span style="color: #ff0000;">value</span><span style="color: #0000ff;">="@item.Key"</span><span style="color: #0000ff;">></span> <span style="color: #000000;">@item.Value</span> <span style="color: #0000ff;"></</span><span style="color: #800000;">option</span><span style="color: #0000ff;">></span> <span style="color: #000000;">}</span> <span style="color: #0000ff;"></</span><span style="color: #800000;">select</span><span style="color: #0000ff;">></span></pre>

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

</div>

生成的html为：

<div class="cnblogs_code">

<pre><span style="color: #0000ff;"><</span><span style="color: #800000;">select</span> <span style="color: #ff0000;">class</span><span style="color: #0000ff;">="form-control"</span><span style="color: #0000ff;">></span>
    <span style="color: #0000ff;"><</span><span style="color: #800000;">option</span> <span style="color: #ff0000;">value</span><span style="color: #0000ff;">="2"</span><span style="color: #0000ff;">></span>男性<span style="color: #0000ff;"></</span><span style="color: #800000;">option</span><span style="color: #0000ff;">></span>
    <span style="color: #0000ff;"><</span><span style="color: #800000;">option</span> <span style="color: #ff0000;">value</span><span style="color: #0000ff;">="1"</span><span style="color: #0000ff;">></span>女性<span style="color: #0000ff;"></</span><span style="color: #800000;">option</span><span style="color: #0000ff;">></span>
    <span style="color: #0000ff;"><</span><span style="color: #800000;">option</span> <span style="color: #ff0000;">value</span><span style="color: #0000ff;">="3"</span><span style="color: #0000ff;">></span>未知<span style="color: #0000ff;"></</span><span style="color: #800000;">option</span><span style="color: #0000ff;">></span>
    <span style="color: #0000ff;"><</span><span style="color: #800000;">option</span> <span style="color: #ff0000;">value</span><span style="color: #0000ff;">="4"</span><span style="color: #0000ff;">></span>人妖<span style="color: #0000ff;"></</span><span style="color: #800000;">option</span><span style="color: #0000ff;">></span>
<span style="color: #0000ff;"></</span><span style="color: #800000;">select</span><span style="color: #0000ff;">></span></pre>

</div>

 这样我们就已顺利的解决了枚举的命名以及排序显示等问题。

## 四、枚举特性扩展至HtmlHelper

我们已经解决了枚举的命名以及排序显示问题，但是我们想做的更好，比如每次都要写一个foreach获取所有的枚举然后在判断默认值和哪个相等，循环遍历，周而复始，重复造轮子，bad code。所以我们要进行封装，封装成与 @Html.DropDownList一样好用的HtmlHelper扩展。

<div class="cnblogs_code">

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

<pre><span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
<span style="color: #808080;">///</span> <span style="color: #008000;">枚举下拉</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><typeparam name="T"></span><span style="color: #008000;">枚举类型</span><span style="color: #808080;"></typeparam></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="html"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="htmlAttributes"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><returns></returns></span>
<span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> MvcHtmlString EnumToolsSelect<T>(<span style="color: #0000ff;">this</span> HtmlHelper html, <span style="color: #0000ff;">object</span> htmlAttributes = <span style="color: #0000ff;">null</span><span style="color: #000000;">)
{</span> <span style="color: #0000ff;">return</span> html.EnumToolsSelect(<span style="color: #0000ff;">typeof</span>(T), <span style="color: #0000ff;">int</span><span style="color: #000000;">.MaxValue, htmlAttributes);
}</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
<span style="color: #808080;">///</span> <span style="color: #008000;">枚举下拉</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><typeparam name="T"></span><span style="color: #008000;">枚举类型</span><span style="color: #808080;"></typeparam></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="html"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="selectedValue"></span><span style="color: #008000;">选择项</span><span style="color: #808080;"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="htmlAttributes"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><returns></returns></span>
<span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> MvcHtmlString EnumToolsSelect<T>(<span style="color: #0000ff;">this</span> HtmlHelper html, <span style="color: #0000ff;">int</span> selectedValue, <span style="color: #0000ff;">object</span> htmlAttributes = <span style="color: #0000ff;">null</span><span style="color: #000000;">)
{</span> <span style="color: #0000ff;">return</span> html.EnumToolsSelect(<span style="color: #0000ff;">typeof</span><span style="color: #000000;">(T), selectedValue, htmlAttributes);
}</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
<span style="color: #808080;">///</span> <span style="color: #008000;">枚举下拉</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><typeparam name="T"></span><span style="color: #008000;">枚举类型</span><span style="color: #808080;"></typeparam></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="html"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="selectedValue"></span><span style="color: #008000;">选择项</span><span style="color: #808080;"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="htmlAttributes"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><returns></returns></span>
<span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> MvcHtmlString EnumToolsSelect<T>(<span style="color: #0000ff;">this</span> HtmlHelper html, T selectedValue, <span style="color: #0000ff;">object</span> htmlAttributes = <span style="color: #0000ff;">null</span><span style="color: #000000;">)
{</span> <span style="color: #0000ff;">return</span> html.EnumToolsSelect(<span style="color: #0000ff;">typeof</span><span style="color: #000000;">(T), Convert.ToInt32(selectedValue), htmlAttributes);
}</span> <span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
<span style="color: #808080;">///</span> <span style="color: #008000;">枚举下拉</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="html"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="enumType"></span><span style="color: #008000;">枚举类型</span><span style="color: #808080;"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="selectedValue"></span><span style="color: #008000;">选择项</span><span style="color: #808080;"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="htmlAttributes"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><returns></returns></span>
<span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> MvcHtmlString EnumToolsSelect(<span style="color: #0000ff;">this</span> HtmlHelper html, Type enumType, <span style="color: #0000ff;">int</span> selectedValue, <span style="color: #0000ff;">object</span> htmlAttributes = <span style="color: #0000ff;">null</span><span style="color: #000000;">)
{</span> <span style="color: #008000;">//</span> <span style="color: #008000;">创建标签</span>
    TagBuilder tag = <span style="color: #0000ff;">new</span> TagBuilder(<span style="color: #800000;">"</span><span style="color: #800000;">select</span><span style="color: #800000;">"</span><span style="color: #000000;">);</span> <span style="color: #008000;">//</span> <span style="color: #008000;">添加自定义标签</span>
    <span style="color: #0000ff;">if</span> (htmlAttributes != <span style="color: #0000ff;">null</span><span style="color: #000000;">)
    {
        RouteValueDictionary htmlAttr</span> = htmlAttributes <span style="color: #0000ff;">as</span> RouteValueDictionary ?? <span style="color: #000000;">HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        tag.MergeAttributes(htmlAttr);
    }</span> <span style="color: #008000;">//</span> <span style="color: #008000;">创建option集合</span>
    StringBuilder options = <span style="color: #0000ff;">new</span> <span style="color: #000000;">StringBuilder();</span> <span style="color: #0000ff;">foreach</span> (<span style="color: #0000ff;">var</span> item <span style="color: #0000ff;">in</span> <span style="color: #000000;">GetAll(enumType))
    {</span> <span style="color: #008000;">//</span> <span style="color: #008000;">创建option</span>
        TagBuilder option = <span style="color: #0000ff;">new</span> TagBuilder(<span style="color: #800000;">"</span><span style="color: #800000;">option</span><span style="color: #800000;">"</span><span style="color: #000000;">);</span> <span style="color: #008000;">//</span> <span style="color: #008000;">添加值</span>
        option.MergeAttribute(<span style="color: #800000;">"</span><span style="color: #800000;">value</span><span style="color: #800000;">"</span><span style="color: #000000;">, item.Key.ToString());</span> <span style="color: #008000;">//</span> <span style="color: #008000;">设置选择项</span>
        <span style="color: #0000ff;">if</span> (item.Key == <span style="color: #000000;">selectedValue)
        {
            option.MergeAttribute(</span><span style="color: #800000;">"</span><span style="color: #800000;">selected</span><span style="color: #800000;">"</span>, <span style="color: #800000;">"</span><span style="color: #800000;">selected</span><span style="color: #800000;">"</span><span style="color: #000000;">);
        }</span> <span style="color: #008000;">//</span> <span style="color: #008000;">设置option</span>
 <span style="color: #000000;">option.SetInnerText(item.Value);
        options.Append(option.ToString());
    }
    tag.InnerHtml</span> = <span style="color: #000000;">options.ToString();</span> <span style="color: #008000;">//</span> <span style="color: #008000;">返回MVCHtmlString</span>
    <span style="color: #0000ff;">return</span> <span style="color: #000000;">MvcHtmlString.Create(tag.ToString());

}</span></pre>

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

</div>

 然后调用

<div class="cnblogs_code">

<pre>@(Html.EnumToolsSelect<Gender><span style="color: #000000;">())
@(Html.EnumToolsSelect</span><Gender><span style="color: #000000;">(Gender.Unknown))
@(Html.EnumToolsSelect</span><Gender>(<span style="color: #800080;">1</span><span style="color: #000000;">))
@(Html.EnumToolsSelect</span><Gender>(Gender.Female, <span style="color: #0000ff;">new</span> { @class = <span style="color: #800000;">"</span><span style="color: #800000;">form-control</span><span style="color: #800000;">"</span> <span style="color: #000000;">}))
@(Html.EnumToolsSelect(</span><span style="color: #0000ff;">typeof</span>(Gender), <span style="color: #800080;">1</span>)</pre>

</div>

这样就可以生成你所需要的下拉框的html，一行代码就可以解决复杂的枚举下拉。

你以为就这样结束了吗，很明显没有，因为不是我风格，我的风格是继续封装。

## 五、枚举特性扩展至HtmlHelper Model

这个可能有很多不会陌生，因为很多HtmlHelper都有一个For结尾的，如@Html.DropDownListFor等等，那我们也要有For结尾的，要不然都跟不上潮流了。

关于For的一些扩展和没有For的扩展的区别，简单来说带For就是和Model一起用的，如：**@Html.TextBoxFor(i => i.Name)**

这样就可以更加一步的封装，如Id,name,model的Name值以及**验证**等等。

话不多说，直接代码

<div class="cnblogs_code">

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

<pre><span style="color: #808080;">///</span> <span style="color: #808080;"><summary></span>
<span style="color: #808080;">///</span> <span style="color: #008000;">下拉枚举</span> <span style="color: #808080;">///</span> <span style="color: #808080;"></summary></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><typeparam name="TModel"></span><span style="color: #008000;">Model</span><span style="color: #808080;"></typeparam></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><typeparam name="TProperty"></span><span style="color: #008000;">属性</span><span style="color: #808080;"></typeparam></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="htmlHelper"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="expression"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><param name="htmlAttributes"></param></span>
<span style="color: #808080;">///</span> <span style="color: #808080;"><returns></returns></span>
<span style="color: #0000ff;">public</span> <span style="color: #0000ff;">static</span> MvcHtmlString EnumToolsSelectFor<TModel, TProperty>(<span style="color: #0000ff;">this</span> HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, <span style="color: #0000ff;">object</span> htmlAttributes = <span style="color: #0000ff;">null</span><span style="color: #000000;">)
{</span> <span style="color: #008000;">//</span> <span style="color: #008000;">获取元数据meta</span>
    ModelMetadata modelMetadata = <span style="color: #000000;">ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

    Type enumType</span> = <span style="color: #000000;">modelMetadata.ModelType;</span> <span style="color: #008000;">//</span> <span style="color: #008000;">设置id name的属性值</span>
    <span style="color: #0000ff;">var</span> rvd = <span style="color: #0000ff;">new</span> <span style="color: #000000;">RouteValueDictionary
    {
        {</span> <span style="color: #800000;">"</span><span style="color: #800000;">id</span><span style="color: #800000;">"</span><span style="color: #000000;">, modelMetadata.PropertyName },
        {</span> <span style="color: #800000;">"</span><span style="color: #800000;">name</span><span style="color: #800000;">"</span><span style="color: #000000;">, modelMetadata.PropertyName }
    };</span> <span style="color: #008000;">//</span> <span style="color: #008000;">添加自定义属性</span>
    <span style="color: #0000ff;">if</span> (htmlAttributes != <span style="color: #0000ff;">null</span><span style="color: #000000;">)
    {
        RouteValueDictionary htmlAttr</span> = htmlAttributes <span style="color: #0000ff;">as</span> RouteValueDictionary ?? <span style="color: #000000;">HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);</span> <span style="color: #0000ff;">foreach</span> (<span style="color: #0000ff;">var</span> item <span style="color: #0000ff;">in</span> <span style="color: #000000;">htmlAttr)
        {
            rvd.Add(item.Key, item.Value);
        }
    }</span> <span style="color: #008000;">//</span> <span style="color: #008000;">获取验证信息</span>
    IDictionary<<span style="color: #0000ff;">string</span>, <span style="color: #0000ff;">object</span>> validationAttributes = <span style="color: #000000;">htmlHelper.GetUnobtrusiveValidationAttributes(modelMetadata.PropertyName, modelMetadata);</span> <span style="color: #008000;">//</span> <span style="color: #008000;">添加至自定义属性</span>
    <span style="color: #0000ff;">if</span> (validationAttributes != <span style="color: #0000ff;">null</span><span style="color: #000000;">)
    {</span> <span style="color: #0000ff;">foreach</span> (<span style="color: #0000ff;">var</span> item <span style="color: #0000ff;">in</span> <span style="color: #000000;">validationAttributes)
        {
            rvd.Add(item.Key, item.Value);
        }
    }</span> <span style="color: #0000ff;">return</span> <span style="color: #000000;">htmlHelper.EnumToolsSelect(enumType, Convert.ToInt32(modelMetadata.Model), rvd);
}</span></pre>

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

</div>

关于使用：

首先我们需要返回view时需要返回Model

<div class="cnblogs_code">

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

<pre><span style="color: #0000ff;">public</span> <span style="color: #0000ff;">class</span> <span style="color: #000000;">HomeController : Controller
{</span> <span style="color: #0000ff;">public</span> <span style="color: #000000;">ActionResult Index()
    {</span> <span style="color: #0000ff;">return</span> View(<span style="color: #0000ff;">new</span> Person { Age = <span style="color: #800080;">1</span>, Name = <span style="color: #800000;">"</span><span style="color: #800000;">Emrys</span><span style="color: #800000;">"</span>, Gender = <span style="color: #000000;">Gender.Male });
    }

}</span> <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">class</span> <span style="color: #000000;">Person
{</span> <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">string</span> Name { <span style="color: #0000ff;">get</span>; <span style="color: #0000ff;">set</span><span style="color: #000000;">; }</span> <span style="color: #0000ff;">public</span> <span style="color: #0000ff;">int</span> Age { <span style="color: #0000ff;">get</span>; <span style="color: #0000ff;">set</span><span style="color: #000000;">; }</span> <span style="color: #0000ff;">public</span> Gender Gender { <span style="color: #0000ff;">get</span>; <span style="color: #0000ff;">set</span><span style="color: #000000;">; } 
}</span></pre>

<div class="cnblogs_code_toolbar"><span class="cnblogs_code_copy">[![复制代码](//common.cnblogs.com/images/copycode.gif)](javascript:void(0); "复制代码")</span></div>

</div>

cshtm调用

<div class="cnblogs_code">

<pre>@Html.EnumToolsSelectFor(i => i.Gender)</pre>

</div>

生成html代码

<div class="cnblogs_code">

<pre><span style="color: #0000ff;"><</span><span style="color: #800000;">select</span> <span style="color: #ff0000;">data-val</span><span style="color: #0000ff;">="true"</span> <span style="color: #ff0000;">data-val-required</span><span style="color: #0000ff;">="Gender 字段是必需的。"</span> <span style="color: #ff0000;">id</span><span style="color: #0000ff;">="Gender"</span> <span style="color: #ff0000;">name</span><span style="color: #0000ff;">="Gender"</span><span style="color: #0000ff;">></span>
    <span style="color: #0000ff;"><</span><span style="color: #800000;">option</span> <span style="color: #ff0000;">selected</span><span style="color: #0000ff;">="selected"</span> <span style="color: #ff0000;">value</span><span style="color: #0000ff;">="2"</span><span style="color: #0000ff;">></span>男性<span style="color: #0000ff;"></</span><span style="color: #800000;">option</span><span style="color: #0000ff;">></span>
    <span style="color: #0000ff;"><</span><span style="color: #800000;">option</span> <span style="color: #ff0000;">value</span><span style="color: #0000ff;">="1"</span><span style="color: #0000ff;">></span>女性<span style="color: #0000ff;"></</span><span style="color: #800000;">option</span><span style="color: #0000ff;">></span>
    <span style="color: #0000ff;"><</span><span style="color: #800000;">option</span> <span style="color: #ff0000;">value</span><span style="color: #0000ff;">="3"</span><span style="color: #0000ff;">></span>未知<span style="color: #0000ff;"></</span><span style="color: #800000;">option</span><span style="color: #0000ff;">></span>
    <span style="color: #0000ff;"><</span><span style="color: #800000;">option</span> <span style="color: #ff0000;">value</span><span style="color: #0000ff;">="4"</span><span style="color: #0000ff;">></span>人妖<span style="color: #0000ff;"></</span><span style="color: #800000;">option</span><span style="color: #0000ff;">></span>
<span style="color: #0000ff;"></</span><span style="color: #800000;">select</span><span style="color: #0000ff;">></span></pre>

</div>

大功告成。

Github:[https://github.com/Emrys5/Asp.MVC-03-Enum-rename-htmlhelper](https://github.com/Emrys5/Asp.MVC-03-Enum-rename-htmlhelper)

</div>
更多详情请至：
http://www.cnblogs.com/emrys5/p/Enum-rename-htmlhelper.html
