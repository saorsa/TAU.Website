# TAU EVS web site

### Google reCaptcha

To enable Google reCaptcha for the project a Site and a Secret key must be generated
from: [Google reCaptcha](https://www.google.com/recaptcha/about/).

After that add the generated keys to the desired appsettings.json file as a new object as follows:

```
"GoogleReCaptcha": {
    "SiteKey": "",
    "SecretKey": ""
}
```

### ESLint

1. In the embedded Terminal (Ctrl+Alt+1) , type one of the following commands:

```
npm install --g eslint for global installation.
npm install --save-dev eslint to install ESLint as a development dependency.
```
2. Create the .eslintrc.json config file by running:
```
./node_modules/.bin/eslint --init
```
3.To configure ESLint automatically in the current project, open the Settings/Preferences dialog (Ctrl+Alt+S), go to Languages & Frameworks | JavaScript | Code Quality Tools | ESLint, and select the Automatic ESLint configuration option.

### Stylelint

1. Use npm to install Stylelint and its standard configuration:

```
npm install --save-dev stylelint stylelint-config-standard
```

2. Create a .stylelintrc.json configuration file in the root of your project with the following content:

```
{
"extends": "stylelint-config-standard"
}
```

3.To activate Stylelint, open the Settings/Preferences dialog (Ctrl+Alt+S), go to Languages & Frameworks | Style Sheets
| Stylelint, and select the Enable checkbox. After that the controls in the dialog become available. In the Stylelint
Package field, specify the location of the stylelint package installed globally or in the current project. If you
followed the standard installation procedure, JetBrains Rider detects the package automaticaly. In the Run for files
field, specify the pattern that defines the set of files to be linted. By default, StyleLint processes only plain CSS
files therefore the default pattern is {**/*,*}.{css}.