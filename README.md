# Xamarin Certificate and Public Key Pinning
This is a Xamarin sample application that demonstrates certificate public key pinning. 

> See [this OWASP page](https://www.owasp.org/index.php/Certificate_and_Public_Key_Pinning) for reference.

This seems like a straightforward topic, but I struggled to find any working examples -- especially for Xamarin apps. I cobbled together bits from past experience, OWASP, [this developer blog post](https://thomasbandt.com/certificate-and-public-key-pinning-with-xamarin), and Google to build a sample app using Xamarin that would show a **pass** and **fail** example of cert pinning in action on Android and iOS.

I've bundled a `Lookup.PublicKeys` app to help you lookup the public key for a site you're interested in.

I hope this sample helps someone else out. 

I'm not a security pro, so if you find holes in my sample implementation, please let me know, open an issue, submit a PR, or whatever is easiest.