# Trados Studio XML Analysis Viewer
View Trados Studio XML Analysis Reports.

## What's it all about...
The **Trados Studio XML Analysis Viewer** is a free tool for reading XML logs generated in [SDL Trados Studio](https://www.sdl.com/software-and-services/translation-software/sdl-trados-studio/). Translators receiving such files have no easy way of viewing them in a quick and meaningful way, forcing them to request help or extra information from the sender of the file.

This tool provides a simple user interface for loading such XMLs, presenting the contained information in a concise, straightforward manner. In addition to XML logs, this tool is also able to access Trados Studio Project Packages (.sdlppx files), presenting the included XML analysis reports in the same way. It's worth mentioning that both of these functions (viewing directly XML logs or XMLs from SDLPPXs) **do not** require the use or presence of Trados Studio. This feature makes it an ideal companion to translators that do not use or have Trados Studio.

**Known limitations of version 1.1:**
- Does not support SDLPPXs with multiple XML report files (applicable to multi-language packages only)
- Does not support internal fuzzy matches in XML reports

**Screenshot:**

![Trados Studio XML Analysis Viewer screenshot](https://user-images.githubusercontent.com/4114200/62833522-d04ec080-bc48-11e9-8334-43e5367efd5f.png)

## Tool & build environment
- [Visual Studio IDE](https://visualstudio.microsoft.com/)

## Pre-built file
You can download a pre-built version (.EXE) of this tool from [here](https://drive.google.com/file/d/113ffu2oPJhMLeJa-5G3JFyNbwv5SGE1M/view?usp=sharing).

## Notes
- To see the analysis of a specific file (of a loaded XML/SDLPPX), click on it in the File List box. 
- The code is quite rough around the edges and, yes, it's been written in VB.NET (what a sacrilege, I know...). But, I needed something up and running quickly, so spare me the flame wars.
- The application uses the [Microsoft .NET Framework 4.6](https://www.microsoft.com/en-us/download/details.aspx?id=48130) so you might be requested to install it if not present. Usually, this is already installed on your system.
- Your web browser and/or Windows operating system may, incorrectly, flag the download/application as not safe. The reason for this is that the software has not been signed with a developer's certificate. Since I'm not a professional developer, and certificates cost money, the tool has been left unsigned. If you're still uncertain, you can easily scan the file with your anti-virus software and see for yourself.
- Application icon from [Icons8](https://icons8.com).

## Like what you see?

If you find the **Trados Studio XML Analysis Viewer** interesting then why not buy me a coffee?

[![BuyMeACoffee](https://user-images.githubusercontent.com/4114200/63639089-672f6a00-c698-11e9-9fac-3b6fcac47901.png)](https://www.buymeacoffee.com/ADYsLjqfi)
