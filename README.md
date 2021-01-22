# Nullforce.StreamTools.ImageScroller

A Blazor WebAssembly app that scrolls images from a local directory. Can be used as a browser source in OBS.

<!-- |||
----------------------|---
**Build**             | [![Build Status](https://github.com/nullforce-public/Nullforce.StreamTools.ImageScroller/workflows/build/badge.svg?branch=main)](https://github.com/nullforce-public/Nullforce.StreamTools.ImageScroller/actions) -->

## Configuration

Parameters can be configured unders ScrollSettings in the `appsettings.json` file.

Ports can be configured in the `Properties/launchSettings.json` file.

## Usage

### Launch the Web App

#### Via dotnet

From the project root directory:

`dotnet run --project src/Nullforce.StreamTools.ImageScroller`

#### Precompiled

Unzip the files to a directory and run `Nullforce.StreamTools.ImageScroller.exe`.

### OBS (or other streaming application)

Add a browser source with `https://localhost:5001` as the URL.

We recommend cropping the left and right sides of the browser source so that the images appear
to slide into and out of the remaining view.

## Building / Contributing

TBD
