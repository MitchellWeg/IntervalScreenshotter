# IntervalScreenshotter
Take screenshots at an interval.

## Flags
From the command line you can pass a number of flags:

| Full Name  | Abbreviated | Help                                                                                 |
|------------|-------------|--------------------------------------------------------------------------------------|
| interval   | i           | The interval of which to take the screenshots. Default is in milliseconds (required) |
| seconds    | s           | Mark the interval as seconds and not as milliseconds (optional)                      |
| output-dir | o           | The directory of which to store the screenshots (optional)                           |
| verbose    | v           | Set CLI to verbose mode, i.e. output how many shots were taken                       |

## Usage
```
.\Screenshotter.exe --interval 3
```

```
.\Screenshotter.exe -i 3 -s -o /temp/screenshots
```
