namespace Aviv.StronglyTypedIds.Demo.Domain;

[StronglyTypedId(jsonConverter: StronglyTypedIdJsonConverter.SystemTextJson)]
public readonly partial struct StoreId
{
}