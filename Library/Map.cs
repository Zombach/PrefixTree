namespace Library;

public enum LanguageEnum
{
    Ru = 0,
    En = 1
}

public class Map(LanguageEnum language)
{
    private readonly Dictionary<byte, char> _alphabetRuToChar = new()
    {
        {  1, 'а' }, {  2, 'б' }, {  3, 'в' },
        {  4, 'г' }, {  5, 'д' }, {  6, 'е' },
        {  7, 'ё' }, {  8, 'ж' }, {  9, 'з' },
        { 10, 'и' }, { 11, 'й' }, { 12, 'к' },
        { 13, 'л' }, { 14, 'м' }, { 15, 'н' },
        { 16, 'о' }, { 17, 'п' }, { 18, 'р' },
        { 19, 'с' }, { 20, 'т' }, { 21, 'у' },
        { 22, 'ф' }, { 23, 'х' }, { 24, 'ц' },
        { 25, 'ч' }, { 26, 'ш' }, { 27, 'щ' },
        { 28, 'ъ' }, { 29, 'ы' }, { 30, 'ь' },
        { 31, 'э' }, { 32, 'ю' }, { 33, 'я' },
    };

    private readonly Dictionary<char, byte> _alphabetRuLower = new()
    {
        { 'а',  1 }, { 'б',  2 }, { 'в',  3 },
        { 'г',  4 }, { 'д',  5 }, { 'е',  6 },
        { 'ё',  7 }, { 'ж',  8 }, { 'з',  9 },
        { 'и', 10 }, { 'й', 11 }, { 'к', 12 },
        { 'л', 13 }, { 'м', 14 }, { 'н', 15 },
        { 'о', 16 }, { 'п', 17 }, { 'р', 18 },
        { 'с', 19 }, { 'т', 20 }, { 'у', 21 },
        { 'ф', 22 }, { 'х', 23 }, { 'ц', 24 },
        { 'ч', 25 }, { 'ш', 26 }, { 'щ', 27 },
        { 'ъ', 28 }, { 'ы', 29 }, { 'ь', 30 },
        { 'э', 31 }, { 'ю', 32 }, { 'я', 33 },
    };

    private readonly Dictionary<char, byte> _alphabetRuUpper = new()
    {
        { 'А',  1 }, { 'Б',  2 }, { 'В',  3 },
        { 'Г',  4 }, { 'Д',  5 }, { 'Е',  6 },
        { 'Ё',  7 }, { 'Ж',  8 }, { 'З',  9 },
        { 'И', 10 }, { 'Й', 11 }, { 'К', 12 },
        { 'Л', 13 }, { 'М', 14 }, { 'Н', 15 },
        { 'О', 16 }, { 'П', 17 }, { 'Р', 18 },
        { 'С', 19 }, { 'Т', 20 }, { 'У', 21 },
        { 'Ф', 22 }, { 'Х', 23 }, { 'Ц', 24 },
        { 'Ч', 25 }, { 'Ш', 26 }, { 'Щ', 27 },
        { 'Ъ', 28 }, { 'Ы', 29 }, { 'Ь', 30 },
        { 'Э', 31 }, { 'Ю', 32 }, { 'Я', 33 }
    };

    public bool TryGetKey(char symbol, out byte key)
    {
        key = 0;
        return language switch
        {
            LanguageEnum.Ru => char.IsLetter(symbol) &&
            (
                char.IsLower(symbol)
                    ? _alphabetRuLower.TryGetValue(symbol, out key)
                    : _alphabetRuUpper.TryGetValue(symbol, out key)
            ),
            LanguageEnum.En => throw new NotImplementedException(),
            _ => throw new InvalidOperationException()
        };
    }

    public bool TryGetChar(byte key, out char symbol)
    {
        return language switch
        {
            LanguageEnum.Ru => _alphabetRuToChar.TryGetValue(key, out symbol),
            LanguageEnum.En => throw new NotImplementedException(),
            _ => throw new InvalidOperationException()
        };
    }
}