using Library;

Map map = new(LanguageEnum.Ru);
Tree tree = new(map);

string line = "Полка";
tree.Add(line);
line = "Попрыгун";
tree.Add(line);
line = "Поп";
tree.Add(line);
line = "Попкорн";
tree.Add(line);
line = "Полотенце";
tree.Add(line);
line = "Поло";
tree.Add(line);

tree.SearchByPrefix("Пол", out var postfixes);
var words = postfixes.Select(bytes =>
{
    var chars = bytes.Select(key => map.TryGetChar(key, out var symbol)
        ? symbol : throw new Exception());
    return new string(chars.ToArray());
}).OrderBy(word => word).ToList();

words.ForEach(Console.WriteLine);

var sdqw = "";