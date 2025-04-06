namespace portfolio.Services;

public class ThemeConfig
{
    public string CurrentTheme { get; private set; } = "Dark";
    
    private readonly Dictionary<string, Theme> _themes = new()
    {
        ["Light"] = new Theme
        {
            PrimaryColor = "#4285f4",
            BackgroundColor = "#ffffff",
            TextColor = "#202124",
            SearchBarBackground = "#ffffff",
            SearchBarBorder = "#dfe1e5"
        },
        ["Dark"] = new Theme
        {
            PrimaryColor = "#8ab4f8",
            BackgroundColor = "#202124",
            TextColor = "#e8eaed",
            SearchBarBackground = "#303134",
            SearchBarBorder = "#5f6368"
        },
        // ["Sepia"] = new Theme
        // {
        //     PrimaryColor = "#8b4513",
        //     BackgroundColor = "#f4ecd8",
        //     TextColor = "#5b4636",
        //     SearchBarBackground = "#efe6d5",
        //     SearchBarBorder = "#d3c4b4"
        // },
        ["Ocean"] = new Theme
        {
            PrimaryColor = "#48d1cc",
            BackgroundColor = "#1a3c5a",
            TextColor = "#e0ffff",
            SearchBarBackground = "#234b73",
            SearchBarBorder = "#48d1cc"
        }
    };

    public string PrimaryColor => _themes[CurrentTheme].PrimaryColor;
    public string BackgroundColor => _themes[CurrentTheme].BackgroundColor;
    public string TextColor => _themes[CurrentTheme].TextColor;
    public string SearchBarBackground => _themes[CurrentTheme].SearchBarBackground;
    public string SearchBarBorder => _themes[CurrentTheme].SearchBarBorder;

    public event Action? OnThemeChanged;

    public void SetTheme(string themeName)
    {
        if (_themes.ContainsKey(themeName) && CurrentTheme != themeName)
        {
            CurrentTheme = themeName;
            OnThemeChanged?.Invoke();
        }
    }

    public IEnumerable<string> GetAvailableThemes() => _themes.Keys;
}

public class Theme
{
    public required string PrimaryColor { get; set; }
    public required string BackgroundColor { get; set; }
    public required string TextColor { get; set; }
    public required string SearchBarBackground { get; set; }
    public required string SearchBarBorder { get; set; }
}