DissolveEffectForUGUI
===

### NOTE: This project *will* be merged to [UIEffect](https://github.com/mob-sakai/UIEffect).

A dissolve effect for uGUI, without material instancing.

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

DissolveEffectForUGUI applies _dissolve-effect_ to uGUI element (Image, RawImage, Text, etc...) **WITHOUT material instancing**.  
This will suppress extra draw calls and improve performance.



<br><br><br><br>
## Demo



<br><br><br><br>
## Usage

1. Download DissolveEffectForUGUI.unitypackage from [Releases](https://github.com/mob-sakai/DissolveEffectForUGUI/releases).
1. Import the package into your Unity project. Select `Import Package > Custom Package` from the `Assets` menu.
1. Add `DissolveEffectForUGUI` component to UI element (Image, RawImage, Text, etc...) from `Add Component` in inspector.
1. Choose effect type and adjust values in inspector.  
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



## Author

[mob-sakai](https://github.com/mob-sakai)



## See Also

* GitHub page : https://github.com/mob-sakai/DissolveEffectForUGUI
* Releases : https://github.com/mob-sakai/DissolveEffectForUGUI/releases
* Issue tracker : https://github.com/mob-sakai/DissolveEffectForUGUI/issues
* Current project : https://github.com/mob-sakai/DissolveEffectForUGUI/projects/1
* Change log : https://github.com/mob-sakai/DissolveEffectForUGUI/blob/master/CHANGELOG.md
