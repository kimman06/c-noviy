using System;

public class Thermostat
{
    // private fieldlar — tashqaridan to'g'ridan-to'g'ri murojaat yo'q
    private string _roomName;
    private int _currentTemperature;
    private int _targetTemperature;

    // faqat o'qiladigan propertylar
    public string RoomName => _roomName;
    public int CurrentTemperature => _currentTemperature;
    public int TargetTemperature => _targetTemperature;

    public Thermostat(string roomName, int currentTemperature, int targetTemperature)
    {
        _roomName = roomName;
        _currentTemperature = currentTemperature;
        // konstruktorda ham validatsiya qilamiz (xavfsizlik uchun)
        if (targetTemperature >= 16 && targetTemperature <= 30)
            _targetTemperature = targetTemperature;
        else
            _targetTemperature = 16; // yoki default qiymat
    }

    public bool SetTarget(int temperature)
    {
        if (temperature < 16 || temperature > 30)
            return false; // holat o'zgarmaydi

        _targetTemperature = temperature;
        return true;
    }

    public void AdjustOneDegree()
    {
        if (_currentTemperature < _targetTemperature)
            _currentTemperature++;
        else if (_currentTemperature > _targetTemperature)
            _currentTemperature--;
        // teng bo'lsa — hech narsa
    }

    public string GetStatus()
    {
        if (_currentTemperature < _targetTemperature) return "Heating";
        if (_currentTemperature > _targetTemperature) return "Cooling";
        return "At target";
    }
}

// ---- Test ----
class Program
{
    static void Main()
    {
        var living = new Thermostat("Living room", 20, 23);
        var bedroom = new Thermostat("Bedroom", 24, 21);
        var office  = new Thermostat("Office", 19, 19);

        living.AdjustOneDegree();
        living.AdjustOneDegree();
        bedroom.AdjustOneDegree();

        bool ok = living.SetTarget(31); // false bo'lishi kerak
        Console.WriteLine($"Living room.SetTarget(31) => {ok}");

        foreach (var t in new[] { living, bedroom, office })
        {
            Console.WriteLine(
                $"{t.RoomName}: {t.CurrentTemperature}°C, maqsad {t.TargetTemperature}°C, holat: {t.GetStatus()}");
        }
    }
}


using System;

public class Song
{
    private string _code;
    private string _title;
    private int _durationSeconds;
    private int _playCount;   // faqat class ichida o'zgaradi

    public string Code => _code;
    public string Title => _title;
    public int DurationSeconds => _durationSeconds;
    public int PlayCount => _playCount;

    public Song(string code, string title, int durationSeconds)
    {
        _code = code;
        _title = title;
        _durationSeconds = durationSeconds;
        _playCount = 0;
    }

    public void Play() => _playCount++;

    public string GetInfo()
        => $"{_code} — {_title}, {_durationSeconds} soniya, {_playCount} marta ijro etildi";
}

public class Playlist
{
    private Song[] _songs;   // private massiv
    private int _count;      // private — nechta qo'shilgan

    public string Name { get; }  // public, faqat o'qiladi

    public Playlist(string name, int capacity)
    {
        Name = name;
        _songs = new Song[capacity];
        _count = 0;
    }

    public bool AddSong(Song song)
    {
        if (song == null) return false;
        if (_count >= _songs.Length) return false; // joy yo'q

        // takroriy kod tekshiruvi
        for (int i = 0; i < _count; i++)
            if (_songs[i].Code == song.Code) return false;

        _songs[_count] = song;
        _count++;
        return true;
    }

    public bool PlaySong(int index)
    {
        if (index < 0 || index >= _count) return false;
        _songs[index].Play();
        return true;
    }

    public int GetTotalDuration()
    {
        int total = 0;
        for (int i = 0; i < _count; i++)
            total += _songs[i].DurationSeconds;
        return total;
    }

    public void PrintSongs()
    {
        Console.WriteLine($"Playlist: {Name}");
        for (int i = 0; i < _count; i++)
            Console.WriteLine(_songs[i].GetInfo());
    }
}

// ---- Test ----
class Program
{
    static void Main()
    {
        var s01 = new Song("S01", "Focus", 210);
        var s02 = new Song("S02", "Break", 185);
        var s03 = new Song("S03", "Review", 240);

        var mix = new Playlist("Study Mix", 3);
        Console.WriteLine($"Add S01: {mix.AddSong(s01)}");
        Console.WriteLine($"Add S02: {mix.AddSong(s02)}");
        Console.WriteLine($"Add S03: {mix.AddSong(s03)}");
        Console.WriteLine($"Add S02 (takror): {mix.AddSong(s02)}");   // False

        Console.WriteLine($"PlaySong(1): {mix.PlaySong(1)}");
        Console.WriteLine($"PlaySong(1): {mix.PlaySong(1)}");
        Console.WriteLine($"PlaySong(-1): {mix.PlaySong(-1)}");
        Console.WriteLine($"PlaySong(3): {mix.PlaySong(3)}");

        mix.PrintSongs();
        Console.WriteLine($"Jami davomiylik: {mix.GetTotalDuration()} soniya");

        var empty = new Playlist("Empty", 5);
        empty.PrintSongs(); // faqat nomi chiqadi
    }
}
