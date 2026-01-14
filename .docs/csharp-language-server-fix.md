# C# Language Server Fix

## Problem
The C# language server crashes repeatedly due to assembly conflicts in the extension directories.

## Solution Steps

### 1. Uninstall and Reinstall C# Extensions

Run these commands in the VSCode terminal:

```bash
# Uninstall C# extensions
code-server --uninstall-extension ms-dotnettools.csharp
code-server --uninstall-extension ms-dotnettools.csdevkit
code-server --uninstall-extension ms-dotnettools.vscode-dotnet-runtime

# Clear extension cache
rm -rf /home/node/.vscode-server/extensions/ms-dotnettools.csharp-*

# Reinstall C# extension
code-server --install-extension ms-dotnettools.csharp
```

### 2. Alternative: Try Downgrading the Extension

If reinstalling doesn't work, try installing a specific older version:

```bash
# Install a specific older version
code-server --install-extension ms-dotnettools.csharp@2.45.25
```

### 3. Check Extension Settings

Verify your VSCode settings don't have conflicting configurations:

```json
{
  "dotnet.server.useOmnisharp": false,
  "omnisharp.useModernNet": true
}
```

### 4. Reload the Window

After reinstalling, reload VSCode:
- Press `Ctrl+Shift+P` (or `Cmd+Shift+P` on Mac)
- Type "Developer: Reload Window"
- Press Enter

## Verification

After applying the fix:
1. Open a C# file
2. Wait 30 seconds for the language server to initialise
3. Check the C# output panel for errors
4. Verify IntelliSense works (type `System.` and check for autocomplete)

## If Issues Persist

Check the C# extension output panel:
- View → Output → Select "C#" from the dropdown

Look for:
- `[Program] Language server initialized` (good sign)
- No repeated crash/restart messages
- Successful project load messages
