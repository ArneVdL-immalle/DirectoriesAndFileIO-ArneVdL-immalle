# Analyseer

Bekijk de volledige commit-geschiedenis om te bestuderen hoe dit project tot stand gekomen is.

Probeer volgende vragen te beantwoorden:

i.v.m. MSTest:

- Welke Assert-methods worden naast `Assert.AreEqual` nog allemaal gebruikt?

> `Assert.IsTrue` en `Assert.IsFalse`

- Waarom heeft `TestDirectories` een `Initialize`- en `CleanUp`-method?

> kijken of directory bestaat en als dat is verwijdert hij de directory

- Zijn de attributen `[TestMethod]`, `[TestClass]`, ... noodzakelijk? (Test uit!)

> Nodig voor tests te runnen

- Wat is de shortcut om alle tests uit te voeren in VS?

> Ctrl R, A

i.v.m. Files en Directories:

- Wat is het voordeel van `Path.Combine` i.v.m. strings aan elkaar plakken?

> Je moet geen special character zelf typen

- Wordt de return-waarde van `Directory.CreateDirectory(...)` steeds opgevangen? (TIP: gebruik `CTRL-SHIFT-F`)

> Nee, het wordt direct uitgevoerd

- Wat is de return-waarde van `Directory.CreateDirectory(...)`?

> een object

- Wanneer is het nuttig om de return-waarde van `Directory.CreateDirectory(...)` op te vangen?

> wanneer je de directory wilt verwijderen

i.v.m. duidelijkheid/geschiedenis van de code:

- Lukken de testen in de commit 3ffe2c86? Waarom (niet)?
- Wat lost commit d0320b6a op?
- Wat is het probleem met de files in commit 9d184949?
- Wat doet commit 9b3e4065? Maakt dit de code makkelijker leesbaar? Makkelijker uitbreidbaar?


