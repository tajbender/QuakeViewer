Revision: 10
Author: taj
Date: 03 November 2006 22:51:28
Message:
Viele kleine (Refactoring)-Änderungen;
Die fehlenden Klassen und Strukturen zum Auslesen der Models hinzugefügt; funktioniert soweit auch, bis auf "flame2.mdl", wo vier Byte zu früh ins Model gerutscht wird :-(
Methode zum (korrekten!) Auslesen von Strings in den PakStreamReader hinzugefügt, da BinaryReader.ReadChars() encoding-abhängig arbeitet!
----
Modified : /QuakeViewer/IDSoftware/BspEntries/BspMipMapInfo.cs
Added : /QuakeViewer/IDSoftware/PakEntries/ModelFrame.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/ModelHeader.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/ModelSkin.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/PakEntry.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/SpriteHeader.cs
Modified : /QuakeViewer/IDSoftware/PakHeader.cs
Modified : /QuakeViewer/IDSoftware/PakStreamReader.cs
Modified : /QuakeViewer/QuakeViewer.csproj
Modified : /QuakeViewer/QuakeViewerForm.cs

Revision: 9
Author: taj
Date: 01 November 2006 18:37:34
Message:
Klassen für Sprites hinzugefügt
Den Viewer um die Anzahl der Modell-Skins erweitert
Namensräume überarbeitet
----
Modified : /QuakeViewer/IDSoftware/PakEntries/ModelHeader.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/ModelSkin.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/PakEntry.cs
Added : /QuakeViewer/IDSoftware/PakEntries/SpriteHeader.cs
Modified : /QuakeViewer/IDSoftware/PakHeader.cs
Modified : /QuakeViewer/IDSoftware/PakStreamReader.cs
Modified : /QuakeViewer/QuakeViewer.csproj
Modified : /QuakeViewer/QuakeViewerForm.cs
Modified : /QuakeViewer/IDSoftware/BspEntries/BspMipMapHeader.cs
Modified : /QuakeViewer/IDSoftware/BspEntries/BspMipMapTexture.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/BspHeader.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/GamePalette.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/LumpPicture.cs
Added : /QuakeViewer/IDSoftware/PakEntries/SpriteFrame.cs
Modified : /QuakeViewer/PakFileTreeView.cs

Revision: 8
Author: taj
Date: 13 October 2006 20:35:15
Message:
Es werden nun mehrere Skins (sofern vorhanden) pro Model ausgelesen
----
Modified : /QuakeViewer/IDSoftware/PakEntries/ModelHeader.cs
Modified : /QuakeViewer/QuakeViewerForm.cs

Revision: 7
Author: taj
Date: 11 October 2006 22:36:33
Message:
Die Lumps und die Model-Skins werden nun als Bitmapvorschau angezeigt; dafür mußte die ReadBitmap-Methode aber um einiges optimiert werden, läuft nun aber ratzfatz!
----
Modified : /QuakeViewer/IDSoftware/PakEntries/PakEntry.cs
Modified : /QuakeViewer/IDSoftware/PakStreamReader.cs
Modified : /QuakeViewer/QuakeViewer.csproj
Modified : /QuakeViewer/QuakeViewerForm.cs
Modified : /QuakeViewer/PakFileTreeView.cs
Modified : /QuakeViewer/QuakeViewerForm.Designer.cs
Modified : /QuakeViewer/QuakeViewerForm.resx

Revision: 6
Author: taj
Date: 11 October 2006 00:33:25
Message:
BinViewTextBox eingefügt, um damit die ersten 1024 Byte eines selektierten PakEntries anzuzeigen, sobald er im PakFileTreeView selektiert wurde.
Die Eigenschaften eines selektierten Nodes im PakFileTreeView werden nun ebenfalls korrekt angezeigt (was viele kleinere Änderungen nach sich zog).
----
Modified : /QuakeViewer/IDSoftware/PakStreamReader.cs
Modified : /QuakeViewer/QuakeViewer.csproj
Modified : /QuakeViewer/QuakeViewerForm.cs
Modified : /QuakeViewer/PakFileTreeView.cs
Modified : /QuakeViewer/QuakeViewerForm.Designer.cs
Modified : /QuakeViewer/QuakeViewerForm.resx
Added : /QuakeViewer/BinViewTextBox.cs
Modified : /QuakeViewer/IDSoftware/BspEntries/BspEntry.cs
Modified : /QuakeViewer/IDSoftware/Primitives.cs

Revision: 5
Author: taj
Date: 10 October 2006 22:29:43
Message:
Neue Icons für den PakFileTreeView hinzugefügt (FolderOpened und FolderClosed), im Design des Visual Studio
----
Deleted : /QuakeViewer/PakEntryIcons/Folder.png
Added : /QuakeViewer/PakEntryIcons/FolderClosed.png
Added : /QuakeViewer/PakEntryIcons/FolderOpened.png

Revision: 4
Author: taj
Date: 10 October 2006 00:19:13
Message:
Erste Version des QuakeViewerForm implementiert.
Die rudimentären Infos zu einem PakEntry werden angezeigt, der PakFileTreeView baut sich korrekt auf.
----
Modified : /QuakeViewer/IDSoftware/PakEntries/PakEntry.cs
Modified : /QuakeViewer/IDSoftware/PakHeader.cs
Modified : /QuakeViewer/IDSoftware/PakStreamReader.cs
Modified : /QuakeViewer/QuakeViewer.csproj
Added : /QuakeViewer/QuakeViewerForm.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/GamePalette.cs
Added : /QuakeViewer/PakFileTreeView.cs
Added : /QuakeViewer/QuakeViewerForm.Designer.cs
Added : /QuakeViewer/QuakeViewerForm.resx
Modified : /QuakeViewer/IDSoftware/Primitives.cs
Added : /QuakeViewer/PakEntryIcons
Added : /QuakeViewer/PakEntryIcons/Folder.png
Added : /QuakeViewer/PakEntryIcons/Empty.png
Modified : /QuakeViewer/Program.cs

Revision: 3
Author: taj
Date: 08 October 2006 21:08:27
Message:
Neue Klasse ModelSkin eingeführt, diese beherbergt eben das Skin eines Models.
Außerdem ReadBitmap-Methode im PakStreamReader eingeführt.
----
Modified : /QuakeViewer/IDSoftware/PakEntries/ModelHeader.cs
Added : /QuakeViewer/IDSoftware/PakEntries/ModelSkin.cs
Modified : /QuakeViewer/IDSoftware/PakStreamReader.cs
Modified : /QuakeViewer/QuakeViewer.csproj
Modified : /QuakeViewer/IDSoftware/PakEntries/LumpPicture.cs
Modified : /QuakeViewer/Form1.cs

Revision: 2
Author: taj
Date: 07 October 2006 23:50:43
Message:
Erste Ausbaustufe eines PakStreamReader-Refactorings durchgeführt;
Erste Version des ModelHeader.cs hinzugefügt (samt Primitives.cs)

----
Modified : /QuakeViewer/IDSoftware/BspEntries/BspMipMapInfo.cs
Added : /QuakeViewer/IDSoftware/PakEntries/ModelHeader.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/PakEntry.cs
Modified : /QuakeViewer/IDSoftware/PakHeader.cs
Modified : /QuakeViewer/IDSoftware/PakStreamReader.cs
Modified : /QuakeViewer/QuakeViewer.csproj
Modified : /QuakeViewer/IDSoftware/BspEntries/BspMipMapHeader.cs
Modified : /QuakeViewer/IDSoftware/BspEntries/BspMipMapTexture.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/BspHeader.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/GamePalette.cs
Modified : /QuakeViewer/IDSoftware/PakEntries/LumpPicture.cs
Modified : /QuakeViewer/IDSoftware/BspEntries/BspEntry.cs
Added : /QuakeViewer/IDSoftware/Primitives.cs
Modified : /QuakeViewer/Form1.cs

Revision: 1
Author: taj
Date: 07 October 2006 15:57:51
Message:
Initialer Import
----
Added : /QuakeViewer
Added : /QuakeViewer/IDSoftware
Added : /QuakeViewer/IDSoftware/BspEntries
Added : /QuakeViewer/IDSoftware/BspEntries/BspMipMapInfo.cs
Added : /QuakeViewer/IDSoftware/PakEntries
Added : /QuakeViewer/IDSoftware/PakEntries/PakEntry.cs
Added : /QuakeViewer/IDSoftware/PakHeader.cs
Added : /QuakeViewer/IDSoftware/PakStreamReader.cs
Added : /QuakeViewer/QuakeViewer.csproj
Added : /QuakeViewer/IDSoftware/BspEntries/BspMipMapHeader.cs
Added : /QuakeViewer/IDSoftware/BspEntries/BspMipMapTexture.cs
Added : /QuakeViewer/IDSoftware/PakEntries/BspHeader.cs
Added : /QuakeViewer/IDSoftware/PakEntries/GamePalette.cs
Added : /QuakeViewer/IDSoftware/PakEntries/LumpPicture.cs
Added : /QuakeViewer/IDSoftware/BspEntries/BspEntry.cs
Added : /QuakeViewer/Program.cs
Added : /QuakeViewer/Form1.cs
Added : /QuakeViewer/ClassDiagram.cd
Added : /QuakeViewer/Form1.Designer.cs
Added : /QuakeViewer/Form1.resx
Added : /QuakeViewer/IDSoftware/Exceptions
Added : /QuakeViewer/IDSoftware/Exceptions/BspFormatException.cs
Added : /QuakeViewer/IDSoftware/Exceptions/PakFormatException.cs
Added : /QuakeViewer/IDSoftware/Interfaces
Added : /QuakeViewer/Properties
Added : /QuakeViewer/Properties/AssemblyInfo.cs
Added : /QuakeViewer/Properties/Resources.Designer.cs
Added : /QuakeViewer/Properties/Resources.resx
Added : /QuakeViewer/Properties/Settings.Designer.cs
Added : /QuakeViewer/Properties/Settings.settings
Added : /QuakeViewer.sln

