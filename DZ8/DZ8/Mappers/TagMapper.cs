using System.Collections.Generic;
using System.Linq;
using DZ8.Entities;
using DZ8.ViewModel;

namespace DZ8.Mappers;

/// <summary>
/// Мапер для тегів: перетворює TagEntity у спрощену модель ShowTagViewModel.
/// Використовується для відображення у списках/деталях без навігаційних властивостей.
/// </summary>
public static class TagMapper
{
    /// <summary>
    /// Перетворює сутність тега у спрощений в’юмодель.
    /// </summary>
    public static ShortTagViewModel ToShowViewModel(this TagEntity tag)
    {
        if (tag == null) return null;
        return new ShortTagViewModel
        {
            Id = tag.Id,
            Name = tag.Name,
            Slug = tag.Slug
        };
    }

    /// <summary>
    /// Перетворює колекцію сутностей тегів у колекцію спрощених моделей.
    /// </summary>
    public static IEnumerable<ShortTagViewModel> ToShowViewModels(this IEnumerable<TagEntity> tags)
    {
        if (tags == null) yield break;
        foreach (var t in tags)
        {
            yield return ToShowViewModel(t);
        }
    }
}