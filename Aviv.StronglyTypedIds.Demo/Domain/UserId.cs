namespace Aviv.StronglyTypedIds.Demo.Domain;

[StronglyTypedId(jsonConverter: StronglyTypedIdJsonConverter.SystemTextJson)]
public readonly partial struct UserIdReadOnly
{
}

[StronglyTypedId(generateJsonConverter: false)]
public partial struct UserId
{
}