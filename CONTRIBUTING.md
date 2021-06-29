# Contributing to GUISharp Project

We're happy that you have chosen to contribute to the GUISharp project.

To organize the efforts made for this game, the wotoTeam has written this simple guide to help you.

Please read this document completely before contributing to GUISharp.


## How To Contribute

GUISharp has a `master` branch for stable releases and a `develop` branch for daily development.  New features and fixes are always submitted to the `develop` branch.

If you are looking for ways to help, you should start by looking at the [Help Wanted tasks](https://github.com/ALiwoto/GUISharp/issues?q=is%3Aissue+is%3Aopen+label%3A%22Help+Wanted%22).  Please let us know if you plan to work on an issue so that others are not duplicating work.

The GUISharp project follows standard [GitHub flow](https://guides.github.com/introduction/flow/index.html).  You should learn and be familiar with how to [use Git](https://help.github.com/articles/set-up-git/), how to [create a fork of GUISharp](https://help.github.com/articles/fork-a-repo/), and how to [submit a Pull Request](https://help.github.com/articles/using-pull-requests/).

After you submit a PR, the wotoTeam will build your changes and verify all tests pass.  Project maintainers and contributors will review your changes and provide constructive feedback to improve your submission.

Once we are satisfied that your changes are good for GUISharp, we will merge it.


## Quick Guidelines

Here are a few simple rules and suggestions to remember when contributing to GUISharp Project.

* :bangbang: **NEVER** commit code that you didn't personally write.
* :bangbang: **NEVER** use decompiler tools to steal code and submit them as your own work.
* :bangbang: **NEVER** decompile another games' assemblies and steal another companies' copyrighted code.
* **PLEASE** try keep your PRs focused on a single topic and of a reasonable size or we may ask you to break it up.
* **PLEASE** be sure to write simple and descriptive commit messages.
* **DO NOT** surprise us with new APIs or big new features. Open an issue to discuss your ideas first.
* **DO NOT** reorder type members as it makes it difficult to compare code changes in a PR.
* **DO** try to follow our [coding style](CODESTYLE.md) for new code.
* **DO** give priority to the existing style of the file you're changing.
* **DO NOT** send PRs for code style changes or make code changes just for the sake of style.
* **PLEASE** keep a civil and respectful tone when discussing and reviewing contributions.
* **PLEASE** tell others about GUISharp Game and your contributions via social media.


## Decompiler Tools

We prohibit the use of tools like dotPeek, ILSpy, JustDecompiler, or .NET Reflector which convert compiled assemblies into readable code.

There has been confusion on this point in the past, so we want to make this clear.  It is **NEVER ACCEPTABLE** to decompile another games' copyrighted assemblies and submit that code to the GUISharp Game project.

* It **DOES NOT** matter how much you change the code.
* It **DOES NOT** matter what country you live in or what your local laws say.  
* It **DOES NOT** matter that another games' are discontinued.  
* It **DOES NOT** matter how small the bit of code you have stolen is.  
* It **DOES NOT** matter what your opinion is of stealing code.

If you did not write the code, you do not have ownership of the code and you shouldn't submit it to GUISharp Project.

If we find a contribution to be in violation of copyright, it will be immediately removed.  
We will bar that contributor from the GUISharp project.

## Code guidelines

Due to limitations on private target platforms, GUISharp enforces the use of C# 9.0 features.

It is however allowed to use the latest class library, but if contributions make use of classes which are not present in .NET 5.0, it will be required from the contribution to implement backward compatible switches.

These limitations should be lifted at some point.

## Licensing

The GUISharp project is under the [MIT License](https://opensource.org/licenses/MIT). 
See the [LICENSE](LICENSE) file for more details.  
Third-party libraries used by GUISharp are under their own licenses.  Please refer to those libraries for details on the license they use.

We accept contributions in "good faith" that it isn't bound to a conflicting license.  By submitting a PR you agree to distribute your work under the GUISharp license and copyright.

To this end, when submitting new files, include the following in the header if appropriate:
```csharp
/*
 * This file is part of GUISharp Project (https://github.com/GUISharp/GUISharp).
 * Copyright (c) 2021 GUISharp Authors.
 *
 * This library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 3.
 *
 * This library is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this source code of library. 
 * If not, see <http://www.gnu.org/licenses/>.
 */

```

## Need More Help?

If you need help, please ask questions on our [Telegram community](https://t.me/LTW_Game) 
or come and join our [Discord Server](https://discord.gg/Nxd9xs4PbN).


Thanks for reading this guide and helping make GUISharp great!

 :heart: wotoTeam
