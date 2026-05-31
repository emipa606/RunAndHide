# Copilot Instructions for RimWorld Mod: Run and Hide (Continued)

## Mod Overview and Purpose

The "Run and Hide (Continued)" mod aims to improve the survival chances of colonists in RimWorld by offering controlled options for retreat. The mod introduces a feature where players can place specific markers, known as bunker spots, that colonists will flee to when they encounter danger. This prevents colonists from fleeing into unsafe locations, such as corners or away from the colony's protection. This mod is designed to be compatible with all other mods and can be added to existing game saves without issue.

## Key Features and Systems

- **Bunker Spots:** Players can designate specific areas as safe spots for their colonists to flee to during a threat.
- **Animal Integration:** Animals can have designated bunker spots separate from colonists.
- **Multilingual Support:** The mod includes translations for Russian, French, and German languages.
- **HugsLib Removal:** Legacy dependency on HugsLib has been removed, simplifying integration.
  
## Coding Patterns and Conventions

- Classes and methods are defined in a static context, following the static utility class pattern.
- Naming conventions follow typical C# guidelines with PascalCase for class and method names.
- Public accessibility is emphasized for static utility classes for ease of reference and enhancements.
  
### Public Static Classes and Methods:
- `public static class CellFinderLoose_GetFleeDest`
- `public static class RunandHideBase`
- `public static class ThingDefOfRunandHide`

## XML Integration

- XML file formats are used for RimWorld data defintions and translations, allowing easy edits and community additions to localization.
- New bunker spot designations and animal provisions are likely defined under XML files which include ThingDefs or specialized designators within the mod’s XML resources.

## Harmony Patching

- Harmony is used to patch or hook into existing game methods to modify or extend functionality without altering the original source code. This ensures broad compatibility and ease of future updates.
- Custom patches allow for intercepting colonist fleeing logic to guide them towards safe spots.

## Suggestions for Copilot

- **Code Generation for New Features:** Utilize Copilot to draft new features or refine the current mechanics, suggesting improvements in pathfinding or AI behavior.
- **Localization Expansion:** Automate generation of localization keys for additional languages.
- **Debugging Support:** Use Copilot to suggest solutions for common errors or to explain Harmony patches for debugging.
- **Mod Compatibility:** Implement checks or Copilot suggestions for maintaining compatibility across various mod versions and integrations.

Leveraging Copilot for efficiency can significantly accelerate development cycles and quality assurance in maintaining complex codebases for RimWorld mods.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.
