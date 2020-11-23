# UnityLocalize
Localizeのライブラリ
現在は二通りの使い方があります

## Install
* release unitypackage 

* Package Manager

add "com.hmgm.unitylocalize": "https://github.com/hmgmishia/UnityLocalize.git?path=Assets/Plugins/hmgm/UnityLocalize/Scripts" to Packages/manifest.json 

# Usage

## Scriptable Object

### Create
Location: Asset Create Menu -> Create -> Localize -> Text ScriptableObject

### Use
```
[SerializeField]
private LocalizeTextScriptableObject scriptableObject;

private Text text;

private void Start()
{
    text = GetComponent<Text>();
    text.text = scriptableObject.GetLocalizeText();
}
```

### 

## Localize Sheet Manager

### Create
* Format

csv

* Layout

ColumnOrder: Key,Language or Default 

But, Duplicate names are prohibited! 
 
* Default Column 

Set Default Value. 
 
ex: 
|Key|English|Japanese|Default|
|--|--|--|--|
|Book|Book|本|Book|
|Sword|Sword|剣|Sword|

### Use
```
[SerializeField]
private string localizeKey;

private Text text;

private void Start()
{
    text = GetComponent<Text>();
    text.text = LocalizeSheetManager.I.Get(localizeKey);
}
```

# Extensions

## CSV To ScriptableObject

### Location
Unity Tab Menu -> Location -> CSV to Localize ScriptableObject

### Use
* 既にあるファイルを上書き 

Overwrite the already existing file contents.

* CSVパス

Target csv file.

* 出力先Unityパス

Output Unity Path.
It can only be set under the "Assets" folder.

* 出力

Output csv to ScriptableObject.
