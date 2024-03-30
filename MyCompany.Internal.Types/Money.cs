namespace MyCompany.Internal.Types;

public class Money
{
    public decimal Value { get; set; }

    public Currency Currency { get; set; }
}

/// <summary>
///     Currencies according to the ISO 4217 standard.
/// </summary>
/// <remarks>
///     This list is not complete, for a complete list see https://en.wikipedia.org/wiki/ISO_4217
/// </remarks>
public enum Currency
{
    /// <summary>Australian dollar</summary>
    AUD = 036,

    /// <summary>Canadian dollar</summary>
    CAD = 124,

    /// <summary>Japanese yen</summary>
    JPY = 392,

    /// <summary>Swedish krona</summary>
    SEK = 752,

    /// <summary>United States dollar</summary>
    USD = 840,

    /// <summary>Turkish lira</summary>
    TRY = 949,

    /// <summary>Euro</summary>
    EUR = 978,
}
