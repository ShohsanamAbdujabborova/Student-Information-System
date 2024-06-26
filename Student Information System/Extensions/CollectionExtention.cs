﻿using Student_Information_System.Models.Commons;

namespace Student_Information_System.Extensions;

public static class CollectionExtension
{
    public static T Create<T>(this List<T> values, T model) where T : Auditable
    {
        var lastId = values.Count == 0 ? 1 : values.Last().Id + 1;
        model.Id = lastId;
        values.Add(model);
        return values.Last();
    }
}
