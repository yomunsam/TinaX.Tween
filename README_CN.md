# TinaX Framework - Tween.

<img src="https://github.com/yomunsam/TinaX.Core/raw/master/readme_res/logo.png" width = "360" height = "160" alt="logo" align=center />

[![LICENSE](https://img.shields.io/badge/license-NPL%20(The%20996%20Prohibited%20License)-blue.svg)](https://github.com/996icu/996.ICU/blob/master/LICENSE)
<a href="https://996.icu"><img src="https://img.shields.io/badge/link-996.icu-red.svg" alt="996.icu"></a>
[![LICENSE](https://camo.githubusercontent.com/890acbdcb87868b382af9a4b1fac507b9659d9bf/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f6c6963656e73652d4d49542d626c75652e737667)](https://github.com/yomunsam/TinaX/blob/master/LICENSE)

<!-- [![LICENSE](https://camo.githubusercontent.com/3867ce531c10be1c59fae9642d8feca417d39b58/68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f6c6963656e73652f636f6f6b6965592f596561726e696e672e737667)](https://github.com/yomunsam/TinaX/blob/master/LICENSE) -->

[TinaX](https://github.com/yomunsam/TinaX)是一个简洁、完整、愉快的开箱即用的Unity应用游戏开发框架， 它采用"Unity 包"的形式提供功能。

`TinaX.Tween`为[TinaX Framework](https://github.com/yomunsam/TinaX)提供了轻量级补间动画库。

- 轻量级补间动画库
- 无需编写代码的补间动画组件

<br>

package name: `io.nekonya.tinax.tween`

<br>

------


## QuickStart

> 本库的核心功能基于[TweenRx](https://github.com/fumobox/TweenRx)项目（MIT License），您也可以直接访问TweenRx仓库页面查看相关文档。

<br>

### 简单的浮点型补间动画

``` csharp
using UniRx;
using TinaX.Tween;

Tween.Play(1, 10)
    .Subscribe(value =>
    {
        gameObject1.transform.localPosition = new Vector3(x, 0, 0);
    });
```

<br>

### 补见动画组件

我们可以在编辑器中使用组件无需编写代码实现补间动画功能。

![](README_CN.assets/image-20210316172916339.png)




更多用法请 [查看文档](https://tinax.corala.space).

<br>

------

## 安装

请访问文档查看安装指引：[安装TinaX](https://tinax.corala.space/#/cmn-hans/tinax/install/install_tinax)



<br><br>
------

## 依赖

本项目（包）直接依赖以下包

- [com.neuecc.unirx](https://github.com/neuecc/UniRx#upm-package) :`https://github.com/neuecc/UniRx.git?path=Assets/Plugins/UniRx/Scripts`

<br><br>

------

## Learn TinaX

您可以访问TinaX的[文档页面](https://tinax.corala.space/#/cmn-hans)来学习了解各个功能的使用

------

## Third-Party

本项目中使用了以下优秀的第三方库：

- **[TweenRx](https://github.com/fumobox/TweenRx)** : (MIT License)Reactive animation utility for Unity.
