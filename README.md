# TAU EVS web site

### Google reCaptcha
To enable Google reCaptcha for the project a Site and a Secret key must be generated from: [Google reCaptcha](https://www.google.com/recaptcha/about/).

After that add the generated keys to the desired appsettings.json file as a new object as follows:
```
"GoogleReCaptcha": {
    "SiteKey": "",
    "SecretKey": ""
}
```