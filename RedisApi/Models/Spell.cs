using Redis.OM.Modeling;

namespace Redis.OM.Skeleton.Model;

[Document(StorageType = StorageType.Json, Prefixes = new[] { "SpellLogic" })]
public class SpellLogic{
    
    /// <summary>
    /// ID Объекта логики заклинания в DB/Redis
    /// </summary>
    [RedisIdField] [Indexed] public string? Id {get; set;}
    /// <summary>
    /// Название логики заклинания? (Опционально)
    /// </summary>
    [Indexed] public string? Name {get; set;}
    /// <summary>
    /// Строка части логики, происходящей при сотворении заклинания
    /// </summary>
    [Indexed] public string? OnCast {get; set;}
    /// <summary>
    /// Логика передвижения снаряда (если есть) или определения попадания
    /// </summary>
    [Indexed] public string? MoveLogic {get; set;}
    /// <summary>
    /// Логика, происходящая при каждом сдвиге снаряда (если есть)
    /// </summary>
    [Indexed] public string? OnMove {get; set;}
    /// <summary>
    /// Логика при попадании
    /// </summary>
    [Indexed] public string? OnHit { get; set; }    
    /// <summary>
    /// Скорость снаряда (-1 = Instant, 0 = Стоит на месте)
    /// </summary>
    [Indexed] public int Speed {get; set;}
    /// <summary>
    /// Количество отскоков снаряда от стен/объектов (если есть)
    /// </summary>
    [Indexed] public int Bounce {get; set;}
    /// <summary>
    /// Размер снаряда в клетках (если есть)
    /// </summary>
    [Indexed] public int Size {get; set;}
    /// <summary>
    /// Количество зарядов снаряда (уменьшаются при ударе или другой логике)
    /// </summary>
    [Indexed] public int Charges {get; set;}
    /// <summary>
    /// true или false значение, определяющее, видим ли снаряд объекта изначально.
    /// </summary>
    [Indexed] public string? Visible {get; set;}
    /// <summary>
    /// Строка типа заклинания
    /// </summary>
    [Searchable] public string? Type {get; set;}
    /// <summary>
    /// Путь к изображения снаряда заклинания (если есть)
    /// </summary>
    [Indexed] public string? PathToImage {get; set;}
}

[Document(StorageType = StorageType.Json, Prefixes = new[] { "SpellObject" })]
public class SpellObject{
    [Indexed] public string? CurrentPosition { get; set; }
    [Indexed] public int Counter { get; set; }
    [Indexed] public string? SpellLogicId {get; set;}
    [Indexed] public int Speed {get; set;}
    [Indexed] public int Bounces {get; set;}
    [Indexed] public int Size {get; set;}
    [Indexed] public int Charges {get; set;}
}

[Document(StorageType = StorageType.Json, Prefixes = new[] { "SpellCard" })]
public class SpellCard{
    [RedisIdField][Indexed] public string? Id { get; set; }
    [Indexed] public string? Name {get; set;}
    [Indexed] public string? Text {get; set;}
    [Indexed] public string? FullImagePath {get; set;}
    [Indexed] public string? SmallImagePath {get; set;}
    [Indexed] public string? SpellLogicId {get; set;}
}

[Document(StorageType = StorageType.Json, Prefixes = new[] { "SpellCard" })]
public class SpellDeck{
    [Indexed] public string? Name {get; set;}
    [Indexed] public string[] CardIds {get; set;} = Array.Empty<string>();
}