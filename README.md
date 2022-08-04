Slimsy v4
============
**Effortless Responsive & Lazy Images with LazySizes and Umbraco**

# Slimsy v4 is made for Umbraco v10!

![](Slimsy.png)

__Release Downloads__

NuGet Package: [![NuGet release](https://img.shields.io/nuget/vpre/Our.Umbraco.Slimsy.svg)](https://www.nuget.org/packages/Our.Umbraco.Slimsy/)

__Prerelease Downloads__

NuGet Package: [![MyGet build](https://img.shields.io/myget/umbraco-packages/vpre/Our.Umbraco.Slimsy.svg)](https://www.myget.org/feed/umbraco-packages/package/nuget/Our.Umbraco.Slimsy)

[![Build status](https://ci.appveyor.com/api/projects/status/a7rxrfkxc5dx8cuo?svg=true)](https://ci.appveyor.com/project/CrumpledDog/slimsy)

## Installation

### 1. Install from NuGet

### 2. Add to Startup.cs in the ConfigureServices method

```c#
.AddSlimsy()
```
### 3. Add to _ViewImports.cshtml

```c#
@addTagHelper *, Slimsy
@inject Slimsy.Services.SlimsyService SlimsyService
```

### 4. Add lazysizes.min.js & to your templates/views

In your template add the JavaScript files

```
<script src="/scripts/lazysizes.min.js" async=""></script>
```

### 5. Ensure all img elements are set to `display: block` or `display: inline-block;`

e.g.

```css
img {
    display:block;
}
```

If you are using LQIP then you will also need to ensure img elements are set to `width:100%;`

e.g.

```css
img {
    display:block;
    width:100%;
}
```

### 6. Use the `<slimsy-picture>` tag helper or manually adjust your image elements, adding `data-srcset`, `data-src`, `sizes="auto"` & `class="lazyload"` attributes

```C#
<slimsy-picture media-item="@person.Photo" width="323" height="300" css-class="myClass" render-lqip="true" render-webp-alternative="true"></slimsy-picture>
```

Use the `GetSrcSetUrls` UrlHelper extension methods to generate your `data-srcset` attributes. For these methods to function correctly your image property types should use the built-in **Image Cropper**.

```C#
<div class="employee-grid__item__image">
    <img data-srcset="@Url.GetSrcSetUrls(person.Photo, 323, 300)" srcset="@Url.GetSrcSetUrls(person.Photo, 250, 250, quality: 40)" data-sizes="auto" class="lazyload"/>
</div>
```

Or inject SlimsyService into your ViewComponents

```C#
private readonly SlimsyService _slimsyService;
public ResponsiveImageViewComponent(SlimsyService slimsyService)
{
	_slimsyService = slimsyService;
}
```

### 7 (optional). Adjust the rendering of your TinyMce Richtext editors

```C#
<div class="col-md-9">
    <article>
        @SlimsyService.ConvertImgToResponsive(Model, "richTextBody", renderPicture:true, pictureSources: new []{"webp"})
    </article>
</div>
```

### 8 (optional). Adjust the renderer of media within the Grid editor

There's quite a lot to this - so check it out in the demo site [here](https://github.com/Jeavon/Slimsy/blob/dev-v4/src/Slimsy.TestSite/Views/Partials/grid/editors/media.cshtml)

# Advanced Options

Add/Edit `appsettings.json`

```json
  "Slimsy": {
    "WidthStep": 180,
    "UseCropAsSrc": false,
    "DefaultQuality": 70,
    "Format": "",
    "BGColor": ""
  }
```

or edit `Startup.cs` to modify SlimsyOptions
```c#
.AddSlimsy(options =>
{
    options.DefaultQuality = 60;
    options.WidthStep = 60;
    options.UseCropAsSrc = true;
})
```

# Lazysizes.js

Lazysizes.js is awesome and it's part of what makes Slimsy so easy to implement. If you need to find out more information about it or how to hook into it's Javascript events be sure to check out it's [GitHub](https://github.com/aFarkas/lazysizes)

# Test Site & Source Code

A test site is included in the solution, the username and password for Umbraco are `admin@admin.com/password1234567890.`

To run the Blob Test site you will need a Azure storage account, to set the connection string in a local user secret with the TestSite.TestSiteBlobs folder run

    dotnet user-secrets set "Umbraco:Storage:AzureBlob:Media:ConnectionString" "DefaultEndpointsProtocol=https;AccountName=;AccountKey=;EndpointSuffix=core.windows.net"

# Credits and references

This project includes [LazySizes](https://github.com/aFarkas/lazysizes) 
which is MIT licensed.

Without the amazing [ImageSharp](https://github.com/SixLabors/ImageSharp) this package wouldn't exist, so many thanks go to [James](https://github.com/JimBobSquarePants) and all the [SixLabors](https://github.com/SixLabors) team for creating  ImageSharp!

Many thanks to Douglas Robar for naming Slimsy.

# Change log

[Here](Changelog.md)
