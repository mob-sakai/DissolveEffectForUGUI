DissolveEffectForUGUI
===

### NOTE: This project has been merged to [UIEffect](https://github.com/mob-sakai/UIEffect).

A dissolve effect for uGUI, without material instancing.

![](https://user-images.githubusercontent.com/12690315/41188348-c94311d6-6bf6-11e8-9bef-c3a52ead5724.gif)

[![](https://img.shields.io/github/release/mob-sakai/DissolveEffectForUGUI.svg?label=latest%20version)](https://github.com/mob-sakai/DissolveEffectForUGUI/release)
[![](https://img.shields.io/github/release-date/mob-sakai/DissolveEffectForUGUI.svg)](https://github.com/mob-sakai/DissolveEffectForUGUI/releases)
![](https://img.shields.io/badge/requirement-Unity%205.5%2B-green.svg)
[![](https://img.shields.io/github/license/mob-sakai/DissolveEffectForUGUI.svg)](https://github.com/mob-sakai/DissolveEffectForUGUI/blob/master/LICENSE.txt)
[![](https://img.shields.io/github/last-commit/mob-sakai/DissolveEffectForUGUI/develop.svg?label=last%20commit)](https://github.com/mob-sakai/DissolveEffectForUGUI/commits/develop)
[![](https://img.shields.io/github/issues/mob-sakai/DissolveEffectForUGUI.svg)](https://github.com/mob-sakai/DissolveEffectForUGUI/issues)
[![](https://img.shields.io/github/commits-since/mob-sakai/DissolveEffectForUGUI/latest.svg)](https://github.com/mob-sakai/DissolveEffectForUGUI/compare/master...develop)


<< [Description](#Description) | [Demo](#demo) | [Download](https://github.com/mob-sakai/DissolveEffectForUGUI/releases) | [Usage](#usage) | [Development Note](#development-note) | [Change log](https://github.com/mob-sakai/DissolveEffectForUGUI/blob/develop/CHANGELOG.md) >>



<br><br><br><br>
## Description

![](https://user-images.githubusercontent.com/12690315/41188299-2f85c7b4-6bf6-11e8-8034-52d6b66945a1.png)

DissolveEffectForUGUI applies _dissolve-effect_ to uGUI element (Image, RawImage, Text, etc...) **WITHOUT material instancing**.  
This will suppress extra draw calls and improve performance.

* Parameters
  * Dissolve factor
  * Edge width
  * Edge color
  * Edge color mode
  * Edge softness
  * Noise pattern image (shingle channel)
  * Effect player
    * Enable playing
    * Duration
    * Update mode


<br><br><br><br>
## Demo

* ![demo](https://user-images.githubusercontent.com/12690315/39131616-dcf7ea60-474a-11e8-8e20-f9e5bd8b3f5c.gif)
  * Just 1 draw call!

[WebGL Demo](http://mob-sakai.github.io/DissolveEffectForUGUI)


<br><br><br><br>
## Usage

1. Download DissolveEffectForUGUI.unitypackage from [Releases](https://github.com/mob-sakai/DissolveEffectForUGUI/releases).
1. Import the package into your Unity project. Select `Import Package > Custom Package` from the `Assets` menu.
1. Add `DissolveEffectForUGUI` component to UI element (Image, RawImage, Text, etc...) from `Add Component` in inspector.
1. Control effect parameters in inspector.  
1. Enjoy!


##### Requirement

* Unity 5.5+ *(included Unity 2017.x)*
* No other SDK are required



<br><br><br><br>
## Development Note

#### What's doing?

* Control effect parameters for uGUI element WITHOUT MaterialPropertyBlock
  * https://github.com/mob-sakai/UIEffect#how-to-control-effect-parameters-for-ugui-element-without-materialpropertyblock



<br><br><br><br>
## License

* MIT
* [JewelSaviorFREE](http://www.jewel-s.jp/)



## Author

[mob-sakai](https://github.com/mob-sakai)



## See Also

* GitHub page : https://github.com/mob-sakai/DissolveEffectForUGUI
* Releases : https://github.com/mob-sakai/DissolveEffectForUGUI/releases
* Issue tracker : https://github.com/mob-sakai/DissolveEffectForUGUI/issues
* Current project : https://github.com/mob-sakai/DissolveEffectForUGUI/projects/1
* Change log : https://github.com/mob-sakai/DissolveEffectForUGUI/blob/master/CHANGELOG.md
