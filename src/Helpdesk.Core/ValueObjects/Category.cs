using Helpdesk.Core.Enums;

namespace Helpdesk.Core.ValueObjects;

public sealed record Category
{
    public CategoriesEnum Value { get; }

    public Category(CategoriesEnum value)
    {
        Value = value;
    }

    public static implicit operator string(Category category) => category.Value.ToString();
    public static implicit operator Category(int category) => new Category((CategoriesEnum)category);
}