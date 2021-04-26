# TinaX Framework - Tween.

<img src="https://github.com/yomunsam/TinaX.Core/raw/master/readme_res/logo.png" width = "360" height = "160" alt="logo" align=center />

[![LICENSE](https://img.shields.io/badge/license-NPL%20(The%20996%20Prohibited%20License)-blue.svg)](https://github.com/996icu/996.ICU/blob/master/LICENSE)
<a href="https://996.icu"><img src="https://img.shields.io/badge/link-996.icu-red.svg" alt="996.icu"></a>
[![LICENSE](https://camo.githubusercontent.com/890acbdcb87868b382af9a4b1fac507b9659d9bf/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f6c6963656e73652d4d49542d626c75652e737667)](https://github.com/yomunsam/TinaX/blob/master/LICENSE)

<!-- [![LICENSE](https://camo.githubusercontent.com/3867ce531c10be1c59fae9642d8feca417d39b58/68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f6c6963656e73652f636f6f6b6965592f596561726e696e672e737667)](https://github.com/yomunsam/TinaX/blob/master/LICENSE) -->


[TinaX](https://github.com/yomunsam/TinaX) is a Unity-based framework, simple , complete and delightful, ready to use.

TinaX provides functionality in the form of "Unity packages". 

`TinaX.Tween` provides a lightweight tween animation library for [TinaX Framework](https://github.com/yomunsam/TinaX).

- Lightweight tween animation library
- Tween animation components that can be used without coding

<br>

package name: `io.nekonya.tinax.tween`

<br>

------


## QuickStart

> The core function of this library is based on [TweenRx](https://github.com/fumobox/TweenRx) (MIT license). You can also directly visit TweenRx's repo to view relevant documents.

<br>

### Simple float animation

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

### Tween component

We can use components in the editor without coding to achieve tween animation function.

![1619467493256](README.assets~/1619467493256.png)



For more usage, please [see the document](https://tinax.corala.space).

<br>

------

## Install

Please visit the documentation for installation instructions：[Install TinaX](https://tinax.corala.space/#/cmn-hans/tinax/install/install_tinax)



<br><br>
------

## Dependencies

- [io.nekonya.tinax.core](https://github.com/yomunsam/tinax.core) :`git://github.com/yomunsam/TinaX.Core.git`

<br><br>

------

## Learn TinaX

You can find out how to use the various features of TinaX in the [documentation](https://tinax.corala.space)

------

## Third-Party

The following excellent third-party libraries are used in this project:

- **[TweenRx](https://github.com/fumobox/TweenRx)** : (MIT License)Reactive animation utility for Unity.
