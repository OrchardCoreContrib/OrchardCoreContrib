# OrchardCoreContrib

This repository contains a set of features and APIs for [Orchard Core CMS](https://github.com/OrchardCMS/OrchardCore) that driven by the community members who love Orchard Core.

This will encourage all the passionate developers to add and develop the other necessary core features that aren't included in Orchard Core. Such feature and APIs may necessary to drive other [modules](https://github.com/OrchardCoreContrib/OrchardCoreContrib.Modules) or [themes](https://github.com/OrchardCoreContrib/OrchardCoreContrib.Themes) for Orchard Core Contrib.

## Build Status

[![Build status](https://github.com/OrchardCoreContrib/OrchardCoreContrib/actions/workflows/build.yml/badge.svg)](https://github.com/OrchardCoreContrib/OrchardCoreContrib/actions?query=workflow%3A%22Orchard+Core+Contrib%22)

## Goals

There are many goals for creating this repository:

1. Grow the Orchard Core community.

2. Design & develop a crazy ideas that may or could help the Orchard Core team to consider some of these in the future releases, if they are frequently asked by the community.

3. Implement features that may not included in the official release, which may help the community in the way or other.

## Documentations

The `OrchardCoreContrib` repository consists of the following projects:

| Name | Namespace | NuGet |
| --- | --- | --- |
| [Orchard Core Contrib Implementation APIs](src/OrchardCoreContrib/README.md) | `OrchardCoreContrib` ||
| [Orchard Core Contrib Abstractions APIs](src/OrchardCoreContrib.Abstractions/README.md) | `OrchardCoreContrib.Abstractions` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Abstractions.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Abstractions) |
| [Content Localization Abstractions APIs](src/OrchardCoreContrib.ContentLocalization.Abstractions/README.md) | `OrchardCoreContrib.ContentLocalization.Abstractions` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.ContentLocalization.Abstractions.svg)](https://www.nuget.org/packages/OrchardCoreContrib.ContentLocalization.Abstractions) |
| [Content Localization Implementations APIs](src/OrchardCoreContrib.ContentLocalization.Core/README.md) | `OrchardCoreContrib.ContentLocalization.Core` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.ContentLocalization.Core.svg)](https://www.nuget.org/packages/OrchardCoreContrib.ContentLocalization.Core) |
| [Email APIs](src/OrchardCoreContrib.Email/README.md) | `OrchardCoreContrib.Email` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Email.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Email) |
| [Email Abstractions](src/OrchardCoreContrib.Email.Abstractions/README.md) | `OrchardCoreContrib.Email.Abstractions` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Email.Abstractions.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Email.Abstractions) |
| [Health Checks Abstractions](src/OrchardCoreContrib.HealthChecks.Abstractions/README.md) | `OrchardCoreContrib.HealthChecks.Abstractions` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.HealthChecks.Abstractions.svg)](https://www.nuget.org/packages/OrchardCoreContrib.HealthChecks.Abstractions) |
| [Infrastructure Abstractions APIs](src/OrchardCoreContrib.Infrastructure.Abstractions/README.md) | `OrchardCoreContrib.Infrastructure.Abstractions` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Infrastructure.Abstractions.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Infrastructure.Abstractions) |
| [LINQ to Orchard Core](src/OrchardCoreContrib.Linq/README.md) | `OrchardCoreContrib.Linq` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Linq.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Linq) |
| [Localization Implementation APIs](src/OrchardCoreContrib.Localization/README.md) | `OrchardCoreContrib.Localization` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Localization.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Localization) |
| [Localization Abstractions APIs](src/OrchardCoreContrib.Localization.Abstractions/README.md) | `OrchardCoreContrib.Localization.Abstractions` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Localization.Abstractions.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Localization.Abstractions) |
| [JSON Localization APIs](src/OrchardCoreContrib.Localization.Json/README.md) | `OrchardCoreContrib.Localization.Json` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Localization.Json.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Localization.Json) |
| [XLIFF Localization APIs](src/OrchardCoreContrib.Localization.Xliff/README.md) | `OrchardCoreContrib.Localization.Xliff` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Localization.Xliff.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Localization.Xliff) |
| [OpenApi Abstractions APIs](src/OrchardCoreContrib.OpenApi.Abstractions/README.md) | `OrchardCoreContrib.OpenApi.Abstractions` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.OpenApi.Abstractions.svg)](https://www.nuget.org/packages/OrchardCoreContrib.OpenApi.Abstractions) |
| [Shortcodes Abstractions APIs](src/OrchardCoreContrib.Shortcodes.Abstractions/README.md) | `OrchardCoreContrib.Shortcodes.Abstractions` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Shortcodes.Abstractions.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Shortcodes.Abstractions) |
| [Shortcodes Implementation APIs](src/OrchardCoreContrib.Shortcodes.Core/README.md) | `OrchardCoreContrib.Shortcodes.Core` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Shortcodes.Core.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Shortcodes.Core) |
| [SMS Abstractions APIs](src/OrchardCoreContrib.Sms.Abstractions/README.md) | `OrchardCoreContrib.Sms.Abstractions` | [![NuGet](https://img.shields.io/nuget/v/OrchardCoreContrib.Sms.Abstractions.svg)](https://www.nuget.org/packages/OrchardCoreContrib.Sms.Abstractions) |
