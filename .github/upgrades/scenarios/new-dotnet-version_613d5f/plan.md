# .github/upgrades/scenarios/new-dotnet-version_613d5f/plan.md

## Table of contents
- [Executive Summary](#executive-summary)
- [Migration Strategy](#migration-strategy)
- [Detailed Dependency Analysis](#detailed-dependency-analysis)
- [Project-by-Project Plans](#project-by-project-plans)
- [Package Update Reference](#package-update-reference)
- [Breaking Changes Catalog](#breaking-changes-catalog)
- [Testing & Validation Strategy](#testing--validation-strategy)
- [Risk Management](#risk-management)
- [Source Control Strategy](#source-control-strategy)
- [Success Criteria](#success-criteria)
- [Assumptions & Open Questions](#assumptions--open-questions)

---

## Executive Summary

- Scenario: Upgrade solution `QuakeViewer.sln` from .NET Framework `net40` to `net9.0-windows` (user requested target).
- Selected Strategy: **All-At-Once Strategy** — upgrade all projects simultaneously in a single coordinated operation.
- Rationale: Single-project solution (1 project) — atomic upgrade minimizes coordination overhead and aligns with All-At-Once guidance.

Key metrics (from assessment generated for net8.0):
- Total projects: 1
- Project: `QuakeViewer\QuakeViewer.csproj`
  - Current target: `net40`
  - Proposed analysis target (original): `net8.0-windows` (assessment run for net8.0)
  - User-selected target for planning: `net9.0-windows` (requested)
  - SDK-style: false (requires conversion)
  - Files: 28 (12 files with issues)
  - Lines of code: 1,932
  - Estimated LOC to modify: 988+ (≈51.1%)
- API compatibility summary (analysis for net8.0): 2,577 APIs analyzed — 941 binary-incompatible, 47 source-incompatible, 1,589 compatible.

Note: Assessment was executed for `net8.0`. The plan uses the user-requested `net9.0-windows` as the target, but differences between net8.0 and net9.0 may exist. Recommended: run `upgrade_analyze_projects` for `net9.0` before execution to refresh compatibility findings.


## Migration Strategy

- Selected: **All-At-Once Strategy** — perform an atomic upgrade of the single solution/project.
- Scope: Update project file(s) to SDK-style, set `TargetFramework` to `net9.0-windows`, enable Windows desktop support, update any PackageReferences, restore, build, and fix compilation errors in one coordinated operation.
- Justification:
  - Only one project in solution (fits All-At-Once criteria)
  - Homogeneous technology: Classic Windows Forms app
  - Assessment shows no NuGet package constraints that force incremental approach
- High-level phases (for human understanding):
  - Phase 0: Preparation (SDKs, branch, backups)
  - Phase 1: Atomic Upgrade (project file conversion + package updates + restore + build + fix issues)
  - Phase 2: Test Validation (build verification, UI validation, manual tests)


## Detailed Dependency Analysis

- Dependency graph: single project, no project references. No inter-project dependency ordering required.
- Leaf/root analysis: Project is both leaf and root.
- Implication: All changes apply to the same project. No multi-project sequencing required.


## Project-by-Project Plans

### Project: `QuakeViewer\QuakeViewer.csproj`

Current State
- TargetFramework: `net40`
- SDK-style: No (classic project)
- Project type: Classic WinForms
- LOC: 1,932
- Files with issues: 12

Target State
- TargetFramework: `net9.0-windows` (user request)
- SDK-style: Yes (Microsoft.NET.Sdk or Microsoft.NET.Sdk.WindowsDesktop)
- Properties to set: `UseWindowsForms`/`UseWindowsDesktop` as required

Migration Steps (what executor must perform)
1. Preparation
   - Ensure .NET 9 SDK is installed on developer/CI machines.
   - Create feature branch: `upgrade-to-net9` (preserve main).
   - Backup original `.csproj` file.
2. Convert project file to SDK-style and set target
   - Replace classic project file with SDK-style file. Example properties:
     - `<Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">`
     - `<TargetFramework>net9.0-windows</TargetFramework>`
     - `<UseWindowsForms>true</UseWindowsForms>`
     - `<Nullable>enable</Nullable>` (optional)
   - Move any AssemblyInfo or custom build items into SDK-style format.
   - Convert old `<Reference>` entries to `<PackageReference>` where appropriate.
3. Package and compatibility preparations
   - Add `System.Configuration.ConfigurationManager` if app relies on `app.config` settings.
   - Evaluate `System.Drawing` usages; add `System.Drawing.Common` if required (Windows-only) or replace with cross-platform alternative if desired.
4. Restore and build (atomic)
   - `dotnet restore` for solution
   - `dotnet build` and collect compile errors
5. Fix compile-time issues (single bounded pass)
   - Address source-incompatible APIs and refactor code for binary-incompatible APIs identified by assessment (Windows Forms related changes, control property differences, etc.).
   - Update designer-generated code if required (compare with backup carefully).
6. Rebuild and verify solution builds without errors.
7. Run tests and validation (see testing section).

Project-specific notes
- Designer files (.Designer.cs) may require careful manual edits if generated code references APIs changed in .NET 9.
- Large portion of fixes expected in Windows Forms code (approx. 941 binary-incompatible API occurrences from net8.0 assessment).


## Package Update Reference

- Assessment found 0 NuGet packages in the solution. No package upgrades are required per assessment.
- Additions suggested for compatibility:
  - `System.Configuration.ConfigurationManager` — if using `app.config` settings
  - `System.Drawing.Common` — only if required for GDI+ scenarios and acceptable on Windows


## Breaking Changes Catalog

- Primary area: Windows Forms API incompatibilities (controls, properties, collection methods). Examples from assessment (top items):
  - `System.Windows.Forms.Label` usages — frequent binary-incompatible occurrences
  - `Control.Controls` / `Control.ControlCollection.Add(...)` API differences
  - `Control.Name`, `Control.Size`, `Control.Location`, `Control.TabIndex`, `Control.Visible` property changes
  - `ToolStrip`/`ToolStripMenuItem`/`ToolStripContainer` related members
  - `System.Drawing.Bitmap` usages (some source-incompatible occurrences)

- Designer-generated code is likely to surface many of these incompatibilities. Treat designer files as high-risk edit locations.

- For each breaking-change category, executor should:
  - Prefer small, localized code edits (e.g., replace obsolete property usage with supported pattern)
  - When designer code must change, prefer regenerating designer code by opening forms in Visual Studio after project conversion (manual step)


## Testing & Validation Strategy

Automated
- Build verification: solution must `dotnet build` with 0 errors.
- Unit tests: None discovered in assessment; if present, run them.

Manual / Non-automatable (documented but not converted into tasks)
- Manual UI validation of Windows Forms flows: main windows, dialogs, menus, drawing surfaces
- Verify configuration loading (app settings) after migration

Validation checklist for executor
- [ ] Solution builds without errors
- [ ] No remaining compiler warnings caused by upgrade (address as needed)
- [ ] Designer forms render correctly in Visual Studio (open forms to trigger designer regeneration)
- [ ] Key UI scenarios exercised manually


## Risk Management

Risk summary
- Primary risk: High — large number of Windows Forms binary-incompatible API occurrences (assessment: 941).
- Secondary risk: Medium — designer files and generated code edits can be fragile.

Mitigations
- Convert project to SDK-style in a feature branch and keep a backup of original `.csproj` and designer-generated files.
- Use one bounded atomic pass: convert project + package updates + restore + build + fix compilation errors to contain changes in a single commit.
- Prioritize automated build success. Manual UI checks remain required but are outside automation scope.
- If blocking designer incompatibilities occur, consider temporarily isolating designer changes and applying them in the same upgrade commit after confirmation.

Contingency plan
- If migration introduces regressions that cannot be resolved quickly, revert to backup branch and open an issue documenting the blocking incompatibilities.


## Source Control Strategy

- Branching
  - Create and switch to `upgrade-to-net9` from `main`.
  - Keep changes atomic: single commit (or minimal coherent commits) containing all project file conversions and package additions.
- Commit strategy (recommended)
  - Commit 1: Add backup and conversion of project file(s) to SDK-style; update repository metadata (global.json if required)
  - Commit 2: Code fixes for compilation and designer adjustments (if necessary)
  - Squash into a single atomic commit before merge if repository policy prefers a single change for upgrade
- Pull request
  - Include link to `assessment.md` and this `plan.md` in PR description
  - PR checklist should require successful CI build on .NET 9 and at least one reviewer with Windows Forms experience


## Success Criteria

The migration is complete when:
1. All projects target `net9.0-windows` and are converted to SDK-style.
2. All package updates/additions from this plan applied.
3. Solution builds with 0 errors.
4. Unit tests (if any) pass.
5. Manual UI validation completed for core scenarios and no critical regressions remain.
6. No outstanding security vulnerabilities related to packages.


## Assumptions & Open Questions

- The assessment was executed for `net8.0`. The user requested `net9.0-windows`. Differences between net8.0 and net9.0 are assumed minimal for Windows Forms compatibility, but this is an assumption.
  - ⚠️ Recommendation: run `upgrade_analyze_projects` with `targetFramework=net9.0` to refresh API compatibility data before starting execution.
- No NuGet packages were detected in assessment; if packages exist in project file but were not detected, they must be enumerated and included.
- Designer file edits may be required and are delicate — executor should keep backups of `.Designer.cs` files.


---

Next steps (planning -> execution handoff)
1. Confirm target (`net9.0-windows`) and re-run analysis for that target (recommended).
2. Create `upgrade-to-net9` branch and perform Phase 0 prerequisites (SDK installation, backups).
3. Execute Atomic Upgrade (Phase 1) per steps above.


# End of plan
